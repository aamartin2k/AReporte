#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios del programa.
 *  
 *  Parcial Gestion de Asistencias
*/
#endregion

#region Using

using AMGS.Application.Utils.Dialogs;
using AMGS.Application.Utils.Log;
using AReport.Client.Forms;
using AReport.Support.Command;
using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Zyan.Communication;

#endregion

namespace AReport.Client.Services
{
    internal static partial class SystemService
    {
        // Metodos de interaccion con el servidor
        // Accion de salida
        public static Action<AsistenciaQuery> Out_AsistenciaQuery { get; set; }
        public static Action<AsistenciaUpdateCommand> Out_AsistenciaUpdateCommand { get; set; }
        
        // Metodo de entrada de resultado
        public static void In_AsistenciaQueryResult(AsistenciaQueryResult result)
        {
            const string methodName = "In_AsistenciaQueryResult";

            try
            {
                FinEsperaPorTarea(TipoEspera.Consulta);

                bdsTodosEmpleados.DataSource = result.Empleados;
                bdsEmpleados.DataSource = result.Empleados;
                bdsCausasIncidencia.DataSource = result.CausasIncidencias;
                
                // Actualizar etiqueta Mes en Form Edicion
                ActualizarFechaConsultaForm();

                _editForm.TabNavigationMode(FormClient.TabNavigationStatus.Resultados);

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Asistencias consultadas con exito.");
            }
            catch (Exception ex)
            {

                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
            }
        }

        public static void In_AsistenciaUpdateCommandResult(CommandStatus status)
        {
            const string methodName = "In_AsistenciaUpdateCommandResult";

            bool Success = status.GetType() == typeof(Success);

           
            if (Success)
            {
                FinEsperaPorTarea(TipoEspera.Actualizacion);

                colIncidencias = new Collection<Incidencia>();
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Actualizar Asistencias terminado con éxito.");
                //MessageBox.Show("Actualizar Asistencias terminado con éxito.");

                // Ejecutando consulta guardada para actualizar datos en Form
                //ConsultarAsistencias(_consulta);
            }
            else
            {
                FinEsperaPorTarea(TipoEspera.ActualizacionError);
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Comando fallido. Error: {0}", (status as Failure).Errormessage));
                MessageBox.Show("Actualizar Asistencias terminado con Error.");
            }
        }


        #region Metodos Públicos (Internal)

        #region Lectura de datos para rol Jefe de Departamento
        /// <summary>
        /// Prepara ejecución de consulta de Asistencias para Jefe de Departamento. Los resultados se restringen al Departamento del usuario.
        /// </summary>
        /// <param name="key">Objeto Clave de mes a consultar.</param>
        internal static void ConsultarAsistencias(object key)
        {
            // Guardar datos de consulta
            GuardarFechaConsulta(key);

            // Convertir object a ClaveMes
            AsistenciaQuery asistQry = new AsistenciaQuery((key as ClaveMes).Id, _userDeptId);

            ConsultarAsistencias(asistQry);
        }

        /// <summary>
        /// Prepara ejecución de consulta de Asistencias para Jefe de Departamento. Los resultados se restringen al Departamento del usuario.
        /// </summary>
        /// <param name="mes">Mes a consultar.</param>
        /// <param name="anno">Año a consultar.</param>
        internal static void ConsultarAsistencias(int mes, int anno)
        {
            // Guardar datos de consulta
            GuardarFechaConsulta(mes, anno);

            AsistenciaQuery asistQry = new AsistenciaQuery(mes, anno, _userDeptId);
            ConsultarAsistencias(asistQry);

        }

        #endregion


        #region Lectura de datos para rol Supervisor RR HH

        /// <summary>
        /// Prepara ejecución de consulta de Asistencias para Supervisor.
        /// </summary>
        /// <param name="key">Objeto Clave de mes a consultar.</param>
        /// <param name="list">Lista de objetos Departamento a consultar.</param>
        internal static void ConsultarAsistencias(object key, Collection<object> list)
        {
            // Guardar datos de consulta
            GuardarFechaConsulta(key);


            // Pasar lista de elementos seleccionados como datasource
            // del combo de seleccion de departamentos en Tab Resultados
            bdsSelectDepartamentos.DataSource = _editForm.chlbSelDepart.CheckedItems;
            bdsSelectDepartamentosIncid.DataSource = _editForm.chlbSelDepart.CheckedItems;

            // Convertir collection de object en coll int  
            // WARN Codigo repetido.
            var keys = list.Select(k => (k as Dept).Id);
            Collection<int> keyList = new Collection<int>(keys.ToArray());


            AsistenciaQuery asistQry = new AsistenciaQuery((key as ClaveMes).Id, keyList);

            ConsultarAsistencias(asistQry);

        }

