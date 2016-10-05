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
    public partial class frmAlta : Form
    {
        public List<Funcion> funciones;
        public frmAlta()
        {
            InitializeComponent();
            try
            {
                funciones = DBHelper.ExecuteReader("Funciones_GetAll").ToFunciones();
            }
            catch { MessageBox.Show("Error al acceder a database", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            foreach (var fun in funciones)
            {
                //Chequeo aquellas que tiene seleccionada
                lstFunciones.Items.Add(fun.Descripcion, CheckState.Unchecked);
            }
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text;
            var rol = DBHelper.ExecuteReader("Rol_Exists", new Dictionary<string, object>() { { "@rol", nombre } }).ToRol();
            if (rol == null)
            {
                var funcionesSeleccionadas = lstFunciones.CheckedItems;
                if (funcionesSeleccionadas.Count > 0)
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery("Rol_Add", new Dictionary<string, object>() { { "@rol", nombre } });
                        rol = DBHelper.ExecuteReader("Rol_GetByName", new Dictionary<string, object>() { { "@nombre", nombre } }).ToRol();
                        foreach (string fun in funcionesSeleccionadas)
                        {
                            var id = funciones.FirstOrDefault(x => x.Descripcion == fun).Id;
                            DBHelper.ExecuteNonQuery("RolXFuncion_Add", new Dictionary<string, object>() { { "@rol", rol.Id }, { "@funcion", id } });
                        }
                        MessageBox.Show("Insertado con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombre.Text = "";
                        //NO SE COMO GARCHA DESELECCIONAR LOS ITEMS
                       // lstFunciones.SelectedIndex = -1;
                        //lstFunciones.SelectedItems.Clear();
                       // lstFunciones.ClearSelected();
                    }
                    catch
                    {
                        MessageBox.Show("Hubo un error en el alta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione funciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ya existe el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAlta_FormClosing_1(object sender, FormClosingEventArgs e)
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
