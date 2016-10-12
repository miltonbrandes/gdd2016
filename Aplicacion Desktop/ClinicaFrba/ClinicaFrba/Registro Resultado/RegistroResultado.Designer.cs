namespace ClinicaFrba.Registro_Resultado
{
    partial class frmRegistroResultado
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbHorario = new System.Windows.Forms.CheckBox();
            this.txtSintomas = new System.Windows.Forms.TextBox();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dtpFechaTurno = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(858, 286);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione Turno Finalizado";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(876, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Se Realizo la consulta en horario?";
            // 
            // ckbHorario
            // 
            this.ckbHorario.AutoSize = true;
            this.ckbHorario.Location = new System.Drawing.Point(1135, 78);
            this.ckbHorario.Name = "ckbHorario";
            this.ckbHorario.Size = new System.Drawing.Size(98, 21);
            this.ckbHorario.TabIndex = 5;
            this.ckbHorario.Text = "En Horario";
            this.ckbHorario.UseVisualStyleBackColor = true;
            // 
            // txtSintomas
            // 
            this.txtSintomas.Location = new System.Drawing.Point(1133, 122);
            this.txtSintomas.Multiline = true;
            this.txtSintomas.Name = "txtSintomas";
            this.txtSintomas.Size = new System.Drawing.Size(130, 95);
            this.txtSintomas.TabIndex = 6;
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(1133, 223);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(130, 95);
            this.txtDiagnostico.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(876, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ingrese el diagnostico de la consulta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(876, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ingrese los sintomas de la consulta";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(879, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(384, 35);
            this.button2.TabIndex = 11;
            this.button2.Text = "Ingresar Diagnostico";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtpFechaTurno
            // 
            this.dtpFechaTurno.Location = new System.Drawing.Point(205, 13);
            this.dtpFechaTurno.Name = "dtpFechaTurno";
            this.dtpFechaTurno.Size = new System.Drawing.Size(281, 22);
            this.dtpFechaTurno.TabIndex = 12;
            this.dtpFechaTurno.Value = new System.DateTime(2016, 10, 11, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Seleccione la especialidad";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(206, 47);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(154, 24);
            this.cmbEspecialidad.TabIndex = 14;
            // 
            // frmRegistroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 375);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpFechaTurno);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.txtSintomas);
            this.Controls.Add(this.ckbHorario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmRegistroResultado";
            this.Text = "Registrar Resultado Consulta";
            this.Load += new System.EventHandler(this.frmRegistroResultado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbHorario;
        private System.Windows.Forms.TextBox txtSintomas;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtpFechaTurno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
    }
}