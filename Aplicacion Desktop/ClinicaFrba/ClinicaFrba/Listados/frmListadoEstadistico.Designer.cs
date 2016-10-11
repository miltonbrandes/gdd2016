namespace ClinicaFrba.Listados
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
            this.btnFiltros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpAnio
            // 
            this.dtpAnio.Location = new System.Drawing.Point(580, 9);
            this.dtpAnio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpAnio.Name = "dtpAnio";
            this.dtpAnio.Size = new System.Drawing.Size(315, 22);
            this.dtpAnio.TabIndex = 32;
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AllowUserToResizeColumns = false;
            this.dgvResultado.AllowUserToResizeRows = false;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(13, 187);
            this.dgvResultado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.Size = new System.Drawing.Size(1011, 208);
            this.dgvResultado.TabIndex = 29;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(861, 402);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(163, 28);
            this.btnCalcular.TabIndex = 28;
            this.btnCalcular.Text = "Calcular Estadisticas";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
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
            this.cmbTipo.Location = new System.Drawing.Point(580, 94);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(315, 24);
            this.cmbTipo.TabIndex = 26;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 17);
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
            this.cmbSemestre.Location = new System.Drawing.Point(692, 47);
            this.cmbSemestre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(117, 24);
            this.cmbSemestre.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ingrese el año a calcular";
            // 
            // label_plan
            // 
            this.label_plan.AutoSize = true;
            this.label_plan.Location = new System.Drawing.Point(37, 144);
            this.label_plan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_plan.Name = "label_plan";
            this.label_plan.Size = new System.Drawing.Size(36, 17);
            this.label_plan.TabIndex = 33;
            this.label_plan.Text = "Plan";
            this.label_plan.Visible = false;
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(104, 140);
            this.cmbPlan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(205, 24);
            this.cmbPlan.TabIndex = 34;
            this.cmbPlan.Visible = false;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(479, 140);
            this.cmbEspecialidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(331, 24);
            this.cmbEspecialidad.TabIndex = 36;
            this.cmbEspecialidad.Visible = false;
            // 
            // label_especialidad
            // 
            this.label_especialidad.AutoSize = true;
            this.label_especialidad.Location = new System.Drawing.Point(363, 144);
            this.label_especialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_especialidad.Name = "label_especialidad";
            this.label_especialidad.Size = new System.Drawing.Size(88, 17);
            this.label_especialidad.TabIndex = 35;
            this.label_especialidad.Text = "Especialidad";
            this.label_especialidad.Visible = false;
            // 
            // btnFiltros
            // 
            this.btnFiltros.Location = new System.Drawing.Point(861, 140);
            this.btnFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(163, 28);
            this.btnFiltros.TabIndex = 37;
            this.btnFiltros.Text = "Aplicar Filtros";
            this.btnFiltros.UseVisualStyleBackColor = true;
            this.btnFiltros.Visible = false;
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // frmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 436);
            this.Controls.Add(this.btnFiltros);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button btnFiltros;
    }
}