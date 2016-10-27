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

namespace ClinicaFrba.AbmRol
{
    public partial class frmBaja : Form
    {
        List<Rol> roles;
        public frmBaja()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var rol = (Rol)cmbRoles.SelectedItem;
            try
            {
                ConexionesDB.ExecuteNonQuery("Rol_Deactivate", new Dictionary<string, object>() { { "@rol", rol.Id } });
            }
            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
            MessageBox.Show("Dado de baja con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadRoles();
        }
        private void LoadRoles()
        {
            try
            {
                roles = ConexionesDB.ExecuteReader("Rol_GetAll").ToRoles();
            }
            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Descripcion";
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rol = (Rol)cmbRoles.SelectedItem;
            btnGuardar.Enabled = rol.Habilitado;
        }

        private void frmBaja_Load_1(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void frmBaja_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmHome")
                {
                    frm.Show();
                }
            }
            Hide();
        }
    }
}
