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
using ClinicaFrba.Registro_Agenda;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class frmCancelarAtencionMedico : Form
    {
        public Profesional profesional;
        public Usuario usuario;
        public Rol rol;
        public frmCancelarAtencionMedico(Profesional prof, Usuario us, Rol ro)
        {
            InitializeComponent();
            profesional = prof;
            usuario = us;
            rol = ro;
        }

        private void frmCancelarAtencionMedico_Load(object sender, EventArgs e)
        {
            
            Dictionary<string, object> parametros = new Dictionary<string, object>() {
                            {"@matricula", profesional.Matricula}};
            try
            {
                List<Fecha> f = new List<Fecha>();
                f = DBHelper.ExecuteReader("Get_Dias_Turno_Prof", parametros).ToFecha();
                comboBox1.DataSource = f;
                comboBox1.DisplayMember = "DiaMesAnio";
                //comboBox1.
            }
            catch
            {
                MessageBox.Show("Error al cargar los dias con turnos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<Franja> fr = new List<Franja>();
                fr = DBHelper.ExecuteReader("Get_Franjas_Profesional", parametros).ToFranja();
                dataGridView1.DataSource = fr;
            }
            catch
            {
                MessageBox.Show("Error al cargar las franjas del profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridView1.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && cmbTipoCancelacion.Text != string.Empty && hora1.Text != string.Empty && hora2.Text != string.Empty && minuto1.Text != string.Empty && minuto2.Text != string.Empty)
            {
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        /*QUIERE DECIR QUE QUIERE CANCELAR TODO EL DIA*/
                        //Dia a cancelar
                        DateTime d = ((Fecha)comboBox1.SelectedItem).DiaMesAnio;
                        Dictionary<string, object> parametros = new Dictionary<string, object>() {
                                {"@motivo", textBox1.Text},
                                {"@tipo", cmbTipoCancelacion.Text.Substring(0,1)},    
                                {"@matricula", profesional.Matricula},
                                {"@fecha", d },
                                {"@horainicio", 0 },
                                {"@minutosinicio", 0},
                                {"@horafin", 0},
                                {"@minutosfin", 0},
                                {"@franjaid", -1}
                        };

                        try
                        {
                            DBHelper.ExecuteNonQuery("Cancelar_Turnos_Profesional", parametros);
                            //dataGridView1.DataSource = t;
                        }
                        catch
                        {
                            MessageBox.Show("Error al cancelar el turno, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
            
                    }
                    else
                    {
                        if(dataGridView1.SelectedRows.Count == 1)
                        {
                            /*QUIERE CANCELAR UNA FRANJA*/
                            
                            DataGridViewRow r = dataGridView1.SelectedRows[0];
                            Franja f = (Franja)r.DataBoundItem;
                            DateTime dInicio = new DateTime(DateTime.Today.Year, 1, 1, Int32.Parse(hora1.Text), Int32.Parse(minuto1.Text), 0);
                           /* dInicio = dInicio.AddHours(f.HoraInicio);
                            dInicio = dInicio.AddMinutes(f.MinutoInicio);*/
                            TimeSpan tInicio = dInicio.TimeOfDay;
                            DateTime dFin = new DateTime(DateTime.Today.Year, 1, 1, Int32.Parse(hora2.Text), Int32.Parse(minuto2.Text), 0);
                            /*dFin = dFin.AddHours(f.HoraFin);
                            dFin = dFin.AddMinutes(f.MinutoFin);*/
                            TimeSpan tFin = dFin.TimeOfDay;
                            Dictionary<string, object> parametros = new Dictionary<string, object>() {
                                    {"@motivo", textBox1.Text},
                                    {"@tipo", cmbTipoCancelacion.Text.Substring(0,1)},    
                                    {"@matricula", profesional.Matricula},
                                    {"@fecha", 0 },
                                    {"@horain", tInicio},
                                    {"@horafin", tFin},
                                    {"@franjaid", f.Id}
                            };
                            try
                            {
                                DBHelper.ExecuteNonQuery("Cancelar_Turnos_ProfxFranja", parametros);
                                //dataGridView1.DataSource = t;
                            }
                            catch
                            {
                                MessageBox.Show("Error al cancelar el turno, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Se han cancelado los turnos con exito", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
