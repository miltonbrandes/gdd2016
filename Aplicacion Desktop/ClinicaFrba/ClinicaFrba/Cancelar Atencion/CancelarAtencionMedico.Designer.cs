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
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbTipoCancelacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.drop_fecha = new System.Windows.Forms.ComboBox();
            this.hora1 = new System.Windows.Forms.TextBox();
            this.minuto1 = new System.Windows.Forms.TextBox();
            this.hora2 = new System.Windows.Forms.TextBox();
            this.minuto2 = new System.Windows.Forms.TextBox();
            this.hora_desde = new System.Windows.Forms.Label();
            this.hora_hasta = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.chk_fecha = new System.Windows.Forms.CheckBox();
            this.chk_horario = new System.Windows.Forms.CheckBox();
            this.chk_dias = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Location = new System.Drawing.Point(44, 97);
            this.lbl_fecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(37, 13);
            this.lbl_fecha.TabIndex = 0;
            this.lbl_fecha.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Indique Motivo Cancelacion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(293, 247);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(470, 50);
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
            this.cmbTipoCancelacion.Location = new System.Drawing.Point(134, 42);
            this.cmbTipoCancelacion.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoCancelacion.Name = "cmbTipoCancelacion";
            this.cmbTipoCancelacion.Size = new System.Drawing.Size(130, 21);
            this.cmbTipoCancelacion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo Cancelacion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(273, 337);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(258, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar Atencion";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // drop_fecha
            // 
            this.drop_fecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drop_fecha.FormattingEnabled = true;
            this.drop_fecha.Location = new System.Drawing.Point(134, 94);
            this.drop_fecha.Margin = new System.Windows.Forms.Padding(2);
            this.drop_fecha.Name = "drop_fecha";
            this.drop_fecha.Size = new System.Drawing.Size(130, 21);
            this.drop_fecha.TabIndex = 10;
            // 
            // hora1
            // 
            this.hora1.Location = new System.Drawing.Point(134, 127);
            this.hora1.Name = "hora1";
            this.hora1.Size = new System.Drawing.Size(62, 20);
            this.hora1.TabIndex = 12;
            // 
            // minuto1
            // 
            this.minuto1.Location = new System.Drawing.Point(202, 127);
            this.minuto1.Name = "minuto1";
            this.minuto1.Size = new System.Drawing.Size(62, 20);
            this.minuto1.TabIndex = 13;
            // 
            // hora2
            // 
            this.hora2.Location = new System.Drawing.Point(134, 153);
            this.hora2.Name = "hora2";
            this.hora2.Size = new System.Drawing.Size(62, 20);
            this.hora2.TabIndex = 14;
            // 
            // minuto2
            // 
            this.minuto2.Location = new System.Drawing.Point(202, 154);
            this.minuto2.Name = "minuto2";
            this.minuto2.Size = new System.Drawing.Size(62, 20);
            this.minuto2.TabIndex = 15;
            // 
            // hora_desde
            // 
            this.hora_desde.AutoSize = true;
            this.hora_desde.Location = new System.Drawing.Point(35, 127);
            this.hora_desde.Name = "hora_desde";
            this.hora_desde.Size = new System.Drawing.Size(62, 13);
            this.hora_desde.TabIndex = 16;
            this.hora_desde.Text = "Hora desde";
            // 
            // hora_hasta
            // 
            this.hora_hasta.AutoSize = true;
            this.hora_hasta.Location = new System.Drawing.Point(35, 153);
            this.hora_hasta.Name = "hora_hasta";
            this.hora_hasta.Size = new System.Drawing.Size(59, 13);
            this.hora_hasta.TabIndex = 17;
            this.hora_hasta.Text = "Hora hasta";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(620, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Fecha Fin";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(365, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Fecha Inicio";
            this.label11.Visible = false;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(536, 40);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 39;
            this.monthCalendar2.Visible = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(293, 40);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 38;
            this.monthCalendar1.Visible = false;
            // 
            // chk_fecha
            // 
            this.chk_fecha.AutoSize = true;
            this.chk_fecha.Location = new System.Drawing.Point(293, 214);
            this.chk_fecha.Name = "chk_fecha";
            this.chk_fecha.Size = new System.Drawing.Size(107, 17);
            this.chk_fecha.TabIndex = 42;
            this.chk_fecha.Text = "Fecha especifica";
            this.chk_fecha.UseVisualStyleBackColor = true;
            this.chk_fecha.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chk_horario
            // 
            this.chk_horario.AutoSize = true;
            this.chk_horario.Location = new System.Drawing.Point(446, 214);
            this.chk_horario.Name = "chk_horario";
            this.chk_horario.Size = new System.Drawing.Size(111, 17);
            this.chk_horario.TabIndex = 43;
            this.chk_horario.Text = "Horario especifico";
            this.chk_horario.UseVisualStyleBackColor = true;
            this.chk_horario.CheckedChanged += new System.EventHandler(this.chk_horario_CheckedChanged);
            // 
            // chk_dias
            // 
            this.chk_dias.AutoSize = true;
            this.chk_dias.Location = new System.Drawing.Point(597, 214);
            this.chk_dias.Name = "chk_dias";
            this.chk_dias.Size = new System.Drawing.Size(95, 17);
            this.chk_dias.TabIndex = 44;
            this.chk_dias.Text = "Rango de dias";
            this.chk_dias.UseVisualStyleBackColor = true;
            this.chk_dias.CheckedChanged += new System.EventHandler(this.chk_dias_CheckedChanged);
            // 
            // frmCancelarAtencionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 380);
            this.Controls.Add(this.chk_dias);
            this.Controls.Add(this.chk_horario);
            this.Controls.Add(this.chk_fecha);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.hora_hasta);
            this.Controls.Add(this.hora_desde);
            this.Controls.Add(this.minuto2);
            this.Controls.Add(this.hora2);
            this.Controls.Add(this.minuto1);
            this.Controls.Add(this.hora1);
            this.Controls.Add(this.drop_fecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipoCancelacion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_fecha);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCancelarAtencionMedico";
            this.Text = "Cancelar Atencion";
            this.Load += new System.EventHandler(this.frmCancelarAtencionMedico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbTipoCancelacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox drop_fecha;
        private System.Windows.Forms.TextBox hora1;
        private System.Windows.Forms.TextBox minuto1;
        private System.Windows.Forms.TextBox hora2;
        private System.Windows.Forms.TextBox minuto2;
        private System.Windows.Forms.Label hora_desde;
        private System.Windows.Forms.Label hora_hasta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.CheckBox chk_fecha;
        private System.Windows.Forms.CheckBox chk_horario;
        private System.Windows.Forms.CheckBox chk_dias;
    }
}