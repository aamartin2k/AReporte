#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios del programa.
 *  
 *  Parcial Gestion de Esperas. 
 *  
 *  Implementa funciones para entretener al usuario mientras se realizan operaciones largas.
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
        private const string msgEsperaConsulta = "Esperando resultado de consulta...";
        private const string msgResultConsulta = "Resultados de consulta recibidos.";

        private const string msgEsperaActualizacion = "Esperando resultado de actualización...";
        private const string msgResultActualizacionOK = "Actualización terminada con éxito.";
        private const string msgResultActualizacionError = "Actualización terminada con error.";

        private const string msgEsperaReporte = "Esperando resultado de reporte...";
        private const string msgResultReporteOK = "Reporte terminado con éxito.";
        private const string msgResultReporteError = "Reporte terminado con error.";

        private enum TipoEspera { Consulta, Actualizacion, ActualizacionError, Reporte, ReporteError }

        private static void EsperaPorTarea(TipoEspera tipo)
        {
            string msg = null;

            switch (tipo)
            {
                case TipoEspera.Consulta:
                    msg = msgEsperaConsulta;
                    break;
                case TipoEspera.Actualizacion:
                    msg = msgEsperaActualizacion;
                    break;
                case TipoEspera.Reporte:
                    msg = msgEsperaReporte;
                    break;
                case TipoEspera.ReporteError:
                case TipoEspera.ActualizacionError:
                default:
                    break;
            }

            // Indicar espera con puntero Wait
            _editForm.tslbInfo.Text = msg;
            Application.UseWaitCursor = true;
            Application.DoEvents();
        }

        private static void FinEsperaPorTarea(TipoEspera tipo)
        {
            string msg = null;

            switch (tipo)
            {
                case TipoEspera.Consulta:
                    msg = msgResultConsulta;
                     break;
                case TipoEspera.Actualizacion:
                    msg = msgResultActualizacionOK;
                     break;
                case TipoEspera.ActualizacionError:
                    msg = msgResultActualizacionError;
                    break;
                case TipoEspera.Reporte:
                    msg = msgResultReporteOK;
                     break;
                case TipoEspera.ReporteError:
                    msg = msgResultReporteError;
                    break;
                default:
                    break;
            }

            // Indicar fin de espera con puntero normal
            _editForm.tslbInfo.Text = msg;
            Application.UseWaitCursor = false;
            Application.DoEvents();
        }
    }
}
