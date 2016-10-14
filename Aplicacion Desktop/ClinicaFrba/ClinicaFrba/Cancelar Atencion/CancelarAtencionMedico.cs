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
                drop_fecha.DataSource = f;
                drop_fecha.DisplayMember = "DiaMesAnio";
                //comboBox1.
            }
            catch
            {
                MessageBox.Show("Error al cargar los dias con turnos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            monthCalendar1.Visible = monthCalendar2.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && cmbTipoCancelacion.Text != string.Empty)
            {
                    if (chk_fecha.Checked == true)
                    {
                        if (chk_horario.Checked == true)
                        {
                            if (hora1.Text != string.Empty && hora2.Text != string.Empty && minuto1.Text != string.Empty && minuto2.Text != string.Empty)
                            {
                                /*QUIERE CANCELAR UNA FRANJA*/

                                DateTime dInicio = new DateTime(DateTime.Today.Year, 1, 1, Int32.Parse(hora1.Text), Int32.Parse(minuto1.Text), 0);
                                TimeSpan tInicio = dInicio.TimeOfDay;
                                DateTime dFin = new DateTime(DateTime.Today.Year, 1, 1, Int32.Parse(hora2.Text), Int32.Parse(minuto2.Text), 0);
                                TimeSpan tFin = dFin.TimeOfDay;
                                Dictionary<string, object> parametros = new Dictionary<string, object>() {
                                    {"@motivo", textBox1.Text},
                                    {"@tipo", cmbTipoCancelacion.Text.Substring(0,1)},    
                                    {"@matricula", profesional.Matricula},
                                    {"@fecha", 0 },
                                    {"@horain", tInicio},
                                    {"@horafin", tFin}
                                    };
                                try
                                {
                                    DBHelper.ExecuteNonQuery("Cancelar_Turnos_ProfxFranja", parametros);
                                }
                                catch
                                {
                                    MessageBox.Show("Error al cancelar el turno, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {

                            /*QUIERE DECIR QUE QUIERE CANCELAR TODO EL DIA*/
                            //Dia a cancelar
                            DateTime d = ((Fecha)drop_fecha.SelectedItem).DiaMesAnio;
                            Dictionary<string, object> parametros = new Dictionary<string, object>() {
                                        {"@motivo", textBox1.Text},
                                        {"@tipo", cmbTipoCancelacion.Text.Substring(0,1)},    
                                        {"@matricula", profesional.Matricula},
                                        {"@fecha", d }
                                };

                            try
                            {
                                DBHelper.ExecuteNonQuery("Cancelar_Turnos_Profesional", parametros);
                            }
                            catch
                            {
                                MessageBox.Show("Error al cancelar el turno, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
            
                    }
                    else
                    {
                        //  CANCELA RANGO DE FECHAS
                        if (chk_dias.Checked == true)
                        {
                            DateTime dia_desde = monthCalendar1.SelectionStart;
                            DateTime dia_hasta = monthCalendar2.SelectionStart;

                            Dictionary<string, object> parametros = new Dictionary<string, object>() {
                                        {"@motivo", textBox1.Text},
                                        {"@tipo", cmbTipoCancelacion.Text.Substring(0,1)},    
                                        {"@matricula", profesional.Matricula},
                                        {"@fecha_desde", dia_desde },
                                        {"@fecha_hasta", dia_hasta }
                                };
                            try
                            {
                                DBHelper.ExecuteNonQuery("Cancelar_Turnos_Varios_Dias", parametros);
                            }
                            catch
                            {
                                MessageBox.Show("Error al cancelar el turno, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe elegir una opcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fecha.Checked == true)
            {
                chk_dias.Checked = false;
                drop_fecha.Enabled = true;
            }
            else
            {
                chk_horario.Checked = false;
                drop_fecha.Enabled = false;
            }
                
        }

        private void chk_horario_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_horario.Checked == true)
            {
                chk_fecha.Checked = true;
                hora1.Enabled = minuto1.Enabled = hora2.Enabled = minuto2.Enabled = true;
            }
            else
            {
                hora1.Enabled = minuto1.Enabled = hora2.Enabled = minuto2.Enabled = false;
            }
        }

        private void chk_dias_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dias.Checked == true)
            {
                chk_fecha.Checked = false;
                monthCalendar1.Enabled = monthCalendar2.Enabled = true;
            }
            else
            {
                monthCalendar1.Enabled = monthCalendar2.Enabled = false;
            }
            
        }
    }
}
