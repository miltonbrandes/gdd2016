namespace ClinicaFrba.Cancelar_Atencion
{
    partial class frmCancelarAtencionMedico
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbTipoCancelacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.hora1 = new System.Windows.Forms.TextBox();
            this.minuto1 = new System.Windows.Forms.TextBox();
            this.hora2 = new System.Windows.Forms.TextBox();
            this.minuto2 = new System.Windows.Forms.TextBox();
            this.hora_desde = new System.Windows.Forms.Label();
            this.hora_hasta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Fecha de cancelacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione franja de cancelacion";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(187, 39);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(482, 115);
            this.dataGridView1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "(Si quiere dia completo deje la franja sin seleccionar)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Indique Motivo Cancelacion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 158);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(482, 50);
            this.textBox1.TabIndex = 6;
            // 
            // cmbTipoCancelacion
            // 
            this.cmbTipoCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCancelacion.FormattingEnabled = true;
            this.cmbTipoCancelacion.Items.AddRange(new object[] {
            "Enfermedad",
            "Problemas Personales",
            "Motivos Profesionales"});
            this.cmbTipoCancelacion.Location = new System.Drawing.Point(410, 219);
            this.cmbTipoCancelacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTipoCancelacion.Name = "cmbTipoCancelacion";
            this.cmbTipoCancelacion.Size = new System.Drawing.Size(259, 21);
            this.cmbTipoCancelacion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Indique Tipo Cancelacion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(410, 260);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(258, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar Atencion";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(410, 7);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Location = new System.Drawing.Point(11, 93);
            this.btnDesmarcar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(159, 19);
            this.btnDesmarcar.TabIndex = 11;
            this.btnDesmarcar.Text = "Deseleccionar";
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // hora1
            // 
            this.hora1.Location = new System.Drawing.Point(152, 248);
            this.hora1.Name = "hora1";
            this.hora1.Size = new System.Drawing.Size(62, 20);
            this.hora1.TabIndex = 12;
            // 
            // minuto1
            // 
            this.minuto1.Location = new System.Drawing.Point(220, 248);
            this.minuto1.Name = "minuto1";
            this.minuto1.Size = new System.Drawing.Size(62, 20);
            this.minuto1.TabIndex = 13;
            // 
            // hora2
            // 
            this.hora2.Location = new System.Drawing.Point(152, 274);
            this.hora2.Name = "hora2";
            this.hora2.Size = new System.Drawing.Size(62, 20);
            this.hora2.TabIndex = 14;
            // 
            // minuto2
            // 
            this.minuto2.Location = new System.Drawing.Point(220, 275);
            this.minuto2.Name = "minuto2";
            this.minuto2.Size = new System.Drawing.Size(62, 20);
            this.minuto2.TabIndex = 15;
            // 
            // hora_desde
            // 
            this.hora_desde.AutoSize = true;
            this.hora_desde.Location = new System.Drawing.Point(54, 255);
            this.hora_desde.Name = "hora_desde";
            this.hora_desde.Size = new System.Drawing.Size(62, 13);
            this.hora_desde.TabIndex = 16;
            this.hora_desde.Text = "Hora desde";
            // 
            // hora_hasta
            // 
            this.hora_hasta.AutoSize = true;
            this.hora_hasta.Location = new System.Drawing.Point(54, 277);
            this.hora_hasta.Name = "hora_hasta";
            this.hora_hasta.Size = new System.Drawing.Size(59, 13);
            this.hora_hasta.TabIndex = 17;
            this.hora_hasta.Text = "Hora hasta";
            // 
            // frmCancelarAtencionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 307);
            this.Controls.Add(this.hora_hasta);
            this.Controls.Add(this.hora_desde);
            this.Controls.Add(this.minuto2);
            this.Controls.Add(this.hora2);
            this.Controls.Add(this.minuto1);
            this.Controls.Add(this.hora1);
            this.Controls.Add(this.btnDesmarcar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipoCancelacion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmCancelarAtencionMedico";
            this.Text = "Cancelar Atencion";
            this.Load += new System.EventHandler(this.frmCancelarAtencionMedico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbTipoCancelacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.TextBox hora1;
        private System.Windows.Forms.TextBox minuto1;
        private System.Windows.Forms.TextBox hora2;
        private System.Windows.Forms.TextBox minuto2;
        private System.Windows.Forms.Label hora_desde;
        private System.Windows.Forms.Label hora_hasta;
    }
}