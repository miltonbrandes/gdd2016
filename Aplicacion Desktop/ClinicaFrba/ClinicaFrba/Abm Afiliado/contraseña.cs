using Helpers;
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
using Helpers;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class contraseña : Form
    {
        public Usuario usuario;
        public Rol rol;
        public Afiliado afiliadoCambiar;
        public contraseña(Usuario us, Rol ro, Afiliado cambcontra)
        {
            afiliadoCambiar = cambcontra;
            usuario = us;
            rol = ro;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cambio = 0;
            if (txtNueva.Text == string.Empty ||  txtRepita.Text == string.Empty)
            {
                MessageBox.Show("Debe completar los 3 campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//else completo todos los campos
            else
                if (txtNueva.Text != txtRepita.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                try
                {
                    DBHelper.ExecuteNonQuery("Usuario_CambiarContrasenia", new Dictionary<string, object>() { { "@Username", afiliadoCambiar.Username }, { "@Password", txtNueva.Text }, {"@cambiada", cambio} });
                    //if(cambio == 1)
                    //    MessageBox.Show("Contraseña cambiada");
                    //TODO: ver porque no me devuelve 1 aca
                    //else
                    //    MessageBox.Show("La contraseña ingresada no coincide con la guardada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Se ha cambiado. Chequee el cambio de contraseña", "Cambiada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("La contraseña ingresada no coincide con la guardada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } if (cambio == 0)
                {
                    Hide();

                    frmAfiliado amostrar = null;
                    FormCollection fc = Application.OpenForms;
                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "frmAfiliado")
                        {
                            amostrar = (frmAfiliado)frm;

                        }
                    }
                    if (amostrar != null)
                    {
                        amostrar.Show();
                    }
                }
            }
        }
    }
}
