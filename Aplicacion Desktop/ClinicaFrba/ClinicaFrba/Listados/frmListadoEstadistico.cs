using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class frmListadoEstadistico : Form
    {
        public frmListadoEstadistico()
        {
            InitializeComponent();
            dtpAnio.Format = DateTimePickerFormat.Custom;
            dtpAnio.CustomFormat = "yyyy";
            dtpAnio.ShowUpDown = true;
           // dtpAnio.Enabled = false;
        }

        private void frmListadoEstadistico_Load(object sender, EventArgs e)
        {

        }
    }
}
