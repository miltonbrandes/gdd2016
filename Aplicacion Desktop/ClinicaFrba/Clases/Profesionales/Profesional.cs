/*
 * Created by SharpDevelop.
 * User: Lelouch
 * Date: 23/09/2016
 * Time: 20:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Clases
{
	public class Profesional : Usuario
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public char TipoDocumento { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public char sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
