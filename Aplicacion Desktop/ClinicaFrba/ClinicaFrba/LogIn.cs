using Clases;
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

namespace ClinicaFrba
{
    public partial class formInicioSesion : Form
    {
        public Usuario usuario;
        public List<Rol> roles;
        public formInicioSesion()
        {
            InitializeComponent();
        }

        private void button_iniciar_sesion_Click(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == null || txtContrasenia.Text == "" || txtUsuario.Text == null || txtUsuario.Text == "")
            {
                MessageBox.Show("Tiene que completar todos los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //fijarse en db si usuario correcto
                var username = txtUsuario.Text;
                var password = txtContrasenia.Text;
                if (username != null && password != null)
                {
                    usuario = DBHelper.ExecuteReader("Usuario_Get", new Dictionary<string, object>() { { "@usuario", username } }).ToUsuario();
                    if (usuario != null && !usuario.Activo)
                    {
                        MessageBox.Show("Usuario Inhabilitado. El administrador debe volver a habilitarlo");
                        return;
                    }
                    //ACA HACER LO DE LOGIN, lo de encriptar la clave
                    if (usuario != null)
                    {
                       //parte de roles cargarlos
                        cmbRol.Visible = true;
                        buttonContinuar.Visible = true;
                    }
                    else
                    {
                        DBHelper.ExecuteNonQuery("Usuario_SumarIntento", new Dictionary<string, object>() { { "@Username", username } });
                        var usu = DBHelper.ExecuteReader("Usuario_Get", new Dictionary<string, object>() { { "@usuario", username } }).ToUsuario();
                        if (usu != null && usu.Intentos >= 3)
                        {
                            DBHelper.ExecuteNonQuery("Usuario_Inhabilitar", new Dictionary<string, object> { { "@Username", username } });
                            MessageBox.Show("Usuario ha quedado inhabilitado");
                        }
                        else
                        {
                            MessageBox.Show("Password no corresponde con Username.", "Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingresar Username y Password por favor.", "Error");
                }
            }
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form pantallaPrincipal = new Main(usuario, (Rol)cmbRol.SelectedItem);
            pantallaPrincipal.Show();
        }
    }
}
