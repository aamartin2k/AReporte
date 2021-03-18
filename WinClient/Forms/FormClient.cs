
#region Descripción
/*
 *   Formulario principal de la aplicación.
 */
#endregion

#region Using
using AReport.Client.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using AReport.Support.Common;
#endregion

namespace AReport.Client.Forms
{
   
    public partial class FormClient : Form
    {
        #region Declaraciones
        // Componentes de DataGridView Asistencias
        private DataGridViewCellStyle cellStyleAlignMiddleCenter, cellStyleAlignMiddleLeft;
        private DataGridViewTextBoxColumn fechaTextBoxColumn;
        private DataGridViewTextBoxColumn diaSemanaTextBoxColumn;
        private DataGridViewTextBoxColumn chekinTimeTextBoxColumn;
        private DataGridViewTextBoxColumn chekoutTimeTextBoxColumn;
        //internal DataGridViewComboBoxColumn incidCausaIncidenciaComboBoxColumn;
        private DataGridViewTextBoxColumn incidCausaIncidenciaTextBoxColumn;
        private DataGridViewTextBoxColumn incidObservacionTextBoxColumn;

        // Componentes de DataGridView Usuarios
        private DataGridViewTextBoxColumn loginTextBoxColumn;
        private DataGridViewTextBoxColumn passwordTextBoxColumn;
        private DataGridViewTextBoxColumn nombreTextBoxColumn;
        private DataGridViewTextBoxColumn rolTextBoxColumn;

        // Componentes de DataGridView Jefes
        private DataGridViewTextBoxColumn departTextBoxColumn;
        private DataGridViewTextBoxColumn jefeTextBoxColumn;

        // Control de Cambios pendientes
        private bool _cambiosPendientes;

        #endregion

        public FormClient()
        {
            InitializeComponent();
        }

        #region Configurar Editor

        #region Navegar entre Tabs
        // Navegacion entre Tabs de acuerdo a operacion.
        internal enum TabNavigationStatus { Consulta, Resultados, Administracion }
        internal void  TabNavigationMode(TabNavigationStatus mode)
        {
            switch (mode)
            {
                case TabNavigationStatus.Consulta:
                    TabNavConsulta();
                    break;

                case TabNavigationStatus.Resultados:
                    TabNavResultados();
                    break;

                case TabNavigationStatus.Administracion:
                    TabNavAdministracion();
                    break;

                default:
                    break;
            }
        }

        private void TabNavConsulta()
        {
            // ocultar
            if (tbcControl.Controls.Contains(tbpResultados))
                tbcControl.Controls.Remove(tbpResultados);

            if (tbcControl.Controls.Contains(tbpAdmin))
                tbcControl.Controls.Remove(tbpAdmin);

            // mostrar
            if (!tbcControl.Controls.Contains(tbpConsulta))
                tbcControl.Controls.Add(tbpConsulta);

            tbcControl.SelectTab(tbpConsulta);
        }

        private void TabNavResultados()
        {
            // ocultar
            if (tbcControl.Controls.Contains(tbpConsulta))
                tbcControl.Controls.Remove(tbpConsulta);

            if (tbcControl.Controls.Contains(tbpAdmin))
                tbcControl.Controls.Remove(tbpAdmin);

            // mostrar
            if (!tbcControl.Controls.Contains(tbpResultados))
                tbcControl.Controls.Add(tbpResultados);

            tbcControl.SelectTab(tbpResultados);
        }

        private void TabNavAdministracion()
        {
            // ocultar
            if (tbcControl.Controls.Contains(tbpConsulta))
                tbcControl.Controls.Remove(tbpConsulta);

            if (tbcControl.Controls.Contains(tbpResultados))
                tbcControl.Controls.Remove(tbpResultados);

            // mostrar
            if (!tbcControl.Controls.Contains(tbpAdmin))
                tbcControl.Controls.Add(tbpAdmin);

            tbcControl.SelectTab(tbpAdmin);
        }

        #endregion

        #region Configurar controles
        // Configuracion de controles de acuerdo al modo de operacion, que depende
        // del rol del usuario.
        private UserRoleEnum _editMode;
        internal UserRoleEnum EditMode
        {
            private get { return _editMode;  }
            set
            {
                ConfigurarSegunModo(value);
                _editMode = value;
            }
        }
        
