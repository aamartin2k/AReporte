#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios del programa.
 *  
 *  Parcial Lectura de datos para rol de Supervisor de RH HH
*/
#endregion

#region Using

using AMGS.Application.Utils.Log;
using AReport.Support.Query;
using System;
using System.Diagnostics;

#endregion

namespace AReport.Client.Services
{
    internal static partial class SystemService
    {

        #region Metodos Públicos (Internal)

        #endregion

        #region Metodos Privados
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

        private static bool ConsultarListaDepart()
        {
            const string methodName = "ConsultarListaDepart";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Lista de departamentos.");

                DepartamentQuery dptQry = new DepartamentQuery();
                DepartamentQueryResult dptQryRst = _proxy.Handle(dptQry);

                _editForm.chlbSelDepart.Items.Clear();

                if (dptQryRst.Coleccion.Count > 0)
                {
                    _editForm.chlbSelDepart.DataSource = dptQryRst.Coleccion;
                    bdsTodosDepartamentos.DataSource = dptQryRst.Coleccion;
                }

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Lista de Departamentos consultada con exito.");
                return true;
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