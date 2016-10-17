namespace ClinicaFrba.Abm_Afiliado
{
    partial class frmHistorialModificaciones
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
            this.gD2C2016DataSet = new ClinicaFrba.Abm_Profesional.GD2C2016DataSet();
            this.modifPlanGetAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modif_Plan_Get_AllTableAdapter = new ClinicaFrba.Abm_Profesional.GD2C2016DataSetTableAdapters.Modif_Plan_Get_AllTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.afiliadonombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afiliadoapellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifmotivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifplanfechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plandescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plandescripcion1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifPlanGetAllBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gD2C2016DataSet1 = new ClinicaFrba.Abm_Profesional.GD2C2016DataSet1();
            this.modif_Plan_Get_AllTableAdapter1 = new ClinicaFrba.Abm_Profesional.GD2C2016DataSet1TableAdapters.Modif_Plan_Get_AllTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifPlanGetAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifPlanGetAllBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // gD2C2016DataSet
            // 
            this.gD2C2016DataSet.DataSetName = "GD2C2016DataSet";
            this.gD2C2016DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // modifPlanGetAllBindingSource
            // 
            this.modifPlanGetAllBindingSource.DataMember = "Modif_Plan_Get_All";
            this.modifPlanGetAllBindingSource.DataSource = this.gD2C2016DataSet;
            // 
            // modif_Plan_Get_AllTableAdapter
            // 
            this.modif_Plan_Get_AllTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.afiliadonombreDataGridViewTextBoxColumn,
            this.afiliadoapellidoDataGridViewTextBoxColumn,
            this.modifmotivoDataGridViewTextBoxColumn,
            this.modifplanfechaDataGridViewTextBoxColumn,
            this.plandescripcionDataGridViewTextBoxColumn,
            this.plandescripcion1DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.modifPlanGetAllBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(863, 299);
            this.dataGridView1.TabIndex = 0;
            // 
            // afiliadonombreDataGridViewTextBoxColumn
            // 
            this.afiliadonombreDataGridViewTextBoxColumn.DataPropertyName = "afiliado_nombre";
            this.afiliadonombreDataGridViewTextBoxColumn.HeaderText = "Nombre Afiliado";
            this.afiliadonombreDataGridViewTextBoxColumn.Name = "afiliadonombreDataGridViewTextBoxColumn";
            this.afiliadonombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.afiliadonombreDataGridViewTextBoxColumn.Width = 122;
            // 
            // afiliadoapellidoDataGridViewTextBoxColumn
            // 
            this.afiliadoapellidoDataGridViewTextBoxColumn.DataPropertyName = "afiliado_apellido";
            this.afiliadoapellidoDataGridViewTextBoxColumn.HeaderText = "Apellido Afiliado";
            this.afiliadoapellidoDataGridViewTextBoxColumn.Name = "afiliadoapellidoDataGridViewTextBoxColumn";
            this.afiliadoapellidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.afiliadoapellidoDataGridViewTextBoxColumn.Width = 122;
            // 
            // modifmotivoDataGridViewTextBoxColumn
            // 
            this.modifmotivoDataGridViewTextBoxColumn.DataPropertyName = "modif_motivo";
            this.modifmotivoDataGridViewTextBoxColumn.HeaderText = "Motivo Cambio Plan";
            this.modifmotivoDataGridViewTextBoxColumn.Name = "modifmotivoDataGridViewTextBoxColumn";
            this.modifmotivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.modifmotivoDataGridViewTextBoxColumn.Width = 118;
            // 
            // modifplanfechaDataGridViewTextBoxColumn
            // 
            this.modifplanfechaDataGridViewTextBoxColumn.DataPropertyName = "modif_plan_fecha";
            this.modifplanfechaDataGridViewTextBoxColumn.HeaderText = "Fecha Cambio Plan";
            this.modifplanfechaDataGridViewTextBoxColumn.Name = "modifplanfechaDataGridViewTextBoxColumn";
            this.modifplanfechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.modifplanfechaDataGridViewTextBoxColumn.Width = 116;
            // 
            // plandescripcionDataGridViewTextBoxColumn
            // 
            this.plandescripcionDataGridViewTextBoxColumn.DataPropertyName = "plan_descripcion";
            this.plandescripcionDataGridViewTextBoxColumn.HeaderText = "Plan Nuevo Elegido";
            this.plandescripcionDataGridViewTextBoxColumn.Name = "plandescripcionDataGridViewTextBoxColumn";
            this.plandescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.plandescripcionDataGridViewTextBoxColumn.Width = 143;
            // 
            // plandescripcion1DataGridViewTextBoxColumn
            // 
            this.plandescripcion1DataGridViewTextBoxColumn.DataPropertyName = "plan_descripcion1";
            this.plandescripcion1DataGridViewTextBoxColumn.HeaderText = "Plan Viejo";
            this.plandescripcion1DataGridViewTextBoxColumn.Name = "plandescripcion1DataGridViewTextBoxColumn";
            this.plandescripcion1DataGridViewTextBoxColumn.ReadOnly = true;
            this.plandescripcion1DataGridViewTextBoxColumn.Width = 88;
            // 
            // modifPlanGetAllBindingSource1
            // 
            this.modifPlanGetAllBindingSource1.DataMember = "Modif_Plan_Get_All";
            this.modifPlanGetAllBindingSource1.DataSource = this.gD2C2016DataSet1;
            // 
            // gD2C2016DataSet1
            // 
            this.gD2C2016DataSet1.DataSetName = "GD2C2016DataSet1";
            this.gD2C2016DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // modif_Plan_Get_AllTableAdapter1
            // 
            this.modif_Plan_Get_AllTableAdapter1.ClearBeforeFill = true;
            // 
            // frmHistorialModificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 324);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmHistorialModificaciones";
            this.Text = "frmHistorialModificaciones";
            this.Load += new System.EventHandler(this.frmHistorialModificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifPlanGetAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifPlanGetAllBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2016DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Abm_Profesional.GD2C2016DataSet gD2C2016DataSet;
        private System.Windows.Forms.BindingSource modifPlanGetAllBindingSource;
        private Abm_Profesional.GD2C2016DataSetTableAdapters.Modif_Plan_Get_AllTableAdapter modif_Plan_Get_AllTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Abm_Profesional.GD2C2016DataSet1 gD2C2016DataSet1;
        private System.Windows.Forms.BindingSource modifPlanGetAllBindingSource1;
        private Abm_Profesional.GD2C2016DataSet1TableAdapters.Modif_Plan_Get_AllTableAdapter modif_Plan_Get_AllTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn afiliadonombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afiliadoapellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifmotivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifplanfechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plandescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plandescripcion1DataGridViewTextBoxColumn;
    }
}