        private void ConfigurarSegunModo(UserRoleEnum mode)
        {
            string text;

            
            switch (mode)
            {
                case UserRoleEnum.JefeDepartamento:
                    text = "Modo Jefe Grupo";
                    ConfigurarModoJefeGrupo();
                    break;

                case UserRoleEnum.Supervisor:
                    text = "Modo Supervisor RR HH";
                    ConfigurarModoSupervisor();
                    break;

                case UserRoleEnum.Administrador:
                default:
                    text = "Modo Administrador";
                    ConfigurarModoAdministrador();
                    break;
            }

            tslbInfo.Text = text;
        }

        private void ConfigurarDataGridViewAsistencias()
        {
            // Creación
            cellStyleAlignMiddleCenter = new DataGridViewCellStyle();
            cellStyleAlignMiddleLeft = new DataGridViewCellStyle();
            
            fechaTextBoxColumn = new DataGridViewTextBoxColumn();
            diaSemanaTextBoxColumn = new DataGridViewTextBoxColumn();
            chekinTimeTextBoxColumn = new DataGridViewTextBoxColumn();
            chekoutTimeTextBoxColumn = new DataGridViewTextBoxColumn();
            // Remplazar columna combo por texto
            //incidCausaIncidenciaComboBoxColumn = new DataGridViewComboBoxColumn();
            incidCausaIncidenciaTextBoxColumn = new DataGridViewTextBoxColumn();

            incidObservacionTextBoxColumn = new DataGridViewTextBoxColumn();

            dgvAsistencia.AutoGenerateColumns = false;
            // permitir seleccionar una UNICA fila. Asi se asigna una incidencia a una única Fecha
            // aunque se asigne a varios empleados.
            dgvAsistencia.MultiSelect = false;

            dgvAsistencia.Columns.AddRange(new DataGridViewColumn[]
             {
                fechaTextBoxColumn,
                diaSemanaTextBoxColumn,
                chekinTimeTextBoxColumn,
                chekoutTimeTextBoxColumn,
                incidCausaIncidenciaTextBoxColumn,
                incidObservacionTextBoxColumn});

            // fechaTextBoxColumn
            fechaTextBoxColumn.DataPropertyName = "Fecha";
            cellStyleAlignMiddleCenter.Alignment = DataGridViewContentAlignment.MiddleCenter;
            fechaTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;
            fechaTextBoxColumn.HeaderText = "Fecha";
            fechaTextBoxColumn.ReadOnly = true;
            // 
            // diaSemanaTextBoxColumn 
            diaSemanaTextBoxColumn.DataPropertyName = "DiaSemana";
            
            diaSemanaTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;
            diaSemanaTextBoxColumn.HeaderText = "Dia";
            diaSemanaTextBoxColumn.ReadOnly = true;
            // 
            // chekinTimeTextBoxColumn
            chekinTimeTextBoxColumn.DataPropertyName = "ChekinTime";
            chekinTimeTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;
            chekinTimeTextBoxColumn.HeaderText = "Entrada";
            chekinTimeTextBoxColumn.ReadOnly = true;
            // 
            // chekoutTimeTextBoxColumn
            chekoutTimeTextBoxColumn.DataPropertyName = "ChekoutTime";
            chekoutTimeTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;
            chekoutTimeTextBoxColumn.HeaderText = "Salida";
            chekoutTimeTextBoxColumn.ReadOnly = true;
            // 
            // incidCausaIncidenciaComboBoxColumn
            //incidCausaIncidenciaComboBoxColumn.DataPropertyName = "IncidenciaCausaIncidencia";
            incidCausaIncidenciaTextBoxColumn.DataPropertyName = "IncidenciaCausaDesc";
            incidCausaIncidenciaTextBoxColumn.HeaderText = "Incidencia";
            //incidCausaIncidenciaComboBoxColumn.MaxDropDownItems = 9;
            //incidCausaIncidenciaComboBoxColumn.Resizable = DataGridViewTriState.True;
            //incidCausaIncidenciaComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            incidCausaIncidenciaTextBoxColumn.ReadOnly = true;
            // 
            // incidObservacionTextBoxColumn 
            incidObservacionTextBoxColumn.DataPropertyName = "IncidenciaObservacion";
            cellStyleAlignMiddleLeft.Alignment = DataGridViewContentAlignment.MiddleLeft;
            incidObservacionTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleLeft;
            incidObservacionTextBoxColumn.HeaderText = "Observación";
            incidObservacionTextBoxColumn.ReadOnly = true;

        }

