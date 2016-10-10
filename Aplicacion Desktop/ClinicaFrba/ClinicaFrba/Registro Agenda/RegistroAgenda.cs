﻿/*
 * Created by SharpDevelop.
 * User: Lelouch
 * Date: 05/10/2016
 * Time: 23:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Clases;
using Helpers;
using System.Data.SqlClient;

namespace ClinicaFrba.Registro_Agenda
{
	public partial class RegistroAgenda : Form
	{
		Profesional profesional;
		TextBox[,] matriz = new TextBox[4,6];
		CustomHour[,] matrizHoras = new CustomHour[4,6];
		
		public RegistroAgenda(Profesional profesional)
		{
			InitializeComponent();
			
			this.profesional = profesional;
			
			#region matriz
			//Hora inicio 1
			matriz[0,0] = horaInicio1Lunes;
			matriz[0,1] = horaInicio1Martes;
			matriz[0,2] = horaInicio1Miercoles;
			matriz[0,3] = horaInicio1Jueves;
			matriz[0,4] = horaInicio1Viernes;
			matriz[0,5] = horaInicio1Sabado;
			//Hora fin 1
			matriz[1,0] = horaFin1Lunes;
			matriz[1,1] = horaFin1Martes;
			matriz[1,2] = horaFin1Miercoles;
			matriz[1,3] = horaFin1Jueves;
			matriz[1,4] = horaFin1Viernes;
			matriz[1,5] = horaFin1Sabado;
			//Hora inicio 2
			matriz[2,0] = horaInicio2Lunes;
			matriz[2,1] = horaInicio2Martes;
			matriz[2,2] = horaInicio2Miercoles;
			matriz[2,3] = horaInicio2Jueves;
			matriz[2,4] = horaInicio2Viernes;
			matriz[2,5] = horaInicio2Sabado;
			//Horafin 2
			matriz[3,0] = horaFin2Lunes;
			matriz[3,1] = horaFin2Martes;
			matriz[3,2] = horaFin2Miercoles;
			matriz[3,3] = horaFin2Jueves;
			matriz[3,4] = horaFin2Viernes;
			matriz[3,5] = horaFin2Sabado;
			#endregion matriz
			
			listaEspecialidades.DataSource = profesional.Especialidades;
			listaEspecialidades.DisplayMember = "Descripcion";
			listaEspecialidades.ValueMember = "Descripcion";
			
			monthCalendar1.MaxSelectionCount = 1;
			monthCalendar2.MaxSelectionCount = 1;
		}
		
		void ButtonOKClick(object sender, EventArgs e)
		{
			validarTextBoxes();
			validarHoras();
			
			//Ahora tengo que enviarlo a la bd.
		}
		
		#region validacion textBoxes
		private void validarTextBoxes(){
			bool resultado = true;
			
			int i,j;
			for(i=0;i<4;i+2){ //Solo checkeo las filas pares
				for(j=0;j<6;j++){
					
					if( !textBoxCorrecta(i,j) )
						resultado = false;
				}
			}
		}
		
		private bool textBoxCorrecta(int i, int j){
			CustomHour hora1;
			CustomHour hora2;
			
			if(matriz[i,j].Text != null){
				//Miro a ver si la hora inicio y hora fin son correctas
				if( horaCorrecta(matriz[i,j], (CustomHour(hora1)) ) && horaCorrecta(matriz[i+1,j], (CustomHour(hora2)) ) ){

					if(hora1.esAntes(hora2) && CustomHour.esMultiplo30(hora1,hora2)){
						//Son correctas las asigno en matrizHoras
						matrizHoras[i,j] = hora1;
						matrizHoras[i+1,j] = hora2;
						
						return true;
					}
					
					return false;
				}
			}else if(matriz[i+1,j].Text == null)
				return true;
		}
		
		private bool horaCorrecta(TextBox box, out CustomHour hour){
			
			bool resultado = true;
			string[] split = box.Text.Split(':');
			
			foreach(string hora in split ){
				if( !int.TryParse(hora) ){
					resultado = false;
				}
			}
			
			if(resultado){
				try{
					hour = new CustomHour( int.Parse(split[0]),int.Parse(split[1]) );
				}catch(ArgumentOutOfRangeException ex){
					resultado = false;
				}
			}
			
			return resultado;
		}
		#endregion
		
		private bool validarHoras(){
			
			DateTime fecha1;
			DateTime fecha2;
			
			if(fecha1.CompareTo(fecha2) >= 0 )
				return false;
			else return true;
		}
		
	}
}