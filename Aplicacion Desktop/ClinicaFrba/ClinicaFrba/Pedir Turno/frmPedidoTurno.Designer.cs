namespace ClinicaFrba.Pedir_Turno
{
    partial class frmPedidoTurno
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
            this.filtrarEspecialidades = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textEspecialidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvProfesionales = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // filtrarEspecialidades
            // 
            this.filtrarEspecialidades.Location = new System.Drawing.Point(230, 50);
            this.filtrarEspecialidades.Name = "filtrarEspecialidades";
            this.filtrarEspecialidades.Size = new System.Drawing.Size(79, 20);
            this.filtrarEspecialidades.TabIndex = 0;
            this.filtrarEspecialidades.Text = "Filtrar";
            this.filtrarEspecialidades.UseVisualStyleBackColor = true;
            this.filtrarEspecialidades.Click += new System.EventHandler(this.filtrarEspecialidades_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.MaximumSize = new System.Drawing.Size(70000, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pedir turno";
            // 
            // textEspecialidad
            // 
            this.textEspecialidad.Location = new System.Drawing.Point(85, 50);
            this.textEspecialidad.Name = "textEspecialidad";
            this.textEspecialidad.Size = new System.Drawing.Size(139, 20);
            this.textEspecialidad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Especialidad";
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Location = new System.Drawing.Point(12, 92);
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecialidades.Size = new System.Drawing.Size(348, 190);
            this.dgvEspecialidades.TabIndex = 12;
            this.dgvEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEspecialidades_CellContentClick_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(775, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvProfesionales
            // 
            this.dgvProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesionales.Location = new System.Drawing.Point(366, 92);
            this.dgvProfesionales.Name = "dgvProfesionales";
            this.dgvProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfesionales.Size = new System.Drawing.Size(600, 190);
            this.dgvProfesionales.TabIndex = 14;
            this.dgvProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProfesionales_CellContentClick_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Haga click en el código de la especialidad para la que desea pedir turno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Haga click en el código del profesional con el que se desea atender";
            // 
            // frmPedidoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 373);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvProfesionales);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvEspecialidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEspecialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filtrarEspecialidades);
            this.Name = "frmPedidoTurno";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button filtrarEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvProfesionales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}