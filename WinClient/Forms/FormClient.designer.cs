namespace AReport.Client.Forms
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.tbcControl = new System.Windows.Forms.TabControl();
            this.tbpConsulta = new System.Windows.Forms.TabPage();
            this.groupBoxDepart = new System.Windows.Forms.GroupBox();
            this.btCheckAllDepts = new System.Windows.Forms.Button();
            this.btUncheckAllDepts = new System.Windows.Forms.Button();
            this.chlbSelDepart = new System.Windows.Forms.CheckedListBox();
            this.groupBoxMes = new System.Windows.Forms.GroupBox();
            this.nupAnno = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtIntrodClave = new System.Windows.Forms.RadioButton();
            this.nupMes = new System.Windows.Forms.NumericUpDown();
            this.rbtSelectClave = new System.Windows.Forms.RadioButton();
            this.cmbSelMes = new System.Windows.Forms.ComboBox();
            this.btConsultar = new System.Windows.Forms.Button();
            this.tbpResultados = new System.Windows.Forms.TabPage();
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();
            this.tlpEmpleados = new System.Windows.Forms.TableLayoutPanel();
            this.lbDepart = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNumero = new System.Windows.Forms.Label();
            this.btAsignar = new System.Windows.Forms.Button();
            this.btGrupo = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.bdnEmpleados = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btTerminar = new System.Windows.Forms.Button();
            this.btRegresarConsulta = new System.Windows.Forms.Button();
            this.btReporte = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.cmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.lbMes = new System.Windows.Forms.Label();
            this.tbpAdmin = new System.Windows.Forms.TabPage();
            this.tbcAdmin = new System.Windows.Forms.TabControl();
            this.tbpUsuarios = new System.Windows.Forms.TabPage();
            this.tlpUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.btEditarUsuario = new System.Windows.Forms.Button();
            this.btNuevoUsuario = new System.Windows.Forms.Button();
            this.btGuardarUsuario = new System.Windows.Forms.Button();
            this.btEliminarUsuario = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tbpDirectivos = new System.Windows.Forms.TabPage();
            this.dgvJefes = new System.Windows.Forms.DataGridView();
            this.tlpDirectivos = new System.Windows.Forms.TableLayoutPanel();
            this.btEditarJefe = new System.Windows.Forms.Button();
            this.btNuevoJefe = new System.Windows.Forms.Button();
            this.btGuardarJefe = new System.Windows.Forms.Button();
            this.btEliminarJefe = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbcControl.SuspendLayout();
            this.tbpConsulta.SuspendLayout();
            this.groupBoxDepart.SuspendLayout();
            this.groupBoxMes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMes)).BeginInit();
            this.tbpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            this.tlpEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnEmpleados)).BeginInit();
            this.bdnEmpleados.SuspendLayout();
            this.tbpAdmin.SuspendLayout();
            this.tbcAdmin.SuspendLayout();
            this.tbpUsuarios.SuspendLayout();
            this.tlpUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tbpDirectivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJefes)).BeginInit();
            this.tlpDirectivos.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcControl
            // 
            this.tbcControl.Controls.Add(this.tbpConsulta);
            this.tbcControl.Controls.Add(this.tbpResultados);
            this.tbcControl.Controls.Add(this.tbpAdmin);
            this.tbcControl.Location = new System.Drawing.Point(0, 1);
            this.tbcControl.Name = "tbcControl";
            this.tbcControl.SelectedIndex = 0;
            this.tbcControl.Size = new System.Drawing.Size(852, 426);
            this.tbcControl.TabIndex = 1;
            // 
            // tbpConsulta
            // 
            this.tbpConsulta.Controls.Add(this.groupBoxDepart);
            this.tbpConsulta.Controls.Add(this.groupBoxMes);
            this.tbpConsulta.Controls.Add(this.btConsultar);
            this.tbpConsulta.Location = new System.Drawing.Point(4, 22);
            this.tbpConsulta.Name = "tbpConsulta";
            this.tbpConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConsulta.Size = new System.Drawing.Size(844, 400);
            this.tbpConsulta.TabIndex = 0;
            this.tbpConsulta.Text = "Consulta";
            this.tbpConsulta.UseVisualStyleBackColor = true;
            // 
            // groupBoxDepart
            // 
            this.groupBoxDepart.Controls.Add(this.btCheckAllDepts);
            this.groupBoxDepart.Controls.Add(this.btUncheckAllDepts);
            this.groupBoxDepart.Controls.Add(this.chlbSelDepart);
            this.groupBoxDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDepart.Location = new System.Drawing.Point(320, 11);
            this.groupBoxDepart.Name = "groupBoxDepart";
            this.groupBoxDepart.Size = new System.Drawing.Size(493, 284);
            this.groupBoxDepart.TabIndex = 17;
            this.groupBoxDepart.TabStop = false;
            this.groupBoxDepart.Text = "Seleccionar Departamentos a consultar:  ";
            // 
            // btCheckAllDepts
            // 
            this.btCheckAllDepts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCheckAllDepts.Location = new System.Drawing.Point(16, 40);
            this.btCheckAllDepts.Name = "btCheckAllDepts";
            this.btCheckAllDepts.Size = new System.Drawing.Size(65, 23);
            this.btCheckAllDepts.TabIndex = 14;
            this.btCheckAllDepts.Text = "X Todos";
            this.btCheckAllDepts.UseVisualStyleBackColor = true;
            this.btCheckAllDepts.Click += new System.EventHandler(this.btCheckAllDepts_Click);
            // 
            // btUncheckAllDepts
            // 
            this.btUncheckAllDepts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUncheckAllDepts.Location = new System.Drawing.Point(16, 71);
            this.btUncheckAllDepts.Name = "btUncheckAllDepts";
            this.btUncheckAllDepts.Size = new System.Drawing.Size(65, 23);
            this.btUncheckAllDepts.TabIndex = 15;
            this.btUncheckAllDepts.Text = "__ Todos";
            this.btUncheckAllDepts.UseVisualStyleBackColor = true;
            this.btUncheckAllDepts.Click += new System.EventHandler(this.btUncheckAllDepts_Click);
            // 
            // chlbSelDepart
            // 
            this.chlbSelDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chlbSelDepart.FormattingEnabled = true;
            this.chlbSelDepart.Location = new System.Drawing.Point(104, 22);
            this.chlbSelDepart.Name = "chlbSelDepart";
            this.chlbSelDepart.Size = new System.Drawing.Size(355, 244);
            this.chlbSelDepart.TabIndex = 7;
            // 
            // groupBoxMes
            // 
            this.groupBoxMes.Controls.Add(this.nupAnno);
            this.groupBoxMes.Controls.Add(this.label2);
            this.groupBoxMes.Controls.Add(this.label3);
            this.groupBoxMes.Controls.Add(this.rbtIntrodClave);
            this.groupBoxMes.Controls.Add(this.nupMes);
            this.groupBoxMes.Controls.Add(this.rbtSelectClave);
            this.groupBoxMes.Controls.Add(this.cmbSelMes);
            this.groupBoxMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMes.Location = new System.Drawing.Point(11, 11);
            this.groupBoxMes.Name = "groupBoxMes";
            this.groupBoxMes.Size = new System.Drawing.Size(293, 187);
            this.groupBoxMes.TabIndex = 16;
            this.groupBoxMes.TabStop = false;
            this.groupBoxMes.Text = "Seleccionar mes a consultar:  ";
            // 
            // nupAnno
            // 
            this.nupAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupAnno.Location = new System.Drawing.Point(46, 96);
            this.nupAnno.Name = "nupAnno";
            this.nupAnno.Size = new System.Drawing.Size(67, 20);
            this.nupAnno.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Año:";
            // 
            // rbtIntrodClave
            // 
            this.rbtIntrodClave.AutoSize = true;
            this.rbtIntrodClave.Checked = true;
            this.rbtIntrodClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtIntrodClave.Location = new System.Drawing.Point(13, 33);
            this.rbtIntrodClave.Name = "rbtIntrodClave";
            this.rbtIntrodClave.Size = new System.Drawing.Size(123, 17);
            this.rbtIntrodClave.TabIndex = 4;
            this.rbtIntrodClave.TabStop = true;
            this.rbtIntrodClave.Text = "Introducir mes y año.";
            this.rbtIntrodClave.UseVisualStyleBackColor = true;
            this.rbtIntrodClave.CheckedChanged += new System.EventHandler(this.rbtIntrodClave_CheckedChanged);
            // 
            // nupMes
            // 
            this.nupMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupMes.Location = new System.Drawing.Point(46, 63);
            this.nupMes.Name = "nupMes";
            this.nupMes.Size = new System.Drawing.Size(67, 20);
            this.nupMes.TabIndex = 12;
            // 
            // rbtSelectClave
            // 
            this.rbtSelectClave.AutoSize = true;
            this.rbtSelectClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtSelectClave.Location = new System.Drawing.Point(155, 33);
            this.rbtSelectClave.Name = "rbtSelectClave";
            this.rbtSelectClave.Size = new System.Drawing.Size(135, 17);
            this.rbtSelectClave.TabIndex = 5;
            this.rbtSelectClave.Text = "Seleccionar mes y año.";
            this.rbtSelectClave.UseVisualStyleBackColor = true;
            this.rbtSelectClave.CheckedChanged += new System.EventHandler(this.rbtSelectClave_CheckedChanged);
            // 
            // cmbSelMes
            // 
            this.cmbSelMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelMes.FormattingEnabled = true;
            this.cmbSelMes.Location = new System.Drawing.Point(155, 63);
            this.cmbSelMes.Name = "cmbSelMes";
            this.cmbSelMes.Size = new System.Drawing.Size(121, 21);
            this.cmbSelMes.TabIndex = 6;
            // 
            // btConsultar
            // 
            this.btConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultar.Location = new System.Drawing.Point(11, 319);
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.Size = new System.Drawing.Size(138, 32);
            this.btConsultar.TabIndex = 9;
            this.btConsultar.Text = "Ejecutar consulta";
            this.btConsultar.UseVisualStyleBackColor = true;
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // tbpResultados
            // 
            this.tbpResultados.AutoScroll = true;
            this.tbpResultados.Controls.Add(this.dgvAsistencia);
            this.tbpResultados.Controls.Add(this.tlpEmpleados);
            this.tbpResultados.Location = new System.Drawing.Point(4, 22);
            this.tbpResultados.Name = "tbpResultados";
            this.tbpResultados.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResultados.Size = new System.Drawing.Size(844, 400);
            this.tbpResultados.TabIndex = 1;
            this.tbpResultados.Text = "Resultados";
            this.tbpResultados.UseVisualStyleBackColor = true;
            // 
            // dgvAsistencia
            // 
            this.dgvAsistencia.AllowUserToAddRows = false;
            this.dgvAsistencia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvAsistencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencia.Location = new System.Drawing.Point(6, 119);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.Size = new System.Drawing.Size(830, 275);
            this.dgvAsistencia.TabIndex = 3;
            this.dgvAsistencia.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAsistencia_CellMouseDown);
            this.dgvAsistencia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAsistencia_DataError);
            // 
            // tlpEmpleados
            // 
            this.tlpEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpEmpleados.ColumnCount = 6;
            this.tlpEmpleados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpEmpleados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpEmpleados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tlpEmpleados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpEmpleados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpEmpleados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tlpEmpleados.Controls.Add(this.lbDepart, 1, 2);
            this.tlpEmpleados.Controls.Add(this.lbNombre, 1, 0);
            this.tlpEmpleados.Controls.Add(this.label1, 0, 0);
            this.tlpEmpleados.Controls.Add(this.label4, 0, 1);
            this.tlpEmpleados.Controls.Add(this.label5, 0, 2);
            this.tlpEmpleados.Controls.Add(this.lbNumero, 1, 1);
            this.tlpEmpleados.Controls.Add(this.btAsignar, 3, 0);
            this.tlpEmpleados.Controls.Add(this.btGrupo, 3, 1);
            this.tlpEmpleados.Controls.Add(this.btEliminar, 3, 2);
            this.tlpEmpleados.Controls.Add(this.bdnEmpleados, 2, 2);
            this.tlpEmpleados.Controls.Add(this.btTerminar, 5, 0);
            this.tlpEmpleados.Controls.Add(this.btRegresarConsulta, 5, 1);
            this.tlpEmpleados.Controls.Add(this.btReporte, 4, 2);
            this.tlpEmpleados.Controls.Add(this.btGuardar, 4, 0);
            this.tlpEmpleados.Controls.Add(this.cmbDepartamentos, 2, 1);
            this.tlpEmpleados.Controls.Add(this.lbMes, 2, 0);
            this.tlpEmpleados.Location = new System.Drawing.Point(6, 6);
            this.tlpEmpleados.Name = "tlpEmpleados";
            this.tlpEmpleados.RowCount = 4;
            this.tlpEmpleados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpEmpleados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpEmpleados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpEmpleados.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEmpleados.Size = new System.Drawing.Size(830, 95);
            this.tlpEmpleados.TabIndex = 0;
            // 
            // lbDepart
            // 
            this.lbDepart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbDepart.AutoSize = true;
            this.lbDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepart.Location = new System.Drawing.Point(89, 66);
            this.lbDepart.Name = "lbDepart";
            this.lbDepart.Size = new System.Drawing.Size(86, 13);
            this.lbDepart.TabIndex = 8;
            this.lbDepart.Text = "Departamento";
            this.lbDepart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNombre
            // 
            this.lbNombre.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(89, 8);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(50, 13);
            this.lbNombre.TabIndex = 6;
            this.lbNombre.Text = "Nombre";
            this.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nro:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Departamento:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNumero
            // 
            this.lbNumero.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbNumero.AutoSize = true;
            this.lbNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumero.Location = new System.Drawing.Point(89, 37);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(27, 13);
            this.lbNumero.TabIndex = 7;
            this.lbNumero.Text = "Nro";
            this.lbNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btAsignar
            // 
            this.btAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAsignar.Location = new System.Drawing.Point(558, 3);
            this.btAsignar.Name = "btAsignar";
            this.btAsignar.Size = new System.Drawing.Size(72, 22);
            this.btAsignar.TabIndex = 9;
            this.btAsignar.Text = "Asignar";
            this.btAsignar.UseVisualStyleBackColor = true;
            this.btAsignar.Click += new System.EventHandler(this.btAsignar_Click);
            // 
            // btGrupo
            // 
            this.btGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrupo.Location = new System.Drawing.Point(558, 32);
            this.btGrupo.Name = "btGrupo";
            this.btGrupo.Size = new System.Drawing.Size(72, 22);
            this.btGrupo.TabIndex = 10;
            this.btGrupo.Text = "Grupo";
            this.btGrupo.UseVisualStyleBackColor = true;
            this.btGrupo.Click += new System.EventHandler(this.btGrupo_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Location = new System.Drawing.Point(558, 61);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(72, 22);
            this.btEliminar.TabIndex = 11;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // bdnEmpleados
            // 
            this.bdnEmpleados.AddNewItem = null;
            this.bdnEmpleados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bdnEmpleados.CountItem = this.bindingNavigatorCountItem;
            this.bdnEmpleados.DeleteItem = null;
            this.bdnEmpleados.Dock = System.Windows.Forms.DockStyle.None;
            this.bdnEmpleados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdnEmpleados.Location = new System.Drawing.Point(341, 60);
            this.bdnEmpleados.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnEmpleados.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnEmpleados.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnEmpleados.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnEmpleados.Name = "bdnEmpleados";
            this.bdnEmpleados.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnEmpleados.Size = new System.Drawing.Size(209, 25);
            this.bdnEmpleados.TabIndex = 3;
            this.bdnEmpleados.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Ir al inicio";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Ir al inicio. Use ALT + Home.";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Ir al anterior.";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Ir al anterior. Use ALT + Flecha Izquierda.";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Ir al próximo.";
            this.bindingNavigatorMoveNextItem.ToolTipText = "Ir al próximo. Use ALT+Flecha Derecha.";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ir al final.";
            this.bindingNavigatorMoveLastItem.ToolTipText = "Ir al final. Use ALT + End.";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btTerminar
            // 
            this.btTerminar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTerminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btTerminar.Location = new System.Drawing.Point(714, 3);
            this.btTerminar.Name = "btTerminar";
            this.btTerminar.Size = new System.Drawing.Size(71, 22);
            this.btTerminar.TabIndex = 13;
            this.btTerminar.Text = "Terminar";
            this.btTerminar.UseVisualStyleBackColor = true;
            this.btTerminar.Click += new System.EventHandler(this.btTerminar_Click);
            // 
            // btRegresarConsulta
            // 
            this.btRegresarConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btRegresarConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegresarConsulta.Location = new System.Drawing.Point(714, 32);
            this.btRegresarConsulta.Name = "btRegresarConsulta";
            this.btRegresarConsulta.Size = new System.Drawing.Size(71, 22);
            this.btRegresarConsulta.TabIndex = 14;
            this.btRegresarConsulta.Text = "Consultar";
            this.btRegresarConsulta.UseVisualStyleBackColor = true;
            this.btRegresarConsulta.Click += new System.EventHandler(this.btRegresarConsulta_Click);
            // 
            // btReporte
            // 
            this.btReporte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpEmpleados.SetColumnSpan(this.btReporte, 2);
            this.btReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReporte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btReporte.Location = new System.Drawing.Point(636, 61);
            this.btReporte.Name = "btReporte";
            this.btReporte.Size = new System.Drawing.Size(149, 22);
            this.btReporte.TabIndex = 15;
            this.btReporte.Text = "Generar Reporte";
            this.btReporte.UseVisualStyleBackColor = true;
            this.btReporte.Click += new System.EventHandler(this.btReporte_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btGuardar.Location = new System.Drawing.Point(636, 4);
            this.btGuardar.Name = "btGuardar";
            this.tlpEmpleados.SetRowSpan(this.btGuardar, 2);
            this.btGuardar.Size = new System.Drawing.Size(71, 50);
            this.btGuardar.TabIndex = 16;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // cmbDepartamentos
            // 
            this.cmbDepartamentos.DisplayMember = "Id";
            this.cmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamentos.FormattingEnabled = true;
            this.cmbDepartamentos.Location = new System.Drawing.Point(339, 32);
            this.cmbDepartamentos.Name = "cmbDepartamentos";
            this.cmbDepartamentos.Size = new System.Drawing.Size(206, 21);
            this.cmbDepartamentos.TabIndex = 4;
            this.cmbDepartamentos.ValueMember = "Id";
            // 
            // lbMes
            // 
            this.lbMes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbMes.AutoSize = true;
            this.lbMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMes.Location = new System.Drawing.Point(339, 8);
            this.lbMes.Name = "lbMes";
            this.lbMes.Size = new System.Drawing.Size(30, 13);
            this.lbMes.TabIndex = 17;
            this.lbMes.Text = "Mes";
            // 
            // tbpAdmin
            // 
            this.tbpAdmin.Controls.Add(this.tbcAdmin);
            this.tbpAdmin.Location = new System.Drawing.Point(4, 22);
            this.tbpAdmin.Name = "tbpAdmin";
            this.tbpAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAdmin.Size = new System.Drawing.Size(844, 400);
            this.tbpAdmin.TabIndex = 2;
            this.tbpAdmin.Text = "Administración";
            this.tbpAdmin.UseVisualStyleBackColor = true;
            // 
            // tbcAdmin
            // 
            this.tbcAdmin.Controls.Add(this.tbpUsuarios);
            this.tbcAdmin.Controls.Add(this.tbpDirectivos);
            this.tbcAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcAdmin.Location = new System.Drawing.Point(3, 3);
            this.tbcAdmin.Multiline = true;
            this.tbcAdmin.Name = "tbcAdmin";
            this.tbcAdmin.SelectedIndex = 0;
            this.tbcAdmin.Size = new System.Drawing.Size(838, 394);
            this.tbcAdmin.TabIndex = 0;
            // 
            // tbpUsuarios
            // 
            this.tbpUsuarios.Controls.Add(this.tlpUsuarios);
            this.tbpUsuarios.Controls.Add(this.dgvUsuarios);
            this.tbpUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tbpUsuarios.Name = "tbpUsuarios";
            this.tbpUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUsuarios.Size = new System.Drawing.Size(830, 368);
            this.tbpUsuarios.TabIndex = 0;
            this.tbpUsuarios.Text = "Usuarios";
            this.tbpUsuarios.UseVisualStyleBackColor = true;
            // 
            // tlpUsuarios
            // 
            this.tlpUsuarios.ColumnCount = 4;
            this.tlpUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUsuarios.Controls.Add(this.btEditarUsuario, 0, 0);
            this.tlpUsuarios.Controls.Add(this.btNuevoUsuario, 0, 0);
            this.tlpUsuarios.Controls.Add(this.btGuardarUsuario, 3, 0);
            this.tlpUsuarios.Controls.Add(this.btEliminarUsuario, 2, 0);
            this.tlpUsuarios.Location = new System.Drawing.Point(20, 6);
            this.tlpUsuarios.Name = "tlpUsuarios";
            this.tlpUsuarios.RowCount = 1;
            this.tlpUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpUsuarios.Size = new System.Drawing.Size(420, 28);
            this.tlpUsuarios.TabIndex = 1;
            // 
            // btEditarUsuario
            // 
            this.btEditarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditarUsuario.Location = new System.Drawing.Point(108, 3);
            this.btEditarUsuario.Name = "btEditarUsuario";
            this.btEditarUsuario.Size = new System.Drawing.Size(83, 22);
            this.btEditarUsuario.TabIndex = 11;
            this.btEditarUsuario.Text = "Editar";
            this.btEditarUsuario.UseVisualStyleBackColor = true;
            this.btEditarUsuario.Click += new System.EventHandler(this.btEditarUsuario_Click);
            // 
            // btNuevoUsuario
            // 
            this.btNuevoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevoUsuario.Location = new System.Drawing.Point(3, 3);
            this.btNuevoUsuario.Name = "btNuevoUsuario";
            this.btNuevoUsuario.Size = new System.Drawing.Size(83, 22);
            this.btNuevoUsuario.TabIndex = 10;
            this.btNuevoUsuario.Text = "Nuevo";
            this.btNuevoUsuario.UseVisualStyleBackColor = true;
            this.btNuevoUsuario.Click += new System.EventHandler(this.btNuevoUsuario_Click);
            // 
            // btGuardarUsuario
            // 
            this.btGuardarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardarUsuario.Location = new System.Drawing.Point(318, 3);
            this.btGuardarUsuario.Name = "btGuardarUsuario";
            this.btGuardarUsuario.Size = new System.Drawing.Size(83, 22);
            this.btGuardarUsuario.TabIndex = 13;
            this.btGuardarUsuario.Text = "Guardar";
            this.btGuardarUsuario.UseVisualStyleBackColor = true;
            this.btGuardarUsuario.Click += new System.EventHandler(this.btGuardarUsuario_Click);
            // 
            // btEliminarUsuario
            // 
            this.btEliminarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarUsuario.Location = new System.Drawing.Point(213, 3);
            this.btEliminarUsuario.Name = "btEliminarUsuario";
            this.btEliminarUsuario.Size = new System.Drawing.Size(83, 22);
            this.btEliminarUsuario.TabIndex = 12;
            this.btEliminarUsuario.Text = "Eliminar";
            this.btEliminarUsuario.UseVisualStyleBackColor = true;
            this.btEliminarUsuario.Click += new System.EventHandler(this.btEliminarUsuario_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 60);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(781, 189);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // tbpDirectivos
            // 
            this.tbpDirectivos.Controls.Add(this.dgvJefes);
            this.tbpDirectivos.Controls.Add(this.tlpDirectivos);
            this.tbpDirectivos.Location = new System.Drawing.Point(4, 22);
            this.tbpDirectivos.Name = "tbpDirectivos";
            this.tbpDirectivos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDirectivos.Size = new System.Drawing.Size(830, 368);
            this.tbpDirectivos.TabIndex = 1;
            this.tbpDirectivos.Text = "Directivos";
            this.tbpDirectivos.UseVisualStyleBackColor = true;
            // 
            // dgvJefes
            // 
            this.dgvJefes.AllowUserToAddRows = false;
            this.dgvJefes.AllowUserToDeleteRows = false;
            this.dgvJefes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJefes.Location = new System.Drawing.Point(20, 60);
            this.dgvJefes.Name = "dgvJefes";
            this.dgvJefes.Size = new System.Drawing.Size(781, 189);
            this.dgvJefes.TabIndex = 3;
            // 
            // tlpDirectivos
            // 
            this.tlpDirectivos.ColumnCount = 4;
            this.tlpDirectivos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDirectivos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDirectivos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDirectivos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDirectivos.Controls.Add(this.btEditarJefe, 0, 0);
            this.tlpDirectivos.Controls.Add(this.btNuevoJefe, 0, 0);
            this.tlpDirectivos.Controls.Add(this.btGuardarJefe, 3, 0);
            this.tlpDirectivos.Controls.Add(this.btEliminarJefe, 2, 0);
            this.tlpDirectivos.Location = new System.Drawing.Point(20, 6);
            this.tlpDirectivos.Name = "tlpDirectivos";
            this.tlpDirectivos.RowCount = 1;
            this.tlpDirectivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpDirectivos.Size = new System.Drawing.Size(420, 28);
            this.tlpDirectivos.TabIndex = 2;
            // 
            // btEditarJefe
            // 
            this.btEditarJefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditarJefe.Location = new System.Drawing.Point(108, 3);
            this.btEditarJefe.Name = "btEditarJefe";
            this.btEditarJefe.Size = new System.Drawing.Size(83, 22);
            this.btEditarJefe.TabIndex = 11;
            this.btEditarJefe.Text = "Editar";
            this.btEditarJefe.UseVisualStyleBackColor = true;
            // 
            // btNuevoJefe
            // 
            this.btNuevoJefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevoJefe.Location = new System.Drawing.Point(3, 3);
            this.btNuevoJefe.Name = "btNuevoJefe";
            this.btNuevoJefe.Size = new System.Drawing.Size(83, 22);
            this.btNuevoJefe.TabIndex = 10;
            this.btNuevoJefe.Text = "Nuevo";
            this.btNuevoJefe.UseVisualStyleBackColor = true;
            this.btNuevoJefe.Click += new System.EventHandler(this.btNuevoJefe_Click);
            // 
            // btGuardarJefe
            // 
            this.btGuardarJefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardarJefe.Location = new System.Drawing.Point(318, 3);
            this.btGuardarJefe.Name = "btGuardarJefe";
            this.btGuardarJefe.Size = new System.Drawing.Size(83, 22);
            this.btGuardarJefe.TabIndex = 14;
            this.btGuardarJefe.Text = "Guardar";
            this.btGuardarJefe.UseVisualStyleBackColor = true;
            // 
            // btEliminarJefe
            // 
            this.btEliminarJefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarJefe.Location = new System.Drawing.Point(213, 3);
            this.btEliminarJefe.Name = "btEliminarJefe";
            this.btEliminarJefe.Size = new System.Drawing.Size(83, 22);
            this.btEliminarJefe.TabIndex = 12;
            this.btEliminarJefe.Text = "Eliminar";
            this.btEliminarJefe.UseVisualStyleBackColor = true;
            this.btEliminarJefe.Click += new System.EventHandler(this.btEliminarJefe_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(852, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslbInfo
            // 
            this.tslbInfo.Name = "tslbInfo";
            this.tslbInfo.Size = new System.Drawing.Size(56, 17);
            this.tslbInfo.Text = "Info label";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 452);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbcControl);
            this.Name = "FormClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tbcControl.ResumeLayout(false);
            this.tbpConsulta.ResumeLayout(false);
            this.groupBoxDepart.ResumeLayout(false);
            this.groupBoxMes.ResumeLayout(false);
            this.groupBoxMes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMes)).EndInit();
            this.tbpResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            this.tlpEmpleados.ResumeLayout(false);
            this.tlpEmpleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnEmpleados)).EndInit();
            this.bdnEmpleados.ResumeLayout(false);
            this.bdnEmpleados.PerformLayout();
            this.tbpAdmin.ResumeLayout(false);
            this.tbcAdmin.ResumeLayout(false);
            this.tbpUsuarios.ResumeLayout(false);
            this.tlpUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tbpDirectivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJefes)).EndInit();
            this.tlpDirectivos.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tbcControl;
        private System.Windows.Forms.TabPage tbpConsulta;
        private System.Windows.Forms.TabPage tbpResultados;
        private System.Windows.Forms.TabPage tbpAdmin;
        private System.Windows.Forms.RadioButton rbtSelectClave;
        private System.Windows.Forms.RadioButton rbtIntrodClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btConsultar;
        internal System.Windows.Forms.ComboBox cmbSelMes;
        internal System.Windows.Forms.CheckedListBox chlbSelDepart;
        private System.Windows.Forms.NumericUpDown nupAnno;
        private System.Windows.Forms.NumericUpDown nupMes;
        private System.Windows.Forms.TableLayoutPanel tlpEmpleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        internal System.Windows.Forms.ComboBox cmbDepartamentos;
        internal System.Windows.Forms.Label lbNombre;
        internal System.Windows.Forms.Label lbNumero;
        internal System.Windows.Forms.Label lbDepart;
        internal System.Windows.Forms.DataGridView dgvAsistencia;
        internal System.Windows.Forms.BindingNavigator bdnEmpleados;
        private System.Windows.Forms.Button btAsignar;
        private System.Windows.Forms.Button btGrupo;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btReporte;
        private System.Windows.Forms.Button btRegresarConsulta;
        private System.Windows.Forms.Button btTerminar;
        private System.Windows.Forms.Button btGuardar;
        internal System.Windows.Forms.ToolStripStatusLabel tslbInfo;
        private System.Windows.Forms.GroupBox groupBoxDepart;
        private System.Windows.Forms.Button btCheckAllDepts;
        private System.Windows.Forms.Button btUncheckAllDepts;
        private System.Windows.Forms.GroupBox groupBoxMes;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label lbMes;
        private System.Windows.Forms.TabControl tbcAdmin;
        private System.Windows.Forms.TabPage tbpUsuarios;
        private System.Windows.Forms.TabPage tbpDirectivos;
        internal System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TableLayoutPanel tlpUsuarios;
        private System.Windows.Forms.Button btEliminarUsuario;
        private System.Windows.Forms.Button btEditarUsuario;
        private System.Windows.Forms.Button btNuevoUsuario;
        private System.Windows.Forms.TableLayoutPanel tlpDirectivos;
        private System.Windows.Forms.Button btEliminarJefe;
        private System.Windows.Forms.Button btEditarJefe;
        private System.Windows.Forms.Button btNuevoJefe;
        internal System.Windows.Forms.DataGridView dgvJefes;
        private System.Windows.Forms.Button btGuardarUsuario;
        private System.Windows.Forms.Button btGuardarJefe;
    }
}