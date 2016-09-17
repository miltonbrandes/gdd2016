using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Turno
    {
        public int Id { get; set; }
        public int Afiliado { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public DateTime Llegada { get; set; }
        public string Sintomas { get; set; }
        public string Enfermedades { get; set; }
        public int IdMedicoEspecialidad { get; set; }
    }
}
