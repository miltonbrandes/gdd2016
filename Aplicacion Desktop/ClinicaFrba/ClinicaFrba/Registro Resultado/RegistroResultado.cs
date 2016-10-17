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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class frmRegistroResultado : Form
    {
        public Profesional profesional;
        public frmRegistroResultado(Profesional pro)
        {
            //this.Width = 
            InitializeComponent();
            dtpFechaTurno.Value = ConfigTime.getFechaSinHora();
            profesional = pro;
        }

        private void frmRegistroResultado_Load(object sender, EventArgs e)
        {
            this.Width = 675;
            //if(usuario.Username == "admin"
            
            Dictionary<string, object> parametros = new Dictionary<string, object>()
        		{ {"@matricula", profesional.Matricula} };
            profesional.Especialidades = DBHelper.ExecuteReader("Especialidad_GetByMatricula", parametros).ToEspecialidad();
            cmbEspecialidad.DataSource = profesional.Especialidades;
            cmbEspecialidad.DisplayMember = "Descripcion";

            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Dictionary<string, object> parametros2 = new Dictionary<string, object>()
        		{ {"@fecha", dtpFechaTurno.Value}, {"@matricula", profesional.Matricula},{"@especialidad", ((Especialidad)cmbEspecialidad.SelectedItem).Id} };
            List<Turno> lista = new List<Turno>();
            lista = DBHelper.ExecuteReader("GetTurnosDiaLlegaron", parametros2).ToTurno();

            dataGridView1.DataSource = lista;
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "Codigo",
                Width = 128,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Afiliado",
                HeaderText = "Nro Afiliado",
                Width = 128,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewColumn(){
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 128,
                ReadOnly = true
            });
            }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (dtpFechaTurno.Value >= ConfigTime.getFechaSinHora())
                {
                    button1.Enabled = false;
                    dataGridView1.Enabled = false;
                    this.Width = 980;
                }
                else
                {
                    MessageBox.Show("Debe ingresar una fecha igual o posterior al dia de hoy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtDiagnostico.Text == "" || txtSintomas.Text == "")
            {
                MessageBox.Show("Debe completar los sintomas y enfermedades", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int turnonro;
                int.TryParse(dataGridView1.SelectedCells[0].Value.ToString(),out turnonro);
                Dictionary<string, object> parametros2 = new Dictionary<string, object>() { { "@turnoid", turnonro }
                    , { "@sintomas", txtSintomas.Text }, { "@enfermedades", txtDiagnostico.Text }, {"@tiempo",ckbHorario.Checked } };
                try
                {
                    DBHelper.ExecuteNonQuery("Registrar_Resultado", parametros2);
                    
                }
                catch { MessageBox.Show("Se registro el resultado con exito", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }

            }
            Hide();
            Main aabrir = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Main")
                {
                    aabrir = (Main)frm;

                }
            }
            if (aabrir != null)
            {
                aabrir.Show();
            }

        }
    }
}
