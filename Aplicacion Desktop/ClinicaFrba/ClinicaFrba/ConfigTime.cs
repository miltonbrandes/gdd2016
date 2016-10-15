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

namespace ClinicaFrba
{
	public static class ConfigTime
	{
		public static DateTime Fecha{ 
			get{
				
				if(NowViejo == DateTime.MinValue)
					NowViejo = DateTime.Now;
				
				try{
					Fecha = DateTime.Parse(ConfigurationManager.AppSettings["fecha"]);
				}catch(FormatException e){
					//imprimir mensaje error
				}
				
				return Fecha.Add(DateTime.Now.Subtract(NowViejo));
			}
		}
		
		private static DateTime NowViejo;
		
	}
}
