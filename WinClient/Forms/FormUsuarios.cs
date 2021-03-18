using AReport.Support.Entity;
using System;
using AReport.Client.Services;
using System.Windows.Forms;

namespace AReport.Client.Forms
{
    public partial class FormUsuarios : Form
    {

        // Cancelar cierre dialogo en caso de fallo validacion
        private bool CancelarSalida ;

        public FormUsuarios()
        {
            InitializeComponent();
        }

        // Modo de operacion
        private enum ModoOperacion { Creacion, Edicion}

        private ModoOperacion _modo;

        internal void ConfigurarSegunModo(Usuario data)
        {
            if (data == null)
            {
                _modo = ModoOperacion.Creacion;
                ConfigurarCrearNuevo();
            }
            else
            {
                _modo = ModoOperacion.Edicion;
                ConfigurarEditar(data);
            }
        }

        private void ConfigurarCrearNuevo()
        {
            // eliminar valores o selecciones
            cmbNombreUsuario.Text = null;
            cmbRolUsuario.Text = null;
            tbCuentaUsuario.Text = null;
            tbClaveUsuario.Text = null;
            tbClaveUsuarioConfirm.Text = null;
        }

        private void ConfigurarEditar(Usuario data)
        {
            cmbNombreUsuario.Text = data.Nombre;
            cmbNombreUsuario.SelectedValue = data.UserId;

            cmbRolUsuario.SelectedValue = data.RoleId;
            tbCuentaUsuario.Text = data.Login;

            tbClaveUsuario.Text = null;
            tbClaveUsuarioConfirm.Text = null;
        }


        private bool ValidarSegunModo()
        {
            bool ret;

            switch (_modo)
            {
                case ModoOperacion.Creacion:
                    ret = ValidarCrearNuevo();
                    break;

                case ModoOperacion.Edicion:
                default:
                    ret = ValidarEditar();
                    break;
            }
            return ret;
        }

        private bool ValidarCrearNuevo()
        {
            // Se requiere un rol
            if (cmbRolUsuario.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un rol.");
                cmbRolUsuario.Focus();
                return false;
            }

            // roles 1 y 2 requieren nombre de usuario
            int rol = (int) cmbRolUsuario.SelectedValue;
            if (rol == 1 || rol == 2)
            {
                if (cmbNombreUsuario.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un nombre de usuario.");
                    cmbNombreUsuario.Focus();
                    return false;
                }
            }

            // se requiere login
            if (string.IsNullOrEmpty(tbCuentaUsuario.Text))
            {
                MessageBox.Show("Debe escribir un nombre para la cuenta.");
                tbCuentaUsuario.Focus();
                return false;
            }

            // login debe ser unico
            if (SystemService.LoginExiste(tbCuentaUsuario.Text))
            {
                MessageBox.Show("La cuenta de usuario debe ser única.");
                tbCuentaUsuario.Focus();
                return false;
            }

            // se requiere claves
            if (string.IsNullOrEmpty(tbClaveUsuario.Text ))
            {
                MessageBox.Show("Debe escribir una clave.");
                tbClaveUsuario.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbClaveUsuarioConfirm.Text))
            {
                MessageBox.Show("Debe escribir la confirmación de la clave.");
                tbClaveUsuarioConfirm.Focus();
                return false;
            }


            // claves deben coincidir
            if (!string.Equals(tbClaveUsuario.Text, tbClaveUsuarioConfirm.Text))
            {
                MessageBox.Show("Las claves deben coincidir.");
                tbClaveUsuarioConfirm.Focus();
                return false;
            }

             return true;
        }

        private bool ValidarEditar()
        {
            return true;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            //if (ValidarSegunModo())
            if (ValidarCrearNuevo())
            {
                CancelarSalida = false;
            }
            else
                CancelarSalida = true;
        }

        private void FormUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelarSalida;
        }
    }
}
