using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using Clases;
using System.Data.SqlClient;

namespace ClinicaFrba.Listados
{
    public partial class frmListadoEstadistico : Form
    {
        DateTime fecha1;
        DateTime fecha2;


        public frmListadoEstadistico()
        {
            InitializeComponent();
            dtpAnio.Format = DateTimePickerFormat.Custom;
            dtpAnio.CustomFormat = "yyyy";
            dtpAnio.ShowUpDown = true;
        }

        private void frmListadoEstadistico_Load(object sender, EventArgs e)
        {
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
                acerrar.Close();
            }
        }

        #region LOADS
        private void Load_Listado_1(List<Listado_1> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Especialidad_descripcion",
                HeaderText = "Especialidad",
                Width = 200,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Cancelaciones",
                Width = 150,
                ReadOnly = true
            });
        }
        private void Load_Listado_2(List<Listado_2> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Matricula",
                HeaderText = "Matricula",
                Width = 70,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Especialidad",
                HeaderText = "Especialidad",
                Width = 170,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Consultas",
                Width = 128,
                ReadOnly = true
            });
        }
        private void Load_Listado_3(List<Listado_3> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Matricula",
                HeaderText = "Matricula",
                Width = 70,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 128,
                ReadOnly = true
            });             
           dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Horas",
                Width = 128,
                ReadOnly = true
            });
        }
        private void Load_Listado_4(List<Listado_4> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NroAfiliado",
                HeaderText = "NroAfiliado",
                Width = 70,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 128,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Grupo_Familiar",
                HeaderText = "Pertenece a un grupo familiar",
                Width = 170,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Bonos",
                Width = 128,
                ReadOnly = true
            });
        }
        private void Load_Listado_5(List<Listado_5> listado)
        {
            dgvResultado.Focus();
            dgvResultado.DataSource = listado;
            dgvResultado.Columns.Clear();
            dgvResultado.AutoGenerateColumns = false;

            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Especialidad_descripcion",
                HeaderText = "Especialidad",
                Width = 200,
                ReadOnly = true
            });
            dgvResultado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad Bonos",
                Width = 128,
                ReadOnly = true
            });
        }
        #endregion

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (cmbSemestre.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un semestre", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cmbSemestre.SelectedIndex.Equals(0))
            {
                fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 1, 1);     //  formato año/mes/dia - no se porque
                fecha2 = new DateTime(Int32.Parse(dtpAnio.Text), 7, 1);
            }
            else if (cmbSemestre.SelectedIndex.Equals(1))
            {
                fecha1 = new DateTime(Int32.Parse(dtpAnio.Text), 7, 1);
                fecha2 = new DateTime(Int32.Parse(dtpAnio.Text) + 1, 1, 1);
            }

            try
            {
                switch (cmbTipo.SelectedIndex)
                {
                    case 0:
                        List<Listado_1> lista_1 = DBHelper.ExecuteReader("listado_Mas_Cancelaciones_Especialidad", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_1();
                        Load_Listado_1(lista_1);
                        break;
                    case 1:
                        var parametros = new Dictionary<string, object> { 
                            { "@fecha1", fecha1 }, 
                            { "@fecha2", fecha2 }, 
                            { "@plan", ((Plan)cmbPlan.SelectedItem).Descripcion },
                            };
                        List<Listado_2> lista_2 = DBHelper.ExecuteReader("listado_Profesionales_Consultados", parametros).ToListado_2();
                        Load_Listado_2(lista_2);
                        break;
                    case 2:
                        parametros = new Dictionary<string, object> { 
                            { "@fecha1", fecha1 }, 
                            { "@fecha2", fecha2 }, 
                            { "@plan", ((Plan)cmbPlan.SelectedItem).Descripcion }, 
                            { "@especialidad ", ((Especialidad)cmbEspecialidad.SelectedItem).Descripcion } 
                            };
                        List<Listado_3> lista_3 = DBHelper.ExecuteReader("listado_Profesionales_Menos_Horas", parametros).ToListado_3();
                        Load_Listado_3(lista_3);
                        break;
                    case 3:
                        List<Listado_4> lista_4 = DBHelper.ExecuteReader("listado_Afiliado_Mas_Bonos", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_4();
                        Load_Listado_4(lista_4);
                        break;
                    case 4:
                        List<Listado_5> lista_5 = DBHelper.ExecuteReader("listado_Especialidad_Mas_Bonos", (new Dictionary<string, object> { { "@fecha1", fecha1 }, { "@fecha2", fecha2 } })).ToListado_5();
                        Load_Listado_5(lista_5);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Error al obtener datos de db", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void funcion_para_listado_2()
        {
            List<Plan> planes = DBHelper.ExecuteReader("Planes_GetAll").ToPlanes();
            cmbPlan.DataSource = planes;
            cmbPlan.DisplayMember = "Descripcion";
        }

        public void funcion_para_listado_3()
        {
            List<Plan> planes = DBHelper.ExecuteReader("Planes_GetAll").ToPlanes();
            cmbPlan.DataSource = planes;
            cmbPlan.DisplayMember = "Descripcion";

            List<Especialidad> especialidad = DBHelper.ExecuteReader("Get_Especialidades_All_2").ToEspecialidad();
            cmbEspecialidad.DataSource = especialidad;
            cmbEspecialidad.DisplayMember = "Descripcion";

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbTipo.SelectedIndex)
            {
                case 1:
                    label_plan.Visible = cmbPlan.Visible = true;
                    label_especialidad.Visible = cmbEspecialidad.Visible = false;
                    funcion_para_listado_2();
                    break;
                case 2:
                    label_plan.Visible = label_especialidad.Visible = cmbPlan.Visible = cmbEspecialidad.Visible = true;
                    funcion_para_listado_3();
                    break;
                default:
                    label_plan.Visible = label_especialidad.Visible = cmbPlan.Visible = cmbEspecialidad.Visible = false;
                    break;
            }
        }

    }
}
