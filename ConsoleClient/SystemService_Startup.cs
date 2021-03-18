#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios de sistema.
 *  
 *  Parcial Tareas de Inicio
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

#endregion

namespace ConsoleClient
{
    internal static partial class SystemService
    {
        #region Tareas de Inicio
        private static bool TareasInicio()
        {
            const string methodName = "TareasInicio";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Ejecutando Tareas de Inicio.");



                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Terminadas Tareas de Inicio.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        private static bool LeerConfiguracion()
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

        private static bool ConectarServidor()
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
        private static bool ConectarNuevoServidor()
        {
            const string methodName = "ConectarNuevoServidor";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Conectando con servidor.");

                var connection = new ZyanConnection(_connString);
                var service = connection.CreateProxy<IMessageHandler>();

                _connection = connection;
                _proxy = service;

                // Conectando input y output.
                // Las acciones de salida del form, a metodos del proxy, para su transmision remota al servidor.
                // Comandos
                Out_LoginCommand = Asynchronizer<LoginCommand>.WireUp(_proxy.In_LoginCommand);
                Out_AsistenciaUpdateCommand = Asynchronizer<AsistenciaUpdateCommand>.WireUp(_proxy.In_AsistenciaUpdateCommand);

                // Queries

                // La salida del servidor remoto, a controladores de solicitud del formulario.
                _proxy.Out_LoginCommandResult = SyncContextSwitcher<CommandStatus>.WireUp(In_LoginCommand);

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

        private static bool RealizarLogin()
        {
            const string methodName = "RealizarLogin";

            AutoLogin = false;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retorna unicamente por la via de FALSE si el usuario cancela, se agotan
        /// los intentos o se produce una exception.</returns>
        private static bool IniciarNuevoLogin()
        {
            _intentoLogin = _maxIntento;

            return RealizarNuevoLogin();
        }

        private static bool RealizarNuevoLogin()
        {
            const string methodName = "RealizarLogin";

            AutoLogin = false;

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Realizando login de usuario.");
                // mostrar login dialog
                LoginHandler _login = new LoginHandler();

                _login.PasswordChar = "x";
                _login.Title = "Inicio";
                _login.Mensaje = string.Empty;
                _login.Owner = null;

                if (_intentoLogin != _maxIntento)
                    _login.Mensaje = string.Format("{0} intentos restantes.", _intentoLogin);

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

                // Ejecutar accion de salida, la secuencia de ejecucion continua en In_LoginCommand.
                Out_LoginCommand(loginCmd);
                return true;
            }
            catch (Exception ex)
            {
                //Log
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        private static bool ConsultarRol()
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

        private static bool ConfigurarMainForm()
        {
            const string methodName = "ConfigurarMainForm";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Creando Formulario de Edicion.");

                switch (_userRole)
                {
                    case UserRoleEnum.JefeDepartamento:

                        ConfigBindSourcesJefeDepartamento();
                        break;

                    case UserRoleEnum.Supervisor:

                        ConfigBindSourcesJefeDepartamento();
                        ConfigBindSourcesSupervisor();
                        break;

                    case UserRoleEnum.Administrador:
                    default:

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

        private static bool LeerDatosInicio()
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
    }

}