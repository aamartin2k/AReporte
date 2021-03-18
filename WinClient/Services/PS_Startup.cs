#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios del programa.
 *  
 *  Parcial Tareas de Inicio
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
using Zyan.Communication.Toolbox;

#endregion

namespace AReport.Client.Services
{
    internal static partial class SystemService
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Declaraciones
            bool ret;

            // Secuencia de Inicio
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Log
            Log.WriteStart();


            // Ejecutar tareas de inicio
            ret = TareasInicio();
            if (!ret)
                goto FinalError;

            // Cargar configuracion
            ret = LeerConfiguracion();
            if (!ret)
                goto FinalError;

            // Intentar conexion
            ret = ConectarServidor();
            
            if (!ret)
                goto FinalError;

            // DEBUG
            // Chequear arg de linea de comando para autologin
            if (args.Length > 0)
            {
                if (args[0].StartsWith("al"))
                {
                    ret = RealizarAutoLogin(args[0]);

                    if (ret)
                        goto ApplicationRun;
                    else
                        goto FinalOK;
                }
            }


            // Ejecutar User Login RealizarLogin()
            ret = RealizarLogin();
            if (!ret)
                goto FinalError;

            // Consultar User Role para configurar form de acuerdo
            ret = ConsultarRol();
            if (!ret)
                goto FinalError;

            // 
            // Configurar Form
            ret = ConfigurarMainForm();
            if (!ret)
                goto FinalError;

            // Leer datos de inicio
            ret = LeerDatosInicio();
            if (!ret)
                goto FinalError;

            ApplicationRun:

            Application.Run(MainForm);

            FinalOK:
            // Termino de la aplicacion sin ocurrir errores durante la ejecucion de Main 
            //  o termino normal por cierre de Mainform por usurio.

            DesconectarServidor();

            // guardar config
            ret = GuardarConfiguracion();
            if (!ret)
                goto FinalError;


            // realizar tareas de fin
            ret = TareasFin();
            if (!ret)
                goto FinalError;

            Log.WriteEndOK();
            // the end when everything goes OK!
            return;