        private void ConfigurarConstante()
        {
            // Configurar controles de introducir Mes y Año
            nupMes.Minimum = 1;
            nupMes.Maximum = 12;
            nupMes.Value = DateTime.Today.Month;


            nupAnno.Maximum = DateTime.Today.Year;
            nupAnno.Value = nupAnno.Maximum;
            //Hardcoded. Se limita a 5 años atras arbitrariamente.
            nupAnno.Minimum = nupAnno.Maximum - 5;

            HandleSelectClave(true);
        }

        private void ConfigurarModoJefeGrupo()
        {
        
            ConfigurarDataGridViewAsistencias();

            // Ubicar boton [Ejecutar consulta] en posicion Horizontal, debajo del GroupBox
            // correspondiente.
            btConsultar.Left = groupBoxMes.Left;
            // Ocultar GroupBox [Seleccionar Departamentos].  
            groupBoxDepart.Visible = false;
            // Ocultar ComboBox [Seleccionar Departamentos].
            cmbDepartamentos.Visible = false;
            // Ocultar boton [Asignar Incidencias a Grupo]
            btGrupo.Visible = false;

            // Mostrar tabControl page Consulta y ocultar las demas.
            TabNavigationMode(TabNavigationStatus.Consulta);


            ConfigurarConstante();
        }

        private void ConfigurarModoSupervisor()
        {
            ConfigurarDataGridViewAsistencias();

            btConsultar.Left = groupBoxDepart.Left;
            groupBoxDepart.Visible = true;

            cmbDepartamentos.Visible = true;
            btGrupo.Visible = true;

            TabNavigationMode(TabNavigationStatus.Consulta);

            ConfigurarConstante();
        }

        private void ConfigurarModoAdministrador()
        {
            ConfigurarDataGridViewAdministracion();

            // Mostrar tabControl page Consulta y ocultar las demas.
            TabNavigationMode(TabNavigationStatus.Administracion);
        }

        private void ConfigurarDataGridViewAdministracion()
        {
            // Configurar Grid Usuarios
            // Columnas Nombre, Rol, Login y Password
            loginTextBoxColumn = new DataGridViewTextBoxColumn();
            passwordTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreTextBoxColumn = new DataGridViewTextBoxColumn();
            rolTextBoxColumn = new DataGridViewTextBoxColumn();

            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.MultiSelect = false;

            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[]
                {
                    nombreTextBoxColumn,
                    rolTextBoxColumn,
                    loginTextBoxColumn,
                    passwordTextBoxColumn
                });

            // nombreTextBoxColumn
            nombreTextBoxColumn.DataPropertyName = "Nombre";
            nombreTextBoxColumn.HeaderText = "Nombre";
            nombreTextBoxColumn.ReadOnly = true;
            nombreTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;

            // rolComboBoxColumn
            rolTextBoxColumn.DataPropertyName = "RoleIdEnum";
            rolTextBoxColumn.HeaderText = "Rol";
            rolTextBoxColumn.ReadOnly = true;
            rolTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;

            // loginTextBoxColumn
            loginTextBoxColumn.DataPropertyName = "Login";
            loginTextBoxColumn.HeaderText = "Login";
            loginTextBoxColumn.ReadOnly = true;
            loginTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;

            // passwordTextBoxColumn
            passwordTextBoxColumn.DataPropertyName = "Password";
            passwordTextBoxColumn.HeaderText = "Password";
            
            passwordTextBoxColumn.ReadOnly = true;
            passwordTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;


            // Configurar Grid Jefes DEpartamentos
            // Columnas Departamento y Responsable texto
            departTextBoxColumn = new DataGridViewTextBoxColumn();
            jefeTextBoxColumn = new DataGridViewTextBoxColumn();

            dgvJefes.AutoGenerateColumns = false;
            dgvJefes.MultiSelect = false;

            dgvJefes.Columns.AddRange(new DataGridViewColumn[]
                {
                    departTextBoxColumn,
                    jefeTextBoxColumn
                });

            // departTextBoxColumn
            departTextBoxColumn.DataPropertyName = "DepartamentoNombre";
            departTextBoxColumn.HeaderText = "Departamento";
            departTextBoxColumn.ReadOnly = true;
            departTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;

