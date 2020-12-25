
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
        // Componentes de DataGridView
        private DataGridViewCellStyle dataGridViewCellStyle3, dataGridViewCellStyle4;
        private DataGridViewTextBoxColumn fechaTextBoxColumn;
        private DataGridViewTextBoxColumn diaSemanaTextBoxColumn;
        private DataGridViewTextBoxColumn chekinTimeTextBoxColumn;
        private DataGridViewTextBoxColumn chekoutTimeTextBoxColumn;
        //internal DataGridViewComboBoxColumn incidCausaIncidenciaComboBoxColumn;
        private DataGridViewTextBoxColumn incidCausaIncidenciaComboBoxColumn;
        private DataGridViewTextBoxColumn incidObservacionTextBoxColumn;

        // Control de Cambios pendientes
        private bool cambiosPendientes;

        #endregion

        public FormClient()
        {
            InitializeComponent();
        }

        #region Configurar Editor

        // Navegacion entre Tabs
        private enum TabNavigationStatus { Consulta, Resultados, Administracion }
        private void  TabNavigationMode(TabNavigationStatus mode)
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

            ConfigurarDataGridView();

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

        private void ConfigurarDataGridView()
        {
            // Creación
            dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle4 = new DataGridViewCellStyle();
            
            fechaTextBoxColumn = new DataGridViewTextBoxColumn();
            diaSemanaTextBoxColumn = new DataGridViewTextBoxColumn();
            chekinTimeTextBoxColumn = new DataGridViewTextBoxColumn();
            chekoutTimeTextBoxColumn = new DataGridViewTextBoxColumn();
            // Remplazar columna combo por textoo 
            //incidCausaIncidenciaComboBoxColumn = new DataGridViewComboBoxColumn();
            incidCausaIncidenciaComboBoxColumn = new DataGridViewTextBoxColumn();

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
                incidCausaIncidenciaComboBoxColumn,
                incidObservacionTextBoxColumn});

            // fechaTextBoxColumn
            fechaTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            fechaTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            fechaTextBoxColumn.HeaderText = "Fecha";
            fechaTextBoxColumn.ReadOnly = true;
            // 
            // diaSemanaTextBoxColumn 
            diaSemanaTextBoxColumn.DataPropertyName = "DiaSemana";
            
            diaSemanaTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            diaSemanaTextBoxColumn.HeaderText = "Dia";
            diaSemanaTextBoxColumn.ReadOnly = true;
            // 
            // chekinTimeTextBoxColumn
            chekinTimeTextBoxColumn.DataPropertyName = "ChekinTime";
            chekinTimeTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            chekinTimeTextBoxColumn.HeaderText = "Entrada";
            chekinTimeTextBoxColumn.ReadOnly = true;
            // 
            // chekoutTimeTextBoxColumn
            chekoutTimeTextBoxColumn.DataPropertyName = "ChekoutTime";
            chekoutTimeTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            chekoutTimeTextBoxColumn.HeaderText = "Salida";
            chekoutTimeTextBoxColumn.ReadOnly = true;
            // 
            // incidCausaIncidenciaComboBoxColumn
            //incidCausaIncidenciaComboBoxColumn.DataPropertyName = "IncidenciaCausaIncidencia";
            incidCausaIncidenciaComboBoxColumn.DataPropertyName = "IncidenciaCausaDesc";
            incidCausaIncidenciaComboBoxColumn.HeaderText = "Incidencia";
            //incidCausaIncidenciaComboBoxColumn.MaxDropDownItems = 9;
            //incidCausaIncidenciaComboBoxColumn.Resizable = DataGridViewTriState.True;
            //incidCausaIncidenciaComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            incidCausaIncidenciaComboBoxColumn.ReadOnly = true;
            // 
            // incidObservacionTextBoxColumn 
            incidObservacionTextBoxColumn.DataPropertyName = "IncidenciaObservacion";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            incidObservacionTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
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
            lbSelDepart.Visible = false;
            chlbSelDepart.Visible = false;
            cmbDepartamentos.Visible = false;
            btGrupo.Visible = false;

            // Mostrar tabControl page Consulta y ocultar las demas.
            TabNavigationMode(TabNavigationStatus.Consulta);


            ConfigurarConstante();
        }

        private void ConfigurarModoSupervisor()
        {
            lbSelDepart.Visible = true;
            chlbSelDepart.Visible = true;
            cmbDepartamentos.Visible = true;
            btGrupo.Visible = true;

            // Mostrar tabControl page Consulta y ocultar las demas.
            TabNavigationMode(TabNavigationStatus.Consulta);

            ConfigurarConstante();
        }

        private void ConfigurarModoAdministrador()
        {
            // Mostrar tabControl page Consulta y ocultar las demas.
            TabNavigationMode(TabNavigationStatus.Administracion);
        }

        #endregion

        #region Controladores de Eventos de Formulario

        private void btRegresarConsulta_Click(object sender, EventArgs e)
        {
            if (ChequeoCambios())
            {
                TabNavigationMode(TabNavigationStatus.Consulta);
            }
        }

        private void btTerminar_Click(object sender, EventArgs e)
        {

            ChequeoCambios();
        }

        private void btReporte_Click(object sender, EventArgs e)
        {
            ChequeoCambios();
            SystemService.MostrarReporte();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            SystemService.ActualizarAsistencias();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (!ExistsSelectionInGrid())
                return;

            SystemService.EliminarIncidencia();
            cambiosPendientes = true;
        }

        private void btGrupo_Click(object sender, EventArgs e)
        {
            if (!ExistsSelectionInGrid())
                return;

            SystemService.AsignarIncidenciaGrupo();
            cambiosPendientes = true;
        }

        private void btAsignar_Click(object sender, EventArgs e)
        {
            // comprobar que hay rows seleccionadas
            if (!ExistsSelectionInGrid())
                return;

            // llamada a Sys serv y mostrar dialogo
            SystemService.AsignarIncidencia();

            cambiosPendientes = true;
        }


        private void btConsultar_Click(object sender, System.EventArgs e)
        {
            bool ret = false;

            // Indicar espera con puntero
            tslbInfo.Text = "Esperando resultado de consulta...";
            Application.UseWaitCursor = true;
    
            Application.DoEvents();


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

            if (ret)
            {
                // Indicar fin espera con puntero
                tslbInfo.Text = "Resultados de consulta recibidos.";
                Application.UseWaitCursor = false;

                Application.DoEvents();

                // mostrar tab resultados
                TabNavigationMode(TabNavigationStatus.Resultados);
            }
            else
            {
                UseWaitCursor = false;
                tslbInfo.Text = "No se ha realizado la consulta.";
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

        #endregion

       


        #region Metodos privados

        private bool ExistsSelectionInGrid()
        {
            if (dgvAsistencia.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debe seleccionar al menos una fila.", "Asignar incidencias.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (cambiosPendientes)
            {
                string warning = "Existen cambios sin guardar que pueden perderse. Seguro desea continuar?";
                var ret = MessageBox.Show(warning, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                return ret == DialogResult.Yes;
            }

            return true;
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
