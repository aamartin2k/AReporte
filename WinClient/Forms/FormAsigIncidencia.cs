using AReport.Client.Services;
using AReport.Support.Common;
using System.Windows.Forms;

namespace AReport.Client.Forms
{
    public partial class FormAsigIncidencia : Form
    {
        public FormAsigIncidencia()
        {
            InitializeComponent();
        }

        private UserRoleEnum _editMode;
        internal UserRoleEnum EditMode
        {
            private get { return _editMode; }
            set
            {
                ConfigurarSegunModo(value);
                _editMode = value;
            }
        }



        private void ConfigurarSegunModo(UserRoleEnum mode)
        {
            

            switch (mode)
            {
                case UserRoleEnum.JefeDepartamento:
                    ConfigurarModoJefeGrupo();
                    break;

                case UserRoleEnum.Supervisor:
                    ConfigurarModoSupervisor();
                    break;

                case UserRoleEnum.Administrador:
                default:
                    //
                    //ConfigurarModoAdministrador();
                    break;
            }

            ConfigurarConstante();
        }

        private void ConfigurarModoJefeGrupo()
        {
            this.Text = "Asignar incidencia a empleado.";
            grpBoxDepartamento.Visible = false;
            grpBoxUsuario.Visible = false;

            btOk.Top = grpBoxDepartamento.Top + btOk.Margin.Vertical ;
            btCancel.Top = btOk.Top;

            this.Height = btOk.Top + btOk.Height + btOk.Margin.Vertical + 60; 
        }

        private void ConfigurarModoSupervisor()
        {
            this.Text = "Asignar incidencia a grupo de empleados.";
            grpBoxDepartamento.Visible = true;
            grpBoxUsuario.Visible = true;

            btOk.Top = 360;
            btCancel.Top = btOk.Top;

            this.Height = 460;

            SetItemState(chlbSelDepartIncid, false, true);
        }

        private void ConfigurarConstante()
        {
            // Eliminar seleccion anterior
            tbObserv.Text = string.Empty;
            cmbCausas.SelectedIndex = 0;

        }


        private void chlbSelDepart_MouseUp(object sender, MouseEventArgs e)
        {
            if (ItemChanged)
            {
                SystemService.ConfigSelectEmpleados();
                ItemChanged = false;
            }
        }

        private bool ItemChanged = false;

        private void chlbSelDepart_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ItemChanged = true;
        }


        private void btCheckAllDepts_Click(object sender, System.EventArgs e)
        {
            
            SetItemState(chlbSelDepartIncid, true, true);
        }

        private void btUncheckAllDepts_Click(object sender, System.EventArgs e)
        {
            
            SetItemState(chlbSelDepartIncid, false, true);
        }

        private void SetItemState(CheckedListBox list, bool state, bool update)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, state);
            }

            if (update)
                SystemService.ConfigSelectEmpleados();
        }

        private void btCheckAllEmps_Click(object sender, System.EventArgs e)
        {
            SetItemState(chlbSelEmpleado, true, false);
        }

        private void btUncheckAllEmps_Click(object sender, System.EventArgs e)
        {
            SetItemState(chlbSelEmpleado, false, false);
        }

        private void btOk_Click(object sender, System.EventArgs e)
        {
            if (_editMode == UserRoleEnum.Supervisor)
            {
                string warning = "La operación que va a realizar no se puede deshacer en una única operación.\n" +
                                  "En caso de error deberá eliminar la incidencia en cada uno de los registros editados.\n" +
                                  "Recomendamos que revise bien los datos.\n\n" +
                                  "¿Desea continuar con la operación ? ";
                // Mostrar advertencia
                var ret = MessageBox.Show(warning, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (ret == DialogResult.Yes)
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;

            }
        }
    }
}
