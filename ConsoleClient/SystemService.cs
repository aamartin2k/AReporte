
#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios de sistema.
*/
#endregion

#region Using

using AMGS.Application.Utils.Dialogs;
using AMGS.Application.Utils.Log;
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
using Zyan.Communication.Toolbox;

//using FastReport;
//using FastReport.Export.Image;

#endregion

namespace ConsoleClient
{
    internal static partial class SystemService
    {
       
        #region Métodos

        #region Métodos Públicos

        // Region
       


        #region Entrada de Respuestas del servidor

      

        #endregion

        #region Tareas de Depuracion
        internal static bool RealizarAutoLogin(string arg)
        {
            const string methodName = "RealizarAutoLogin";

            
            string login =null;
            string password = null;

            // login Jefe grupo
            if (arg == "aljg")
            {
                login = "Pepe";
                password = "PasswordPepe";
            }

            if (arg == "alsrh")
            {
                login = "Tata";
                password = "PasswordTata";
            }

            var loginCmd = new LoginCommand
            {
                UserName = login,
                Password = password,
            };

            var status = _proxy.Handle(loginCmd);
            bool Success = status.GetType() == typeof(Success);
            if (Success)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Login exitoso para usuario: {0}", loginCmd.UserName));
                _userName = loginCmd.UserName;

                // continuar inicio
                bool ret;

                ret = ConsultarRol();
                if (!ret)
                    return false;

                ret = ConfigurarMainForm();
                if (!ret)
                    return false;

                ret = LeerDatosInicio();
                if (!ret)
                    return false;

                return true;
            }


            return false;

        }

        internal static void IniciarNuevoAutoLogin(string arg)
        {
            const string IniciarNuevoAutoLogin = "RealizarNuevoAutoLogin";

            AutoLogin = true;

            string login = null;
            string password = null;

            // login Jefe grupo
            if (arg == "aljg")
            {
                login = "Pepe";
                password = "PasswordPepe";
            }

            if (arg == "alsrh")
            {
                login = "Tata";
                password = "PasswordTata";
            }

            var loginCmd = new LoginCommand
            {
                UserName = login,
                Password = password,
            };

            // ejecutar accion de salida y termina bloque
            Out_LoginCommand(loginCmd);

        }

        // La accion continua al recbir respuesta del servidor
        #endregion

       

        #region Configuracion de BindingSources

       
        private static void ConfigBindSourcesJefeDepartamento()
        {
            // bdsEmpleados  
            bdsEmpleados = new BindingSource();
            bdsEmpleados.DataSource = typeof(Empleado);
            bdsEmpleados.CurrentChanged += new EventHandler(bdsEmpleados_CurrentChanged);

            // bdsTodosEmpleados
            bdsTodosEmpleados = new BindingSource();
            bdsTodosEmpleados.DataSource = typeof(Empleado);
            bdsTodosEmpleados.DataSourceChanged += new EventHandler(bdsTodosEmpleados_DataSourceChanged);
            
            //_editForm.lbNombre.DataBindings.Add(new Binding("Text", bdsEmpleados, "Nombre", true));
            //_editForm.lbNumero.DataBindings.Add(new Binding("Text", bdsEmpleados, "Code", true));
            //_editForm.lbDepart.DataBindings.Add(new Binding("Text", bdsEmpleados, "Departamento", true));
            //_editForm.bdnEmpleados.BindingSource = bdsEmpleados;

            // bdsAsistencias
            bdsAsistencias = new BindingSource();
            bdsAsistencias.DataSource = typeof(Asistencia);

            //_editForm.dgvAsistencia.DataSource = bdsAsistencias;

            //bdsCausasIncidencias
            bdsCausasIncidencia = new BindingSource();
            bdsCausasIncidencia.DataSource = typeof(CausaIncidencia);

            //_editForm.incidCausaIncidenciaComboBoxColumn.DataSource = bdsCausasIncidencia;
            //_editForm.incidCausaIncidenciaComboBoxColumn.DisplayMember = "Description";
            //_editForm.incidCausaIncidenciaComboBoxColumn.ValueMember = "Id";

            //_incidAsignForm.cmbCausas.DataSource = bdsCausasIncidencia;
            //_incidAsignForm.cmbCausas.DisplayMember = "Description";
            //_incidAsignForm.cmbCausas.ValueMember = "Id";

            // Incidencias
            colIncidencias = new Collection<Incidencia>();

            // creando instancias para modo supervisor
            bdsSelectEmpleados = new BindingSource();
            bdsSelectDepartamentosIncid = new BindingSource();
            bdsTodosDepartamentos = new BindingSource();
            bdsSelectDepartamentos = new BindingSource();

        }

