/*
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
using System.Collections.Generic;
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
			if( !validarTextBoxes() ){
				Array.Clear(matrizHoras,0,matrizHoras.Length);
				return;
			}
			if(!validarFechas())
				return;
			if(!validarComboBox())
				return;
			
			//Ahora tengo que enviarlo a la bd.
			int agenda_id;
			
			Dictionary<string,object> parametros = new Dictionary<string,object>(){
				{"@matricula",profesional.Matricula},
				{"@especialidad",listaEspecialidades.SelectedValue.ToString()},
				{"@fecha_inicio",monthCalendar1.SelectionStart},
				{"@fecha_fin",monthCalendar2.SelectionStart}
			};
			List<string> outputParam = new List<string>(){"@id_agenda"};
			SqlParameterCollection sqlParameters = DBHelper.ExecuteNonQueryWithOutput("Agenda_Agregar",outputParam,parametros);
			agenda_id = (int)sqlParameters[parametros.Count].Value;
			
			//Ya agregue la agenda, ahora tengo que enviar todas las franjas
			int i,j;
			for(i=0;i<4;i=i+2){
				for(j=0;j<6;j++){
					if(matrizHoras[i,j] != null){
						parametros = new Dictionary<string, object>(){
							{"@agenda_id",agenda_id},
							{"@dia",j},
							{"@hora_inicio",matrizHoras[i,j].hora},
							{"@minuto_inicio",matrizHoras[i,j].minuto},
							{"@hora_fin",matrizHoras[i+1,j].hora},
							{"@minuto_fin",matrizHoras[i+1,j].minuto},
						};
						DBHelper.ExecuteNonQuery("Franja_Agregar",parametros);
					}
				}
			}
			
			//for(DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
			for(DateTime fecha = monthCalendar1.SelectionStart;
			    fecha.Date <= monthCalendar2.SelectionStart;
			    fecha = fecha.AddDays(1) )
			{
				int indice = (int)fecha.DayOfWeek -1;
				if(fecha.DayOfWeek != DayOfWeek.Sunday){
					if(matrizHoras[0,indice] != null){
						generarTurnos(matrizHoras[0,indice],matrizHoras[1,indice],fecha);
					}
					if(matrizHoras[2,indice] != null){
						generarTurnos(matrizHoras[2,indice],matrizHoras[3,indice],fecha);
					}
				}
			}
			
			//Listo, cerrar el form
		}
		
		private void generarTurnos(CustomHour horaInicio, CustomHour horaFin, DateTime fecha){
			
			int cantTurnos = ( horaInicio.toMinutes() - horaFin.toMinutes() ) / 30;
			int i;
			for(i=0;i<cantTurnos;i++){
				CustomHour aux = CustomHour.FromMinutes(horaInicio.toMinutes() + 30 * i);
				fecha.AddHours(aux.hora);
				fecha.AddMinutes(aux.minuto);
				
				//Genero el turno
				Dictionary<string,object> parametros = new Dictionary<string, object>(){
					{"@matricula",profesional.Matricula},
					{"@especialidad",profesional.Especialidades[listaEspecialidades.SelectionStart].Id},
					{"@fecha",fecha}
				};
				DBHelper.ExecuteNonQuery("Turno_Agregar",parametros);
			}
		}
		
		#region validacion textBoxes
		private bool validarTextBoxes(){
			bool resultado = true;
			int horasTotales = 0;
			const int horaAperturaSemana = 7;
			const int horaCierreSemana = 20;
			const int horaAperturaSabado = 10;
			const int horaCierreSabado = 15;
			
			bool errorTextBox = false;
			int i,j;
			for(i=0;i<4;i=i+2){ //Solo checkeo las filas pares
				for(j=0;j<6;j++){
					
					if( !textBoxCorrecta(i,j) ){
						resultado = false;
						errorTextBox = true;
					}
				}
			}
			
			//Hago la validacion para ver que no se crucen las horas
			bool horaCruzada = false;
			if(resultado){
				
				for(j=0;j<6;j++){
					
					if(matrizHoras[0,j] != null && matrizHoras[2,j] != null){
						if( matrizHoras[1,j].esDespues(matrizHoras[2,j]) ){
							resultado = false;
							horaCruzada = true;
						}
					}
				}
			}
			
			//Valido que el total de horas no supere 48
			bool totalHorasMayorA48 = false;
			if(resultado){
				
				for(i=0;i<4;i=i+2){
				for(j=0;j<6;j++){
					if(matrizHoras[i,j] != null)
						horasTotales += matrizHoras[i+1,j].toMinutes() - matrizHoras[i,j].toMinutes();
					}
				}
				if(horasTotales > 48*60){
					resultado = false;
					totalHorasMayorA48 = true;
				}
			}
			
			//Valido que la clinica este abierta
			bool clinicaAbierta = false;
			if(resultado){
				
				for(i=0;i<4;i++){
					for(j=0;j<6;j++){
						if(matrizHoras[i,j] != null){ 
							if( j != 5 ){
								if(matrizHoras[i,j].hora < horaAperturaSemana || matrizHoras[i,j].hora > horaCierreSemana){
									resultado = false;
									clinicaAbierta = true;
								}
							}else if(matrizHoras[i,j].hora < horaAperturaSabado || matrizHoras[i,j].hora > horaCierreSabado){
								resultado = false;
								clinicaAbierta = true;
							}
						}
					}
				}
			}
			
			//Muestro los mensajes de error
			if(clinicaAbierta)
				MessageBox.Show("Los horarios introducidos no se corresponden con los horarios de apertura de la clinica. " +
				                "Por favor introduzca de 7:00 a 20:00 (dia de semana) o de 10:00 a 15:00 (dias sábados).",
				                "Horarios fuera de rango",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			if(totalHorasMayorA48)
				MessageBox.Show("El total de horas ingresadas supera las 48. Por una política interna de la organizacion " +
				                "esto es imposible. Revise los horarios ingresados",
				                "Total de Horas incorrecto",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			if(horaCruzada)
				MessageBox.Show("La Hora Fin 1 no puede ser anterior a la Hora de Inicio 2.",
				                "Horario Incorrecto",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			if(errorTextBox)
				MessageBox.Show("Tenga en cuenta que:" + Environment.NewLine +
				                "si introdujo una Hora Inicio, tambien debe introducir una Hora Fin." + Environment.NewLine +
				                "El formato correcto de hora es: 15:30." + Environment.NewLine +
				                "La Hora Inicio debe ser anterior a la Hora Fin." + Environment.NewLine +
				                "El intervalo introducido debe ser multiplo de 30 minutos.",
				                "Horario incorrecto",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			
			return resultado;
		}
		
		private bool textBoxCorrecta(int i, int j){
			CustomHour hora1;
			CustomHour hora2;
			
			if(matriz[i,j].Text != null){
				//Miro a ver si la hora inicio y hora fin son correctas
				if( horaCorrecta(matriz[i,j], out hora1) && horaCorrecta(matriz[i+1,j], out hora2) ){

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
			
			return false;
		}
		
		private bool horaCorrecta(TextBox box, out CustomHour hour){
			
			bool resultado = true;
			string[] split = box.Text.Split(':');
			int horaParseada;
			
			foreach(string hora in split ){
				if( !int.TryParse(hora,out horaParseada) ){
					resultado = false;
				}
			}
			
			if(resultado){
				try{
					hour = new CustomHour( int.Parse(split[0]),int.Parse(split[1]) );
				}catch(ArgumentOutOfRangeException ex){
					resultado = false;
					hour = null;
				}
			}else hour = null;
			
			return resultado;
		}
		#endregion
		
		private bool validarFechas(){
			
			DateTime fecha1 = monthCalendar1.SelectionStart;
			DateTime fecha2 = monthCalendar2.SelectionStart;
			
			if(fecha1.CompareTo(fecha2) >= 0 )
				return false;
			else return true;
		}
		
		private bool validarComboBox(){
			return listaEspecialidades.SelectedValue != null;
		}

        private void RegistroAgenda_Load(object sender, EventArgs e)
        {

        }
	}
}