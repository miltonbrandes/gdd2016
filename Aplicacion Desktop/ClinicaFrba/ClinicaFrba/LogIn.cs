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
                    //OBTENGO EL USUARIO Y ME FIJO SI ESTA ACTIVO
                    usuario = DBHelper.ExecuteReader("Usuario_Get", new Dictionary<string, object>() { { "@usuario", username } }).ToUsuario();
                    if (usuario != null && !usuario.Activo)
                    {
                        MessageBox.Show("Usuario Inhabilitado. El administrador debe volver a habilitarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@Username", username);
                    parametros.Add("@Password", password);
                    //REALIZO EL LOGIN
                    usuario = DBHelper.ExecuteReader("Usuario_LogIn", parametros).ToUsuario();
                    if (usuario != null)
                    {
                        //OBTENGO LOS ROLES DEL USUARIO
                        roles = DBHelper.ExecuteReader("UsuarioXRol_GetRolesByUser", new Dictionary<string, object>() { { "@Username", usuario.Username } }).ToRoles();
                        if (roles.Count > 1)
                        {
                            cmbRol.Visible = true;
                            cmbRol.DataSource = roles;
                            cmbRol.DisplayMember = "Descripcion";
                            buttonContinuar.Visible = true;
                        }
                        else if (roles.Count == 0)
                        {
                            MessageBox.Show("Este usuario no tiene roles asignados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Main main = new Main(usuario, roles.FirstOrDefault());
                            main.Show();
                            Hide();
                        }
                    }
                    else
                    {
                        //LE SUMO UN INTENTO PORQUE FALLO LA CONTRASEÑA
                        DBHelper.ExecuteNonQuery("Usuario_SumarIntento", new Dictionary<string, object>() { { "@Username", username } });
                        var usu = DBHelper.ExecuteReader("Usuario_Get", new Dictionary<string, object>() { { "@usuario", username } }).ToUsuario();
                        if (usu != null && usu.Intentos >= 3)
                        {
                            //LO INHABILITO SI YA HIZO 3 INTENTOS MAL
                            DBHelper.ExecuteNonQuery("Usuario_Inhabilitar", new Dictionary<string, object> { { "@Username", username } });
                            MessageBox.Show("Usuario ha quedado inhabilitado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Password no corresponde con Username.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingresar Username y Password por favor.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex != -1)
            {
                Main main = new Main(usuario, (Rol)cmbRol.SelectedItem);
                main.Show();
                this.Hide();
            }
        }
    }
}
