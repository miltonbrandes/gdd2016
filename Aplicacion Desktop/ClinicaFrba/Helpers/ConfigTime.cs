/*
 * Created by SharpDevelop.
 * User: Lelouch
 * Date: 15/10/2016
 * Time: 13:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Collections.Generic;
using Helpers;

namespace Helpers
{
	public static class ConfigTime
	{
		private static DateTime Fecha{ get; set; }
		
		private static DateTime NowViejo;
		
		public static DateTime getFecha(){
				
			DateTime aux = Fecha;
			try{
				Fecha = DateTime.Parse(ConfigurationManager.AppSettings["fecha"]);	
			}catch(FormatException e){
				//imprimir mensaje error
			}
			
			//Actualizo si se modifico el archivo
			if(!Fecha.Equals(aux)){
				NowViejo = DateTime.Now;
				
				//exec procedure
				Dictionary<string,object> parametros = new Dictionary<string, object>(){
					{"@fecha",Fecha},
					{"@now_viejo",NowViejo}
				};
				ConexionesDB.ExecuteNonQuery("Reestablecer_Fecha",parametros);
			}
			
			return Fecha.Add(DateTime.Now.Subtract(NowViejo));
		}
		
		public static DateTime getFechaSinHora(){
			return Fecha.Date;
		}
	}
}