        private static void bdsEmpleados_CurrentChanged(object sender, EventArgs e)
        {
            Empleado emp = (Empleado)bdsEmpleados.Current;
            // Extraer Collection Asistencias del empleado activo y crear Lista genérica 
            // para editar campos en DataGrid. Si se asigna la Collection directamente NO permite editar!
            List<Asistencia> asist = new List<Asistencia>(emp.Asistencias);

            bdsAsistencias.DataSource = asist;
        }

        private static void ConfigBindSourcesSupervisor()
        {
            
            bdsSelectEmpleados.DataSource = typeof(Empleado);
            bdsSelectDepartamentosIncid.DataSource = typeof(Dept);
            bdsTodosDepartamentos.DataSource = typeof(Dept);   
            bdsSelectDepartamentos.DataSource = typeof(Dept);

            //_editForm.cmbDepartamentos.DataSource = bdsSelectDepartamentos;
            //_editForm.cmbDepartamentos.DisplayMember = "Description";
            //_editForm.cmbDepartamentos.ValueMember = "Id";
            //_editForm.cmbDepartamentos.SelectedIndexChanged += new EventHandler(cmbDepartamentos_SelectedIndexChanged);

            //_incidAsignForm.chlbSelDepartIncid.DataSource = bdsSelectDepartamentosIncid;

        }

        private static void bdsTodosEmpleados_DataSourceChanged(object sender, EventArgs e)
        {
            Collection<Empleado> colEmp = bdsTodosEmpleados.DataSource as Collection<Empleado>;

            if (_userRole == UserRoleEnum.Supervisor)
            {
                var empl = colEmp.OrderBy(em => em.DepartamentoId).ThenBy(em => em.Nombre);
                bdsEmpleados.DataSource = empl.ToList();
            }

            if (_userRole == UserRoleEnum.JefeDepartamento)
            {
                var empl = colEmp.OrderBy(em => em.Nombre);
                bdsEmpleados.DataSource = empl.ToList();
            }

        }

       

        private static void ConfigBindSourcesAdministrador()
        {

        }

        #endregion

