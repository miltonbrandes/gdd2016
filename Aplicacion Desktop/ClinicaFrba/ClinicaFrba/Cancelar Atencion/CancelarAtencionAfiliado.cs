using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using Helpers;
using System.Configuration;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class frmCancelarAtencionAfiliado : Form
    {
        public Afiliado afiliado;
        public Rol rol;
        public Usuario usuario;
        public frmCancelarAtencionAfiliado(Afiliado afil, Usuario us, Rol ro)
        {
            InitializeComponent();
            afiliado = afil;
            rol = ro;
            usuario = us;
        }

        void load_datagrid()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>() { { "@nroafiliado", afiliado.NroAfiliado }, { "@fecha", dtpFecha.Value.Date } };
            List<Turno> t = new List<Turno>();
            t = DBHelper.ExecuteReader("Turnos_Afiliado_Mayor", parametros).ToTurno();
            dataGridView1.DataSource = t;
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "Id",
                Width = 150,
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 150,
                ReadOnly = true
            });
        }

        private void frmCancelarAtencionAfiliado_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = ConfigTime.getFechaSinHora().AddDays(1);
            load_datagrid();
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != string.Empty && textBox1.Text != string.Empty)
            {
                if (dtpFecha.Value > ConfigTime.getFechaSinHora())
                {
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        DataGridViewRow r = new DataGridViewRow();
                        r = dataGridView1.SelectedRows[0];
                        Turno turno = (Turno)r.DataBoundItem;
                        Dictionary<string, object> parametros = new Dictionary<string, object>() {
                            {"@nroturno", turno.Id},
                    { "@nroafiliado", afiliado.NroAfiliado },
                    { "@fecha", dtpFecha.Value.Date },
                    {"@motivo", textBox1.Text},
                    {"@tipo", comboBox1.Text}};
                        List<Turno> t = new List<Turno>();
                        try
                        {
                            t = DBHelper.ExecuteReader("Cancelar_Turno_Afiliado", parametros).ToTurno();
                            //dataGridView1.DataSource = t;
                        }
                        catch {
                            MessageBox.Show("Error al cancelar el turno, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar 1 fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar una fecha mayor a la de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Se cancelo el turno con exito", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            Main amostrar = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Main")
                {
                    amostrar = (Main)frm;

                }
            }
            if (amostrar != null)
            {
                amostrar.Show();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpFecha.Value > ConfigTime.getFechaSinHora())
            {
                load_datagrid();
            }
            else
            {
                MessageBox.Show("Debe ingresar una fecha mayor a la de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
