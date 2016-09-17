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
                this.Hide();
                Form pantallaPrincipal = new main();
                pantallaPrincipal.Show();
            }
        }
    }
}
