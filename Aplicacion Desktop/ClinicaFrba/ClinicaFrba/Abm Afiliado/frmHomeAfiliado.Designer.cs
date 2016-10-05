namespace ClinicaFrba.Abm_Afiliado
{
    partial class frmHomeAfiliado
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHistorialCambiosPlan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBajaAfiliado = new System.Windows.Forms.Button();
            this.btnTodosAfiliados = new System.Windows.Forms.Button();
            this.btnFiltrarAfiliados = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.dgvAfiliado = new System.Windows.Forms.DataGridView();
            this.txtMailAfiliado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(28, 57);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(135, 28);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHistorialCambiosPlan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBajaAfiliado);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnTodosAfiliados);
            this.groupBox1.Controls.Add(this.btnFiltrarAfiliados);
            this.groupBox1.Controls.Add(this.btnAlta);
            this.groupBox1.Controls.Add(this.dgvAfiliado);
            this.groupBox1.Controls.Add(this.txtMailAfiliado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(960, 489);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afiliado";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnHistorialCambiosPlan
            // 
            this.btnHistorialCambiosPlan.Location = new System.Drawing.Point(181, 452);
            this.btnHistorialCambiosPlan.Name = "btnHistorialCambiosPlan";
            this.btnHistorialCambiosPlan.Size = new System.Drawing.Size(188, 28);
            this.btnHistorialCambiosPlan.TabIndex = 17;
            this.btnHistorialCambiosPlan.Text = "Ver Historial Cambios Plan";
            this.btnHistorialCambiosPlan.UseVisualStyleBackColor = true;
            this.btnHistorialCambiosPlan.Click += new System.EventHandler(this.btnHistorialCambiosPlan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(692, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Hacer Doble Click para modificar";
            // 
            // btnBajaAfiliado
            // 
            this.btnBajaAfiliado.Location = new System.Drawing.Point(28, 452);
            this.btnBajaAfiliado.Margin = new System.Windows.Forms.Padding(4);
            this.btnBajaAfiliado.Name = "btnBajaAfiliado";
            this.btnBajaAfiliado.Size = new System.Drawing.Size(146, 28);
            this.btnBajaAfiliado.TabIndex = 20;
            this.btnBajaAfiliado.Text = "Dar De Baja Afiliado";
            this.btnBajaAfiliado.UseVisualStyleBackColor = true;
            this.btnBajaAfiliado.Click += new System.EventHandler(this.btnBajaAfiliado_Click);
            // 
            // btnTodosAfiliados
            // 
            this.btnTodosAfiliados.Location = new System.Drawing.Point(775, 55);
            this.btnTodosAfiliados.Margin = new System.Windows.Forms.Padding(4);
            this.btnTodosAfiliados.Name = "btnTodosAfiliados";
            this.btnTodosAfiliados.Size = new System.Drawing.Size(131, 28);
            this.btnTodosAfiliados.TabIndex = 13;
            this.btnTodosAfiliados.Text = "Mostrar todos";
            this.btnTodosAfiliados.UseVisualStyleBackColor = true;
            this.btnTodosAfiliados.Click += new System.EventHandler(this.btnTodosAfiliados_Click);
            // 
            // btnFiltrarAfiliados
            // 
            this.btnFiltrarAfiliados.Location = new System.Drawing.Point(775, 23);
            this.btnFiltrarAfiliados.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltrarAfiliados.Name = "btnFiltrarAfiliados";
            this.btnFiltrarAfiliados.Size = new System.Drawing.Size(131, 28);
            this.btnFiltrarAfiliados.TabIndex = 12;
            this.btnFiltrarAfiliados.Text = "Filtrar Afiliados";
            this.btnFiltrarAfiliados.UseVisualStyleBackColor = true;
            this.btnFiltrarAfiliados.Click += new System.EventHandler(this.btnFiltrarAfiliados_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(28, 25);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(135, 28);
            this.btnAlta.TabIndex = 15;
            this.btnAlta.Text = "Alta Afiliado";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // dgvAfiliado
            // 
            this.dgvAfiliado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAfiliado.Location = new System.Drawing.Point(28, 93);
            this.dgvAfiliado.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAfiliado.Name = "dgvAfiliado";
            this.dgvAfiliado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAfiliado.Size = new System.Drawing.Size(878, 351);
            this.dgvAfiliado.TabIndex = 11;
            this.dgvAfiliado.DoubleClick += new System.EventHandler(this.dgvAfiliado_DoubleClick);
            // 
            // txtMailAfiliado
            // 
            this.txtMailAfiliado.Location = new System.Drawing.Point(561, 57);
            this.txtMailAfiliado.Margin = new System.Windows.Forms.Padding(4);
            this.txtMailAfiliado.Name = "txtMailAfiliado";
            this.txtMailAfiliado.Size = new System.Drawing.Size(132, 22);
            this.txtMailAfiliado.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mail";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(561, 25);
            this.txtDni.Margin = new System.Windows.Forms.Padding(4);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(132, 22);
            this.txtDni.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(519, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "DNI";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(364, 57);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(132, 22);
            this.txtApellido.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(364, 25);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // frmHomeAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 515);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHomeAfiliado";
            this.Text = "Home Afiliado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHomeAfiliado_FormClosed);
            this.Load += new System.EventHandler(this.frmHomeAfiliado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTodosAfiliados;
        private System.Windows.Forms.Button btnFiltrarAfiliados;
        private System.Windows.Forms.DataGridView dgvAfiliado;
        private System.Windows.Forms.TextBox txtMailAfiliado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBajaAfiliado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHistorialCambiosPlan;
    }
}