        #region Tareas de Fin
        internal static bool TareasFin()
        {
            const string methodName = "TareasFin";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Ejecutando Tareas de Fin.");

                // Disponer las referencias a BindingSources.
                bdsEmpleados.Dispose();
                bdsEmpleados = null;

                bdsCausasIncidencia.Dispose();
                bdsCausasIncidencia = null;

                bdsAsistencias.Dispose();
                bdsAsistencias = null;

                bdsSelectDepartamentosIncid.Dispose();
                bdsSelectDepartamentosIncid = null;

                bdsTodosDepartamentos.Dispose();
                bdsTodosDepartamentos = null;

                bdsSelectDepartamentos.Dispose();
                bdsSelectDepartamentos = null;

                bdsTodosEmpleados.Dispose();
                bdsTodosEmpleados = null;

                bdsSelectEmpleados.Dispose();
                bdsSelectEmpleados = null;

                colIncidencias = null;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Terminadas Tareas de Fin.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool GuardarConfiguracion()
        {
            const string methodName = "GuardarConfiguracion";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Ejecutando Guardar Configuracion.");

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Terminada Guardar Configuracion.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static void DesconectarServidor()
        {
            const string methodName = "DesconectarServidor";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Cerrando conexion con servidor.");
                _connection.Dispose();

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Conexion terminada.");
            }
            catch (Exception ex)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                }
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
            }
            finally
            {
                _connection = null;
                _proxy = null;

            }
        }

        #endregion

        #region Lectura de Datos

        internal static bool ConsultarClavesMes()
        {
            const string methodName = "ConsultarClavesMes";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Claves de Mes registradas.");

                // consultar claves mes existentes
                ClaveMesQuery cmQry = new ClaveMesQuery();
                ClaveMesQueryResult cmQryRst = _proxy.Handle(cmQry);

                // actualizar lista en cmbSelMes
                

                if (cmQryRst.Coleccion.Count > 0)
                {
                    foreach (var mes in cmQryRst.Coleccion)
                    {
                        //_editForm.cmbSelMes.Items.Add(mes);
                    }
                }


                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Claves de Mes consultadas con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

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

        private static bool LeerDatosSupervisor()
        {
            bool ret;

            ret = ConsultarDepartUsuario();

            if (ret)
                ret = ConsultarListaDepart();
            else
                return false;

            if (ret)
                ret = ConsultarClavesMes();

            return ret;
        }

        internal static bool ConsultarListaDepart()
        {
            const string methodName = "ConsultarListaDepart";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Departamento del usuario.");

                DepartamentQuery dptQry = new DepartamentQuery();
                DepartamentQueryResult dptQryRst = _proxy.Handle(dptQry);

                //_editForm.chlbSelDepart.Items.Clear();

                if (dptQryRst.Coleccion.Count > 0)
                {
                    //_editForm.chlbSelDepart.DataSource = dptQryRst.Coleccion;
                    bdsTodosDepartamentos.DataSource = dptQryRst.Coleccion;
                }

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Departamento del usuario consultado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

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
            //bdsSelectDepartamentos.DataSource = _editForm.chlbSelDepart.CheckedItems;
            //bdsSelectDepartamentosIncid.DataSource = _editForm.chlbSelDepart.CheckedItems;

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
            //bdsSelectDepartamentos.DataSource = _editForm.chlbSelDepart.CheckedItems;
            //bdsSelectDepartamentosIncid.DataSource = _editForm.chlbSelDepart.CheckedItems;

            // Convertir collection de object en coll int  
            // WARN Codigo repetido.
            var keys = list.Select(k => (k as Dept).Id);
            Collection<int> keyList = new Collection<int>(keys.ToArray());

            AsistenciaQuery asistQry = new AsistenciaQuery(mes, anno, keyList);

            ConsultarAsistencias(asistQry);

        }

       

        #endregion

        #region Lectura de datos para rol Administrador

        private static bool LeerDatosAdministrador()
        {
            return true;
        }

        #endregion
        #endregion

        #region Manejo Incidencias
        /*
        internal static void AsignarIncidencia()
        {
            // mostrar form modal
            _incidAsignForm.EditMode = UserRoleEnum.JefeDepartamento;
            var ret = _incidAsignForm.ShowDialog(_editForm);

            // actualizar valores
            if (ret != DialogResult.OK)
                return;

            string obs = _incidAsignForm.tbObserv.Text;
            string causaDesc = _incidAsignForm.cmbCausas.Text;
            int causaId = (int) _incidAsignForm.cmbCausas.SelectedValue;

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

        }

        internal static void AsignarIncidenciaGrupo()
        {
            // pasar datos a form   bdsTodosDepartamentos
            _incidAsignForm.chlbSelEmpleado.DataSource = bdsSelectEmpleados;

            // mostrar form modal
            _incidAsignForm.EditMode = UserRoleEnum.Supervisor;
            var ret = _incidAsignForm.ShowDialog(_editForm);

            // actualizar valores
            if (ret != DialogResult.OK)
                return;

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
        }

        internal static void  EliminarIncidencia()
        {
            Asistencia data;
            Incidencia inc;

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
                    data.IncidenciaObservacion = string.Empty;
                    // Refrescar datos en lista.
                    bdsAsistencias.ResetBindings(false);
                }
            }
        }
        */
        #endregion

        internal static void ActualizarAsistencias()
        {
            const string methodName = "ActualizarAsistencias";

            
            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Ejecutando Actualizar Asistencias.");

                Collection<Asistencia> colAsist = new Collection<Asistencia>();
                Collection<Empleado> colEmpleados = bdsTodosEmpleados.DataSource as Collection<Empleado>;

                // implementacion sin LINQ
                foreach (var empl in colEmpleados)
                {
                    foreach (var asi in empl.Asistencias)
                    {
                        colAsist.Add(asi);
                    }
                }

                // Seleccionando solo las que se modificaron.
                var modAsist = colAsist.Where(asi => asi.State != EntityState.Unchanged);

                colAsist = new Collection<Asistencia>(modAsist.ToArray());

                // Comando de actualizacion
                AsistenciaUpdateCommand asistCmd = new AsistenciaUpdateCommand(colAsist, colIncidencias);
                var status = _proxy.Handle(asistCmd);

                bool Success = status.GetType() == typeof(Success);

                if (Success)
                {
                    colIncidencias = new Collection<Incidencia>();
                    Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Actualizar Asistencias terminado con éxito.");
                    MessageBox.Show("Actualizar Asistencias terminado con éxito.");

                }
                else
                {
                    Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Comando fallido. Error: {0}", (status as Failure).Errormessage));
                    MessageBox.Show("Actualizar Asistencias terminado con Error.");
                }
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
            }
        }


        

        // Region reportes

        /*
        internal static void MostrarReporte()
        {
            Collection<Empleado> colEmpleados = bdsTodosEmpleados.DataSource as Collection<Empleado>;
            List<Empleado> colEmp = new List<Empleado>(colEmpleados);

            // Crear instancia.
            Report report = new Report();

            // Cargar definicion de reporte. 
            report.Load("Reports\\report.frx");
           
            // Pasar datos.
            report.RegisterData(colEmpleados, "Empleados");

            // Pasar parametros
            report.SetParameterValue("parNombreMesAnno", _fechaConsulta.TextoNombreMesReporte);
            // prepare the report
            bool ret =  report.Prepare();

            if (ret)
            {
                // export as imahge
                //ImageExport image = new ImageExport();
                //image.ImageFormat = ImageExportFormat.Jpeg;
                //report.Export(image, "Reports\\report.jpg");

                FastReport.Export.PdfSimple.PDFSimpleExport pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
                pdfExport.Export(report, "Reports\\report.pdf");

                MessageBox.Show("Reporte listo!");
            }
            else
            {
                MessageBox.Show("Error perparando Reporte");
            }
            // free resources used by report
            report.Dispose();

           
        }

        */

        #endregion

        #region Métodos Privados

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
            //_editForm.lbMes.Text = _fechaConsulta.TextoNombreMes;
            //MessageBox.Show("Actualizado: " + _fechaConsulta.TextoNombreMes);
        }

        /// <summary>
        /// Realiza la consulta de Asistencia.
        /// </summary>
        /// <param name="qry">Objeto con parámetros de consulta.</param>
        private static void ConsultarAsistencias(AsistenciaQuery qry)
        {
            
            const string methodName = "ConsultarAsistencias";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Asistencias registradas.");

                AsistenciaQueryResult result = _proxy.Handle(qry);

                bdsTodosEmpleados.DataSource = result.Empleados;
                bdsEmpleados.DataSource = result.Empleados;
                bdsCausasIncidencia.DataSource = result.CausasIncidencias;
                // Actualizar etiqueta Mes en Form Edicion
                ActualizarFechaConsultaForm();

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Asistencias consultadas con exito.");
                
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
            }
        }

        private static bool LeerDatosJefeDepartamento()
        {
            bool ret;

            ret = ConsultarDepartUsuario();

            if (ret)
                ret = ConsultarClavesMes();

            return ret;
        }

        // consultar dept del usuario
        private static bool ConsultarDepartUsuario()
        {
            const string methodName = "ConsultarDepartUsuario";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Departamento del usuario.");

                UserDepartamentQuery dptQry = new UserDepartamentQuery(_userID);
                UserDepartamentQueryResult dptQryRst = _proxy.Handle(dptQry);

                _userDeptId = dptQryRst.Id;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Departamento del usuario consultado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        #endregion

        #endregion

    }
}
