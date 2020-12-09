using System;
using AReport.Srv.Data;
using AReport.Support.Command;
using AReport.Support.Entity;
using System.Collections.ObjectModel;

namespace AReport.Srv.Command
{
    internal class AsistenciaUpdateCommandHandler 
    {
        private AsistenciaUpdateData _data;

        public AsistenciaUpdateCommandHandler(AsistenciaUpdateData data)
        {   _data = data; }

        /*  Comprobar todos los casos     *************
         
            Para gestionar Incidencias y Asistencias

            La Entidad Asistencia tiene una Propiedad CausaIncidenciaId 
            y una Referencia a entidad Incidencia.

            La referencia se crea en el servidor y no se modifica en GUI
            Las propiedades CausaIncidenciaId se puede  modificar en la GUI.

	Propiedad		Referencia		Accion  
	 0				 NULL			Ignorar, no hay cambios
	 0				 Not NULL		Delete, se ha eliminado la Incidencia de la Asistencia. Actualizar Asistencia, Eliminar Incidencia (obtener ent por referencia y eliminar de la db por Id)
	 Not 0			 NULL			Insert, se ha añadido la Incidencia a la Asistencia.  Crear nueva ent Incidencia, insertar (se actualiza Id). Copiar id en propiedad de Asistencia y Actualizar Asistencia en db.
	 Not 0			 Not NULL   	Posible Update, se puede hacer update o comparar valores
         */

        public CommandStatus Handle(AsistenciaUpdateCommand command)
        {
            try
            {
                int causa;
                Incidencia incidenciaRef;
                bool esPropiedadCero, esReferenciaNull;

                Collection<Asistencia> colAssist = new Collection<Asistencia>();
                Collection<Incidencia> colIncid = new Collection<Incidencia>();


                // recorrer las asistencias y comparar propiedad y referencia

                foreach (var asistencia in command.Asistencias)
                {
                    causa = asistencia.IncidenciaCausaIncidencia;
                    incidenciaRef = asistencia.IncidenciaRef;

                    esPropiedadCero = (causa == 0);
                    esReferenciaNull = (incidenciaRef == null);

                    // Sin cambios, ignorar y continuar ciclo
                    if (esPropiedadCero && esReferenciaNull)
                        continue;

                    // Eliminar Incidencia
                    if (esPropiedadCero && !esReferenciaNull)
                    {
                        asistencia.IncidenciaId = 0;
                        asistencia.State = EntityState.Modified;
                        colAssist.Add(asistencia);
                        // primero actualizar entidad asistencia para no violar foreign key constraint
                        // al hacer cero la prop, se escribe DbNull en record

                        incidenciaRef.State = EntityState.Deleted;
                        colIncid.Add(incidenciaRef);
                    }

                    // Insertar Nueva Incidencia
                    if (!esPropiedadCero && esReferenciaNull)
                    {
                        // Se crea la entidad y se inserta el registro en DB primero,
                        //para obtenr su Id y actualizar Asistencia relacionada
                        Incidencia newInc = _data.InsertarNuevaIncidencia(asistencia.IncidenciaCausaIncidencia, asistencia.IncidenciaObservacion);

                        asistencia.IncidenciaId = newInc.Id;
                        asistencia.State = EntityState.Modified;
                        colAssist.Add(asistencia);
                    }

                    // Posible actualizacion
                    if (!esPropiedadCero && !esReferenciaNull)
                    {
                        bool cambioCausa, cambioObs;

                        cambioCausa = (asistencia.IncidenciaCausaIncidencia != incidenciaRef.CausaId);
                        cambioObs = (asistencia.IncidenciaObservacion != incidenciaRef.Observacion);

                        if (cambioCausa || cambioObs)
                        {
                            Console.WriteLine("Coinciden Asist Incidencia Id y Referencia Id: " + (asistencia.IncidenciaId == incidenciaRef.Id));
                            // actualizando propiedades de incidencia con valores en Asistencia modificados en GUI
                            incidenciaRef.CausaId = asistencia.IncidenciaCausaIncidencia;
                            incidenciaRef.Observacion = asistencia.IncidenciaObservacion;

                            incidenciaRef.State = EntityState.Modified;
                            colIncid.Add(incidenciaRef);
                        }
                    }
                }


                // fin ciclos, escribir colecciones
                bool ret = _data.ActualizarAsistencias(colAssist);
                if (!ret)
                    return new Failure("Error actualizando Asistencias");


                ret = _data.ActualizarIncidencias(colIncid);
                if (!ret)
                    return new Failure("Error actualizando Incidencias");

                
                return new Success();
            }
            catch (Exception ex)
            {
                // Log, Notify
                return new Failure(ex.Message);
            }

           
        }

    }






}
