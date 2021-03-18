#region Descripción
/* 
 *  Soporte a las operaciones de usuario.
 * 
 *  Es el acceso de la capa de presentación a todos los servicios del programa.
 *  
 *  Parcial Lectura de datos para rol Administrador
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

        #region Metodos Públicos (Internal)

        internal static bool CrearUsuario()
        {
            const string methodName = "CrearUsuario";

            try
            {
                Usuario data = null;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Crear Usuario.");

                // Configurar Form Auxiliar
                _usuariosForm.ConfigurarSegunModo(data);

                //Mostrar Dialogo
                DialogResult ret = _usuariosForm.ShowDialog( _editForm);
                // Actualizar valores si no se cancela dialogo.
                if (ret != DialogResult.OK)
                    return false;

                // Crear nuevo entity
                data = new Usuario();
                data.State = EntityState.Added;

                // Actualizar propiedades
                data.Nombre = _usuariosForm.cmbNombreUsuario.Text;
                data.UserId = (string) _usuariosForm.cmbNombreUsuario.SelectedValue;
                data.RoleId = (int) _usuariosForm.cmbRolUsuario.SelectedValue;
                data.Login = _usuariosForm.tbCuentaUsuario.Text;
                data.Password = _usuariosForm.tbClaveUsuario.Text;

                // Refrescar datos en lista y bindingsource
                bdsUsuarios.List.Add(data);
                bdsUsuarios.ResetBindings(false);


                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Crear Usuario terminado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool LoginExiste(string login)
        {
            Collection<Usuario> users = (Collection<Usuario>)bdsUsuarios.List;
            var hit = users.Where(us => us.Login == login).FirstOrDefault();

            return (hit != null);
        }

        internal static bool EditarUsuario()
        {
            const string methodName = "EditarUsuario";

            try
            {
                Usuario data;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Editar Usuario.");

                foreach (DataGridViewRow row in _editForm.dgvUsuarios.SelectedRows)
                {
                    data = (Usuario)row.DataBoundItem;
                
                    // Configurar Form Auxiliar
                    _usuariosForm.ConfigurarSegunModo(data);

                    //Mostrar Dialogo
                    DialogResult ret = _usuariosForm.ShowDialog(_editForm);
                    // Actualizar valores si no se cancela dialogo.
                    if (ret != DialogResult.OK)
                        return false;

                    data.State = EntityState.Modified;
                 
                    // Actualizar propiedades
                    data.Nombre = _usuariosForm.cmbNombreUsuario.Text;
                    data.UserId = (string)_usuariosForm.cmbNombreUsuario.SelectedValue;
                    data.RoleId = (int)_usuariosForm.cmbRolUsuario.SelectedValue;
                    data.Login = _usuariosForm.tbCuentaUsuario.Text;
                    data.Password = _usuariosForm.tbClaveUsuario.Text;

                    // Refrescar datos en lista y bindingsource
                    bdsUsuarios.ResetBindings(false);

                }

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Editar Usuario terminado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }


        internal static bool EliminarUsuario()
        {
            const string methodName = "EliminarUsuario";

            try
            {
                Usuario data;
                
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Eliminar Usuario.");

                foreach (DataGridViewRow row in _editForm.dgvUsuarios.SelectedRows)
                {
                    data = (Usuario)row.DataBoundItem;

                    // Marcar para eliminar
                    data.State = EntityState.Deleted;

                    // Refrescar datos en lista.
                    colUsuarios.Add(data);
                    bdsUsuarios.Remove(data);
                    bdsUsuarios.ResetBindings(false);
                }

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Eliminar Usuario terminado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }



        internal static bool CrearDirectivo()
        {
            const string methodName = "CrearDirectivo";

            try
            {
                JefeDept data = null;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Crear Directivo.");

                // Configurar Form Auxiliar
                //_usuariosForm.ConfigurarSegunModo(data);

                //Mostrar Dialogo
                DialogResult ret = _usuariosForm.ShowDialog(_editForm);
                // Actualizar valores si no se cancela dialogo.
                if (ret != DialogResult.OK)
                    return false;

                // Crear nuevo entity
                data = new JefeDept();
                data.State = EntityState.Added;

                // Actualizar propiedades
                
                // Refrescar datos en lista.
                bdsUsuarios.Add(data);
                bdsUsuarios.ResetBindings(false);


                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Crear Directivo terminado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        internal static bool EliminarDirectivo()
        {
            const string methodName = "EliminarDirectivo";

            try
            {
                JefeDept data;
                
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Eliminar Directivo.");

                foreach (DataGridViewRow row in _editForm.dgvJefes.SelectedRows)
                {
                    data = (JefeDept)row.DataBoundItem;

                    // Marcar para eliminar
                    data.State = EntityState.Deleted;

                    // Refrescar datos en lista.
                    bdsJefes.Remove(data);
                    bdsJefes.ResetBindings(false);
                }

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Eliminar Directivo terminado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        #endregion

        #region Metodos Privados

        private static bool LeerDatosAdministrador()
        {
            bool ret;
            ret = ConsultarDatosAdministrador();

            return ret;
        }

        private static bool ConsultarDatosAdministrador()
        {
            const string methodName = "ConsultarDatosAdministrador";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando datos del rol Administrador.");

                AdministracionQuery qry = new AdministracionQuery();
                AdministracionQueryResult dptQryRst = _proxy.Handle(qry);

                // Hacer copia de colecciones editables
                // se actualiza la copia
                // los elementos eliminados por el usuario se eliminan del bindingSource
                //colUsuarios = dptQryRst.Usuarios;
                colUsuarios = new Collection<Usuario>();
                bdsUsuarios.DataSource = dptQryRst.Usuarios;

                colJefes = dptQryRst.JefesDept;
                bdsJefes.DataSource = dptQryRst.JefesDept;

                bdsUserRoles.DataSource = dptQryRst.Roles;
                bdsTodosDepartamentos.DataSource = dptQryRst.Departamentos;
                bdsUserinfo.DataSource = dptQryRst.Userinfo;

                // actualizando ref a datos en form Usuarios
                _usuariosForm.cmbNombreUsuario.DataSource = bdsUserinfo;
                _usuariosForm.cmbNombreUsuario.DisplayMember = "Nombre";
                _usuariosForm.cmbNombreUsuario.ValueMember = "Userid";

                _usuariosForm.cmbRolUsuario.DataSource = bdsUserRoles;
                _usuariosForm.cmbRolUsuario.DisplayMember = "Description";
                _usuariosForm.cmbRolUsuario.ValueMember = "Id";


                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Datos del rol Administrador consultado con exito.");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Error, string.Format("Error: {0}", ex.Message));
                return false;
            }
        }

        private static bool ConsultarDirectivos()
        {
            const string methodName = "ConsultarDirectivos";

            try
            {
                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Consultando Directivos.");

                UserDepartamentQuery dptQry = new UserDepartamentQuery(_userID);
                UserDepartamentQueryResult dptQryRst = _proxy.Handle(dptQry);

                _userDeptId = dptQryRst.Id;
                _userDeptName = dptQryRst.Name;

                Log.WriteEntry(ClassName, methodName, TraceEventType.Information, "Lista de directivos consultada con exito.");
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


