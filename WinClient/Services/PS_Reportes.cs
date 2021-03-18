#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios del programa.
 *  
 *  Parcial Gestión de Reportes. Implementa la generacion de reportes empleando componente externo.
*/
#endregion

#region Using

using AMGS.Application.Utils.Log;
using AReport.Client.Reports;
using AReport.Support.Common;
using AReport.Support.Entity;
using FastReport;
using FastReport.Export.PdfSimple;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

#endregion

namespace AReport.Client.Services
{
   
    internal static partial class SystemService
    {
        // State object para pasar informacion a async worker.
        private class reportInfo
        {
            public List<Empleado> DataSet;
            public string DataSetName;
            public object Parameter;
            public string ParameterName;
            public string ReportLoadPath;
            public string PdfReportPath;
            public string ReportAsString;
        }

        // Delegate para invocación asíncrona de la generacion del reporte.
        delegate bool ReporteOnTaskDelegate(object info);

        #region Metodos Públicos (Internal)

        internal static void GenerarReporte()
        {
            const string methodName = "GenerarReporte";
            Collection<Empleado> colEmpleados;
            List<Empleado> colEmp;
            reportInfo rptInfoStateObj;

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Generar Reporte.");

                EsperaPorTarea(TipoEspera.Reporte);

                colEmpleados = bdsTodosEmpleados.DataSource as Collection<Empleado>;
                colEmp = new List<Empleado>(colEmpleados);

                rptInfoStateObj = new reportInfo();

                rptInfoStateObj.DataSet = colEmp;
                rptInfoStateObj.DataSetName = "Empleados";
                rptInfoStateObj.Parameter = _fechaConsulta.TextoNombreMesReporte;
                rptInfoStateObj.ParameterName = "parNombreMesAnno";
                rptInfoStateObj.ReportAsString = myReport.ReportAsString;
                const string rptPath = "Reports\\";
                rptInfoStateObj.ReportLoadPath = rptPath + "report.frx";

                if(_userRole == UserRoleEnum.JefeDepartamento)
                    //rptInfoStateObj.PdfReportPath = rptPath + "reporte_" + _userDeptName + "_" + rptInfoStateObj.Parameter + ".pdf";
                    rptInfoStateObj.PdfReportPath = string.Format("{0}reporte_{1}_{2}.pdf", rptPath, _userDeptName, rptInfoStateObj.Parameter);
                else
                    //rptInfoStateObj.PdfReportPath = rptPath + "reporte_" + rptInfoStateObj.Parameter + ".pdf";
                    rptInfoStateObj.PdfReportPath = string.Format("{0}reporte_{1}.pdf", rptPath, rptInfoStateObj.Parameter);


                ReporteOnTaskDelegate rtd = GenerarReporteOnTask;

                rtd.BeginInvoke(rptInfoStateObj, ReporteOnTaskCompleted, rtd);

            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
            }
            finally
            {
                colEmpleados = null;
                colEmp = null;
                rptInfoStateObj = null;
            }
        }

        #endregion

        #region Metodos Privados
        // Callback asíncrono.
        private static void ReporteOnTaskCompleted(IAsyncResult ar)
        {
            ReporteOnTaskDelegate rtd = ar.AsyncState as ReporteOnTaskDelegate;

            bool ret = rtd.EndInvoke(ar);

            if (ret)
                FinEsperaPorTarea(TipoEspera.Reporte);
            else
                FinEsperaPorTarea(TipoEspera.ReporteError);
        }

        // Worker asíncrono. Genera el reporte en otro hilo. 
        private static bool GenerarReporteOnTask(object info)
        {
            const string methodName = "GenerarReporteOnTask";
            Report report;
            PDFSimpleExport pdfExport;
            reportInfo rInfo = (reportInfo)info;

            try
            {
                // Crear instancia del componente reporte.
                report = new Report();

                // Cargar definicion de reporte. Permite alternar entre archivo FRX en carpet \Reports
                // y definicion de reporte contenida en string en clase auxiliar
                //report.Load(rInfo.ReportLoadPath);
                report.LoadFromString(rInfo.ReportAsString);

                // Pasar datos.
                report.RegisterData(rInfo.DataSet, rInfo.DataSetName);
                // Pasar parametros
                report.SetParameterValue(rInfo.ParameterName, rInfo.Parameter);

                bool ret = report.Prepare();

                if (ret)
                {
                    pdfExport = new PDFSimpleExport();
                    pdfExport.Export(report, rInfo.PdfReportPath);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
            finally
            {
                report = null;
                rInfo = null;
                pdfExport = null;
            }
        }

        #endregion

    }

}
