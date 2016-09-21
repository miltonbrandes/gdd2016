namespace GDD.ABM_Rol
{
    partial class frmHome
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
            this.btnRol = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRol
            // 
            this.btnRol.Location = new System.Drawing.Point(67, 13);
            this.btnRol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRol.Name = "btnRol";
            this.btnRol.Size = new System.Drawing.Size(100, 28);
            this.btnRol.TabIndex = 0;
            this.btnRol.Text = "Alta";
            this.btnRol.UseVisualStyleBackColor = true;
            this.btnRol.Click += new System.EventHandler(this.btnRol_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(67, 49);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 28);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(67, 85);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(100, 28);
            this.btnBaja.TabIndex = 2;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 171);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnRol);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHome";
            this.Text = "ABM Rol";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRol;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBaja;
    }
}