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
            this.dgvProfesionales = new System.Windows.Forms.DataGridView();
            this.labelEspecialidad = new System.Windows.Forms.Label();
            this.labelProfesional = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // filtrarEspecialidades
            // 
            this.filtrarEspecialidades.Location = new System.Drawing.Point(307, 62);
            this.filtrarEspecialidades.Margin = new System.Windows.Forms.Padding(4);
            this.filtrarEspecialidades.Name = "filtrarEspecialidades";
            this.filtrarEspecialidades.Size = new System.Drawing.Size(105, 25);
            this.filtrarEspecialidades.TabIndex = 0;
            this.filtrarEspecialidades.Text = "Filtrar";
            this.filtrarEspecialidades.UseVisualStyleBackColor = true;
            this.filtrarEspecialidades.Click += new System.EventHandler(this.filtrarEspecialidades_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.MaximumSize = new System.Drawing.Size(93333, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pedir turno";
            // 
            // textEspecialidad
            // 
            this.textEspecialidad.Location = new System.Drawing.Point(113, 62);
            this.textEspecialidad.Margin = new System.Windows.Forms.Padding(4);
            this.textEspecialidad.Name = "textEspecialidad";
            this.textEspecialidad.Size = new System.Drawing.Size(184, 22);
            this.textEspecialidad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Especialidad";
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Location = new System.Drawing.Point(16, 113);
            this.dgvEspecialidades.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecialidades.Size = new System.Drawing.Size(423, 234);
            this.dgvEspecialidades.TabIndex = 12;
            this.dgvEspecialidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEspecialidades_CellContentClick_1);
            // 
            // dgvProfesionales
            // 
            this.dgvProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesionales.Location = new System.Drawing.Point(16, 113);
            this.dgvProfesionales.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProfesionales.Name = "dgvProfesionales";
            this.dgvProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfesionales.Size = new System.Drawing.Size(701, 234);
            this.dgvProfesionales.TabIndex = 14;
            this.dgvProfesionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProfesionales_CellContentClick_1);
            // 
            // labelEspecialidad
            // 
            this.labelEspecialidad.AutoSize = true;
            this.labelEspecialidad.Location = new System.Drawing.Point(12, 90);
            this.labelEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEspecialidad.Name = "labelEspecialidad";
            this.labelEspecialidad.Size = new System.Drawing.Size(464, 17);
            this.labelEspecialidad.TabIndex = 15;
            this.labelEspecialidad.Text = "Haga click en el código de la especialidad para la que desea pedir turno";
            // 
            // labelProfesional
            // 
            this.labelProfesional.AutoSize = true;
            this.labelProfesional.Location = new System.Drawing.Point(12, 90);
            this.labelProfesional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProfesional.Name = "labelProfesional";
            this.labelProfesional.Size = new System.Drawing.Size(436, 17);
            this.labelProfesional.TabIndex = 16;
            this.labelProfesional.Text = "Haga click en el código del profesional con el que se desea atender";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 25);
            this.button1.TabIndex = 17;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(15, 62);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(192, 25);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver a especialidades";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Visible = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmPedidoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 361);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelProfesional);
            this.Controls.Add(this.labelEspecialidad);
            this.Controls.Add(this.dgvProfesionales);
            this.Controls.Add(this.dgvEspecialidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEspecialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filtrarEspecialidades);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPedidoTurno";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPedidoTurno_Load);
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
        private System.Windows.Forms.DataGridView dgvProfesionales;
        private System.Windows.Forms.Label labelEspecialidad;
        private System.Windows.Forms.Label labelProfesional;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVolver;
    }
}