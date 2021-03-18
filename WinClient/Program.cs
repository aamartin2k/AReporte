
#region Descripción
/*
 *  Inicio del Programa.
 *  
 *   Marcado para eliminar
 */
#endregion

#region Using

using AMGS.Application.Utils.Log;
using System;
using System.Windows.Forms;
using AReport.Client.Services;
#endregion

namespace AReport.Client
{
    static class Program
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
            ret = SystemService.TareasInicio();
            if (!ret)
                goto FinalError;

            // Cargar configuracion
            ret = SystemService.LeerConfiguracion();
            if (!ret)
                goto FinalError;

            // Intentar conexion
            ret = SystemService.ConectarServidor();
            if (!ret)
                goto FinalError;

            // DEBUG
            // Chequear arg de linea de comando para autologin
            if (args.Length > 0)
            {
                if (args[0].StartsWith("al"))
                {
                    ret = SystemService.RealizarAutoLogin(args[0]);

                    if (ret)
                        goto ApplicationRun;
                    else
                        goto FinalOK;
                }
            }


            // Ejecutar User Login RealizarLogin()
            ret = SystemService.RealizarLogin();
            if (!ret)
                goto FinalError;

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

            Application.Run(SystemService.MainForm);

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
