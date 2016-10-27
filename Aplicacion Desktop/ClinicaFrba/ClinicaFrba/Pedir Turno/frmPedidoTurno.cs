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
        public static string esp = "";
        public static decimal nro_afiliado = 0;

        public frmPedidoTurno(Afiliado afiliado)
        {
            InitializeComponent();
            dgvProfesionales.Visible = false;
            labelProfesional.Visible = false;
            this.Width = 400;
            cargarAfiliadoGlobal(afiliado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void cargarAfiliadoGlobal(Afiliado afiliado)
        {
            nro_afiliado = afiliado.NroAfiliado;
        }

        private void filtrarEspecialidades_Click(object sender, EventArgs e)
        {
            dgvEspecialidades.Visible = true;
            labelEspecialidad.Visible = true;
            this.Width = 400;
            dgvProfesionales.Visible = false;
            labelProfesional.Visible = false;

            List<Especialidad> especialidadesFiltradas = null;
            if (!string.IsNullOrEmpty(textEspecialidad.Text))
            {
                var parametros = new Dictionary<string, object>() {
                    { "@especialidad", textEspecialidad.Text}
                };

                try
                {
                    especialidadesFiltradas = ConexionesDB.ExecuteReader("especialidades_GetByFilerEspecialidad", parametros).ToEspecialidad2();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            LoadEspecialidades(especialidadesFiltradas);
        }

        private void dgvProfesionales_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProfesionales.CurrentCell.ColumnIndex == 0)
            {
                string codigo_profesional = dgvProfesionales.CurrentCell.Value.ToString();
                frmTurnosxProf turnosDisponibles = new frmTurnosxProf(codigo_profesional, esp, nro_afiliado);
                turnosDisponibles.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Haga click sobre el codigo del profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dgvEspecialidades_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEspecialidades.CurrentCell.ColumnIndex == 0)
            {
                string codigo_especialidad = dgvEspecialidades.CurrentCell.Value.ToString();
                List<Profesional> profesionalesFiltrados = null;
                var parametros = new Dictionary<string, object>() {
                    { "@especialidad", codigo_especialidad}
                };

                esp = codigo_especialidad;

                try
                {
                    profesionalesFiltrados = ConexionesDB.ExecuteReader("profesional_GetByFilerEspecialidad", parametros).ToProfesional2();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnVolver.Visible = true;
                LoadProfesionales(profesionalesFiltrados);
                dgvProfesionales.Visible = true;
                labelProfesional.Visible = true;
                this.Width = 575;
                dgvEspecialidades.Visible = false;
                labelEspecialidad.Visible = false;
                button1.Visible = false;
                label2.Visible = false;
                textEspecialidad.Visible = false;
                filtrarEspecialidades.Visible = false;
            }
            else 
            {
                MessageBox.Show("Haga click sobre el codigo de la especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                Width = 64,
                ReadOnly = true
            });
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 70,
                ReadOnly = true
            });
            dgvProfesionales.Columns.Add(new DataGridViewTextBoxColumn()
            {

                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 75,
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
                Width = 175,
                ReadOnly = true
            });
        }

        private void frmPedidoTurno_Load(object sender, EventArgs e)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            var parametros = new Dictionary<string, object>() {
                    { "@especialidad", textEspecialidad.Text}
                };

            try
            {
                especialidades = ConexionesDB.ExecuteReader("especialidades_GetByFilerEspecialidad", parametros).ToEspecialidad2();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            var parametros = new Dictionary<string, object>() {
                    { "@especialidad", textEspecialidad.Text}
                };

            try
            {
                especialidades = ConexionesDB.ExecuteReader("especialidades_GetByFilerEspecialidad", parametros).ToEspecialidad2();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            btnVolver.Visible = false;
            dgvProfesionales.Visible = false;
            labelProfesional.Visible = false;
            this.Width = 400;
            dgvEspecialidades.Visible = true;
            labelEspecialidad.Visible = true;
            button1.Visible = true;
            label2.Visible = true;
            textEspecialidad.Visible = true;
            filtrarEspecialidades.Visible = true;
            frmPedidoTurno_Load(sender, e);
        }

    }
}
