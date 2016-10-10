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
            //this.get_MedicoXEsp_AllTableAdapter = new ClinicaFrba.GD2C2016DataSet2TableAdapters.Get_MedicoXEsp_AllTableAdapter();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.get_Especialidades_AllTableAdapter = new ClinicaFrba.GD2C2016DataSet3TableAdapters.Get_Especialidades_AllTableAdapter();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.getMedicoXEspAllBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.get_MedicoXEsp_AllTableAdapter1 = new ClinicaFrba.GD2C2016DataSet4TableAdapters.Get_MedicoXEsp_AllTableAdapter();
            this.get_MedicoXEsp_AllTableAdapter2 = new ClinicaFrba.GD2C2016DataSet5TableAdapters.Get_MedicoXEsp_AllTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTraerTurnos = new System.Windows.Forms.Button();
            this.txtNroAfiliado = new System.Windows.Forms.TextBox();
            this.gD2C2016DataSet6 = new ClinicaFrba.GD2C2016DataSet6();
            this.getTurnosTodayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.get_Turnos_TodayTableAdapter = new ClinicaFrba.GD2C2016DataSet6TableAdapters.Get_Turnos_TodayTableAdapter();
            this.turnonroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afiliadonroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnofechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoestadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnohorallegadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnosintomasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoenfermedadesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnomedicoespecialidadidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoXEspecialidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getEspecialidadesAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getTurnosTodayBindingSource)).BeginInit();
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
            this.dgvMedicoXEspecialidad.Location = new System.Drawing.Point(12, 42);
            this.dgvMedicoXEspecialidad.Name = "dgvMedicoXEspecialidad";
            this.dgvMedicoXEspecialidad.ReadOnly = true;
            this.dgvMedicoXEspecialidad.RowTemplate.Height = 24;
            this.dgvMedicoXEspecialidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicoXEspecialidad.Size = new System.Drawing.Size(680, 459);
            this.dgvMedicoXEspecialidad.TabIndex = 0;
            this.dgvMedicoXEspecialidad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicoXEspecialidad_CellContentClick);
            this.dgvMedicoXEspecialidad.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicoXEspecialidad_CellContentDoubleClick);
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
            this.cmbEspecialidades.Location = new System.Drawing.Point(180, 12);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(273, 24);
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
            // get_MedicoXEsp_AllTableAdapter
            // 
           // this.get_MedicoXEsp_AllTableAdapter.ClearBeforeFill = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(459, 12);
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
            this.dgvTurnos.AutoGenerateColumns = false;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.turnonroDataGridViewTextBoxColumn,
            this.afiliadonroDataGridViewTextBoxColumn,
            this.turnofechaDataGridViewTextBoxColumn,
            this.turnoestadoDataGridViewTextBoxColumn,
            this.turnohorallegadaDataGridViewTextBoxColumn,
            this.turnosintomasDataGridViewTextBoxColumn,
            this.turnoenfermedadesDataGridViewTextBoxColumn,
            this.turnomedicoespecialidadidDataGridViewTextBoxColumn});
            this.dgvTurnos.DataSource = this.getTurnosTodayBindingSource;
            this.dgvTurnos.Location = new System.Drawing.Point(698, 42);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.RowTemplate.Height = 24;
            this.dgvTurnos.Size = new System.Drawing.Size(623, 459);
            this.dgvTurnos.TabIndex = 4;
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
            this.label2.Location = new System.Drawing.Point(698, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingrese el nro de afiliado";
            // 
            // btnTraerTurnos
            // 
            this.btnTraerTurnos.Location = new System.Drawing.Point(1088, 12);
            this.btnTraerTurnos.Name = "btnTraerTurnos";
            this.btnTraerTurnos.Size = new System.Drawing.Size(233, 24);
            this.btnTraerTurnos.TabIndex = 6;
            this.btnTraerTurnos.Text = "Traer Turnos";
            this.btnTraerTurnos.UseVisualStyleBackColor = true;
            this.btnTraerTurnos.Click += new System.EventHandler(this.btnTraerTurnos_Click);
            // 
            // txtNroAfiliado
            // 
            this.txtNroAfiliado.Location = new System.Drawing.Point(868, 13);
            this.txtNroAfiliado.Name = "txtNroAfiliado";
            this.txtNroAfiliado.Size = new System.Drawing.Size(214, 22);
            this.txtNroAfiliado.TabIndex = 7;
            // 
            // gD2C2016DataSet6
            // 
            this.gD2C2016DataSet6.DataSetName = "GD2C2016DataSet6";
            this.gD2C2016DataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getTurnosTodayBindingSource
            // 
            this.getTurnosTodayBindingSource.DataMember = "Get_Turnos_Today";
            this.getTurnosTodayBindingSource.DataSource = this.gD2C2016DataSet6;
            // 
            // get_Turnos_TodayTableAdapter
            // 
            this.get_Turnos_TodayTableAdapter.ClearBeforeFill = true;
            // 
            // turnonroDataGridViewTextBoxColumn
            // 
            this.turnonroDataGridViewTextBoxColumn.DataPropertyName = "turno_nro";
            this.turnonroDataGridViewTextBoxColumn.HeaderText = "turno_nro";
            this.turnonroDataGridViewTextBoxColumn.Name = "turnonroDataGridViewTextBoxColumn";
            // 
            // afiliadonroDataGridViewTextBoxColumn
            // 
            this.afiliadonroDataGridViewTextBoxColumn.DataPropertyName = "afiliado_nro";
            this.afiliadonroDataGridViewTextBoxColumn.HeaderText = "afiliado_nro";
            this.afiliadonroDataGridViewTextBoxColumn.Name = "afiliadonroDataGridViewTextBoxColumn";
            // 
            // turnofechaDataGridViewTextBoxColumn
            // 
            this.turnofechaDataGridViewTextBoxColumn.DataPropertyName = "turno_fecha";
            this.turnofechaDataGridViewTextBoxColumn.HeaderText = "turno_fecha";
            this.turnofechaDataGridViewTextBoxColumn.Name = "turnofechaDataGridViewTextBoxColumn";
            // 
            // turnoestadoDataGridViewTextBoxColumn
            // 
            this.turnoestadoDataGridViewTextBoxColumn.DataPropertyName = "turno_estado";
            this.turnoestadoDataGridViewTextBoxColumn.HeaderText = "turno_estado";
            this.turnoestadoDataGridViewTextBoxColumn.Name = "turnoestadoDataGridViewTextBoxColumn";
            // 
            // turnohorallegadaDataGridViewTextBoxColumn
            // 
            this.turnohorallegadaDataGridViewTextBoxColumn.DataPropertyName = "turno_hora_llegada";
            this.turnohorallegadaDataGridViewTextBoxColumn.HeaderText = "turno_hora_llegada";
            this.turnohorallegadaDataGridViewTextBoxColumn.Name = "turnohorallegadaDataGridViewTextBoxColumn";
            // 
            // turnosintomasDataGridViewTextBoxColumn
            // 
            this.turnosintomasDataGridViewTextBoxColumn.DataPropertyName = "turno_sintomas";
            this.turnosintomasDataGridViewTextBoxColumn.HeaderText = "turno_sintomas";
            this.turnosintomasDataGridViewTextBoxColumn.Name = "turnosintomasDataGridViewTextBoxColumn";
            // 
            // turnoenfermedadesDataGridViewTextBoxColumn
            // 
            this.turnoenfermedadesDataGridViewTextBoxColumn.DataPropertyName = "turno_enfermedades";
            this.turnoenfermedadesDataGridViewTextBoxColumn.HeaderText = "turno_enfermedades";
            this.turnoenfermedadesDataGridViewTextBoxColumn.Name = "turnoenfermedadesDataGridViewTextBoxColumn";
            // 
            // turnomedicoespecialidadidDataGridViewTextBoxColumn
            // 
            this.turnomedicoespecialidadidDataGridViewTextBoxColumn.DataPropertyName = "turno_medico_especialidad_id";
            this.turnomedicoespecialidadidDataGridViewTextBoxColumn.HeaderText = "turno_medico_especialidad_id";
            this.turnomedicoespecialidadidDataGridViewTextBoxColumn.Name = "turnomedicoespecialidadidDataGridViewTextBoxColumn";
            // 
            // frmLlegadaPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 513);
            this.Controls.Add(this.txtNroAfiliado);
            this.Controls.Add(this.btnTraerTurnos);
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
            ((System.ComponentModel.ISupportInitialize)(this.getMedicoXEspAllBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getTurnosTodayBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnTraerTurnos;
        private System.Windows.Forms.TextBox txtNroAfiliado;
        private GD2C2016DataSet6 gD2C2016DataSet6;
        private System.Windows.Forms.BindingSource getTurnosTodayBindingSource;
        private GD2C2016DataSet6TableAdapters.Get_Turnos_TodayTableAdapter get_Turnos_TodayTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnonroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afiliadonroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnofechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoestadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnohorallegadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnosintomasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoenfermedadesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnomedicoespecialidadidDataGridViewTextBoxColumn;
    }
}