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
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class frmLlegadaPaciente : Form
    {
        int i = 0;
        string medxespid;
        DateTime fecha;
        public frmLlegadaPaciente()
        {

            InitializeComponent();
            dateTimePicker1.Value = ConfigTime.getFechaSinHora();
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


        private void dgvMedicoXEspecialidad_DoubleClick(object sender, EventArgs e)
        {
            //CON ESTE MEDICO X ESP ID HAY QUE TRAER LOS TURNOS QUE TIENE EL AFILIADO QUE VOY A SELECCIONAR DESPUES
            if (dgvMedicoXEspecialidad.SelectedRows.Count == 1)
            {
                if (dateTimePicker1.Value >= ConfigTime.getFechaSinHora())
                {
                    DataGridViewRow row = dgvMedicoXEspecialidad.SelectedRows[0];
                    medxespid = row.Cells[0].Value.ToString();
                    dgvMedicoXEspecialidad.Enabled = false;
                    cmbEspecialidades.Enabled = false;
                    textBox1.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    btnFiltrar.Enabled = false;
                    fecha = dateTimePicker1.Value;
                    this.Width = 1030;
                }
                else
                {
                    MessageBox.Show("Debe ingresar una fecha igual o posterior al dia de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnTraerTurnos_Click(object sender, EventArgs e)
        {

        }

        private void txtNroAfiliado_TextChanged(object sender, EventArgs e)
        {

            if (dgvMedicoXEspecialidad.SelectedRows.Count == 1)
            {
                
                
                int a;
                if (int.TryParse(txtNroAfiliado.Text, out a))
                {
                    Dictionary<string, object> parametros = new Dictionary<string, object>(){
					{"@medxespid",medxespid},
					{"@fecha",fecha},
                    {"@nroafiliado",txtNroAfiliado.Text}
				};
                    List<Turno> listaTurnos = new List<Turno>();
                    listaTurnos = DBHelper.ExecuteReader("Get_Turnos_Prof_Reservados", parametros).ToTurno();
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.Columns.Clear();
                    dgvTurnos.AutoGenerateColumns = false;

                    dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Id",
                        HeaderText = "Codigo",
                        Width = 128,
                        ReadOnly = true
                    });
                    dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Afiliado",
                        HeaderText = "Nro Afiliado",
                        Width = 128,
                        ReadOnly = true
                    });
                    dgvTurnos.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Fecha",
                        HeaderText = "Fecha",
                        Width = 128,
                        ReadOnly = true
                    });
                }
                else
                {
                    if (txtNroAfiliado.Text.Length > 1)
                    {
                        MessageBox.Show("Debe ingresar unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNroAfiliado.Text = txtNroAfiliado.Text.Substring(0, txtNroAfiliado.Text.Length - 1);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            MessageBox.Show("Debe ingresar unicamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            i = 1;
                            txtNroAfiliado.Clear();
                            
                        }
                        else
                        {
                            txtNroAfiliado.Clear();
                            //i = 0;
                        }
                    }
                }
            }
        }

        private void dgvTurnos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count == 1)
            {
                txtNroAfiliado.Enabled = false;
                DataGridViewRow row = dgvTurnos.SelectedRows[0];
                DateTime fecha = ConfigTime.getFechaSinHora();
                Turno t = (Turno)row.DataBoundItem;
                int horas = ConfigTime.getFecha().Hour;
                int minutos = ConfigTime.getFecha().Minute;
                int segundos = ConfigTime.getFecha().Second;
                DateTime fechaactual = ConfigTime.getFechaSinHora().AddHours(horas).AddMinutes(minutos).AddSeconds(segundos);
                Dictionary<string, object> parametros = new Dictionary<string, object>(){
					{"@nroafiliado", t.Afiliado}
				};
                List<Bono> lista = new List<Bono>();
                lista = DBHelper.ExecuteReader("Get_Bonos_Afiliado", parametros).ToBono();
                //dgvTurnos.DataSource = listaTurnos;
                if (lista.Count != 0) {
                    Dictionary<string, object> parametros2 = new Dictionary<string, object>(){
					{"@nroafiliado", t.Afiliado},{"@nroturno", t.Id},{"@fecha", fechaactual}
				};
                    try
                    {
                        DBHelper.ExecuteNonQuery("Registrar_Llegada", parametros2);
                        MessageBox.Show("Se registro la llegada correctamente del horario: "+ t.Fecha.ToString(), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch {
                    MessageBox.Show("Hubo un problema al registrar la llegada, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
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
                else { MessageBox.Show("No tenia bonos comprados, compre uno primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
                

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvMedicoXEspecialidad.DataSource;
                bs.Filter = string.Format("CONVERT(" + dgvMedicoXEspecialidad.Columns[2].DataPropertyName + ", System.String) like '%" + textBox1.Text.Replace("'", "''") + "%'");
                dgvMedicoXEspecialidad.DataSource = bs;
                dgvMedicoXEspecialidad.Refresh();
            }
        }
    }
}
