using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAlta alta = new frmAlta();
            alta.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmModificar mod = new frmModificar();
            mod.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBaja baja = new frmBaja();
            baja.Show();
            this.Hide();
        }
        
    }
}
