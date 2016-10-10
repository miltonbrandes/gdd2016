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
    public partial class frmPedidoTurno : Form
    {
        public static Profesional profesional;

        public frmPedidoTurno()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        private void filtrarEspecialidades_Click(object sender, EventArgs e)
        {
            List<Especialidad> especialidadesFiltradas = null;
            if (!string.IsNullOrEmpty(textEspecialidad.Text))
            {
                var parametros = new Dictionary<string, object>() {
                    { "@especialidad", textEspecialidad.Text}
                };

                try
                {
                    especialidadesFiltradas = DBHelper.ExecuteReader("especialidades_GetByFilerEspecialidad", parametros).ToEspecialidad();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            LoadEspecialidades(especialidadesFiltradas);
        }

        private void LoadEspecialidades(List<Especialidad> especialidades)
        {
            dgvEspecialidades.Focus();
            dgvEspecialidades.DataSource = especialidades;
            dgvEspecialidades.Columns.Clear();
            dgvEspecialidades.AutoGenerateColumns = false;

            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "Codigo",
                Width = 128,
                ReadOnly = true
            });

            dgvEspecialidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Especialidad",
                Width = 128,
                ReadOnly = true
            });
        }

        private void LoadProfesionales(List<Profesional> profesionales)
        {
            dgvProfesionales.Focus();
            dgvProfesionales.DataSource = profesionales;
            dgvProfesionales.Columns.Clear();
            dgvProfesionales.AutoGenerateColumns = false;

            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Matricula",
                HeaderText = "Matricula",
                Width = 128,
                ReadOnly = true
            });
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn()
            {

                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 140,
                ReadOnly = true
            });
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Telefono",
                HeaderText = "Telefono",
                Width = 100,
                ReadOnly = true
            });
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Mail",
                HeaderText = "Mail",
                Width = 230,
                ReadOnly = true
            });
        }


        private void dgvProfesionales_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string codigo_profesional = dgvProfesionales.CurrentCell.Value.ToString();
            frmTurnosxProf turnosDisponibles = new frmTurnosxProf(codigo_profesional);
            turnosDisponibles.Show();
            this.Hide();
        }

        private void dgvEspecialidades_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string codigo_especialidad = dgvEspecialidades.CurrentCell.Value.ToString();
            List<Profesional> profesionalesFiltrados = null;
            var parametros = new Dictionary<string, object>() {
                    { "@especialidad", codigo_especialidad}
                };

            try
            {
                profesionalesFiltrados = DBHelper.ExecuteReader("profesional_GetByFilerEspecialidad", parametros).ToProfesional2();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadProfesionales(profesionalesFiltrados);
        }
    }
}
