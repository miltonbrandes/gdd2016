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
        public int NroAfiliado { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public char EstadoCivil { get; set; }
        public Plan PlanUsuario { get; set; }
        public char Sexo { get; set; }
        public int CantidadHijos { get; set; }
        public bool Habilitado { get; set; }
        public int CantBonosUsados { get; set; }
    }
}
