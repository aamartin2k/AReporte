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
            this.tbpConsultaJGrupo = new System.Windows.Forms.TabPage();
            this.nupMes = new System.Windows.Forms.NumericUpDown();
            this.nupAnno = new System.Windows.Forms.NumericUpDown();
            this.btConsultar = new System.Windows.Forms.Button();
            this.lbSelDepart = new System.Windows.Forms.Label();
            this.chlbSelDepart = new System.Windows.Forms.CheckedListBox();
            this.cmbSelMes = new System.Windows.Forms.ComboBox();
            this.rbtSelectClave = new System.Windows.Forms.RadioButton();
            this.rbtIntrodClave = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbpResultados = new System.Windows.Forms.TabPage();
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbDepartamentos = new System.Windows.Forms.ComboBox();
            this.lbDepart = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNumero = new System.Windows.Forms.Label();
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
            this.btAsignar = new System.Windows.Forms.Button();
            this.btGrupo = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.tbpAdmin = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbcControl.SuspendLayout();
            this.tbpConsultaJGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnno)).BeginInit();
            this.tbpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnEmpleados)).BeginInit();
            this.bdnEmpleados.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.tbcControl.Location = new System.Drawing.Point(0, 12);
            this.tbcControl.Name = "tbcControl";
            this.tbcControl.SelectedIndex = 0;
            this.tbcControl.Size = new System.Drawing.Size(852, 407);
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
            this.tbpConsultaJGrupo.Size = new System.Drawing.Size(844, 381);
            this.tbpConsultaJGrupo.TabIndex = 0;
            this.tbpConsultaJGrupo.Text = "Consulta";
            this.tbpConsultaJGrupo.UseVisualStyleBackColor = true;
            // 
            // nupMes
            // 
            this.nupMes.Location = new System.Drawing.Point(44, 39);
            this.nupMes.Name = "nupMes";
            this.nupMes.Size = new System.Drawing.Size(67, 20);
            this.nupMes.TabIndex = 12;
            // 
            // nupAnno
            // 
            this.nupAnno.Location = new System.Drawing.Point(44, 72);
            this.nupAnno.Name = "nupAnno";
            this.nupAnno.Size = new System.Drawing.Size(67, 20);
            this.nupAnno.TabIndex = 11;
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
            this.tbpResultados.AutoScroll = true;
            this.tbpResultados.Controls.Add(this.dgvAsistencia);
            this.tbpResultados.Controls.Add(this.tableLayoutPanel1);
            this.tbpResultados.Location = new System.Drawing.Point(4, 22);
            this.tbpResultados.Name = "tbpResultados";
            this.tbpResultados.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResultados.Size = new System.Drawing.Size(844, 381);
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
            this.dgvAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencia.Location = new System.Drawing.Point(6, 114);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.Size = new System.Drawing.Size(830, 261);
            this.dgvAsistencia.TabIndex = 3;
            this.dgvAsistencia.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAsistencia_CellMouseDown);
            this.dgvAsistencia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAsistencia_DataError);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.tableLayoutPanel1.Controls.Add(this.cmbDepartamentos, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDepart, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbNombre, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbNumero, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bdnEmpleados, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btAsignar, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btGrupo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btEliminar, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(829, 86);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbDepartamentos
            // 
            this.cmbDepartamentos.DisplayMember = "Id";
            this.cmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamentos.FormattingEnabled = true;
            this.cmbDepartamentos.Location = new System.Drawing.Point(338, 3);
            this.cmbDepartamentos.Name = "cmbDepartamentos";
            this.cmbDepartamentos.Size = new System.Drawing.Size(206, 21);
            this.cmbDepartamentos.TabIndex = 4;
            this.cmbDepartamentos.ValueMember = "Id";
            // 
            // lbDepart
            // 
            this.lbDepart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbDepart.AutoSize = true;
            this.lbDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepart.Location = new System.Drawing.Point(88, 64);
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
            this.lbNombre.Location = new System.Drawing.Point(88, 7);
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
            this.label1.Location = new System.Drawing.Point(35, 7);
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
            this.label4.Location = new System.Drawing.Point(55, 35);
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
            this.label5.Location = new System.Drawing.Point(5, 64);
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
            this.lbNumero.Location = new System.Drawing.Point(88, 35);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(27, 13);
            this.lbNumero.TabIndex = 7;
            this.lbNumero.Text = "Nro";
            this.lbNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bdnEmpleados
            // 
            this.bdnEmpleados.AddNewItem = null;
            this.bdnEmpleados.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.bdnEmpleados.Location = new System.Drawing.Point(335, 58);
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
            // btAsignar
            // 
            this.btAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAsignar.Location = new System.Drawing.Point(550, 3);
            this.btAsignar.Name = "btAsignar";
            this.btAsignar.Size = new System.Drawing.Size(75, 22);
            this.btAsignar.TabIndex = 9;
            this.btAsignar.Text = "Asignar";
            this.btAsignar.UseVisualStyleBackColor = true;
            this.btAsignar.Click += new System.EventHandler(this.btAsignar_Click);
            // 
            // btGrupo
            // 
            this.btGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrupo.Location = new System.Drawing.Point(550, 31);
            this.btGrupo.Name = "btGrupo";
            this.btGrupo.Size = new System.Drawing.Size(75, 22);
            this.btGrupo.TabIndex = 10;
            this.btGrupo.Text = "Grupo";
            this.btGrupo.UseVisualStyleBackColor = true;
            // 
            // btEliminar
            // 
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.Location = new System.Drawing.Point(550, 59);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 22);
            this.btEliminar.TabIndex = 11;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            // 
            // tbpAdmin
            // 
            this.tbpAdmin.Location = new System.Drawing.Point(4, 22);
            this.tbpAdmin.Name = "tbpAdmin";
            this.tbpAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAdmin.Size = new System.Drawing.Size(844, 381);
            this.tbpAdmin.TabIndex = 2;
            this.tbpAdmin.Text = "Administracion";
            this.tbpAdmin.UseVisualStyleBackColor = true;
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
            this.tslbInfo.Size = new System.Drawing.Size(118, 17);
            this.tslbInfo.Text = "toolStripStatusLabel1";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 452);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbcControl);
            this.Name = "FormClient";
            this.Text = "Form1";
            this.tbcControl.ResumeLayout(false);
            this.tbpConsultaJGrupo.ResumeLayout(false);
            this.tbpConsultaJGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnno)).EndInit();
            this.tbpResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnEmpleados)).EndInit();
            this.bdnEmpleados.ResumeLayout(false);
            this.bdnEmpleados.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tbcControl;
        private System.Windows.Forms.TabPage tbpConsultaJGrupo;
        private System.Windows.Forms.TabPage tbpResultados;
        private System.Windows.Forms.TabPage tbpAdmin;
        private System.Windows.Forms.RadioButton rbtSelectClave;
        private System.Windows.Forms.RadioButton rbtIntrodClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSelDepart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslbInfo;
        private System.Windows.Forms.Button btConsultar;
        internal System.Windows.Forms.ComboBox cmbSelMes;
        internal System.Windows.Forms.CheckedListBox chlbSelDepart;
        private System.Windows.Forms.NumericUpDown nupAnno;
        private System.Windows.Forms.NumericUpDown nupMes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
    }
}