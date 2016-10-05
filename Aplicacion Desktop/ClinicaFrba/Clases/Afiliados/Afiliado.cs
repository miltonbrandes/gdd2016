/*
 * Created by SharpDevelop.
 * User: Lelouch
 * Date: 23/09/2016
 * Time: 20:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Clases
{
	public class Afiliado : Usuario
    {
        public decimal NroAfiliado { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public decimal Telefono { get; set; }
        public string Direccion { get; set; }
        public string Apellido { get; set; }
        public decimal Dni { get; set; }
        public string EstadoCivil { get; set; }
        public decimal PlanUsuario { get; set; }
        public string Sexo { get; set; }
        public decimal CantidadHijos { get; set; }
        //public bool Habilitado { get; set; }
        public decimal CantBonosUsados { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
