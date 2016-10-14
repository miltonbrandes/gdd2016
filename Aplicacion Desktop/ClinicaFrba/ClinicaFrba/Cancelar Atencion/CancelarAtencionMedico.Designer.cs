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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione Fecha de cancelacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 17);
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
            this.dataGridView1.Location = new System.Drawing.Point(249, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(642, 141);
            this.dataGridView1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "(Si quiere dia completo deje la franja sin seleccionar)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Indique Motivo Cancelacion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 195);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(642, 61);
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
            this.cmbTipoCancelacion.Location = new System.Drawing.Point(547, 270);
            this.cmbTipoCancelacion.Name = "cmbTipoCancelacion";
            this.cmbTipoCancelacion.Size = new System.Drawing.Size(344, 24);
            this.cmbTipoCancelacion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Indique Tipo Cancelacion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(547, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(344, 39);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar Atencion";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(547, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(344, 24);
            this.comboBox1.TabIndex = 10;
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Location = new System.Drawing.Point(15, 115);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(212, 23);
            this.btnDesmarcar.TabIndex = 11;
            this.btnDesmarcar.Text = "Deseleccionar";
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // frmCancelarAtencionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 378);
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
    }
}