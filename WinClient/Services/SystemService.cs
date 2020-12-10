
#region Descripción
/* 
 *  Lógica del sistema.
 * 
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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Zyan.Communication;

#endregion

namespace AReport.Client.Services
{
    internal static class SystemService
    {
        #region Declaraciones
        const string _className = "SystemService";

        static public IMessageHandling proxy;
        static ZyanConnection _connection;

        // Valores leidos en configuracion
        static string _connString;

        // Valores necesarios para secuencia de inicio
        // Datos del usuario que inicia sesión
        //TODO Valorar uso de struct.
        static string _userName;
        static public string _userID;
        static UserRoleEnum _userRole;
        static int _userDeptId;

        // Referencia a formularios
        private static FormClient _editForm;

        #endregion

        #region Propiedades

        #region Propiedades Públicas

        /// <summary>
        /// Referencia al formulario principal.
        /// </summary>
        internal static FormClient MainForm
        {
            get { return _editForm; }
        }


        #endregion

        #region Propiedades Privadas
        #endregion

        #endregion

        #region Métodos

        #region Métodos Públicos

        #region Tareas de Inicio
        internal static bool TareasInicio()
        {
            const string methodName = "TareasInicio";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Ejecutando Tareas de Inicio.");

                // Crear formularios
                _editForm = new FormClient();

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Terminadas Tareas de Inicio.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool LeerConfiguracion()
        {
            const string methodName = "LeerConfiguracion";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Leyendo configuracion.");

                _connString = string.Format("tcp://localhost:{1}/{0}", Constants.ZyanServerName, Constants.ZyanServerPort);
                Log.WriteEntry(_className, methodName, TraceEventType.Information, string.Format("Leida cadena de conexion: {0}.", _connString));

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool ConectarServidor()
        {
            const string methodName = "ConectarServidor";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Conectando con servidor.");

                var connection = new ZyanConnection(_connString);
                var service = connection.CreateProxy<IMessageHandling>();

                _connection = connection;
                proxy = service;

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Conexion realizada con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool RealizarLogin()
        {
            const string methodName = "RealizarLogin";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Realizando login de usuario.");
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
                        Log.WriteEntry(_className, methodName, TraceEventType.Information, string.Format("Login cancelado por usuario: {0}", _login.UserLogin));
                        return false;
                    }

                    var loginCmd = new LoginCommand
                    {
                        UserName = _login.UserLogin,
                        Password = _login.UserPassword,
                    };

                    _userName = _login.UserLogin;

                    var status = proxy.Handle(loginCmd);
                    bool Success = status.GetType() == typeof(Success);

                    if (Success)
                    {
                        Log.WriteEntry(_className, methodName, TraceEventType.Information, string.Format("Login exitoso para usuario: {0}", loginCmd.UserName));
                        return true;
                    }

                    intento--;
                    Log.WriteEntry(_className, methodName, TraceEventType.Information, string.Format("Login fallido para usuario: {0}", loginCmd.UserName));
                }
                while (intento > 0);

                Log.WriteEntry(_className, methodName, TraceEventType.Information, string.Format("Agotados los intentos de login para usuario: {0}", _userName));
                return false;

            }
            catch (Exception ex)
            {
                //Log
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool ConsultarRol()
        {
            const string methodName = "ConsultarRol";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Consultando Rol de usuario: " + _userName);

                // Leer User Role
                var URquery = new UserRoleQuery(_userName);
                var result = proxy.Handle(URquery);

                Log.WriteEntry(_className, methodName, TraceEventType.Information, string.Format("Resultado: UserID: {0} Nombre: {1} Rol: {2}", result.UserID, result.UserName, result.UserRole));

                // Guardar UserId para Lectura de datos 
                _userID = result.UserID;
                _userRole = result.UserRole;
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool CrearMainForm()
        {
            const string methodName = "CrearMainForm";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Creando Formulario de Edicion.");

                switch (_userRole)
                {
                    case UserRoleEnum.JefeDepartamento:
                        _editForm.EditMode = FormClientMode.JefeGrupo;
                        break;

                    case UserRoleEnum.Supervisor:
                        _editForm.EditMode = FormClientMode.Supervisor;
                        break;

                    case UserRoleEnum.Administrador:
                    default:
                        _editForm.EditMode = FormClientMode.Administrador;
                        break;
                }
               

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Formulario de Edicion creado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool LeerDatosInicio()
        {
            const string methodName = "LeerDatosInicio";
            bool ret;

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Leyendo datos de inicio.");

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

                if(ret)
                    Log.WriteEntry(_className, methodName, TraceEventType.Information, "Datos de inicio leidos con exito.");

                return ret;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        #endregion

        #region Tareas de Fin
        internal static bool TareasFin()
        {
            const string methodName = "TareasFin";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Ejecutando Tareas de Fin.");

                // Disponer las referencias a formularios. No es imprescindible pero le ahorra trabajo al GC. 
                _editForm.Dispose();
                _editForm = null;


                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Terminadas Tareas de Fin.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool GuardarConfiguracion()
        {
            const string methodName = "GuardarConfiguracion";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Ejecutando Guardar Configuracion.");

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Terminada Guardar Configuracion.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static void DesconectarServidor()
        {
            const string methodName = "DesconectarServidor";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Cerrando conexion con servidor.");
                _connection.Dispose();

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Conexion terminada.");
            }
            catch (Exception ex)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                }
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
            }
            finally
            {
                _connection = null;
                proxy = null;

                //Log.WriteEntry(_className, methodName, TraceEventType.Information, "Refeencia a conexion anulada en bloque finally.");
            }
        }

        #endregion

        #region Lectura de Datos

        internal static bool ConsultarClavesMes()
        {
            const string methodName = "ConsultarClavesMes";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Consultando Claves de Mes registradas.");

                // consultar claves mes existentes
                ClaveMesQuery cmQry = new ClaveMesQuery();
                ClaveMesQueryResult cmQryRst = proxy.Handle(cmQry);

                // actualizar lista en cmbSelMes
                _editForm.cmbSelMes.Items.Clear();

                if (cmQryRst.Coleccion.Count > 0)
                {
                    foreach (var mes in cmQryRst.Coleccion)
                    {
                        //TODO Si no funciona, adicionar string y poner ref a object en prop Tag.
                        _editForm.cmbSelMes.Items.Add(mes);
                    }
                }


                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Claves de Mes consultadas con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        #region Lectura de datos para rol Jefe de Departamento

        internal static void ConsultarAsistencias(object key)
        {
            // Convertir object a ClaveMes
            ClaveMes cm = (ClaveMes)key;
            AsistenciaQuery asistQry = new AsistenciaQuery(cm.Id, _userDeptId);

            ConsultarAsistencias(asistQry);
        }

        internal static void ConsultarAsistencias(int mes, int anno)
        {
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
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Consultando Departamento del usuario.");

                DepartamentQuery dptQry = new DepartamentQuery();
                DepartamentQueryResult dptQryRst = proxy.Handle(dptQry);

                _editForm.chlbSelDepart.Items.Clear();

                if (dptQryRst.Coleccion.Count > 0)
                {
                    foreach (var depart in dptQryRst.Coleccion)
                    {
                        // chlbSelDepart
                        Console.WriteLine(string.Format(" Leído Departamento Id: {0}\t Nombre: {1}", depart.Id, depart.Description));
                        _editForm.chlbSelDepart.Items.Add(depart);
                    }
                }

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Departamento del usuario consultado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static void ConsultarAsistencias(object key, Collection<object> list)
        {
            // Convertir collection de object en coll int 
            //var keys = list.Select(k => (k as ClaveMes).Id);
            Collection<int> keyList = new Collection<int>();
            Dept km;

            foreach (var item in list)
            {
                km = (Dept)item;
                keyList.Add(km.Id);
            }

            ClaveMes cm = (ClaveMes)key;
            AsistenciaQuery asistQry = new AsistenciaQuery(cm.Id, keyList);

            ConsultarAsistencias(asistQry);
        }

        internal static void ConsultarAsistencias(int mes, int anno, Collection<object> list)
        {
            // Convertir collection de object en coll int  
            // WARN Codigo repetido.
            var keys = list.Select(k => (k as ClaveMes).Id);
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

        #endregion

        #region Métodos Privados

        

        private static void ConsultarAsistencias(AsistenciaQuery qry)
        {
            
            const string methodName = "ConsultarAsistencias";

            try
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Consultando Asistencias registradas.");

                AsistenciaQueryResult result = proxy.Handle(qry);

                CausaIncidencia nci = new CausaIncidencia();
                nci.Id = 0;
                nci.Description = string.Empty;
                //result.CausasIncidencias.Add(nci);
                result.CausasIncidencias.Insert(0, nci);
                /*
                // ***************************************
                // Departments
                //Department Empleado
                //Employee  Asistencia
                var matchingEmployees = from dept in Departments
                                        join emp in Employees on dept.DeptNo equals emp.DeptNo
                                        into AvailableEmployees
                                        select new { department = dept, employees = AvailableEmployees };

                //select new
                //{
                //    DeptNo = dept.DeptNo,
                //    employees = from emp in AvailableEmployees
                //               orderby emp.EmployeeNo
                //               select emp
                //};
                this.GroupEmployee = matchingEmployees.ToDictionary(x => x.department, y => y.employees);

                //dgvEmployees.DataSource = matchingEmployees.ToList();
                //bsEmployees.DataSource = matchingEmployees.ToList();
                bsDepartments.DataSource = GroupEmployee.Keys;
                // ****************************************
                */
                _editForm.bdsEmpleados.DataSource = result.Empleados;
                _editForm.bdsCausasIncidencia.DataSource = result.CausasIncidencias;

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Asistencias consultadas con exito.");
                
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
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
                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Consultando Departamento del usuario.");

                UserDepartamentQuery dptQry = new UserDepartamentQuery(_userID);
                UserDepartamentQueryResult dptQryRst = proxy.Handle(dptQry);

                _userDeptId = dptQryRst.Id;

                Log.WriteEntry(_className, methodName, TraceEventType.Information, "Departamento del usuario consultado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(_className, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        #endregion

        #endregion

    }
}
