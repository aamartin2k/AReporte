#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios de sistema.
 *  
 *  Parcial Main
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
        static void Main(string[] args)
        {
            // Declaraciones
            bool ret;

            // Secuencia de Inicio

            //Log
            Log.WriteStart();


            // Ejecutar tareas de inicio
            ret = TareasInicio();
            if (!ret)
                goto FinalError;

            // Cargar configuracion
            ret = SystemService.LeerConfiguracion();
            if (!ret)
                goto FinalError;

            // Intentar conexion
            ret = SystemService.ConectarNuevoServidor();
            if (!ret)
                goto FinalError;

            // DEBUG
            // Chequear arg de linea de comando para autologin
            if (args.Length > 0)
            {

                if (args[0].StartsWith("al"))
                {
                    // Iniciar secuencia de auto login;
                    SystemService.IniciarNuevoAutoLogin(args[0]);

                    if (ret)
                        goto ApplicationRun;
                    else
                        goto FinalOK;
                }
            }

            // Iniciar secuencia de login de usuario;
            ret = SystemService.IniciarNuevoLogin();
            if (!ret)
                goto FinalError;
            else
                goto ApplicationRun;

            // La nueva secuencia de ejecucion termina aqui, las llamadas a comandos en el servidor
            // retornan asincronamente a otros procedimientos.
            // RealizarNuevoLogin retorna unicamente por la via de FALSE si el usuario cancela, se agotan
            // los intentos o se produce una exception.

            // Consultar User Role para configurar form de acuerdo
            ret = SystemService.ConsultarRol();
            if (!ret)
                goto FinalError;

            // 
            // Configurar Form
            ret = SystemService.ConfigurarMainForm();
            if (!ret)
                goto FinalError;

            // Leer datos de inicio
            ret = SystemService.LeerDatosInicio();
            if (!ret)
                goto FinalError;

            ApplicationRun:

            // Ejecutar posibles pruebas

            // Parada de espera
            Console.WriteLine("Secuencia de inicio terminada. Presione ENTER para terminar...");
            Console.ReadLine();

            FinalOK:
            // Termino de la aplicacion sin ocurrir errores durante la ejecucion de Main 
            //  o termino normal por cierre de Mainform por usurio.

            SystemService.DesconectarServidor();

            // guardar config
            ret = SystemService.GuardarConfiguracion();
            if (!ret)
                goto FinalError;


            // realizar tareas de fin
            ret = SystemService.TareasFin();
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
    }
}
