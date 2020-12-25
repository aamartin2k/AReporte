using System;
using AReport.Srv.Data;
using AReport.Support.Command;
using AReport.Support.Entity;
using System.Collections.ObjectModel;
using System.Linq;

namespace AReport.Srv.Command
{
    internal class AsistenciaUpdateCommandHandler 
    {
        private AsistenciaUpdateData _data;

        public AsistenciaUpdateCommandHandler(AsistenciaUpdateData data)
        {   _data = data; }

        // nueva implementacion en base a la original
        /*  Comprobar todos los casos     *************  IncidenciaId

           Para gestionar Incidencias y Asistencias

           La Entidad Asistencia tiene una Propiedad CausaIncidenciaId que indica el tipo de Incidencia, redundante.
           y una propiedad IncidenciaId que es PK id de la Incidencia. 

           La propiedad IncidenciaId se crea en el servidor (al INSERTar nueva Incidencia) y no se modifica en GUI
           Las propiedades CausaIncidenciaId se puede  modificar en la GUI.

   Propiedad		    Prop Referencia		Accion  
   CausaIncidenciaId    IncidenciaId
        0				    0			Ignorar, no hay cambios
        0				    Not 0		Delete, se ha eliminado la Incidencia de la Asistencia. Actualizar Asistencia, Eliminar Incidencia (obtener ent por referencia y eliminar de la db por Id)
        Not 0			    0			Insert, se ha añadido la Incidencia a la Asistencia.  Crear nueva ent Incidencia, insertar (se actualiza Id). Copiar id en propiedad de Asistencia y Actualizar Asistencia en db.
        Not 0			    Not 0   	Posible Update, se puede hacer update o comparar valores
        */

/*
        public CommandStatus HandleY(AsistenciaUpdateCommand command)
        {
            try
            {
                int causa;
                int incidenciaRef;
                bool esPropiedadCero, esReferenciaNull;

                Collection<Asistencia> colAssist = new Collection<Asistencia>();
                Collection<Incidencia> colIncid = new Collection<Incidencia>();


                // recorrer las asistencias y comparar propiedad y referencia

                foreach (var asistencia in command.Asistencias)
                {
                    causa = asistencia.IncidenciaCausaIncidencia;
                    incidenciaRef = asistencia.IncidenciaId;

                    esPropiedadCero = (causa == 0);
                    esReferenciaNull = (incidenciaRef == 0);

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

                        //incidenciaRef.State = EntityState.Deleted;
                        //colIncid.Add(incidenciaRef);
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

                        //cambioCausa = (asistencia.IncidenciaCausaIncidencia != incidenciaRef.CausaId);
                        //cambioObs = (asistencia.IncidenciaObservacion != incidenciaRef.Observacion);

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
       */
        
            // nueva implementacion
        public CommandStatus Handle(AsistenciaUpdateCommand command)
        {
            bool ret;
            try
            {
                // Iniciar transaccion
                //_data.BeginTransaction();

                Collection<Incidencia> colIncid;
                Collection<Asistencia> colAsist;


                // Procesar Incidencias Insertadas Crear nuevas
                var IncidInserted = command.Asistencias.Select(ast => ast.IncidenciaRef).Where(inci => inci != null && inci.State == EntityState.Added);
                var AsistIncidInserted = command.Asistencias.Select(ast => ast).Where(ast => ast.IncidenciaRef != null && ast.IncidenciaRef.State == EntityState.Added);

                colIncid = new Collection<Incidencia>(IncidInserted.ToArray());
                colAsist = new Collection<Asistencia>(AsistIncidInserted.ToArray());

                // Aqui las nuevas incidencias reciben Id
                ret = _data.ActualizarIncidencias(colIncid);
                if (!ret)
                    return new Failure("Error actualizando Incidencias Insert");

                foreach (var asi in colAsist)
                {
                    asi.IncidenciaId = asi.IncidenciaRef.Id;
                }

                // Actualizar Asistencias, se guarda la Inc Id recien creada
                ret = _data.ActualizarAsistencias(colAsist);
                if (!ret)
                    return new Failure("Error actualizando Asistencias Incidencias Insert");

                // IMplementar Update


                // Procesar Incidencias Eliminadas
                

                //var IncidDeleted = command.Asistencias.Select(ast => ast.IncidenciaRef).Where(inci => inci != null && inci.State == EntityState.Deleted);
                var AsistIncDeleted = command.Asistencias.Select(ast => ast).Where(ast => ast.IncidenciaRef != null && ast.IncidenciaRef.State == EntityState.Deleted);

                //colIncid = new Collection<Incidencia>(IncidDeleted.ToArray());
                colAsist = new Collection<Asistencia>(AsistIncDeleted.ToArray());


                // Actualizar Asistencias, se borra FK
                ret = _data.ActualizarAsistencias(colAsist);
                if (!ret)
                    return new Failure("Error actualizando Asistencias Inc Delete");

                // Actualizar Incidencias, se borra PK
                ret = _data.ActualizarIncidencias(command.Incidencias);
                if (!ret)
                    return new Failure("Error actualizando Incidencias Delete");


                // Terminar transaccion
                //_data.CommitTransaction();

                return new Success();
                
            }
            catch (Exception ex)
            {
                // Cancelar transaccion
                //_data.RollbackTransaction();

                //Log, Notify...
                return new Failure(ex.Message);
            }
        }


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

        public CommandStatus HandleX(AsistenciaUpdateCommand command)
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
                    causa = asistencia.IncidenciaCausaId;
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
                        Incidencia newInc = _data.InsertarNuevaIncidencia(asistencia.IncidenciaCausaId, asistencia.IncidenciaObservacion);

                        asistencia.IncidenciaId = newInc.Id;
                        asistencia.State = EntityState.Modified;
                        colAssist.Add(asistencia);
                    }

                    // Posible actualizacion
                    if (!esPropiedadCero && !esReferenciaNull)
                    {
                        bool cambioCausa, cambioObs;

                        cambioCausa = (asistencia.IncidenciaCausaId != incidenciaRef.CausaId);
                        cambioObs = (asistencia.IncidenciaObservacion != incidenciaRef.Observacion);

                        if (cambioCausa || cambioObs)
                        {
                            Console.WriteLine("Coinciden Asist Incidencia Id y Referencia Id: " + (asistencia.IncidenciaId == incidenciaRef.Id));
                            // actualizando propiedades de incidencia con valores en Asistencia modificados en GUI
                            incidenciaRef.CausaId = asistencia.IncidenciaCausaId;
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