            // jefeTextBoxColumn
            jefeTextBoxColumn.DataPropertyName = "UsuarioNombre";
            jefeTextBoxColumn.HeaderText = "Responsable";
            jefeTextBoxColumn.ReadOnly = true;
            jefeTextBoxColumn.DefaultCellStyle = cellStyleAlignMiddleCenter;
        }


        #endregion

        #endregion

        #region Controladores de Eventos de Formulario

        #region Usuarios
        private void btNuevoUsuario_Click(object sender, EventArgs e)
        {
            if (SystemService.CrearUsuario())
                SetCambiosPendientes();
        }

        private void btEditarUsuario_Click(object sender, EventArgs e)
        {
            if (SystemService.EditarUsuario())
                SetCambiosPendientes();
        }
        
        private void btGuardarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (!ExistsSelectionInGrid(dgvUsuarios, "Eliminar Usuario."))
                return;

            if (SystemService.EliminarUsuario())
                SetCambiosPendientes();
        }

        #endregion

        #region Directivos
        private void btNuevoJefe_Click(object sender, EventArgs e)
        {
            if (SystemService.CrearDirectivo())
                SetCambiosPendientes();
        }

       
        private void btEliminarJefe_Click(object sender, EventArgs e)
        {
            if (!ExistsSelectionInGrid(dgvJefes, "Eliminar Directivo."))
                return;

            if (SystemService.EliminarDirectivo())
                SetCambiosPendientes();
        }


        #endregion

        private void btRegresarConsulta_Click(object sender, EventArgs e)
        {
            if (ChequeoCambios())
            {
                TabNavigationMode(TabNavigationStatus.Consulta);
            }
        }

        private void btTerminar_Click(object sender, EventArgs e)
        {
            if (ChequeoCambios())
                this.Close();
        }

        private void btReporte_Click(object sender, EventArgs e)
        {
            if (ChequeoCambios())
                SystemService.GenerarReporte();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (SystemService.ActualizarAsistencias())
                ResetCambiosPendientes();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (!ExistsSelectionInGrid(dgvAsistencia, "Eliminar Incidencia."))
                return;

            if (SystemService.EliminarIncidencia())
                SetCambiosPendientes();
   
        }

        private void btGrupo_Click(object sender, EventArgs e)
        {
            if (!ExistsSelectionInGrid(dgvAsistencia, "Asignar Incidencia."))
                return;

            if (SystemService.AsignarIncidenciaGrupo())
                SetCambiosPendientes();
        }

        private void btAsignar_Click(object sender, EventArgs e)
        {
            // Comprobar que hay rows seleccionadas.
            if (!ExistsSelectionInGrid(dgvAsistencia, "Asignar Incidencia."))
                return;

            // Llamada a Sys serv y mostrar dialogo.
            if (SystemService.AsignarIncidencia())
                SetCambiosPendientes();
        }

        private void btConsultar_Click(object sender, System.EventArgs e)
        {
            bool ret = false;

            // Separar segun rol
            if (EditMode == UserRoleEnum.JefeDepartamento)
            {
                ret = ValidarDatosMesAnno();
                if (ret)
                    ConsultarJefeDepartamento();
            }

            if (EditMode == UserRoleEnum.Supervisor)
            {
                ret = ValidarDatosMesAnno();

                if (ret)
                {
                    ret = ValidarDatosDepartamento();

                    if (ret)
                        ConsultarSupervisor();
                }
            }
        }

        private void rbtIntrodClave_CheckedChanged(object sender, System.EventArgs e)
        {
            // Habilita los controles de introducir Mes y Año. Deshabilita el combo de seleccion
            HandleSelectClave(true);
        }

        private void rbtSelectClave_CheckedChanged(object sender, System.EventArgs e)
        {
            // Habilita el combo de seleccion. Deshabilita los controles de introducir Mes y Año.
            HandleSelectClave(false);
        }

        private void dgvAsistencia_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 4)
                e.Cancel = true; 
        }

        private void dgvAsistencia_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //detectar click derecho sobre columnas de Incidencia (idx = 4) y Observacion (idx = 5) 
            if ((e.Button == MouseButtons.Right) && (e.ColumnIndex == 4) | (e.ColumnIndex == 5))
                MessageBox.Show("Mouse Button Right on Incidencia/Obsr column,  row: " + e.RowIndex);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (tbcControl.SelectedTab == tbpResultados)
            {
                switch (keyData)
                {
                    case (Keys.Alt | Keys.Home):
                        bdnEmpleados.Items[0].PerformClick();
                        break;
                    case (Keys.Alt | Keys.End):
                        bdnEmpleados.Items[7].PerformClick();
                        break;
                    case (Keys.Alt | Keys.Left):
                        bdnEmpleados.Items[1].PerformClick();
                        break;
                    case (Keys.Alt | Keys.Right):
                        bdnEmpleados.Items[6].PerformClick();
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btCheckAllDepts_Click(object sender, EventArgs e)
        {
            SetItemState(chlbSelDepart, true);
        }

        private void btUncheckAllDepts_Click(object sender, EventArgs e)
        {
            SetItemState(chlbSelDepart, false);
        }

        #endregion

        #region Metodos privados


        private void SetCambiosPendientes()
        { _cambiosPendientes = true; }

        private void ResetCambiosPendientes()
        { _cambiosPendientes = false; }

        

        private bool ExistsSelectionInGrid(DataGridView list, string caption)
        {
            if (list.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debe seleccionar al menos una fila.", caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        private bool ValidarDatosMesAnno()
        {
            if (rbtIntrodClave.Checked)
            {
                Int32 mes, anno;

                mes = (int)nupMes.Value;
                anno = (int)nupAnno.Value;

                if (mes < 1 || mes > 12)
                {
                    MessageBox.Show("Valor incorrecto para el mes.");
                    return false;
                }

                //Hardcoded. Se limita a 5 años atras arbitrariamente.
                if (anno < (DateTime.Today.Year - 5) || anno > DateTime.Today.Year)
                {
                    MessageBox.Show("Valor incorrecto para el año.");
                    return false;
                }

                return true;
            }
            else
            {
                if (cmbSelMes.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un mes y año de la lista.");
                    return false;
                }

                return true;
            }
        }

        private void ConsultarJefeDepartamento()
        {
            // Verificar seleccion de usuario para realizar consulta.
            if (rbtIntrodClave.Checked)
            {
                // Leer valores de Mes y Año en controles, convertir a int32
                Int32 mes, anno;
                mes = (int)nupMes.Value;
                anno = (int)nupAnno.Value;

                SystemService.ConsultarAsistencias(mes, anno);
            }
            else
            {
                // Leer clave de Mes y Año en combo de seleccion
                object key = cmbSelMes.SelectedItem;

                SystemService.ConsultarAsistencias(key);
            }
        }

        private bool ValidarDatosDepartamento()
        {
            if (chlbSelDepart.CheckedItems.Count > 0)
                return true;

            MessageBox.Show("Debe seleccionar al menos un Departamento de la lista.");
            return false;
        }

        private void ConsultarSupervisor()
        {
            // Leer departamentos seleccionados
            Collection<object> list = new Collection<object>();

            foreach (var item in chlbSelDepart.CheckedItems)
            {   //TODO Probar asignar colecc a colecc
                list.Add(item);
            }

            // Verificar seleccion de usuario para realizar consulta.
            if (rbtIntrodClave.Checked)
            {
                // Leer valores de Mes y Año en controles, convertir a int32
                Int32 mes, anno;
                mes = (int)nupMes.Value;
                anno = (int)nupAnno.Value;

                SystemService.ConsultarAsistencias(mes, anno, list);
            }
            else
            {
                // Leer clave de Mes y Año en combo de seleccion
                object key = cmbSelMes.SelectedItem;

                SystemService.ConsultarAsistencias(key, list);
            }
        }

        private bool ChequeoCambios()
        {
            // Advertencia cambios
            if (_cambiosPendientes)
            {
                string warning = "Existen cambios sin guardar que pueden perderse. Seguro desea continuar?";
                var ret = MessageBox.Show(warning, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                return ret == DialogResult.Yes;
            }

            return true;
        }

        private void SetItemState(CheckedListBox list, bool state)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, state);
            }
        }

       

        private void HandleSelectClave(bool status)
        {
            // Para habilitar
            nupMes.Enabled = status;
            nupAnno.Enabled = status;

            // Para deshabilitar
            cmbSelMes.Enabled = !status;
        }

        #endregion

    }
}
