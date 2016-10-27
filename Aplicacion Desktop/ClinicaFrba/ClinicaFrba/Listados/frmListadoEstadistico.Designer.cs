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
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.label_filtro = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpAnio
            // 
            this.dtpAnio.Location = new System.Drawing.Point(397, 17);
            this.dtpAnio.Margin = new System.Windows.Forms.Padding(4);
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
            this.dgvResultado.Margin = new System.Windows.Forms.Padding(4);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.Size = new System.Drawing.Size(843, 208);
            this.dgvResultado.TabIndex = 29;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(693, 402);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4);
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
            this.label3.Location = new System.Drawing.Point(147, 117);
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
            "Profesionales mas consultados por plan",
            "Profesionales con menos horas trabajadas por especialidad",
            "Afiliados con mas bonos comprados",
            "Especialidades con mas bonos de consulta utilizados"});
            this.cmbTipo.Location = new System.Drawing.Point(397, 114);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(315, 24);
            this.cmbTipo.TabIndex = 26;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 60);
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
            this.cmbSemestre.Location = new System.Drawing.Point(495, 53);
            this.cmbSemestre.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSemestre.Name = "cmbSemestre";
            this.cmbSemestre.Size = new System.Drawing.Size(117, 24);
            this.cmbSemestre.TabIndex = 24;
            this.cmbSemestre.SelectedIndexChanged += new System.EventHandler(this.cmbSemestre_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ingrese el año a calcular";
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(397, 141);
            this.cmb_filtro.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(315, 24);
            this.cmb_filtro.TabIndex = 36;
            this.cmb_filtro.Visible = false;
            // 
            // label_filtro
            // 
            this.label_filtro.AutoSize = true;
            this.label_filtro.Location = new System.Drawing.Point(147, 144);
            this.label_filtro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_filtro.Name = "label_filtro";
            this.label_filtro.Size = new System.Drawing.Size(88, 17);
            this.label_filtro.TabIndex = 35;
            this.label_filtro.Text = "Especialidad";
            this.label_filtro.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(495, 82);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 24);
            this.comboBox1.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Seleccione mes a calcular";
            // 
            // frmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 436);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmb_filtro);
            this.Controls.Add(this.label_filtro);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListadoEstadistico_FormClosed);
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
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Label label_filtro;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}