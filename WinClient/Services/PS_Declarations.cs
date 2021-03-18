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

using AReport.Client.Forms;
using AReport.Support.Common;
using AReport.Support.Entity;
using AReport.Support.Interface;
using AReport.Support.Query;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Zyan.Communication;

#endregion

namespace AReport.Client.Services
{
    internal static partial class SystemService
    {
        #region Declaraciones

        private static string _className;
        private static string ClassName
        {
            get
            {
                if (_className == null)
                    _className = typeof(SystemService).Name;

                return _className;
            }
        }

        private static IMessageHandler _proxy;
        private static ZyanConnection _connection;

        //const int _maxIntento = 4;
        //private static int _intentoLogin;

        // Valores leidos en configuracion
        private static string _connString;

        // Valores necesarios para secuencia de inicio
        // Datos del usuario que inicia sesión
        private static string _userName;
        private static string _userID;
        private static UserRoleEnum _userRole;
        private static int _userDeptId;
        private static string _userDeptName;
        private static ClaveMes _fechaConsulta;
        private static AsistenciaQuery _consulta;

        // Referencia a formularios
        private static FormClient _editForm;
        private static FormAsigIncidencia _incidAsignForm;
        private static FormUsuarios _usuariosForm;

        // Referencia a BindingSources
        //  // Para rol JefeGrupo
        private static BindingSource bdsEmpleados;
        // Para rol Supervisor
        private static BindingSource bdsTodosEmpleados;
        private static BindingSource bdsSelectEmpleados;
        private static BindingSource bdsCausasIncidencia;
        private static BindingSource bdsAsistencias;
        private static BindingSource bdsSelectDepartamentosIncid;
        private static BindingSource bdsTodosDepartamentos;
        private static BindingSource bdsSelectDepartamentos;
        // Para rol Administrador
        private static BindingSource bdsUsuarios;
        private static BindingSource bdsUserinfo;
        private static BindingSource bdsUserRoles;
        private static BindingSource bdsJefes;

        private static Collection<Usuario> colUsuarios;
        private static Collection<JefeDept> colJefes;

        // Utiliza bdsTodosDepartamentos 


        private static Collection<Incidencia> colIncidencias;

        #endregion
    }
}
