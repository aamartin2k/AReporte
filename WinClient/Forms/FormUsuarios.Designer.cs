namespace AReport.Client.Forms
{
    partial class FormUsuarios
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
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbNombreUsuario = new System.Windows.Forms.ComboBox();
            this.tbClaveUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCuentaUsuario = new System.Windows.Forms.TextBox();
            this.tbClaveUsuarioConfirm = new System.Windows.Forms.TextBox();
            this.cmbRolUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(35, 140);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "Aceptar";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(433, 140);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Cancelar";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.30499F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4085F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.55083F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.73568F));
            this.tableLayoutPanel1.Controls.Add(this.cmbNombreUsuario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbClaveUsuario, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbCuentaUsuario, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbClaveUsuarioConfirm, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbRolUsuario, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 74);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cmbNombreUsuario
            // 
            this.cmbNombreUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbNombreUsuario.FormattingEnabled = true;
            this.cmbNombreUsuario.Location = new System.Drawing.Point(3, 27);
            this.cmbNombreUsuario.Name = "cmbNombreUsuario";
            this.cmbNombreUsuario.Size = new System.Drawing.Size(185, 21);
            this.cmbNombreUsuario.TabIndex = 10;
            // 
            // tbClaveUsuario
            // 
            this.tbClaveUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbClaveUsuario.Location = new System.Drawing.Point(421, 27);
            this.tbClaveUsuario.Name = "tbClaveUsuario";
            this.tbClaveUsuario.PasswordChar = 'x';
            this.tbClaveUsuario.Size = new System.Drawing.Size(113, 20);
            this.tbClaveUsuario.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Clave";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cuenta";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rol";
            // 
            // tbCuentaUsuario
            // 
            this.tbCuentaUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbCuentaUsuario.Location = new System.Drawing.Point(299, 27);
            this.tbCuentaUsuario.Name = "tbCuentaUsuario";
            this.tbCuentaUsuario.Size = new System.Drawing.Size(113, 20);
            this.tbCuentaUsuario.TabIndex = 6;
            // 
            // tbClaveUsuarioConfirm
            // 
            this.tbClaveUsuarioConfirm.Location = new System.Drawing.Point(421, 51);
            this.tbClaveUsuarioConfirm.Name = "tbClaveUsuarioConfirm";
            this.tbClaveUsuarioConfirm.PasswordChar = 'x';
            this.tbClaveUsuarioConfirm.Size = new System.Drawing.Size(113, 20);
            this.tbClaveUsuarioConfirm.TabIndex = 8;
            // 
            // cmbRolUsuario
            // 
            this.cmbRolUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbRolUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolUsuario.FormattingEnabled = true;
            this.cmbRolUsuario.Location = new System.Drawing.Point(194, 27);
            this.cmbRolUsuario.Name = "cmbRolUsuario";
            this.cmbRolUsuario.Size = new System.Drawing.Size(99, 21);
            this.cmbRolUsuario.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Confirmar Clave";
            // 
            // FormUsuarios
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(566, 179);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUsuarios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUsuarios_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbRolUsuario;
        internal System.Windows.Forms.ComboBox cmbNombreUsuario;
        internal System.Windows.Forms.TextBox tbClaveUsuario;
        internal System.Windows.Forms.TextBox tbCuentaUsuario;
        private System.Windows.Forms.TextBox tbClaveUsuarioConfirm;
        private System.Windows.Forms.Label label5;
    }
}