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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class frmHomeAfiliado : Form
    {

        public static Usuario usuario;
        public static Rol rol;

        public frmHomeAfiliado(Usuario us, Rol ro)
        {
            InitializeComponent();
            usuario = us;
            rol = ro;
        }

        private void frmHomeAfiliado_Load(object sender, EventArgs e)
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
            LoadAfiliados(DBHelper.ExecuteReader("Afiliado_GetAll").ToAfiliado());
        }
        private void LoadAfiliados(List<Afiliado> afiliados)
        {
            dgvAfiliado.Focus();
            dgvAfiliado.DataSource = afiliados;
            dgvAfiliado.Columns.Clear();
            dgvAfiliado.AutoGenerateColumns = false;

            dgvAfiliado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 128,
                ReadOnly = true
            });
            dgvAfiliado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Width = 140,
                ReadOnly = true
            });
            dgvAfiliado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI",
                Width = 100,
                ReadOnly = true
            });
            dgvAfiliado.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Mail",
                HeaderText = "Mail",
                Width = 230,
                ReadOnly = true
            });
        }

        private void frmHomeAfiliado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main princ = new Main(usuario, rol);
            Hide();
            princ.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = txtMailAfiliado.Text = txtDni.Text = txtNombre.Text  = string.Empty;
        }

        private void btnTodosAfiliados_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAfiliados(DBHelper.ExecuteReader("Afiliado_GetAll").ToAfiliado());
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnFiltrarAfiliados_Click(object sender, EventArgs e)
        {
            List<Afiliado> afiladosFiltrados = null;
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                var parametros = new Dictionary<string, object>() {
                    { "@nombre", txtNombre.Text},
                    { "@apellido", txtApellido.Text},
                    { "@mail", txtMailAfiliado.Text}
                };
                try
                {
                    afiladosFiltrados = DBHelper.ExecuteReader("Afiliado_GetByFilters", parametros).ToAfiliado();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                try
                {
                    afiladosFiltrados = DBHelper.ExecuteReader("Afiliado_GetByDni", new Dictionary<string, object> { { "@dni", txtDni.Text } }).ToAfiliado();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            LoadAfiliados(afiladosFiltrados);
        }

        private void dgvAfiliado_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAfiliado.SelectedRows.Count == 1)
            {
                Afiliado afil = (Afiliado)dgvAfiliado.CurrentRow.DataBoundItem;
                if (afil != null)
                {
                    frmAfiliado afiliado = new frmAfiliado(usuario, rol, afil, 2);
                    afiliado.Show();
                    Hide();
                }
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Afiliado afil = null;
            frmAfiliado afiliado = new frmAfiliado(usuario, rol, afil, 1);
            afiliado.Show();
            Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHistorialCambiosPlan_Click(object sender, EventArgs e)
        {
            frmHistorialModificaciones nuevo = new frmHistorialModificaciones();
            nuevo.Show();
        }

        private void btnBajaAfiliado_Click(object sender, EventArgs e)
        {
           // Afiliado afil = ;
            //frmBajaAfiliado baja = new frmBajaAfiliado(usuario, rol);
            //baja.Show();
            //Hide();
            //ACORDARSE QUE CUANDO LE DOY DE BAJA, HAY QUE PONER SUS TURNOS COMO DISPONIBLES, ESO ES UN TRIGGER
            if (dgvAfiliado.SelectedRows.Count == 1)
            {
                Afiliado afil = (Afiliado)dgvAfiliado.CurrentRow.DataBoundItem;
                if (afil != null)
                {
                    //LE DOY DE BAJA LOGICA, REVISAR LO UNICO QUE QUEDA ES LA PARTE DE PORQUE NO ME DEVUELVE SI SE MODIFICO
                    string user = null;
                    if (afil.Username == "administrador32405354")
                    {
                        user = afil.Username.Substring(0, 5);
                    }
                    else
                    {
                        user = afil.Username;
                    }
                    //int resp= 0;
                    
                    try
                    {
                        DBHelper.ExecuteNonQuery("Afiliado_Baja_Logica", (new Dictionary<string, object> { { "@UsuarioId", user }/*, {"@ret", resp} */}));
                        
                    }
                    catch
                    {
                        MessageBox.Show("Error al dar de baja afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                  //  if(resp > 0)
                        MessageBox.Show("Se dio de baja al afiliado: " + afil.Username, "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                 //   else
                  //      MessageBox.Show("No se dio de baja al afiliado: " + afil.Username + "porque no tenia ningun rol o porque ya estaba de baja", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DBHelper.DB.Close();
                    return;
                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar 1 solo afiliado a dar de baja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void dgvAfiliado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
