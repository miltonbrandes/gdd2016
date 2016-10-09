/*
 * Created by SharpDevelop.
 * User: Lelouch
 * Date: 09/10/2016
 * Time: 15:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ClinicaFrba.Registro_Agenda
{
	/// <summary>
	/// Description of CustomHour.
	/// </summary>
	public class CustomHour
	{
		public int hora, minuto;
		
		public CustomHour(int hora, int minuto)
		{
			if(hora < 0 || hora > 24 || minuto < 0 || minuto > 59){
				throw new ArgumentOutOfRangeException();
			}else{
				this.hora = hora;
				this.minuto = minuto;
			}
		}
		
		public bool esDespues(CustomHour hour){
			
			if(hora == hour.hora){
				return minuto > hour.minuto;
			}else if(hora > hour.hora){
				return true;
			}else return false;
		}
		
		public bool esAntes(CustomHour hour){
			
			if(hora == hour.hora){
				return minuto < hour.minuto;
			}else if(hora < hour.hora){
				return true;
			}else return false;
		}
	}
}
