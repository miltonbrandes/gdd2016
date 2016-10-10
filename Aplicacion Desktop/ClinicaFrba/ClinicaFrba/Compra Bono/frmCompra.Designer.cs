namespace ClinicaFrba.Compra_Bono
{
    partial class frmCompra
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
            this.textBox_afiliado = new System.Windows.Forms.TextBox();
            this.label_afiliado = new System.Windows.Forms.Label();
            this.textBox_cantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boton_confirmar = new System.Windows.Forms.Button();
            this.label_cantidad = new System.Windows.Forms.Label();
            this.label_precio = new System.Windows.Forms.Label();
            this.boton_comprar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_afiliado
            // 
            this.textBox_afiliado.Location = new System.Drawing.Point(12, 56);
            this.textBox_afiliado.Name = "textBox_afiliado";
            this.textBox_afiliado.Size = new System.Drawing.Size(259, 20);
            this.textBox_afiliado.TabIndex = 0;
            // 
            // label_afiliado
            // 
            this.label_afiliado.AutoSize = true;
            this.label_afiliado.Location = new System.Drawing.Point(9, 40);
            this.label_afiliado.Name = "label_afiliado";
            this.label_afiliado.Size = new System.Drawing.Size(41, 13);
            this.label_afiliado.TabIndex = 1;
            this.label_afiliado.Text = "Afiliado";
            // 
            // textBox_cantidad
            // 
            this.textBox_cantidad.Location = new System.Drawing.Point(144, 83);
            this.textBox_cantidad.Name = "textBox_cantidad";
            this.textBox_cantidad.Size = new System.Drawing.Size(100, 20);
            this.textBox_cantidad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Comprar Bonos";
            // 
            // boton_confirmar
            // 
            this.boton_confirmar.Location = new System.Drawing.Point(12, 123);
            this.boton_confirmar.Name = "boton_confirmar";
            this.boton_confirmar.Size = new System.Drawing.Size(259, 23);
            this.boton_confirmar.TabIndex = 5;
            this.boton_confirmar.Text = "Confirmar";
            this.boton_confirmar.UseVisualStyleBackColor = true;
            this.boton_confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // label_cantidad
            // 
            this.label_cantidad.AutoSize = true;
            this.label_cantidad.Location = new System.Drawing.Point(15, 168);
            this.label_cantidad.Name = "label_cantidad";
            this.label_cantidad.Size = new System.Drawing.Size(55, 13);
            this.label_cantidad.TabIndex = 6;
            this.label_cantidad.Text = "Cantidad: ";
            // 
            // label_precio
            // 
            this.label_precio.AutoSize = true;
            this.label_precio.Location = new System.Drawing.Point(128, 168);
            this.label_precio.Name = "label_precio";
            this.label_precio.Size = new System.Drawing.Size(65, 13);
            this.label_precio.TabIndex = 7;
            this.label_precio.Text = "Precio Final:";
            // 
            // boton_comprar
            // 
            this.boton_comprar.Enabled = false;
            this.boton_comprar.Location = new System.Drawing.Point(12, 195);
            this.boton_comprar.Name = "boton_comprar";
            this.boton_comprar.Size = new System.Drawing.Size(259, 23);
            this.boton_comprar.TabIndex = 8;
            this.boton_comprar.Text = "Comprar";
            this.boton_comprar.UseVisualStyleBackColor = true;
            this.boton_comprar.Click += new System.EventHandler(this.boton_comprar_Click);
            // 
            // frmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 234);
            this.Controls.Add(this.boton_comprar);
            this.Controls.Add(this.label_precio);
            this.Controls.Add(this.label_cantidad);
            this.Controls.Add(this.boton_confirmar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_cantidad);
            this.Controls.Add(this.label_afiliado);
            this.Controls.Add(this.textBox_afiliado);
            this.Name = "frmCompra";
            this.Text = "Comprar Bonos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_afiliado;
        private System.Windows.Forms.Label label_afiliado;
        private System.Windows.Forms.TextBox textBox_cantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button boton_confirmar;
        private System.Windows.Forms.Label label_cantidad;
        private System.Windows.Forms.Label label_precio;
        private System.Windows.Forms.Button boton_comprar;
    }
}