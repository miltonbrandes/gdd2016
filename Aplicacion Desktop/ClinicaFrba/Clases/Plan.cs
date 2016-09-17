using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Plan
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string PrecioBonoConsulta { get; set; }
        public int PrecioBonoFarmacia { get; set; }
        public string CuotaPrecio { get; set; }
    }
}
