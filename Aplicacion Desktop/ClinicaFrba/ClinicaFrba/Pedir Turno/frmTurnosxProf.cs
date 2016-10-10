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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class frmTurnosxProf : Form
    {
        public static string codigo_profesional;

        public frmTurnosxProf()
        {
            InitializeComponent();
        }

        public frmTurnosxProf(string codigo_profesional)
        {
            // TODO: Complete member initialization
            //this.codigo_profesional = codigo_profesional;
            InitializeComponent();
            cargarTurnos(codigo_profesional);
        }

        public void cargarTurnos(string codigo_profesional)
        {
            List<Franja> franjasFiltradas = null;
            var parametros = new Dictionary<string, object>() {
                    { "@profesional", codigo_profesional}
                };

            try
            {
                franjasFiltradas = DBHelper.ExecuteReader("turnos_GetByFilerProfesional", parametros).ToFranja();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loadTurnos(franjasFiltradas);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loadTurnos(List<Franja> franjas)
        {
            dgvTurnos.Focus();
            dgvTurnos.DataSource = franjas;
            dgvTurnos.Columns.Clear();
            dgvTurnos.AutoGenerateColumns = false;

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "Id",
                Width = 128,
                ReadOnly = true
            });
            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Dia",
                HeaderText = "Dia",
                Width = 128,
                ReadOnly = true
            });
            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {

                DataPropertyName = "HoraInicio",
                HeaderText = "Hora Inicio",
                Width = 140,
                ReadOnly = true
            });
            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MinutoInicio",
                HeaderText = "Minuto Inicio",
                Width = 100,
                ReadOnly = true
            });
            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HoraFin",
                HeaderText = "Hora Fin",
                Width = 230,
                ReadOnly = true
            });
            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MinutoFin",
                HeaderText = "Minuto Fin",
                Width = 230,
                ReadOnly = true
            });
        }
    }
}
