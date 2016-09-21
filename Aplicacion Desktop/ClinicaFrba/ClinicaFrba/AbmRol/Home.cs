using ClinicaFrba.AbmRol;
using System;
using System.Windows.Forms;

namespace GDD.ABM_Rol
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnRol_Click(object sender, EventArgs e)
        {
            frmAlta alta = new frmAlta();
            alta.Show();
            Hide();
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar mod = new frmModificar();
            mod.Show();
            Hide();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            frmBaja baja = new frmBaja();
            baja.Show();
            Hide();
        }
    }
}
