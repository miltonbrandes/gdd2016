using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba;
using Clases;

namespace ClinicaFrba.AbmRol
{
    public partial class frmHome : Form
    {
        public Usuario usua;
        public Rol rolactual;
        public frmHome(Usuario us, Rol rol)
        {

            InitializeComponent();
            rolactual = rol;
            usua = us;
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main princ = new Main(usua, rolactual);
            Hide();
            princ.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
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
                acerrar.Close();
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAlta alta = new frmAlta();
            alta.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmModificar mod = new frmModificar();
            mod.Show();
            this.Hide();
        
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmBaja baja = new frmBaja();
            baja.Show();
            this.Hide();
        
        }
        
    }
}
