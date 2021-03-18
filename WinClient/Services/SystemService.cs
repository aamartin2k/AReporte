
#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios de sistema.
*/
#endregion

#region Using

using AMGS.Application.Utils.Log;
using AReport.Support.Command;
using AReport.Support.Query;
using AReport.Client.Forms;
using System;
using System.Diagnostics;

#endregion

namespace AReport.Client.Services
{
    internal static partial class SystemService
    {

        #region Propiedades

        #region Propiedades Públicas




        #endregion

        #region Propiedades Privadas
        /// <summary>
        /// Referencia al formulario principal.
        /// </summary>
        private static FormClient MainForm
        {
            get { return _editForm; }
        }
        #endregion

        #endregion

        #region Métodos

        #region Métodos Públicos

        #endregion

        #region Métodos Privados

        #region Tareas de Depuracion
        private static bool RealizarAutoLogin(string arg)
        {
            const string methodName = "RealizarAutoLogin";

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

            if (arg == "aladm")
            {
                login = "Admin";
                password = "Admin";
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

        #endregion

        #endregion

        #endregion

    }
}
