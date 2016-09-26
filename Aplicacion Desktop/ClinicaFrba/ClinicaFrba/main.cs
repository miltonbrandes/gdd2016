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
        public Main(Usuario us, Rol ro)
        {
            InitializeComponent();
            usuario = us;
            rol = ro;
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
          this.Size = new Size(this.Width, (tamanio*cantbot)+100);
          //  this.Size= new Size((tamanio*cantbot)+70, this.Height);
            
        }

        Dictionary<int, EventHandler> dicFunciones = new Dictionary<int, EventHandler>() {
            { 1, new EventHandler(ABMRol)},
            { 2, new EventHandler(ABMAfiliado)},
            { 3, new EventHandler(ABMUsuario)},
            { 4, new EventHandler(ABMPlan)},
            { 5, new EventHandler(ABMProfesional)},
            { 6, new EventHandler(ABMEspecialidad)},
            { 7, new EventHandler(RegistrarAgenda)},
            { 8, new EventHandler(ComprarBono)},
            { 9, new EventHandler(PedirTurno)},
            { 10, new EventHandler(RegistrarLlegada)},
            { 11, new EventHandler(RegistrarResultado)},
            { 12, new EventHandler(CancelarTurno)},
            { 13, new EventHandler(HistorialUsuario)}
        };

        static void ABMRol(object sender, EventArgs e) {
            var home = new AbmRol.frmHome();
            home.Show();
        }
        static void ABMAfiliado(object sender, EventArgs e)
        {
            var home = new Abm_Afiliado.Form1();
            home.Show();
        }
        static void ABMUsuario(object sender, EventArgs e)
        {
            var home = new Abm_Usuario.homeAbmUsuario();
            home.Show();
        }
        static void ABMPlan(object sender, EventArgs e)
        {
            var home = new Abm_Planes.Form1();
            home.Show();
        }
        static void ABMProfesional(object sender, EventArgs e)
        {
            var home = new Abm_Profesional.Form1();
            home.Show();
        }
        static void ABMEspecialidad(object sender, EventArgs e)
        {
            var home = new Abm_Especialidades_Medicas.Form1();
            home.Show();
        }
        static void ComprarBono(object sender, EventArgs e)
        {
            var home = new Compra_Bono.Form1(); //aca habria que pasarle el usuario
            home.Show();
        }
        static void RegistrarAgenda(object sender, EventArgs e)
        {
            var home = new Registrar_Agenta_Medico.Form1();
            home.Show();
        }
        static void PedirTurno(object sender, EventArgs e)
        {
            var home = new Pedir_Turno.Form1();
            home.Show();
        }
        static void RegistrarLlegada(object sender, EventArgs e)
        {
            var home = new Registro_Llegada.Form1();
            home.Show();
        }
        static void RegistrarResultado(object sender, EventArgs e)
        {
            var home = new Registro_Resultado.Form1();
            home.Show();
        }

        static void CancelarTurno(object sender, EventArgs e)
        {
            var home = new Cancelar_Atencion.Form1();
            home.Show();
        }
        static void HistorialUsuario(object sender, EventArgs e)
        {
            var home = new Listados.Form1();
            home.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