            //  
            FinalError:
            // Termino de la aplicacion con un error en la ejecucion de Main
            Log.WriteEndError();
            // the end when something goes wrong!
        }

        #region Tareas de Inicio
        internal static bool TareasInicio()
        {
            const string methodName = "TareasInicio";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Ejecutando Tareas de Inicio.");

                // Crear formularios
                _editForm = new FormClient();
                _incidAsignForm = new FormAsigIncidencia();
                _usuariosForm = new FormUsuarios();


                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Terminadas Tareas de Inicio.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool LeerConfiguracion()
        {
            const string methodName = "LeerConfiguracion";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Leyendo configuracion.");

                _connString = string.Format("tcp://localhost:{1}/{0}", Constants.ZyanServerName, Constants.ZyanServerPort);
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Leida cadena de conexion: {0}.", _connString));

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }
        /*
        internal static bool ConectarServidor()
        {
            const string methodName = "ConectarServidor";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Conectando con servidor.");

                var connection = new ZyanConnection(_connString);
                var service = connection.CreateProxy<IMessageHandler>();

                _connection = connection;
                _proxy = service;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Conexion realizada con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }
        */
        internal static bool ConectarServidor()
        {
            const string methodName = "ConectarServidor";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Conectando con servidor.");

                var connection = new ZyanConnection(_connString);
                var service = connection.CreateProxy<IMessageHandler>();

                _connection = connection;
                _proxy = service;

                // Conectando input y output.
                // Las acciones de salida, a metodos del proxy, para su transmision remota al servidor.
                // Comandos
                Out_AsistenciaUpdateCommand = Asynchronizer<AsistenciaUpdateCommand>.WireUp(_proxy.In_AsistenciaUpdateCommand);
                // Consultas
                Out_AsistenciaQuery = Asynchronizer<AsistenciaQuery>.WireUp(_proxy.In_AsistenciaQuery);

                // La respuesta del servidor remoto, a acciones de entrada.
                // Comandos
                _proxy.Out_AsistenciaUpdateCommandResult = SyncContextSwitcher<CommandStatus>.WireUp(In_AsistenciaUpdateCommandResult);

                // Consultas
                _proxy.Out_AsistenciaQuery = SyncContextSwitcher<AsistenciaQueryResult>.WireUp(In_AsistenciaQueryResult);


                // Estableciendo controlador de sesion.
                _connection.Disconnected += _zyanConn_Disconnected;
                // Estableciendo monitoreo de la conexion.
                _connection.PollingInterval = TimeSpan.FromSeconds(3);
                _connection.PollingEnabled = true;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Conexion realizada con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        private static void _zyanConn_Disconnected(object sender, DisconnectedEventArgs e)
        {
            // Notificar form
            DesconectarServidor();
        }

        internal static bool RealizarLogin()
        {
            const string methodName = "RealizarLogin";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Realizando login de usuario.");
                // mostrar login dialog
                LoginHandler _login = new LoginHandler();

                _login.PasswordChar = "x";
                _login.Title = "Inicio";
                _login.Mensaje = string.Empty;
                _login.Owner = null;

                int intento = 4;

                do
                {
                    if (intento != 4)
                        _login.Mensaje = string.Format("{0} intentos restantes.", intento);

                    DialogResult ret = _login.ShowDialogSyn();

                    if (ret != DialogResult.OK)
                    {
                        Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Login cancelado por usuario: {0}", _login.UserLogin));
                        return false;
                    }

                    var loginCmd = new LoginCommand
                    {
                        UserName = _login.UserLogin,
                        Password = _login.UserPassword,
                    };

                    _userName = _login.UserLogin;

                    var status = _proxy.Handle(loginCmd);
                    bool Success = status.GetType() == typeof(Success);

                    if (Success)
                    {
                        Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Login exitoso para usuario: {0}", loginCmd.UserName));
                        return true;
                    }

                    intento--;
                    Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Login fallido para usuario: {0}", loginCmd.UserName));
                }
                while (intento > 0);

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Agotados los intentos de login para usuario: {0}", _userName));
                return false;

            }
            catch (Exception ex)
            {
                //Log
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool ConsultarRol()
        {
            const string methodName = "ConsultarRol";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Rol de usuario: " + _userName);

                // Leer User Role
                var URquery = new UserRoleQuery(_userName);
                var result = _proxy.Handle(URquery);

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Resultado: UserID: {0} Nombre: {1} Rol: {2}", result.UserID, result.UserName, result.UserRole));

                // Guardar UserId para Lectura de datos 
                _userID = result.UserID;
                _userRole = result.UserRole;
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool ConfigurarMainForm()
        {
            const string methodName = "ConfigurarMainForm";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Creando Formulario de Edicion.");

                switch (_userRole)
                {
                    case UserRoleEnum.JefeDepartamento:
                        _editForm.EditMode = UserRoleEnum.JefeDepartamento;
                        ConfigBindSourcesJefeDepartamento();
                        break;

                    case UserRoleEnum.Supervisor:
                        _editForm.EditMode = UserRoleEnum.Supervisor;
                        ConfigBindSourcesJefeDepartamento();
                        ConfigBindSourcesSupervisor();
                        break;

                    case UserRoleEnum.Administrador:
                    default:
                        _editForm.EditMode = UserRoleEnum.Administrador;
                        ConfigBindSourcesAdministrador();
                        break;
                }


                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Formulario de Edicion creado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool LeerDatosInicio()
        {
            const string methodName = "LeerDatosInicio";
            bool ret;

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Leyendo datos de inicio.");

                switch (_userRole)
                {
                    case UserRoleEnum.JefeDepartamento:
                        ret = LeerDatosJefeDepartamento();
                        break;

                    case UserRoleEnum.Supervisor:
                        ret = LeerDatosSupervisor();
                        break;

                    case UserRoleEnum.Administrador:
                    default:
                        ret = LeerDatosAdministrador();
                        break;
                }

                if (ret)
                    Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Datos de inicio leidos con exito.");

                return ret;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        #endregion

        #region Configuracion de BindingSources

        internal static void ConfigSelectEmpleados()
        {
            // Cuando No hay departamentos seleccionados y hay empleados en lista, borrarlos todos.
            if ((_incidAsignForm.chlbSelDepartIncid.CheckedItems.Count < 1) &&
                 (bdsSelectEmpleados.Count > 0))
            {
                bdsSelectEmpleados.Clear();
                return;
            }

            // Actualizar listado de empleados que pertenecen a los departamentos seleccionados.
            Collection<Empleado> colEmp = bdsTodosEmpleados.DataSource as Collection<Empleado>;
            Collection<Empleado> selEmp = new Collection<Empleado>();

            // hacer foreach coleccion
            foreach (var dept in _incidAsignForm.chlbSelDepartIncid.CheckedItems)
            {
                var emplId = colEmp.Where(em => em.DepartamentoId == (dept as Dept).Id);

                foreach (var emp in emplId)
                {
                    selEmp.Add(emp);
                }
            }

            bdsSelectEmpleados.DataSource = selEmp;
            bdsSelectEmpleados.ResetBindings(false);
        }

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

            _editForm.lbNombre.DataBindings.Add(new Binding("Text", bdsEmpleados, "Nombre", true));
            _editForm.lbNumero.DataBindings.Add(new Binding("Text", bdsEmpleados, "Code", true));
            _editForm.lbDepart.DataBindings.Add(new Binding("Text", bdsEmpleados, "Departamento", true));
            _editForm.bdnEmpleados.BindingSource = bdsEmpleados;

            // bdsAsistencias
            bdsAsistencias = new BindingSource();
            bdsAsistencias.DataSource = typeof(Asistencia);

            _editForm.dgvAsistencia.DataSource = bdsAsistencias;

            //bdsCausasIncidencias
            bdsCausasIncidencia = new BindingSource();
            bdsCausasIncidencia.DataSource = typeof(CausaIncidencia);

            //_editForm.incidCausaIncidenciaComboBoxColumn.DataSource = bdsCausasIncidencia;
            //_editForm.incidCausaIncidenciaComboBoxColumn.DisplayMember = "Description";
            //_editForm.incidCausaIncidenciaComboBoxColumn.ValueMember = "Id";

            _incidAsignForm.cmbCausas.DataSource = bdsCausasIncidencia;
            _incidAsignForm.cmbCausas.DisplayMember = "Description";
            _incidAsignForm.cmbCausas.ValueMember = "Id";

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

            _editForm.cmbDepartamentos.DataSource = bdsSelectDepartamentos;
            _editForm.cmbDepartamentos.DisplayMember = "Description";
            _editForm.cmbDepartamentos.ValueMember = "Id";
            _editForm.cmbDepartamentos.SelectedIndexChanged += new EventHandler(cmbDepartamentos_SelectedIndexChanged);

            _incidAsignForm.chlbSelDepartIncid.DataSource = bdsSelectDepartamentosIncid;

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

        private static void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_editForm.cmbDepartamentos.SelectedValue != null)
            {
                int deptId = (int)_editForm.cmbDepartamentos.SelectedValue;

                Collection<Empleado> colEmp = bdsTodosEmpleados.DataSource as Collection<Empleado>;

                //HARDCODED Caso especial Al seleccionar Departamento Caudal, id =  1
                // se deben mostrar todos los empleados.

                if (deptId == 1)
                {
                    var empl = colEmp.OrderBy(em => em.DepartamentoId).ThenBy(em => em.Nombre);
                    bdsEmpleados.DataSource = empl.ToList();
                }
                else
                {
                    var empl = colEmp.Where(em => em.DepartamentoId == deptId).OrderBy(em => em.DepartamentoId).ThenBy(em => em.Nombre);
                    bdsEmpleados.DataSource = empl.ToList();
                }

                //  Mover al primer registro.
                bdsEmpleados.MoveFirst();

            }
        }

        private static void ConfigBindSourcesAdministrador()
        {
            bdsUsuarios = new BindingSource();
            bdsUsuarios.DataSource = typeof(Usuario);
            _editForm.dgvUsuarios.DataSource = bdsUsuarios;

            bdsUserinfo = new BindingSource();
            bdsUserinfo.DataSource = typeof(Userinfo);

            bdsUserRoles = new BindingSource();
            bdsUserRoles.DataSource = typeof(Role);

            bdsJefes = new BindingSource();
            bdsJefes.DataSource = typeof(JefeDept);
            _editForm.dgvJefes.DataSource = bdsJefes;

            bdsTodosDepartamentos = new BindingSource();
            bdsTodosDepartamentos.DataSource = typeof(Dept);

            //cmbNombreUsuario

            _usuariosForm.cmbNombreUsuario.DataSource = bdsUserinfo;
            _usuariosForm.cmbNombreUsuario.DisplayMember = "Nombre";
            _usuariosForm.cmbNombreUsuario.ValueMember = "Userid";

            //cmbRolUsuario
            _usuariosForm.cmbRolUsuario.DataSource = bdsCausasIncidencia;
            _usuariosForm.cmbRolUsuario.DisplayMember = "Description";
            _usuariosForm.cmbRolUsuario.ValueMember = "Id";

        }

        #endregion

        #region Tareas de Fin
        internal static bool TareasFin()
        {
            const string methodName = "TareasFin";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Ejecutando Tareas de Fin.");


                // Disponer las referencias a formularios. No es imprescindible pero le ahorra trabajo al GC. 
                _editForm.cmbDepartamentos.SelectedIndexChanged -= new EventHandler(cmbDepartamentos_SelectedIndexChanged);

                _editForm.Dispose();
                _editForm = null;

                _incidAsignForm.Dispose();
                _incidAsignForm = null;

                _usuariosForm.Dispose();
                _usuariosForm = null;

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

                bdsUsuarios.Dispose();
                bdsUsuarios = null;

                bdsUserinfo.Dispose();
                bdsUserinfo = null;

                bdsUserRoles.Dispose();
                bdsUserRoles = null;

                bdsJefes.Dispose();
                bdsJefes = null;

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

    }
}
