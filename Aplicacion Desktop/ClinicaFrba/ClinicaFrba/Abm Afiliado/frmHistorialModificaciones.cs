using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class frmHistorialModificaciones : Form
    {
        public frmHistorialModificaciones()
        {
            InitializeComponent();
        }

        private void frmHistorialModificaciones_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet1.Modif_Plan_Get_All' Puede moverla o quitarla según sea necesario.
            this.modif_Plan_Get_AllTableAdapter1.Fill(this.gD2C2016DataSet1.Modif_Plan_Get_All);
            // TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet.Modif_Plan_Get_All' Puede moverla o quitarla según sea necesario.
            this.modif_Plan_Get_AllTableAdapter.Fill(this.gD2C2016DataSet.Modif_Plan_Get_All);

        }
    }
}
