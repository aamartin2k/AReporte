#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios de sistema.
 *  
 *  Parcial Declaraciones
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
        #region Declaraciones

        static string _className;
        static string ClassName
        {
            get
            {
                if (_className == null)
                    _className = typeof(SystemService).Name;

                return _className;
            }
        }

        static IMessageHandler _proxy;
        static ZyanConnection _connection;

        const int _maxIntento = 4;
        static int _intentoLogin;

        // Valores leidos en configuracion
        static string _connString;

        // Valores necesarios para secuencia de inicio
        // Datos del usuario que inicia sesión
        static string _userName;
        static public string _userID;
        static UserRoleEnum _userRole;
        static int _userDeptId;
        static ClaveMes _fechaConsulta;



        // Referencia a BindingSources
        private static BindingSource bdsEmpleados;
        private static BindingSource bdsTodosEmpleados;
        private static BindingSource bdsSelectEmpleados;
        private static BindingSource bdsCausasIncidencia;
        private static BindingSource bdsAsistencias;
        private static BindingSource bdsSelectDepartamentosIncid;
        private static BindingSource bdsTodosDepartamentos;
        private static BindingSource bdsSelectDepartamentos;

        private static Collection<Incidencia> colIncidencias;
        #endregion
    }
}
