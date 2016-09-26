namespace ClinicaFrba.AbmRol
{
    partial class frmAlta
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.lstFunciones = new System.Windows.Forms.CheckedListBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(13, 149);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(250, 28);
            this.btnCrear.TabIndex = 9;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click_1);
            // 
            // lstFunciones
            // 
            this.lstFunciones.FormattingEnabled = true;
            this.lstFunciones.Location = new System.Drawing.Point(13, 35);
            this.lstFunciones.Margin = new System.Windows.Forms.Padding(4);
            this.lstFunciones.Name = "lstFunciones";
            this.lstFunciones.Size = new System.Drawing.Size(250, 106);
            this.lstFunciones.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(13, 5);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(252, 22);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.Text = "Ingrese Nombre Rol";
            // 
            // frmAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 198);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lstFunciones);
            this.Controls.Add(this.txtNombre);
            this.Name = "frmAlta";
            this.Text = "frmAlta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAlta_FormClosing_1);
            this.Load += new System.EventHandler(this.frmAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.CheckedListBox lstFunciones;
        private System.Windows.Forms.TextBox txtNombre;
    }
}