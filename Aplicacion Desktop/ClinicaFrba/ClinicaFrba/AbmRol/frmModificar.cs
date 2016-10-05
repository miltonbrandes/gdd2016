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
    public partial class frmModificar : Form
    {
        List<Rol> roles;
        List<Funcion> funciones, funcionesXRol;
        public frmModificar()
        {
            InitializeComponent();
        }
        private void SetRoles()
        {
            try
            {
                roles = DBHelper.ExecuteReader("Rol_GetAll").ToRoles();
            }
            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Descripcion";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var rolAsignado = (Rol)cmbRoles.SelectedItem;
            if (txtNombre.Text != string.Empty)
            {
                try
                {
                    if (txtNombre.Text != rolAsignado.Descripcion.Trim())
                    {
                        var rol = DBHelper.ExecuteReader("Rol_Exists", new Dictionary<string, object>() { { "@rol", txtNombre.Text } }).ToRol();
                        if (rol == null)
                        {
                            try
                            {
                                DBHelper.ExecuteNonQuery("Rol_ModifyName", new Dictionary<string, object>() { { "@nombre", txtNombre.Text }, { "@id", rolAsignado.Id } });
                                
                            }
                            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            
                        }
                        else
                        {
                            MessageBox.Show("Ya existe el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNombre.Focus();
                            return;
                        }
                    }

                    foreach (var item in lstFunciones.Items)
                    {
                        var nombre = (string)item;
                        if (lstFunciones.CheckedItems.Contains(item))
                        {
                            //Si está chequeado y no estaba, lo agrego   
                            if (!funcionesXRol.Exists(x => x.Descripcion == nombre))
                            {
                                try
                                {
                                    DBHelper.ExecuteNonQuery("RolXFuncion_Add", new Dictionary<string, object>() { { "@rol", rolAsignado.Id }, { "@funcion", funciones.First(x => x.Descripcion == nombre).Id } });
                                    
                                }
                                catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                
                            }
                        }
                        else
                        {
                            //No esta chequedado y si estaba, lo borro
                            if (funcionesXRol.Exists(x => x.Descripcion == nombre))
                            {
                                try
                                {
                                    DBHelper.ExecuteNonQuery("RolXFuncion_Remove", new Dictionary<string, object>() { { "@rol", ((Rol)cmbRoles.SelectedItem).Id }, { "@funcion", funciones.First(x => x.Descripcion == nombre).Id } });
                                }
                                catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                
            //                    lstFunciones.CheckedItems = false;
                            }
                        }
                    }
                    MessageBox.Show("Modificado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetRoles();
                }
                catch
                {
                    MessageBox.Show("Hubo un error en la modificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede quedar vacío el nombre del rol","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmModificar_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //aca va la logica para activar rol
            var rolAsignado = (Rol)cmbRoles.SelectedItem;
            try
            {
                DBHelper.ExecuteNonQuery("Rol_Activate", new Dictionary<string, object>() { { "@rol", rolAsignado.Id } });
                
            }
            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
            MessageBox.Show("Rol activado nuevamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnActivar.Visible = false;
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstFunciones.Enabled = true;
            var rol = (Rol)cmbRoles.SelectedItem;
            try
            {
                funcionesXRol = DBHelper.ExecuteReader("RolXFuncion_Active", new Dictionary<string, object>() { { "@rol", rol.Descripcion } }).ToFunciones();
            }
            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
            lstFunciones.Items.Clear();
            foreach (var fun in funciones)
            {
                //Chequeo aquellas que tiene seleccionada
                lstFunciones.Items.Add(fun.Descripcion, funcionesXRol.Exists(x => x.Id == fun.Id));
            }
            txtNombre.Text = rol.Descripcion;
            btnActivar.Visible = !rol.Habilitado;
        }

        private void frmModificar_Load(object sender, EventArgs e)
        {
            try
            {
                funciones = DBHelper.ExecuteReader("Funciones_GetAll").ToFunciones();
            }
            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
            SetRoles();
        }
    }
}
