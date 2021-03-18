#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios de sistema.
 *  
 *  Parcial <>
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
        public static void In_LoginCommand(CommandStatus status)
        {
            if (AutoLogin)
                Continue_AutoLogin(status);
            else
                Continue_Login(status);
        }


        private static void Continue_AutoLogin(CommandStatus status)
        {
            const string methodName = "Continue_AutoLogin";

            bool Success = status.GetType() == typeof(Success);

            if (Success)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Auto Login exitoso para usuario: {0}", _userName));
                // Login Positivo, continuar secuencia
                _intentoLogin = _maxIntento;

                // DeBUG
                Console.WriteLine(string.Format("Auto Login exitoso para usuario: {0}", _userName));
                Continue_PostAutoLogin();
            }
            else
            {
                // Fin de secuencia Auto Logi
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Auto Login fallido para usuario: {0}", _userName));
            }
        }

        private static void Continue_Login(CommandStatus status)
        {
            const string methodName = "Continue_Login";

            bool Success = status.GetType() == typeof(Success);

            if (Success)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Login exitoso para usuario: {0}", _userName));
                // Login Positivo, continuar secuencia
                _intentoLogin = _maxIntento;

                // DeBUG
                Console.WriteLine(string.Format("Login exitoso para usuario: {0}", _userName));
                Continue_PostLogin();
            }
            else
            {
                // disminuir intentos
                _intentoLogin--;
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Login fallido para usuario: {0}", _userName));

                if (_intentoLogin > 0)
                {
                    // repetir secuencia login
                    RealizarNuevoLogin();
                }
                else
                {
                    Log.WriteEntry(ClassName, methodName, TraceEventType.Information, string.Format("Agotados los intentos de login para usuario: {0}", _userName));
                    // agotados los intentos, terminar secuencia login
                }
            }
        }

        private static void Continue_PostLogin()
        {

        }

        private static void Continue_PostAutoLogin()
        {

        }
    }

}