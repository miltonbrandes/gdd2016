using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Bono
    {
        public decimal Id { get; set; }
        public decimal Afiliado { get; set; }
        public decimal Plan { get; set; }
        public decimal Turno { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Utilizado { get; set; }
        public decimal NroBonoAfiliado { get; set; }
    }
}
