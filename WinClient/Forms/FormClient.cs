
#region Descripción
/*
 *   Formulario principal de la aplicación.
 */
#endregion


//  revisar casos de uso
// mostrar y ocultar tabs desde consulta hasta resultados
// implemen crear/eliminar incidencias en grid y aplicar incidencias masivas

using AReport.Client.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using AReport.Support.Entity;
using System.Collections.Generic;
using System.Linq;
using AReport.Support.Common;

namespace AReport.Client.Forms
{
    //public enum FormClientMode { JefeGrupo, Supervisor, Administrador}

    public partial class FormClient : Form
    {
        // Componentes de DataGridView
        private DataGridViewCellStyle dataGridViewCellStyle3, dataGridViewCellStyle4;
        private DataGridViewTextBoxColumn fechaTextBoxColumn;
        private DataGridViewTextBoxColumn diaSemanaTextBoxColumn;
        private DataGridViewTextBoxColumn chekinTimeTextBoxColumn;
        private DataGridViewTextBoxColumn chekoutTimeTextBoxColumn;
        internal DataGridViewComboBoxColumn incidCausaIncidenciaComboBoxColumn;
        private DataGridViewTextBoxColumn incidObservacionTextBoxColumn;

        public FormClient()
        {
            InitializeComponent();
        }

        #region Configurar Editor

        private UserRoleEnum _editMode;
        internal UserRoleEnum EditMode
        {
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
            incidCausaIncidenciaComboBoxColumn = new DataGridViewComboBoxColumn();
            incidObservacionTextBoxColumn = new DataGridViewTextBoxColumn();

            dgvAsistencia.AutoGenerateColumns = false;

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
            incidCausaIncidenciaComboBoxColumn.DataPropertyName = "IncidenciaCausaIncidencia";
            incidCausaIncidenciaComboBoxColumn.HeaderText = "Incidencia";
            incidCausaIncidenciaComboBoxColumn.MaxDropDownItems = 9;
            incidCausaIncidenciaComboBoxColumn.Resizable = DataGridViewTriState.True;
            incidCausaIncidenciaComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
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

           
        }

        private void ConfigurarModoJefeGrupo()
        {
            lbSelDepart.Visible = false;
            chlbSelDepart.Visible = false;
            cmbDepartamentos.Visible = false;
            // Mostrar tabControl page Seleccion y ocultar las demas.
            tbcControl.Controls.Remove(tbpResultados);
            tbcControl.Controls.Remove(tbpAdmin);
        
            ConfigurarConstante();
        }

        private void ConfigurarModoSupervisor()
        {
            lbSelDepart.Visible = true;
            chlbSelDepart.Visible = true;
            cmbDepartamentos.Visible = true;

            // Mostrar tabControl page Seleccion y ocultar las demas.
            tbcControl.Controls.Remove(tbpResultados);
            tbcControl.Controls.Remove(tbpAdmin);

            ConfigurarConstante();
        }

        private void ConfigurarModoAdministrador()
        {
            tbcControl.Controls.Remove(tbpConsultaJGrupo);
            tbcControl.Controls.Remove(tbpResultados);
        }

        #endregion

        #region Controladores de Eventos de Formulario

        private void btAsignar_Click(object sender, EventArgs e)
        {
            // comprobar que hay rows seleccionadas
            if (dgvAsistencia.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debe seleccionar al menos una fila.", "Asignar incidencias.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // llamada a Sys serv y mostra dialogo
            SystemService.AsignarIncidencia();
        }


        private void btConsultar_Click(object sender, System.EventArgs e)
        {
            bool ret;

            // Ocultar tabs innecesarios
            tbcControl.Controls.Remove(tbpConsultaJGrupo);
           
            // Indicar espera con puntero
            tslbInfo.Text = "Esperando resultado de consulta...";
            UseWaitCursor = true;
            Application.DoEvents();


            // Separar segun rol
            if (_editMode == UserRoleEnum.JefeDepartamento)
            {
                ret = ValidarDatosMesAnno();
                if (ret)
                    ConsultarJefeDepartamento();
            }

            if (_editMode == UserRoleEnum.Supervisor)
            {
                ret = ValidarDatosMesAnno();

                if (ret)
                {
                    ret = ValidarDatosDepartamento();

                    if (ret)
                        ConsultarSupervisor();
                }
                
            }
            
            // Indicar fin espera con puntero
            tslbInfo.Text = "Resultados de consulta recibidos.";
            UseWaitCursor = false;
            Application.DoEvents();

            // mostrar tab resultados
            tbcControl.Controls.Add(tbpResultados);
            tbcControl.SelectTab(tbpResultados);

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

            // Pasar lista de elementos seleccionados como datasource
            // del combo de seleccion de departamentos en Tab Resultados
            SystemService.bdsDepartamentos.DataSource = chlbSelDepart.CheckedItems;

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
