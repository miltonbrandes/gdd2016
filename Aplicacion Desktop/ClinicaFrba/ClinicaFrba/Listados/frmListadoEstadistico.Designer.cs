﻿namespace ClinicaFrba.Listados
{
    partial class frmListadoEstadistico
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
            this.dtpAnio = new System.Windows.Forms.DateTimePicker();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSemestre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_plan = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.label_especialidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpAnio
            // 
            this.dtpAnio.Location = new System.Drawing.Point(298, 7);
            this.dtpAnio.Name = "dtpAnio";
            this.dtpAnio.Size = new System.Drawing.Size(237, 20);
            this.dtpAnio.TabIndex = 32;
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AllowUserToResizeColumns = false;
            this.dgvResultado.AllowUserToResizeRows = false;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(10, 152);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.Size = new System.Drawing.Size(632, 169);
            this.dgvResultado.TabIndex = 29;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(520, 327);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(122, 23);
            this.btnCalcular.TabIndex = 28;
            this.btnCalcular.Text = "Calcular Estadisticas";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Seleccione tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Especialidades con mas cancelaciones",
            "Profesionales mas consultados por especialidad",
            "Profesionales con menos horas trabajadas por plan y especialidad",
            "Afiliados con mas bonos comprados",
            "Especialidades con mas bonos de consulta utilizados"});
            this.cmbTipo.Location = new System.Drawing.Point(298, 76);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(237, 21);
            this.cmbTipo.TabIndex = 26;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Seleccione semestre a calcular";
            // 
            // cmbSemestre
            // 
            this.cmbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemestre.FormattingEnabled = true;
            this.cmbSemestre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbSemestre.Location = new System.Drawing.Point(372, 43);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(89, 21);
            this.cmbSemestre.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ingrese el año a calcular";
            // 
            // label_plan
            // 
            this.label_plan.AutoSize = true;
            this.label_plan.Location = new System.Drawing.Point(54, 117);
            this.label_plan.Name = "label_plan";
            this.label_plan.Size = new System.Drawing.Size(28, 13);
            this.label_plan.TabIndex = 33;
            this.label_plan.Text = "Plan";
            this.label_plan.Visible = false;
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(113, 114);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(155, 21);
            this.cmbPlan.TabIndex = 34;
            this.cmbPlan.Visible = false;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(372, 114);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(249, 21);
            this.cmbEspecialidad.TabIndex = 36;
            this.cmbEspecialidad.Visible = false;
            // 
            // label_especialidad
            // 
            this.label_especialidad.AutoSize = true;
            this.label_especialidad.Location = new System.Drawing.Point(295, 117);
            this.label_especialidad.Name = "label_especialidad";
            this.label_especialidad.Size = new System.Drawing.Size(67, 13);
            this.label_especialidad.TabIndex = 35;
            this.label_especialidad.Text = "Especialidad";
            this.label_especialidad.Visible = false;
            // 
            // frmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 354);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.label_especialidad);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.label_plan);
            this.Controls.Add(this.dtpAnio);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSemestre);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.frmListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAnio;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSemestre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_plan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label label_especialidad;
    }
}