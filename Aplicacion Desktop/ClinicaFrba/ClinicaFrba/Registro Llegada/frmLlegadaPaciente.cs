using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class frmLlegadaPaciente : Form
    {
        string medxespid;
        public frmLlegadaPaciente()
        {

            InitializeComponent();
        }

        private void frmLlegadaPaciente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet6.Get_Turnos_Today' Puede moverla o quitarla según sea necesario.
            this.get_Turnos_TodayTableAdapter.Fill(this.gD2C2016DataSet6.Get_Turnos_Today);
            // TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet5.Get_MedicoXEsp_All' Puede moverla o quitarla según sea necesario.
            this.get_MedicoXEsp_AllTableAdapter2.Fill(this.gD2C2016DataSet5.Get_MedicoXEsp_All);
            this.Width = 538;
            // TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet3.Get_Especialidades_All' Puede moverla o quitarla según sea necesario.
            this.get_Especialidades_AllTableAdapter.Fill(this.gD2C2016DataSet3.Get_Especialidades_All);
           
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string rowFilter = string.Format("[{0}] = '{1}'", "especialidad_descripcion", cmbEspecialidades.Text);
            BindingSource dt = (BindingSource)dgvMedicoXEspecialidad.DataSource;
            dt.Filter = rowFilter;
        }

        private void dgvMedicoXEspecialidad_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvMedicoXEspecialidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMedicoXEspecialidad_DoubleClick(object sender, EventArgs e)
        {
            //CON ESTE MEDICO X ESP ID HAY QUE TRAER LOS TURNOS QUE TIENE EL AFILIADO QUE VOY A SELECCIONAR DESPUES
            if (dgvMedicoXEspecialidad.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvMedicoXEspecialidad.SelectedRows[0];
                medxespid = row.Cells[0].Value.ToString();
                dgvMedicoXEspecialidad.Enabled = false;
                this.Width = 1030;
            }
        }

        private void btnTraerTurnos_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
           // this.dgvMedicoXEspecialidad.DataSource = null;
            frmLlegadaPaciente_Load(sender, e);
        }
    }
}
