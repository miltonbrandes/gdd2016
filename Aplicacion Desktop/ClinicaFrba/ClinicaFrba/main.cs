using Clases;
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
    public partial class Main : Form
    {
        public Usuario usuario;
        public Rol rol;
        public Main(Usuario us, Rol ro)
        {
            InitializeComponent();
            usuario = us;
            rol = ro;
        }

        private void main_Load(object sender, EventArgs e)
        {
            //mostrar estas opciones de acuerdo al usuario que este logueado
        }
    }
}
