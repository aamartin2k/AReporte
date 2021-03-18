
#region Descripción
/* 
    *  Soporte a las operaciones de usuario.
    * 
    *  Es el acceso de la capa de presentación a todos los servicios del programa.
    *  
    *  Parcial Lectura de datos para rol Jefe de Grupo
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
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Departamento del usuario.");

                UserDepartamentQuery dptQry = new UserDepartamentQuery(_userID);
                UserDepartamentQueryResult dptQryRst = _proxy.Handle(dptQry);

                _userDeptId = dptQryRst.Id;
                _userDeptName = dptQryRst.Name;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Departamento del usuario consultado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        private static bool ConsultarClavesMes()
            {
                const string methodName = "ConsultarClavesMes";

                try
                {
                    Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Claves de Mes registradas.");

                    // consultar claves mes existentes
                    ClaveMesQuery cmQry = new ClaveMesQuery();
                    ClaveMesQueryResult cmQryRst = _proxy.Handle(cmQry);

                    // actualizar lista en cmbSelMes
                    _editForm.cmbSelMes.Items.Clear();

                    if (cmQryRst.Coleccion.Count > 0)
                    {
                        foreach (var mes in cmQryRst.Coleccion)
                        {
                            _editForm.cmbSelMes.Items.Add(mes);
                        }
                    }


                    Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Claves de Mes consultadas con exito.");
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

