namespace ClinicaFrba.Registro_Llegada
{
    partial class frmLlegadaPaciente
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
            this.components = new System.ComponentModel.Container();
            this.dgvMedicoXEspecialidad = new System.Windows.Forms.DataGridView();
            this.medxespidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesionalnombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesionalapellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesionaldireccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidaddescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getMedicoXEspAllBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.gD2C2016DataSet5 = new ClinicaFrba.GD2C2016DataSet5();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.getEspecialidadesAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD2C2016DataSet3 = new ClinicaFrba.GD2C2016DataSet3();
            this.getMedicoXEspAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.get_Especialidades_AllTableAdapter = new ClinicaFrba.GD2C2016DataSet3TableAdapters.Get_Especialidades_AllTableAdapter();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.getTurnosTodayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD2C2016DataSet6 = new ClinicaFrba.GD2C2016DataSet6();
            this.getMedicoXEspAllBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.get_MedicoXEsp_AllTableAdapter1 = new ClinicaFrba.GD2C2016DataSet4TableAdapters.Get_MedicoXEsp_AllTableAdapter();
            this.get_MedicoXEsp_AllTableAdapter2 = new ClinicaFrba.GD2C2016DataSet5TableAdapters.Get_MedicoXEsp_AllTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroAfiliado = new System.Windows.Forms.TextBox();
            this.get_Turnos_TodayTableAdapter = new ClinicaFrba.GD2C2016DataSet6TableAdapters.Get_Turnos_TodayTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoXEspecialidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getEspecialidadesAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getTurnosTodayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMedicoXEspecialidad
            // 
            this.dgvMedicoXEspecialidad.AutoGenerateColumns = false;
            this.dgvMedicoXEspecialidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicoXEspecialidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medxespidDataGridViewTextBoxColumn,
            this.profesionalnombreDataGridViewTextBoxColumn,
            this.profesionalapellidoDataGridViewTextBoxColumn,
            this.profesionaldireccionDataGridViewTextBoxColumn,
            this.especialidaddescripcionDataGridViewTextBoxColumn});
            this.dgvMedicoXEspecialidad.DataSource = this.getMedicoXEspAllBindingSource2;
            this.dgvMedicoXEspecialidad.Location = new System.Drawing.Point(12, 108);
            this.dgvMedicoXEspecialidad.Name = "dgvMedicoXEspecialidad";
            this.dgvMedicoXEspecialidad.ReadOnly = true;
            this.dgvMedicoXEspecialidad.RowTemplate.Height = 24;
            this.dgvMedicoXEspecialidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicoXEspecialidad.Size = new System.Drawing.Size(680, 393);
            this.dgvMedicoXEspecialidad.TabIndex = 0;
            this.dgvMedicoXEspecialidad.DoubleClick += new System.EventHandler(this.dgvMedicoXEspecialidad_DoubleClick);
            // 
            // medxespidDataGridViewTextBoxColumn
            // 
            this.medxespidDataGridViewTextBoxColumn.DataPropertyName = "medxesp_id";
            this.medxespidDataGridViewTextBoxColumn.HeaderText = "medxesp_id";
            this.medxespidDataGridViewTextBoxColumn.Name = "medxespidDataGridViewTextBoxColumn";
            this.medxespidDataGridViewTextBoxColumn.ReadOnly = true;
            this.medxespidDataGridViewTextBoxColumn.Visible = false;
            // 
            // profesionalnombreDataGridViewTextBoxColumn
            // 
            this.profesionalnombreDataGridViewTextBoxColumn.DataPropertyName = "profesional_nombre";
            this.profesionalnombreDataGridViewTextBoxColumn.HeaderText = "Nombre Medico";
            this.profesionalnombreDataGridViewTextBoxColumn.Name = "profesionalnombreDataGridViewTextBoxColumn";
            this.profesionalnombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profesionalapellidoDataGridViewTextBoxColumn
            // 
            this.profesionalapellidoDataGridViewTextBoxColumn.DataPropertyName = "profesional_apellido";
            this.profesionalapellidoDataGridViewTextBoxColumn.HeaderText = "Apellido Medico";
            this.profesionalapellidoDataGridViewTextBoxColumn.Name = "profesionalapellidoDataGridViewTextBoxColumn";
            this.profesionalapellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profesionaldireccionDataGridViewTextBoxColumn
            // 
            this.profesionaldireccionDataGridViewTextBoxColumn.DataPropertyName = "profesional_direccion";
            this.profesionaldireccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.profesionaldireccionDataGridViewTextBoxColumn.Name = "profesionaldireccionDataGridViewTextBoxColumn";
            this.profesionaldireccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.profesionaldireccionDataGridViewTextBoxColumn.Width = 150;
            // 
            // especialidaddescripcionDataGridViewTextBoxColumn
            // 
            this.especialidaddescripcionDataGridViewTextBoxColumn.DataPropertyName = "especialidad_descripcion";
            this.especialidaddescripcionDataGridViewTextBoxColumn.HeaderText = "Especialidad";
            this.especialidaddescripcionDataGridViewTextBoxColumn.Name = "especialidaddescripcionDataGridViewTextBoxColumn";
            this.especialidaddescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // getMedicoXEspAllBindingSource2
            // 
            this.getMedicoXEspAllBindingSource2.DataMember = "Get_MedicoXEsp_All";
            this.getMedicoXEspAllBindingSource2.DataSource = this.gD2C2016DataSet5;
            // 
            // gD2C2016DataSet5
            // 
            this.gD2C2016DataSet5.DataSetName = "GD2C2016DataSet5";
            this.gD2C2016DataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.getEspecialidadesAllBindingSource, "especialidad_descripcion", true));
            this.cmbEspecialidades.DataSource = this.getEspecialidadesAllBindingSource;
            this.cmbEspecialidades.DisplayMember = "especialidad_descripcion";
            this.cmbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(193, 12);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(260, 24);
            this.cmbEspecialidades.TabIndex = 1;
            this.cmbEspecialidades.ValueMember = "especialidad_descripcion";
            // 
            // getEspecialidadesAllBindingSource
            // 
            this.getEspecialidadesAllBindingSource.DataMember = "Get_Especialidades_All";
            this.getEspecialidadesAllBindingSource.DataSource = this.gD2C2016DataSet3;
            // 
            // gD2C2016DataSet3
            // 
            this.gD2C2016DataSet3.DataSetName = "GD2C2016DataSet3";
            this.gD2C2016DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(459, 42);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(233, 24);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione Especialidad";
            // 
            // get_Especialidades_AllTableAdapter
            // 
            this.get_Especialidades_AllTableAdapter.ClearBeforeFill = true;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(698, 56);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.RowTemplate.Height = 24;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(623, 445);
            this.dgvTurnos.TabIndex = 4;
            this.dgvTurnos.DoubleClick += new System.EventHandler(this.dgvTurnos_DoubleClick);
            // 
            // getTurnosTodayBindingSource
            // 
            this.getTurnosTodayBindingSource.DataMember = "Get_Turnos_Today";
            this.getTurnosTodayBindingSource.DataSource = this.gD2C2016DataSet6;
            // 
            // gD2C2016DataSet6
            // 
            this.gD2C2016DataSet6.DataSetName = "GD2C2016DataSet6";
            this.gD2C2016DataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // get_MedicoXEsp_AllTableAdapter1
            // 
            this.get_MedicoXEsp_AllTableAdapter1.ClearBeforeFill = true;
            // 
            // get_MedicoXEsp_AllTableAdapter2
            // 
            this.get_MedicoXEsp_AllTableAdapter2.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(698, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingrese el nro de afiliado";
            // 
            // txtNroAfiliado
            // 
            this.txtNroAfiliado.Location = new System.Drawing.Point(868, 28);
            this.txtNroAfiliado.Name = "txtNroAfiliado";
            this.txtNroAfiliado.Size = new System.Drawing.Size(210, 22);
            this.txtNroAfiliado.TabIndex = 7;
            this.txtNroAfiliado.TextChanged += new System.EventHandler(this.txtNroAfiliado_TextChanged);
            // 
            // get_Turnos_TodayTableAdapter
            // 
            this.get_Turnos_TodayTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(698, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hacer Doble Click sobre la fila para marcar que llego";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seleccione Apellido Medico";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(193, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(260, 22);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Seleccione Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 514);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Hacer Doble Click para seleccionar medico";
            // 
            // frmLlegadaPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 540);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNroAfiliado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cmbEspecialidades);
            this.Controls.Add(this.dgvMedicoXEspecialidad);
            this.Name = "frmLlegadaPaciente";
            this.Text = "Registro Llegada Paciente";
            this.Load += new System.EventHandler(this.frmLlegadaPaciente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoXEspecialidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getEspecialidadesAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getTurnosTodayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedicoXEspecialidad;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.BindingSource getMedicoXEspAllBindingSource;
        //private GD2C2016DataSet2TableAdapters.Get_MedicoXEsp_AllTableAdapter get_MedicoXEsp_AllTableAdapter;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label1;
        private GD2C2016DataSet3 gD2C2016DataSet3;
        private System.Windows.Forms.BindingSource getEspecialidadesAllBindingSource;
        private GD2C2016DataSet3TableAdapters.Get_Especialidades_AllTableAdapter get_Especialidades_AllTableAdapter;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.BindingSource getMedicoXEspAllBindingSource1;
        private GD2C2016DataSet4TableAdapters.Get_MedicoXEsp_AllTableAdapter get_MedicoXEsp_AllTableAdapter1;
        private GD2C2016DataSet5 gD2C2016DataSet5;
        private System.Windows.Forms.BindingSource getMedicoXEspAllBindingSource2;
        private GD2C2016DataSet5TableAdapters.Get_MedicoXEsp_AllTableAdapter get_MedicoXEsp_AllTableAdapter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn medxespidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesionalnombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesionalapellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesionaldireccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidaddescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroAfiliado;
        private GD2C2016DataSet6 gD2C2016DataSet6;
        private System.Windows.Forms.BindingSource getTurnosTodayBindingSource;
        private GD2C2016DataSet6TableAdapters.Get_Turnos_TodayTableAdapter get_Turnos_TodayTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}