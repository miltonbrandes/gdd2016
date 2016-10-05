﻿using System;
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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class frmAfiliado : Form
    {
        //OPCION 1 ES ALTA AFILIADO OPCION 2 ES MODIFICAR AFILIADO (ES EN LA MISMA PANTALLA)
        public static Usuario usuario;
        public static Plan planactual;
        public static Rol rol;
        public static Afiliado afiliadoModificar;
        public int opcionelegida;
        public int i = 0;
        public frmAfiliado(Usuario us, Rol ro, Afiliado afil, int opcion)
        {
            InitializeComponent();
            usuario = us;
            rol = ro;
            afiliadoModificar = afil;
            opcionelegida = opcion;
            if (opcion == 1)
            {
                lblEstado.Visible = false;
                ckbEstado.Visible = false;
                btnHabilitar.Visible = false;
                cargarPlanes();
            }
            else if (opcion == 2)
            {
                txtNombre.Text = afiliadoModificar.Nombre;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtApellido.Text = afiliadoModificar.Apellido;
                txtDni.Text = afiliadoModificar.Dni.ToString();
                txtDni.Enabled = false;
                agregarPlanes(afiliadoModificar.PlanUsuario);
                txtMail.Text = afiliadoModificar.Mail;
                cmbEstadoCivil.Text = reconocerEstadoCivil(afiliadoModificar);
                txtTelefono.Text = afiliadoModificar.Telefono.ToString();
                txtDireccion.Text = afiliadoModificar.Direccion;
                dtpFecha.Value = afiliadoModificar.FechaNacimiento;
                dtpFecha.Enabled = false;
                planactual = (Plan)cmbPlan.SelectedItem;
                ckbEstado.Checked = usuario.Activo;
                btnContraseña.Visible = true;
                cmbSexo.Text = reconocerSexo(afiliadoModificar);

                if (!usuario.Activo)
                {
                    btnHabilitar.Visible = true;
                }
            }
        }
        
        public void agregarPlanes(decimal planUsuario)
        {

            List<Plan> plan = null;
            var parametros = new Dictionary<string, object>() {
                    { "@IdPlan", afiliadoModificar.PlanUsuario}
                };
            try
            {
                plan = DBHelper.ExecuteReader("Planes_GetPorId", parametros).ToPlanes();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            List<Plan> otrosPlanes = null;
            try
            {
                otrosPlanes = DBHelper.ExecuteReader("Planes_GetAll", null).ToPlanes();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            foreach (Plan p in otrosPlanes)
            {
                if (p.Id != plan[0].Id)
                {
                    plan.Add(p);
                }
            }
            cmbPlan.DataSource = plan;
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.SelectedItem = cmbPlan.Items[0];
            
            return;
        }

        public void cargarPlanes()
        {

            List<Plan> otrosPlanes = null;
            try
            {
                otrosPlanes = DBHelper.ExecuteReader("Planes_GetAll", null).ToPlanes();
            }
            catch
            {
                MessageBox.Show("Hubo un error al acceder a la base de datos, intente nuevamente", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cmbPlan.DataSource = otrosPlanes;
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.SelectedItem = cmbPlan.Items[0];
            return;
        }

        public string reconocerEstadoCivil(Afiliado afiliadoModificar)
        {
            if (afiliadoModificar.EstadoCivil == "N")
            {
                return "No Especifica";
            }
            else if (afiliadoModificar.EstadoCivil == "C")
            {
                return "Casado/a";
            }
            else if (afiliadoModificar.EstadoCivil == "D")
            {
                return "Divorciado/a";
            }
            else if (afiliadoModificar.EstadoCivil == "S")
            {
                return "Soltero/a";
            }
            else if (afiliadoModificar.EstadoCivil == "V")
            {
                return "Viudo/a";
            }
            return null;
        }

        public string reconocerSexo(Afiliado afiliadoModificar)
        {
            if (afiliadoModificar.Sexo == "N")
            {
                return "No Especifica";
            }
            else if (afiliadoModificar.Sexo == "M")
            {
                return "Masculino";
            }
            else if (afiliadoModificar.Sexo == "F")
            {
                return "Femenino";
            }
            return null;
        }

        private void frmAltaAfiliado_Load(object sender, EventArgs e)
        {
            dtpFecha.CustomFormat = "yyyy-M-d HH:mm:ss";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            frmHomeAfiliado acerrar = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "frmHomeAfiliado")
                {
                    acerrar = (frmHomeAfiliado)frm;
                    
                }
            }
            acerrar.Hide();
        }

        private void frmAltaAfiliado_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmHomeAfiliado princ = new frmHomeAfiliado(usuario, rol);
            Hide();
            princ.Show();
        }

        private void btnIngresarFamiliar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosCompletados())
            {
                if (opcionelegida == 1)
                {
                    Plan planElegido = (Plan)cmbPlan.SelectedValue;
                    var afiliado = new Dictionary<string, object>()
                    {
                   
                        { "@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString()},
                        { "@Nombre", txtNombre.Text },
                        { "@Apellido", txtApellido.Text },
                        { "@Dni", Convert.ToInt32(txtDni.Text)  },
                        { "@Mail",  txtMail.Text  },
                        { "@Telefono", txtTelefono.Text  },
                        { "@Direccion",txtDireccion.Text  },
                        { "@CantHijos",  0 },
                        { "@EstadoCivil", cmbEstadoCivil.Text.Substring(0,1)},
                        { "@Fecha", dtpFecha.Value},
                        { "@Plan", Convert.ToDecimal(planElegido.Id) },
                        { "@Sexo", cmbSexo.Text.Substring(0,1)},
                    };

                    if (Alta(afiliado))
                    {
                        Close();
                    }

                }
                else if (opcionelegida == 2)
                {
                    Plan planElegido = (Plan)cmbPlan.SelectedValue;
                    var afiliado = new Dictionary<string, object>()
                    {
                        { "@Nombre", txtNombre.Text },
                        { "@Apellido", txtApellido.Text },
                        { "@Dni", Convert.ToInt32(txtDni.Text)  },
                        { "@CantHijos",  0 },
                        { "@Sexo", cmbSexo.Text.Substring(0,1)},
                        { "@EstadoCivil", cmbEstadoCivil.Text.Substring(0,1)},
                        { "@Mail",  txtMail.Text  },
                        { "@Telefono", txtTelefono.Text  },
                        { "@Direccion",txtDireccion.Text  },
                        { "@Plan", Convert.ToDecimal(planElegido.Id) },
                        { "@Fecha", dtpFecha.Value},
                    };
                    if (Modificar(afiliado))
                    {
                        Close();
                    }
                }

       
            }
        }
        
        private bool Modificar(Dictionary<string, object> afiliado)
        {
            if (((Plan)cmbPlan.SelectedItem).Id != planactual.Id)
            {
                //HAY QUE CREAR UNA MODIFICACION DEL PLAN
                var planmodif = new Dictionary<string, object>()
                    {
                        { "@PlanNuevoId", ((Plan)cmbPlan.SelectedItem).Id },
                        { "@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString()},
                        { "@Motivo", txtCambioPlan.Text},
                    };

                try
                {
                    DBHelper.ExecuteNonQuery("Agregar_Modif_Plan", planmodif);
                }
                catch
                {
                    MessageBox.Show("Error al modificar el plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            afiliado.Add("@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString());
            try
            {
                DBHelper.ExecuteNonQuery("Afiliado_Modify", afiliado);
            }
            catch 
            {
                MessageBox.Show("Hubo un error inesperado en la modificacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MessageBox.Show("Modificado con exito", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool Alta(Dictionary<string, object> afiliado)
        {
            Usuario user;
            try
            {
                user = DBHelper.ExecuteReader("Usuario_Exists", new Dictionary<string, object>() { { "@usuarioid", txtNombre.Text + txtApellido.Text + txtDni.Text } }).ToUsuario();
            }
            catch
            {
                MessageBox.Show("El Afiliado ingresado ya existia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (user == null)
            {
                try
                {
                    DBHelper.ExecuteNonQuery("Afiliado_Add", afiliado);
                }
                catch
                {
                    MessageBox.Show("No se pudo agregar el afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                MessageBox.Show("Se agrego correctamente el afiliado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (cmbEstadoCivil.Text.Substring(0,1) == "C")//esta casado, ofrezco si quiere registrar a su conyuge
                {
                    DialogResult resultado = MessageBox.Show("Desea agregar a su conyuge a la clinica?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)//quiere decir que quiere registrar a su conyuge
                    {
                        //ACA TENGO QUE IR A UN NUEVO FORMULARIO DE ALTA PARA EL CONYUGE
                    }
                    else // no quiere registrar a su conyuge
                    {
                        DialogResult resultado2 = MessageBox.Show("Desea agregar a algun otro familiar a la clinica?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado2 == DialogResult.Yes)//quiere decir que quiere registrar a su conyuge
                        {
                            //ACA TENGO QUE IR A UN NUEVO FORM DE ALTA PARA EL FAMILIAR
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ese Afiliado ya esta registrado en la clinica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool DatosCompletados()
        {
            int result;
            StringBuilder sb = new StringBuilder();
            if (txtNombre.Text == string.Empty)
            {
                sb.AppendLine("Complete nombre.");
            }

            if (txtApellido.Text == string.Empty)
            {
                sb.AppendLine("Complete apellido.");
            }
            if (txtDni.Text == string.Empty)
            {
                sb.AppendLine("Complete dni.");
            }
            if (txtMail.Text == string.Empty)
            {
                sb.AppendLine("Complete mail.");
            }
            if (txtTelefono.Text == string.Empty)
            {
                sb.AppendLine("Complete telefono.");
            }
            if (txtDireccion.Text == string.Empty)
            {
                sb.AppendLine("Complete direccion.");
            }
            if (cmbEstadoCivil.Text == string.Empty)
            {
                sb.AppendLine("Complete estado civil");
            }
            if (cmbPlan.Text == string.Empty)
            {
                sb.AppendLine("Complete el plan");
            }
            if (dtpFecha.Text == string.Empty)
            {
                sb.AppendLine("Complete fecha.");
            }
            if (!int.TryParse(txtDni.Text, out result))
            {
                sb.AppendLine("El campo DNI debe ser numérico.");
            }
            if (!int.TryParse(txtTelefono.Text, out result))
            {
                sb.AppendLine("El campo Telefono debe ser numerico");
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                MessageBox.Show(sb.ToString(), "Complete los siguientes campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i == 0)
            {
                planactual = (Plan)cmbPlan.SelectedItem;
                i++;
            }
            if (opcionelegida == 2 && planactual.Id != ((Plan)cmbPlan.SelectedItem).Id)
            {
                txtCambioPlan.Visible = true;
                label11.Visible = true;
            }
            if (opcionelegida == 2 && planactual.Id == ((Plan)cmbPlan.SelectedItem).Id)
            {
                txtCambioPlan.Visible = false;
                label11.Visible = false;
            }
        }

    }
}