        /// <summary>
        /// Prepara ejecución de consulta de Asistencias para Supervisor. Permite consultar varios Departamentos.
        /// </summary>
        /// <param name="mes">Mes a consultar.</param>
        /// <param name="anno">Año a consultar.</param>
        /// <param name="list">Lista de objetos Departamento a consultar.</param>
        internal static void ConsultarAsistencias(int mes, int anno, Collection<object> list)
        {
            // Guardar datos de consulta
            GuardarFechaConsulta(mes, anno);

            // Pasar lista de elementos seleccionados como datasource
            // del combo de seleccion de departamentos en Tab Resultados
            bdsSelectDepartamentos.DataSource = _editForm.chlbSelDepart.CheckedItems;
            bdsSelectDepartamentosIncid.DataSource = _editForm.chlbSelDepart.CheckedItems;

            // Convertir collection de object en coll int  
            // WARN Codigo repetido.
            var keys = list.Select(k => (k as Dept).Id);
            Collection<int> keyList = new Collection<int>(keys.ToArray());

            AsistenciaQuery asistQry = new AsistenciaQuery(mes, anno, keyList);

            ConsultarAsistencias(asistQry);

        }

        #endregion

        #endregion

        #region Metodos Privados
        // Almacenar consulta de asistencias.
        private static void GuardarConsulta(AsistenciaQuery qry)
        {
            _consulta = qry;
        }

        // Almacenar fecha de consulta en objeto ClaveMes, para actualizar etiqueta de mes en form de edicion
        // y pasar texto a reporte.
        private static void GuardarFechaConsulta(object key)
        {
            _fechaConsulta = key as ClaveMes;
        }

        private static void GuardarFechaConsulta(int mes, int anno)
        {
            _fechaConsulta = new ClaveMes();
            _fechaConsulta.Mes = mes;
            _fechaConsulta.Anno = anno;
        }

        private static void ActualizarFechaConsultaForm()
        {
            _editForm.lbMes.Text = _fechaConsulta.TextoNombreMes;
            //MessageBox.Show("Actualizado: " + _fechaConsulta.TextoNombreMes);
        }


        /// <summary>
        /// Realiza la consulta de Asistencia al servidor de forma asíncrona.
        /// </summary>
        /// <param name="qry">Objeto con parámetros de consulta.</param>
        private static void ConsultarAsistencias(AsistenciaQuery qry)
        {
            const string methodName = "ConsultarAsistencias";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Asistencias registradas.");

                GuardarConsulta(qry);

                // Comienzo de Implementacion Asíncrona
                EsperaPorTarea(TipoEspera.Consulta);

                // Realizar la consulta y termina la ejecucion secuencial
                // Se continua al recibir respuesta del server en In_AsistenciaQueryResult
                Out_AsistenciaQuery(qry);

            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Realiza la salva de modificaciones de Asistencia al servidor de forma asíncrona.
        /// </summary>
        internal static bool ActualizarAsistencias()
        {
            const string methodName = "ActualizarAsistencias";
      
            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Ejecutando Actualizar Asistencias.");

                EsperaPorTarea(TipoEspera.Actualizacion);

                List<Asistencia> concat = new List<Asistencia>();
                Collection<Empleado> colTodosEmpleados = bdsTodosEmpleados.DataSource as Collection<Empleado>;
                
                // Crear lista de asistencias modificadas de todos los empleados
                var colAsistencias = colTodosEmpleados.Select(e => e.Asistencias);

                foreach (var col in colAsistencias)
                {
                    concat = concat.Concat(col.Where(asi => asi.State != EntityState.Unchanged).ToList()).ToList();
                }

                var updCol = new Collection<Asistencia>(concat.ToArray());

                // Comando de actualizacion
                AsistenciaUpdateCommand asistCmd = new AsistenciaUpdateCommand(updCol, colIncidencias);
                // Realizar la consulta y termina la ejecucion secuencial
                // Se continua al recibir respuesta del server en In_AsistenciaUpdateCommandResult
           
                Out_AsistenciaUpdateCommand(asistCmd);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }
        #endregion

    }

}