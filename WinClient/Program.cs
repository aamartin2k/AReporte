
#region Descripción
/*
 *  Inicio del Programa.
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
        // Declaraciones
        const string _className = "Program";
       

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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
