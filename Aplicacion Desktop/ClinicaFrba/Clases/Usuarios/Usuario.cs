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
}