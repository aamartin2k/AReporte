namespace AReport.Client.Forms
{
    partial class FormAsigIncidencia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCausas = new System.Windows.Forms.ComboBox();
            this.tbObserv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.grpBoxIncidencia = new System.Windows.Forms.GroupBox();
            this.grpBoxDepartamento = new System.Windows.Forms.GroupBox();
            this.btUncheckAllDepts = new System.Windows.Forms.Button();
            this.btCheckAllDepts = new System.Windows.Forms.Button();
            this.chlbSelDepartIncid = new System.Windows.Forms.CheckedListBox();
            this.grpBoxUsuario = new System.Windows.Forms.GroupBox();
            this.btUncheckAllEmps = new System.Windows.Forms.Button();
            this.btCheckAllEmps = new System.Windows.Forms.Button();
            this.chlbSelEmpleado = new System.Windows.Forms.CheckedListBox();
            this.grpBoxIncidencia.SuspendLayout();
            this.grpBoxDepartamento.SuspendLayout();
            this.grpBoxUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCausas
            // 
            this.cmbCausas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCausas.FormattingEnabled = true;
            this.cmbCausas.Location = new System.Drawing.Point(11, 34);
            this.cmbCausas.Name = "cmbCausas";
            this.cmbCausas.Size = new System.Drawing.Size(182, 21);
            this.cmbCausas.TabIndex = 0;
            // 
            // tbObserv
            // 
            this.tbObserv.Location = new System.Drawing.Point(209, 35);
            this.tbObserv.Name = "tbObserv";
            this.tbObserv.Size = new System.Drawing.Size(285, 20);
            this.tbObserv.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Causa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Observaciones:";
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(24, 360);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "Aceptar";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(416, 360);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // grpBoxIncidencia
            // 
            this.grpBoxIncidencia.Controls.Add(this.label2);
            this.grpBoxIncidencia.Controls.Add(this.cmbCausas);
            this.grpBoxIncidencia.Controls.Add(this.tbObserv);
            this.grpBoxIncidencia.Controls.Add(this.label1);
            this.grpBoxIncidencia.Location = new System.Drawing.Point(12, 12);
            this.grpBoxIncidencia.Name = "grpBoxIncidencia";
            this.grpBoxIncidencia.Size = new System.Drawing.Size(500, 68);
            this.grpBoxIncidencia.TabIndex = 6;
            this.grpBoxIncidencia.TabStop = false;
            this.grpBoxIncidencia.Text = "Incidencia:  ";
            // 
            // grpBoxDepartamento
            // 
            this.grpBoxDepartamento.Controls.Add(this.btUncheckAllDepts);
            this.grpBoxDepartamento.Controls.Add(this.btCheckAllDepts);
            this.grpBoxDepartamento.Controls.Add(this.chlbSelDepartIncid);
            this.grpBoxDepartamento.Location = new System.Drawing.Point(12, 86);
            this.grpBoxDepartamento.Name = "grpBoxDepartamento";
            this.grpBoxDepartamento.Size = new System.Drawing.Size(500, 100);
            this.grpBoxDepartamento.TabIndex = 7;
            this.grpBoxDepartamento.TabStop = false;
            this.grpBoxDepartamento.Text = "Departamentos: ";
            // 
            // btUncheckAllDepts
            // 
            this.btUncheckAllDepts.Location = new System.Drawing.Point(21, 56);
            this.btUncheckAllDepts.Name = "btUncheckAllDepts";
            this.btUncheckAllDepts.Size = new System.Drawing.Size(65, 23);
            this.btUncheckAllDepts.TabIndex = 10;
            this.btUncheckAllDepts.Text = "__ Todos";
            this.btUncheckAllDepts.UseVisualStyleBackColor = true;
            this.btUncheckAllDepts.Click += new System.EventHandler(this.btUncheckAllDepts_Click);
            // 
            // btCheckAllDepts
            // 
            this.btCheckAllDepts.Location = new System.Drawing.Point(21, 25);
            this.btCheckAllDepts.Name = "btCheckAllDepts";
            this.btCheckAllDepts.Size = new System.Drawing.Size(65, 23);
            this.btCheckAllDepts.TabIndex = 9;
            this.btCheckAllDepts.Text = "X Todos";
            this.btCheckAllDepts.UseVisualStyleBackColor = true;
            this.btCheckAllDepts.Click += new System.EventHandler(this.btCheckAllDepts_Click);
            // 
            // chlbSelDepartIncid
            // 
            this.chlbSelDepartIncid.FormattingEnabled = true;
            this.chlbSelDepartIncid.Location = new System.Drawing.Point(113, 12);
            this.chlbSelDepartIncid.Name = "chlbSelDepartIncid";
            this.chlbSelDepartIncid.Size = new System.Drawing.Size(381, 79);
            this.chlbSelDepartIncid.TabIndex = 8;
            this.chlbSelDepartIncid.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chlbSelDepart_ItemCheck);
            this.chlbSelDepartIncid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chlbSelDepart_MouseUp);
            // 
            // grpBoxUsuario
            // 
            this.grpBoxUsuario.Controls.Add(this.btUncheckAllEmps);
            this.grpBoxUsuario.Controls.Add(this.btCheckAllEmps);
            this.grpBoxUsuario.Controls.Add(this.chlbSelEmpleado);
            this.grpBoxUsuario.Location = new System.Drawing.Point(12, 195);
            this.grpBoxUsuario.Name = "grpBoxUsuario";
            this.grpBoxUsuario.Size = new System.Drawing.Size(500, 157);
            this.grpBoxUsuario.TabIndex = 8;
            this.grpBoxUsuario.TabStop = false;
            this.grpBoxUsuario.Text = "Empleados: ";
            // 
            // btUncheckAllEmps
            // 
            this.btUncheckAllEmps.Location = new System.Drawing.Point(21, 80);
            this.btUncheckAllEmps.Name = "btUncheckAllEmps";
            this.btUncheckAllEmps.Size = new System.Drawing.Size(65, 23);
            this.btUncheckAllEmps.TabIndex = 12;
            this.btUncheckAllEmps.Text = "__ Todos";
            this.btUncheckAllEmps.UseVisualStyleBackColor = true;
            this.btUncheckAllEmps.Click += new System.EventHandler(this.btUncheckAllEmps_Click);
            // 
            // btCheckAllEmps
            // 
            this.btCheckAllEmps.Location = new System.Drawing.Point(21, 49);
            this.btCheckAllEmps.Name = "btCheckAllEmps";
            this.btCheckAllEmps.Size = new System.Drawing.Size(65, 23);
            this.btCheckAllEmps.TabIndex = 11;
            this.btCheckAllEmps.Text = "X Todos";
            this.btCheckAllEmps.UseVisualStyleBackColor = true;
            this.btCheckAllEmps.Click += new System.EventHandler(this.btCheckAllEmps_Click);
            // 
            // chlbSelEmpleado
            // 
            this.chlbSelEmpleado.FormattingEnabled = true;
            this.chlbSelEmpleado.Location = new System.Drawing.Point(113, 19);
            this.chlbSelEmpleado.Name = "chlbSelEmpleado";
            this.chlbSelEmpleado.Size = new System.Drawing.Size(381, 124);
            this.chlbSelEmpleado.TabIndex = 9;
            // 
            // FormAsigIncidencia
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(524, 391);
            this.Controls.Add(this.grpBoxUsuario);
            this.Controls.Add(this.grpBoxDepartamento);
            this.Controls.Add(this.grpBoxIncidencia);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAsigIncidencia";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar Incidencia";
            this.grpBoxIncidencia.ResumeLayout(false);
            this.grpBoxIncidencia.PerformLayout();
            this.grpBoxDepartamento.ResumeLayout(false);
            this.grpBoxUsuario.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbCausas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        internal System.Windows.Forms.TextBox tbObserv;
        private System.Windows.Forms.GroupBox grpBoxIncidencia;
        private System.Windows.Forms.GroupBox grpBoxDepartamento;
        private System.Windows.Forms.GroupBox grpBoxUsuario;
        internal System.Windows.Forms.CheckedListBox chlbSelDepartIncid;
        internal System.Windows.Forms.CheckedListBox chlbSelEmpleado;
        private System.Windows.Forms.Button btUncheckAllDepts;
        private System.Windows.Forms.Button btCheckAllDepts;
        private System.Windows.Forms.Button btUncheckAllEmps;
        private System.Windows.Forms.Button btCheckAllEmps;
    }
}