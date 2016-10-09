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
using Clases;
using Helpers;
using System.Data.SqlClient;

namespace ClinicaFrba.Registro_Agenda
{
	public partial class RegistroAgenda : Form
	{
		Profesional profesional;
		
		public RegistroAgenda(Profesional profesional)
		{
			InitializeComponent();
			
			this.profesional = profesional;
		}

	}
}