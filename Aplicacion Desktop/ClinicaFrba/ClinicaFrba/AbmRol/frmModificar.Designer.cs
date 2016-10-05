namespace ClinicaFrba.AbmRol
{
    partial class frmModificar
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
            this.btnActivar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lstFunciones = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnActivar
            // 
            this.btnActivar.Location = new System.Drawing.Point(13, 378);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(254, 28);
            this.btnActivar.TabIndex = 21;
            this.btnActivar.Text = "Activar Rol";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(13, 45);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(254, 22);
            this.txtNombre.TabIndex = 20;
            this.txtNombre.Text = "Nuevo Nombre";
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(13, 13);
            this.cmbRoles.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(254, 24);
            this.cmbRoles.TabIndex = 18;
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(13, 342);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(254, 28);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "Modificar Rol";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lstFunciones
            // 
            this.lstFunciones.Enabled = false;
            this.lstFunciones.FormattingEnabled = true;
            this.lstFunciones.Location = new System.Drawing.Point(13, 75);
            this.lstFunciones.Margin = new System.Windows.Forms.Padding(4);
            this.lstFunciones.Name = "lstFunciones";
            this.lstFunciones.Size = new System.Drawing.Size(254, 259);
            this.lstFunciones.TabIndex = 15;
            // 
            // frmModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 411);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lstFunciones);
            this.Name = "frmModificar";
            this.Text = "frmModificar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModificar_FormClosing);
            this.Load += new System.EventHandler(this.frmModificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckedListBox lstFunciones;
    }
}