namespace AReport.Client
{
    partial class FormClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.tbcControl = new System.Windows.Forms.TabControl();
            this.tbpConsultaJGrupo = new System.Windows.Forms.TabPage();
            this.btConsultar = new System.Windows.Forms.Button();
            this.lbSelDepart = new System.Windows.Forms.Label();
            this.chlbSelDepart = new System.Windows.Forms.CheckedListBox();
            this.cmbSelMes = new System.Windows.Forms.ComboBox();
            this.rbtSelectClave = new System.Windows.Forms.RadioButton();
            this.rbtIntrodClave = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpResultados = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.nupAnno = new System.Windows.Forms.NumericUpDown();
            this.nupMes = new System.Windows.Forms.NumericUpDown();
            this.tbpAdmin = new System.Windows.Forms.TabPage();
            this.tbcControl.SuspendLayout();
            this.tbpConsultaJGrupo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMes)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcControl
            // 
            this.tbcControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcControl.Controls.Add(this.tbpConsultaJGrupo);
            this.tbcControl.Controls.Add(this.tbpResultados);
            this.tbcControl.Controls.Add(this.tbpAdmin);
            this.tbcControl.Location = new System.Drawing.Point(12, 25);
            this.tbcControl.Name = "tbcControl";
            this.tbcControl.SelectedIndex = 0;
            this.tbcControl.Size = new System.Drawing.Size(637, 314);
            this.tbcControl.TabIndex = 1;
            // 
            // tbpConsultaJGrupo
            // 
            this.tbpConsultaJGrupo.Controls.Add(this.nupMes);
            this.tbpConsultaJGrupo.Controls.Add(this.nupAnno);
            this.tbpConsultaJGrupo.Controls.Add(this.btConsultar);
            this.tbpConsultaJGrupo.Controls.Add(this.lbSelDepart);
            this.tbpConsultaJGrupo.Controls.Add(this.chlbSelDepart);
            this.tbpConsultaJGrupo.Controls.Add(this.cmbSelMes);
            this.tbpConsultaJGrupo.Controls.Add(this.rbtSelectClave);
            this.tbpConsultaJGrupo.Controls.Add(this.rbtIntrodClave);
            this.tbpConsultaJGrupo.Controls.Add(this.label3);
            this.tbpConsultaJGrupo.Controls.Add(this.label2);
            this.tbpConsultaJGrupo.Location = new System.Drawing.Point(4, 22);
            this.tbpConsultaJGrupo.Name = "tbpConsultaJGrupo";
            this.tbpConsultaJGrupo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConsultaJGrupo.Size = new System.Drawing.Size(629, 288);
            this.tbpConsultaJGrupo.TabIndex = 0;
            this.tbpConsultaJGrupo.Text = "Consulta";
            this.tbpConsultaJGrupo.UseVisualStyleBackColor = true;
            // 
            // btConsultar
            // 
            this.btConsultar.Location = new System.Drawing.Point(153, 243);
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.Size = new System.Drawing.Size(121, 23);
            this.btConsultar.TabIndex = 9;
            this.btConsultar.Text = "Leer datos";
            this.btConsultar.UseVisualStyleBackColor = true;
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // lbSelDepart
            // 
            this.lbSelDepart.AutoSize = true;
            this.lbSelDepart.Location = new System.Drawing.Point(307, 11);
            this.lbSelDepart.Name = "lbSelDepart";
            this.lbSelDepart.Size = new System.Drawing.Size(141, 13);
            this.lbSelDepart.TabIndex = 8;
            this.lbSelDepart.Text = "Seleccionar Departamentos:";
            // 
            // chlbSelDepart
            // 
            this.chlbSelDepart.FormattingEnabled = true;
            this.chlbSelDepart.Location = new System.Drawing.Point(310, 37);
            this.chlbSelDepart.Name = "chlbSelDepart";
            this.chlbSelDepart.Size = new System.Drawing.Size(281, 229);
            this.chlbSelDepart.TabIndex = 7;
            // 
            // cmbSelMes
            // 
            this.cmbSelMes.FormattingEnabled = true;
            this.cmbSelMes.Location = new System.Drawing.Point(153, 39);
            this.cmbSelMes.Name = "cmbSelMes";
            this.cmbSelMes.Size = new System.Drawing.Size(121, 21);
            this.cmbSelMes.TabIndex = 6;
            // 
            // rbtSelectClave
            // 
            this.rbtSelectClave.AutoSize = true;
            this.rbtSelectClave.Location = new System.Drawing.Point(153, 9);
            this.rbtSelectClave.Name = "rbtSelectClave";
            this.rbtSelectClave.Size = new System.Drawing.Size(132, 17);
            this.rbtSelectClave.TabIndex = 5;
            this.rbtSelectClave.Text = "Seleccionar mes y año";
            this.rbtSelectClave.UseVisualStyleBackColor = true;
            this.rbtSelectClave.CheckedChanged += new System.EventHandler(this.rbtSelectClave_CheckedChanged);
            // 
            // rbtIntrodClave
            // 
            this.rbtIntrodClave.AutoSize = true;
            this.rbtIntrodClave.Checked = true;
            this.rbtIntrodClave.Location = new System.Drawing.Point(11, 9);
            this.rbtIntrodClave.Name = "rbtIntrodClave";
            this.rbtIntrodClave.Size = new System.Drawing.Size(120, 17);
            this.rbtIntrodClave.TabIndex = 4;
            this.rbtIntrodClave.TabStop = true;
            this.rbtIntrodClave.Text = "Introducir mes y año";
            this.rbtIntrodClave.UseVisualStyleBackColor = true;
            this.rbtIntrodClave.CheckedChanged += new System.EventHandler(this.rbtIntrodClave_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mes:";
            // 
            // tbpResultados
            // 
            this.tbpResultados.Location = new System.Drawing.Point(4, 22);
            this.tbpResultados.Name = "tbpResultados";
            this.tbpResultados.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResultados.Size = new System.Drawing.Size(629, 288);
            this.tbpResultados.TabIndex = 1;
            this.tbpResultados.Text = "Resultados";
            this.tbpResultados.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbInfo,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(661, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslbInfo
            // 
            this.tslbInfo.Name = "tslbInfo";
            this.tslbInfo.Size = new System.Drawing.Size(118, 17);
            this.tslbInfo.Text = "toolStripStatusLabel1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // nupAnno
            // 
            this.nupAnno.Location = new System.Drawing.Point(44, 72);
            this.nupAnno.Name = "nupAnno";
            this.nupAnno.Size = new System.Drawing.Size(67, 20);
            this.nupAnno.TabIndex = 11;
            // 
            // nupMes
            // 
            this.nupMes.Location = new System.Drawing.Point(44, 39);
            this.nupMes.Name = "nupMes";
            this.nupMes.Size = new System.Drawing.Size(67, 20);
            this.nupMes.TabIndex = 12;
            // 
            // tbpAdmin
            // 
            this.tbpAdmin.Location = new System.Drawing.Point(4, 22);
            this.tbpAdmin.Name = "tbpAdmin";
            this.tbpAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAdmin.Size = new System.Drawing.Size(629, 288);
            this.tbpAdmin.TabIndex = 2;
            this.tbpAdmin.Text = "Administracion";
            this.tbpAdmin.UseVisualStyleBackColor = true;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 364);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbcControl);
            this.Name = "FormClient";
            this.Text = "Form1";
            this.tbcControl.ResumeLayout(false);
            this.tbpConsultaJGrupo.ResumeLayout(false);
            this.tbpConsultaJGrupo.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tbcControl;
        private System.Windows.Forms.TabPage tbpConsultaJGrupo;
        private System.Windows.Forms.TabPage tbpResultados;
        private System.Windows.Forms.RadioButton rbtSelectClave;
        private System.Windows.Forms.RadioButton rbtIntrodClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSelDepart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslbInfo;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.Button btConsultar;
        internal System.Windows.Forms.ComboBox cmbSelMes;
        internal System.Windows.Forms.CheckedListBox chlbSelDepart;
        private System.Windows.Forms.NumericUpDown nupAnno;
        private System.Windows.Forms.NumericUpDown nupMes;
        private System.Windows.Forms.TabPage tbpAdmin;
    }
}