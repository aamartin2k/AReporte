﻿
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

namespace AReport.Client
{
    public enum FormClientMode { JefeGrupo, Supervisor, Administrador}

    public partial class FormClient : Form
    {


        public FormClient()
        {
            InitializeComponent();
        }

        #region Configurar Editor

        private FormClientMode _editMode;
        internal FormClientMode EditMode
        {
            set
            {
                ConfigurarSegunModo(value);
                _editMode = value;
            }
        }
        
        private void ConfigurarSegunModo(FormClientMode mode)
        {
            string text;

            switch (mode)
            {
                case FormClientMode.JefeGrupo:
                    text = "Modo Jefe Grupo";
                    ConfigurarModoJefeGrupo();
                    break;

                case FormClientMode.Supervisor:
                    text = "Modo Supervisor RR HH";
                    ConfigurarModoSupervisor();
                    break;

                case FormClientMode.Administrador:
                default:
                    text = "Modo Administrador";
                    ConfigurarModoAdministrador();
                    break;
            }

            tslbInfo.Text = text;
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

        #region Controlador de Eventos de Formulario
        private void btConsultar_Click(object sender, System.EventArgs e)
        {
            bool ret;
            // Separar segun rol
            if (_editMode == FormClientMode.JefeGrupo)
            {
                ret = ValidarDatosMesAnno();
                if (ret)
                    ConsultarJefeGrupo();
            }

            if (_editMode == FormClientMode.Supervisor)
            {
                ret = ValidarDatosMesAnno();

                if (ret)
                {
                    ret = ValidarDatosDepartamento();

                    if (ret)
                        ConsultarSupervisor();
                }
                
            }
            tbcControl.Controls.Remove(tbpConsultaJGrupo);
            tbcControl.Controls.Add(tbpResultados);
            tbcControl.SelectTab(tbpResultados);
           
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

        private void ConsultarJefeGrupo()
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

            bdsDepartamentos.DataSource = chlbSelDepart.CheckedItems;
           
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

        private void HandleSelectClave(bool status)
        {
            // Para habilitar
            nupMes.Enabled = status;
            nupAnno.Enabled = status;

            // Para deshabilitar
            cmbSelMes.Enabled = !status;
        }

        private void bdsEmpleados_CurrentChanged(object sender, EventArgs e)
        {
            Empleado emp = (Empleado)bdsEmpleados.Current;
            List<Asistencia> asist = new List<Asistencia>(emp.Asistencias);

            bdsAsistencias.DataSource = asist;
            // Implementar metodos diferentes para jefe y supervisor, filtro combo depart
        }

        private void bdsTodosEmpleados_DataSourceChanged(object sender, EventArgs e)
        {
            if (_editMode == FormClientMode.Supervisor)
            {
                bdsEmpleados.DataSource = bdsTodosEmpleados.DataSource;
                // Filtrar de acuerdo a departamento activo, forzando controlador de ebvento del combo
                cmbDepartamentos.SelectedIndex = 0;
            }

            if (_editMode == FormClientMode.JefeGrupo)
            {
                Collection<Empleado> colEmp = bdsTodosEmpleados.DataSource as Collection<Empleado>;
                var empl = colEmp.OrderBy(em => em.Nombre);
                bdsEmpleados.DataSource = empl.ToList();
            }
                
        }

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartamentos.SelectedValue != null)
            {
                int deptId = (int)cmbDepartamentos.SelectedValue;

                Collection<Empleado> colEmp = bdsTodosEmpleados.DataSource as Collection<Empleado>;

                //HARDCODED Caso especial Al seleccionar Caudal, id =  1
                // se deben mostrar todos los empleados.
               
                if (deptId == 1)
                {
                    var empl = colEmp.OrderBy(em => em.DepartamentoId).ThenBy(em => em.Nombre);
                    bdsEmpleados.DataSource = empl.ToList();
                }
                else
                {
                    var empl = colEmp.Where(em => em.DepartamentoId == deptId).OrderBy(em => em.DepartamentoId).ThenBy(em => em.Nombre);
                    bdsEmpleados.DataSource = empl.ToList();
                }

                //  mover al primer registro
                bdsEmpleados.MoveFirst();
                
            }
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

        #endregion


        //// Crear bindings temporalmenet aqui
        //Binding emplNombre = new Binding("Text", bdsEmpleados, "Nombre");
        //lbNombre.DataBindings.Add(emplNombre);

        //Binding emplCode = new Binding("Text", bdsEmpleados, "Code");
        //lbNumero.DataBindings.Add(emplCode);

        //Binding emplDepart = new Binding("Text", bdsEmpleados, "Departamento");
        //lbDepart.DataBindings.Add(emplDepart);


        //// prueba textBox1
        ////Binding emplCode1 = new Binding("Text", bdsEmpleados, "Code");
        ////textBox1.DataBindings.Add(emplCode1);


        //dgvAsistencia.DataSource = bdsAsistencias;



    }
}