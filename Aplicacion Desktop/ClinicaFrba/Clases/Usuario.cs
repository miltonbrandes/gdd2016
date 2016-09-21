using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Descripcion { get; set; }
        public int Intentos { get; set; }
        public bool Activo { get; set; }
    }

    public class Afiliado : Usuario
    {
        public int NroAfiliado { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public char EstadoCivil { get; set; }
        public int PlanUsuario { get; set; }
        public char Sexo { get; set; }
        public int CantidadHijos { get; set; }
        public bool Habilitado { get; set; }
        public int CantBonosUsados { get; set; }
    }

    public class Profesional : Usuario
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string TipoDocumento { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
