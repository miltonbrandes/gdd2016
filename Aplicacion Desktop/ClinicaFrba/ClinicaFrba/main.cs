using Clases;
using ClinicaFrba.AbmRol;
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

namespace ClinicaFrba
{
    public partial class Main : Form
    {
        public static Usuario usuario { get; private set; }
        public static Rol rol;
        public static int i = 0;
        public static Profesional profesional;
        public static Afiliado afiliado;
        public static int load = 0;
        public Main(Usuario us, Rol ro)
        {
            InitializeComponent();
            i = 0;
            usuario = us;
            rol = ro;
            DateTime f = ConfigTime.getFecha();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            int tamanio = 0;
            int cantbot = 0;
            var funciones = DBHelper.ExecuteReader("RolXFuncion_GetFunByRol", new Dictionary<string, object>() { { "@rol", rol.Id } }).ToFunciones();
            var botones = new List<Control>();
            //Obtengo los botones de la vista
            foreach (Control control in Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    tamanio = control.Height;
                    botones.Add(control);
                }
            }
            botones.Reverse();
            int i = 0;
            foreach (Funcion fun in funciones)
            {
                cantbot++;
                botones[i].Visible = true;
                botones[i].Text = fun.Descripcion;
                botones[i].Click += dicFunciones[fun.Id];
                i++;
            }
          this.Size = new Size(this.Width, (tamanio*(cantbot+1))+150);
          load+= 1;
        }

        public static void cargarProfesional(){
            //if(usuario.Username == "admin"
        	Dictionary<string, object> parametros = new Dictionary<string, object>()
        		{ {"@username", usuario.Username} };
        	profesional = DBHelper.ExecuteReader("Profesional_GetProfesionalSegunUsuario", parametros).ToProfesionales();
        	
        	parametros = new Dictionary<string, object>()
        		{ {"@matricula",profesional.Matricula} };
        	profesional.Especialidades = DBHelper.ExecuteReader("Especialidad_GetByMatricula",parametros).ToEspecialidad();
        }
        public static void cargarAfiliado()
        {
            if (usuario.Username == "admin")
            {   
                Dictionary<string, object> parametros = new Dictionary<string, object>() { { "@username",  "administrador32405354"} };
                afiliado = DBHelper.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", parametros).ToAfiliados();
            }
            else
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>() { { "@username", usuario.Username } };
                afiliado = DBHelper.ExecuteReader("Afiliado_GetAfiliadoSegunUsuario", parametros).ToAfiliados();
            }
        }
        
        //Esto es mucho mas facil con un enum.
        Dictionary<int, EventHandler> dicFunciones = new Dictionary<int, EventHandler>() {
            { 1, new EventHandler(ABMRol)},
            { 3, new EventHandler(ABMAfiliado)},
            { 2, new EventHandler(ABMUsuario)},
            { 4, new EventHandler(ABMPlan)},
            { 5, new EventHandler(ABMProfesional)},
            { 6, new EventHandler(ABMEspecialidad)},
            { 7, new EventHandler(RegistrarAgenda)},
            { 8, new EventHandler(ComprarBono)},
            { 9, new EventHandler(PedirTurno)},
            { 10, new EventHandler(RegistrarLlegada)},
            { 11, new EventHandler(RegistrarResultado)},
            { 13, new EventHandler(CancelarTurno)},
            { 12, new EventHandler(HistorialUsuario)}
        };


        public static void CerrarSesion(object sender, EventArgs e)
        {
            afiliado = null;
            profesional = null;
            usuario = null;
            FormCollection fc = Application.OpenForms;
            List<Form> acerrar = new List<Form>();
            foreach (Form frm in fc)
            {
                acerrar.Add(frm);
            }
            if (acerrar != null)
            {
                for (int i = 0; i < acerrar.Count; i++)
                    acerrar[i].Close();
            }
            var login = new formInicioSesion();
            login.Show();
            
        }


        public static void ABMRol(object sender, EventArgs e) {
            var home = new AbmRol.frmHome(usuario, rol);
            home.Show();
          
        }
        public static void ABMAfiliado(object sender, EventArgs e)
        {
            var home = new Abm_Afiliado.frmHomeAfiliado(usuario, rol);
            home.Show();
        }
        public static void ABMUsuario(object sender, EventArgs e)
        {
            MessageBox.Show("En proceso de implementacion", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*var home = new Abm_Usuario.homeAbmUsuario();
            home.Show();*/
        }
        public static void ABMPlan(object sender, EventArgs e)
        {

            MessageBox.Show("En proceso de implementacion", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*var home = new Abm_Planes.Form1();
            home.Show();*/
        }
        public static void ABMProfesional(object sender, EventArgs e)
        {

            MessageBox.Show("En proceso de implementacion", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
           /* var home = new Abm_Profesional.Form1();
            home.Show();*/
        }
        public static void ABMEspecialidad(object sender, EventArgs e)
        {

            MessageBox.Show("En proceso de implementacion", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*var home = new Abm_Especialidades_Medicas.Form1();
            home.Show();*/
        }
        public static void ComprarBono(object sender, EventArgs e)
        {
            var home = new Compra_Bono.frmCompra(usuario, rol);
            home.Show();
        }
        public static void RegistrarAgenda(object sender, EventArgs e)
        {
            //PASARLE EL PROFESIONAL QUE ESTA REGISTRANDO LA AGENDA
            cargarProfesional();
        	var home = new Registro_Agenda.RegistroAgenda(profesional);
            home.Show();
        }

        public static void PedirTurno(object sender, EventArgs e)
        {
            cargarAfiliado();
            var home = new Pedir_Turno.frmPedidoTurno(afiliado);
            home.Show();
        }
         
        public static void RegistrarLlegada(object sender, EventArgs e)
        {
            var home = new Registro_Llegada.frmLlegadaPaciente();
            home.Show();
        }
        public static void RegistrarResultado(object sender, EventArgs e)
        {
            cargarProfesional();
            var home = new Registro_Resultado.frmRegistroResultado(profesional);
            home.Show();
        }

        public static void CancelarTurno(object sender, EventArgs e)
        {
            if (rol.Descripcion == "Profesional")
            {
                cargarProfesional();
                var home = new Cancelar_Atencion.frmCancelarAtencionMedico(profesional, usuario, rol);
                home.Show();
            }
            else if(rol.Descripcion == "Afiliado")
            {
                cargarAfiliado();
                var home = new Cancelar_Atencion.frmCancelarAtencionAfiliado(afiliado, usuario, rol);
                home.Show();
            }
        }
        public static void HistorialUsuario(object sender, EventArgs e)
        {
            var home = new Listados.frmListadoEstadistico();
            home.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

    
        private void Main_Activated(object sender, EventArgs e)
        {
        
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                i++;
                DialogResult d = MessageBox.Show("¿Seguro que desea cerrar sesion?", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                    CerrarSesion(sender, e);
            }
            else
            {
                i = 0;
            }
        }
    }
}
