using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Turno
    {
        public decimal Id { get; set; }
        public decimal Afiliado { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public DateTime Llegada { get; set; }
        //public string Sintomas { get; set; }
        //public string Enfermedades { get; set; }
        public int IdMedicoEspecialidad { get; set; }
        public bool Tiempo { get; set; }
    }
}
