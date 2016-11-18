using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Franja
    {
        public int Id { get; set; }
        public int Dia { get; set; }
        public int HoraInicio { get; set; }
        public int MinutoInicio { get;set; }
        public int HoraFin { get; set; }
        public int MinutoFin { get;set; }
        public int Agenda { get; set; }
        public bool Cancelada { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        //public string Afiliado { get; set; }
    }
}
