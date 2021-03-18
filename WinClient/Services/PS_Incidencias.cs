#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios del programa.
 *  
 *  Parcial Gestion de Incidencias
 */
#endregion

#region Using

using AMGS.Application.Utils.Log;
using AReport.Support.Common;
using AReport.Support.Entity;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace AReport.Client.Services
{
    internal static partial class SystemService
    {

        #region Metodos Públicos (Internal)
        
        internal static bool AsignarIncidencia()
        {
            const string methodName = "AsignarIncidencia";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Asignar Incidencia individual.");

                // Mostrar form modal.
                _incidAsignForm.EditMode = UserRoleEnum.JefeDepartamento;
                var ret = _incidAsignForm.ShowDialog(_editForm);

                // Actualizar valores si no se cancela dialogo.
                if (ret != DialogResult.OK)
                    return false;

                string obs = _incidAsignForm.tbObserv.Text;
                string causaDesc = _incidAsignForm.cmbCausas.Text;
                int causaId = (int)_incidAsignForm.cmbCausas.SelectedValue;

                // crear nueva incidencia
                Incidencia inc = new Incidencia();
                inc.CausaId = causaId;
                inc.Observacion = obs;
                inc.State = EntityState.Added;

                //Asistencia data;
                DataGridViewRow row = _editForm.dgvAsistencia.SelectedRows[0];
                Asistencia asist = (Asistencia)row.DataBoundItem;

                asist.IncidenciaRef = inc;
                asist.IncidenciaObservacion = obs;
                asist.IncidenciaCausaId = causaId;
                asist.IncidenciaCausaDesc = causaDesc;
                asist.State = EntityState.Modified;

                // Existe alternativa de usar BindingList<T> 
                bdsAsistencias.ResetBindings(false);

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Asignar Incidencia individual terminado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool AsignarIncidenciaGrupo()
        {
            const string methodName = "AsignarIncidenciaGrupo";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Asignar Incidencia a grupo.");

                // pasar datos a form   bdsTodosDepartamentos
                _incidAsignForm.chlbSelEmpleado.DataSource = bdsSelectEmpleados;

                // mostrar form modal
                _incidAsignForm.EditMode = UserRoleEnum.Supervisor;
                var ret = _incidAsignForm.ShowDialog(_editForm);

                // actualizar valores
                if (ret != DialogResult.OK)
                    return false;

                string obs = _incidAsignForm.tbObserv.Text;
                string causaDesc = _incidAsignForm.cmbCausas.Text;
                int causaId = (int)_incidAsignForm.cmbCausas.SelectedValue;

                // crear nueva incidencia
                Incidencia newInc = new Incidencia();
                newInc.CausaId = causaId;
                newInc.Observacion = obs;
                newInc.State = EntityState.Added;

                DataGridViewRow row = _editForm.dgvAsistencia.SelectedRows[0];
                Asistencia data = (Asistencia)row.DataBoundItem;

                // obtener clave fecha de Asistencia
                //data.FechaId      bdsAsistencias   bdsSelectEmpleados 

                // para cada empleado seleccoinado en lista
                // buscar asistencias por clave fecha
                // incorporar incidencia

                foreach (var empl in _incidAsignForm.chlbSelEmpleado.CheckedItems)
                {
                    var colAsist = (empl as Empleado).Asistencias.Where(asist => asist.FechaId == data.FechaId);

                    foreach (var asist in colAsist)
                    {
                        asist.IncidenciaRef = newInc;
                        asist.IncidenciaObservacion = obs;
                        asist.IncidenciaCausaId = causaId;
                        asist.IncidenciaCausaDesc = causaDesc;
                        asist.State = EntityState.Modified;
                    }
                }

                bdsAsistencias.ResetBindings(false);
                    Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Asignar Incidencia a grupo terminado con exito.");
                    return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool EliminarIncidencia()
        {
            const string methodName = "EliminarIncidencia";

            try
            {
                Asistencia data;
                Incidencia inc;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Eliminar Incidencia individual.");

                foreach (DataGridViewRow row in _editForm.dgvAsistencia.SelectedRows)
                {
                    data = (Asistencia)row.DataBoundItem;

                    if (data.IncidenciaRef != null)
                    {
                        inc = data.IncidenciaRef;
                        // Marcar para eliminar objeto Incidencia.
                        inc.State = EntityState.Deleted;

                        // Almacenar ref en coleccion de actualizacion
                        colIncidencias.Add(inc);

                        // Marcar objeto Asistencia para actualizacion.
                        // Hacer cero Id de referencia a Incidencia
                        data.IncidenciaId = 0;
                        data.State = EntityState.Modified;
                        // Borrar campos. 
                        data.IncidenciaCausaId = 0;
                        data.IncidenciaCausaDesc = string.Empty;
                        data.IncidenciaObservacion = string.Empty;
                        // Refrescar datos en lista.
                        bdsAsistencias.ResetBindings(false);
                    }
                }

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Eliminar Incidencia individual terminado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        #endregion

        #region Metodos Privados

        #endregion

    }

}