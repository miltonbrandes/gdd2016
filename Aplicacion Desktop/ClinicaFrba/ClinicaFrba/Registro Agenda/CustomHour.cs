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
		
		/// <summary>
		/// Hora1 debe ser anterior a hora2
		/// </summary>
		public static bool esMultiplo30(CustomHour hora1, CustomHour hora2){
			
			if( hora1.esDespues(hora2) )
				return false;
			
			return ((hora1.toMinutes() - hora2.toMinutes) % 30) == 0;
		}
		
		public int toMinutes(){
			return hora*60 + minuto;
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
