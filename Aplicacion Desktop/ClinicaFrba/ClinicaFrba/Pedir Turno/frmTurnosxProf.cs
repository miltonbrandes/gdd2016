using Clases;
using Clases.Profesionales;
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
        public static decimal nro_afiliado = 0;

        public frmTurnosxProf()
        {
            InitializeComponent();
        }

        public frmTurnosxProf(string codigo_profesional, string codigo_especialidad, decimal afiliado)
        {
            // TODO: Complete member initialization
            //this.codigo_profesional = codigo_profesional;
            InitializeComponent();
            cargarTurnos(codigo_profesional, codigo_especialidad);
            nro_afiliado = afiliado;
        }

        public void cargarTurnos(string codigo_profesional, string codigo_especialidad)
        {
            int prof;
            decimal esp;
            decimal.TryParse(codigo_especialidad, out esp);
            int.TryParse(codigo_profesional, out prof);

            List<turnosProcedure> turnosFiltrados = null;
            var parametros = new Dictionary<string, object>() {
                    { "@profesional", codigo_profesional},
                    { "@especialidad", codigo_especialidad}
                };

            try
            {
                turnosFiltrados = ConexionesDB.ExecuteReader("turnos_GetByFilerProfesional", parametros).ToTurnosProc();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loadTurnos(turnosFiltrados);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loadTurnos(List<turnosProcedure> turnos)
        {
            dgvTurnos.Focus();
            dgvTurnos.DataSource = turnos;
            dgvTurnos.Columns.Clear();
            dgvTurnos.AutoGenerateColumns = false;


            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "turno",
                HeaderText = "Turno",
                Width = 75,
                ReadOnly = true
            });

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "dia",
                HeaderText = "Dia",
                Width = 50,
                ReadOnly = true
            });

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {

                DataPropertyName = "mes",
                HeaderText = "Mes",
                Width = 50,
                ReadOnly = true
            });

            dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "horario",
                HeaderText = "Hora",
                Width = 75,
                ReadOnly = true
            });

        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTurnos.CurrentCell.ColumnIndex == 0)
            {
                string nro_turno = dgvTurnos.CurrentCell.Value.ToString();
                //string nro_turno = dgvTurnos.SelectedCells[0].Value.ToString();
                var parametros = new Dictionary<string, object>() {
                    { "@afiliado", nro_afiliado},
                    { "@nro_turno", nro_turno}
                };
                try
                {
                    ConexionesDB.ExecuteReader("reservarTurno_GetByFilerProfesional", parametros);
                }
                catch
                {
                    MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show("Reservado con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
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
                    acerrar.Show();
                }
            }
            else
            {
                MessageBox.Show("Seleccione el nro de turno a utilizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
