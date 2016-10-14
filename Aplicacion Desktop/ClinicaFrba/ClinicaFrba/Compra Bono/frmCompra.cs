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
                    int nro;
                    int.TryParse(textBox_afiliado.Text, out nro);
                    if (nro > 0)
                    {
                        int cant;
                        int.TryParse(textBox_cantidad.Text, out cant);
                        if (cant > 0)
                        {
                            afiliado = DBHelper.ExecuteReader("Afiliado_GetAfiliadoSegunNro", new Dictionary<string, object> { { "@nroAfil", nro } }).ToAfiliados();
                        }
                        else {
                            label_cantidad.Text = "Cantidad:";
                            label_precio.Text = "Precio Final:";
                            boton_comprar.Enabled = false;

                            MessageBox.Show("Ingrese una cantidad numerica mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        label_cantidad.Text = "Cantidad:";
                        label_precio.Text = "Precio Final:";
                        boton_comprar.Enabled = false;
                        MessageBox.Show("Ingrese el nro correcto de afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (usuario.Username == "admin")
                    {
                        int cant;
                        int.TryParse(textBox_cantidad.Text, out cant);
                        if (cant > 0)
                        {
                            afiliado = DBHelper.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", new Dictionary<string, object> { { "@username", "administrador32405354" } }).ToAfiliados();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese una cantidad numerica mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        int cant;
                        int.TryParse(textBox_cantidad.Text, out cant);
                        if (cant > 0)
                        {
                            afiliado = DBHelper.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", new Dictionary<string, object> { { "@username", usuario.Username } }).ToAfiliados();
                        }
                        else
                        {
                            label_cantidad.Text = "Cantidad:";
                            label_precio.Text = "Precio Final:";
                            boton_comprar.Enabled = false;
                            MessageBox.Show("Ingrese una cantidad numerica mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                if (afiliado != null)
                {
                    plan = DBHelper.ExecuteReader("Planes_GetPlanAfiliado", new Dictionary<string, object> { { "@Afiliado_nro", afiliado.NroAfiliado } }).ToPlan();
                    cantidad = Int32.Parse(textBox_cantidad.Text);
                    label_cantidad.Text = "Cantidad: " + cantidad;

                    precio = (cantidad * plan.PrecioBonoConsulta);
                    label_precio.Text = "Precio Final: " + precio;

                    boton_comprar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontro ningun afiliado con ese numero o el afiliado no estaba habilitado", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                return;
            }
            Hide();
            Main acerrar = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Main")
                {
                    acerrar = (Main)frm;

                }
            }
            if (acerrar != null)
            {
                acerrar.Show();
            }

            
        }
    }
}
