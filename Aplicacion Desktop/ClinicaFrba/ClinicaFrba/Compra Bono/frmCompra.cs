using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using System.Data.SqlClient;
using Helpers;

namespace ClinicaFrba.Compra_Bono
{
    public partial class frmCompra : Form
    {
        public Usuario usuario;
        public int cantidad;
        public decimal precio;
        Afiliado afiliado;
        Plan plan;
        Rol rol;

        public frmCompra(Usuario us, Rol rol)
        {
            InitializeComponent();
            usuario = us;
            if (!rol.Descripcion.Equals("Administrador"))
            {
                label_afiliado.Visible = false;
                textBox_afiliado.Visible = false;
            }

        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_afiliado.Visible)
                {
                    afiliado = DBHelper.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", new Dictionary<string, object> { { "@username", textBox_afiliado.Text } }).ToAfiliados();
                }
                else
                {
                    afiliado = DBHelper.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", new Dictionary<string, object> { { "@username", usuario.Username } }).ToAfiliados();
                }
                plan = DBHelper.ExecuteReader("Planes_GetPlanAfiliado", new Dictionary<string, object> { { "@Afiliado_nro", afiliado.NroAfiliado } }).ToPlan();
                cantidad = Int32.Parse(textBox_cantidad.Text);
                label_cantidad.Text = "Cantidad: " + cantidad;

                precio = (cantidad * plan.PrecioBonoConsulta);
                label_precio.Text = "Precio Final: " + precio;

                boton_comprar.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void boton_comprar_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper.ExecuteReader("Comprar_Bono",
                        new Dictionary<string, object> { 
                    { "@cantidad", cantidad },
                    { "@precio", precio },
                    { "@afiliado", afiliado.NroAfiliado },
                    { "@fecha", DateTime.Now },
                    { "@plan", afiliado.PlanUsuario }
                    });
                MessageBox.Show("Compra Registrada", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
