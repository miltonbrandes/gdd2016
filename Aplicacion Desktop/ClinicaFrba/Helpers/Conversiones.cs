using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Clases;


namespace Helpers
{
    public static class Conversiones
    {
        #region USUARIO
        public static Usuario ToUsuario(this SqlDataReader rdr)
        {
            return rdr.ToUsuarios().FirstOrDefault();
        }
        public static List<Usuario> ToUsuarios(this SqlDataReader rdr)
        {
            List<Usuario> list = new List<Usuario>();
            while (rdr.Read())
            {
                list.Add(new Usuario()
                {
                    Username = (string)rdr["usuario_id"],
                    Password = (string)rdr["usuario_password"],
                    Descripcion = (string)rdr["usuario_descripcion"],
                    Activo = (bool)rdr["usuario_habilitado"],
                    Intentos = (int)rdr["usuario_cant_intentos"]
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region PLAN
        public static Plan ToPlan(this SqlDataReader rdr)
        {
            return rdr.ToPlanes().FirstOrDefault();
        }
        public static List<Plan> ToPlanes(this SqlDataReader rdr)
        {
            List<Plan> list = new List<Plan>();
            while (rdr.Read())
            {
                decimal preciocuot;
                if (rdr["plan_cuota_precio"].ToString() == "")
                {
                    preciocuot = 0;
                }
                else
                {
                    preciocuot = (decimal)rdr["plan_cuota_precio"];
                }
                    list.Add(new Plan()
                    {

                        Id = (decimal)rdr["plan_id"],
                        PrecioBonoConsulta = (decimal)rdr["plan_precio_bono_consulta"],
                        Descripcion = (string)rdr["plan_descripcion"],
                        CuotaPrecio = preciocuot

                    });
                
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region MODIFICACION PLAN
        public static ModifPlan ToModifPlan(this SqlDataReader rdr)
        {
            return rdr.ToModifPlanes().FirstOrDefault();
        }
        public static List<ModifPlan> ToModifPlanes(this SqlDataReader rdr)
        {
            List<ModifPlan> list = new List<ModifPlan>();
            while (rdr.Read())
            {
                list.Add(new ModifPlan()
                {
                    FechaNacimiento = (DateTime)rdr["modif_plan_fecha"],
                    ModifId = (decimal)rdr["modif_id"],
                    Motivo = (string)rdr["modif_motivo"],
                    NroAfiliado = (decimal)rdr["modif_afiliado"],
                    PlanNuevo = (decimal)rdr["modif_plan_nuevo"],
                    PlanViejo = (decimal)rdr["modif_plan_viejo"],
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region AFILIADO
        public static Afiliado ToAfiliados(this SqlDataReader rdr)
        {
            return rdr.ToAfiliado().FirstOrDefault();
        }
        public static List<Afiliado> ToAfiliado(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Afiliado> list = new List<Afiliado>();
            while (milector.Read())
            {list.Add(new Afiliado()
                {
                    Username = (string)rdr["usuario_id"], //definir si usuario va a tener id usuario
                    NroAfiliado = (decimal)rdr["afiliado_nro"],
                    Nombre = (string)rdr["afiliado_nombre"],
                    Apellido = (string)rdr["afiliado_apellido"],
                    Dni = (decimal)rdr["afiliado_dni"],
                    Mail = (string)rdr["afiliado_mail"],
                    Telefono = (decimal)rdr["afiliado_telefono"],
                    Direccion = (string)rdr["afiliado_direccion"],
                    EstadoCivil = (string)rdr["afiliado_estado_civil"],
                    FechaNacimiento = (DateTime)rdr["afiliado_fecha_nac"], //fecha nacimiento
                    Sexo = (string)rdr["afiliado_sexo"],
                    PlanUsuario = (decimal)rdr["afiliado_plan"],
                    CantidadHijos = (decimal)rdr["afiliado_cant_hijos"],
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region PROFESIONAL
        public static Profesional ToProfesionales(this SqlDataReader rdr)
        {
            return rdr.ToProfesional().FirstOrDefault();
        }
        public static List<Profesional> ToProfesional(this SqlDataReader rdr)
        {
            List<Profesional> list = new List<Profesional>();
            while (rdr.Read())
            {
                list.Add(new Profesional()
                {
                    Username = (string)rdr["usuario_id"], //definir si usuario va a tener id usuario
                    Matricula = (int)rdr["profesional_matricula"],
                    Nombre = (string)rdr["profesional_nombre"],
                    Apellido = (string)rdr["profesional_apellido"],
                    Dni = (int)rdr["profesional_dni"],
                    TipoDocumento = (char)rdr["profesional_tipo_documento"],// tipo documento
                    Mail = (string)rdr["profesional_mail"],
                    Telefono = (string)rdr["profesional_telefono"],
                    Direccion = (string)rdr["profesional_direccion"],
                    //fecha = (DateTime)rdr["clie_fecha_nacimiento"], fecha nacimiento
                    sexo = (char)rdr["profesional_sexo"],
                  
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region PROFESIONAL2

        public static List<Profesional> ToProfesional2(this SqlDataReader rdr)
        {
            List<Profesional> list = new List<Profesional>();
            while (rdr.Read())
            {
                list.Add(new Profesional()
                {
                    Matricula = (int)rdr["profesional_matricula"],
                    Nombre = (string)rdr["profesional_nombre"],
                    Apellido = (string)rdr["profesional_apellido"],
                    Mail = (string)rdr["profesional_mail"],
                    Telefono = (string)rdr["profesional_telefono"],
                    Direccion = (string)rdr["profesional_direccion"]
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region ROL
        public static Rol ToRol(this SqlDataReader rdr)
        {
            return rdr.ToRoles().FirstOrDefault();
        }
        public static List<Rol> ToRoles(this SqlDataReader rdr)
        {
            List<Rol> list = new List<Rol>();
            while (rdr.Read())
            {
                list.Add(new Rol()
                {
                    Id = (int)rdr["rol_id"],
                    Descripcion = (string)rdr["rol_descripcion"],
                    Habilitado = (bool)rdr["rol_habilitado"]
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region FUNCION
        public static Funcion ToFuncion(this SqlDataReader rdr)
        {
            return rdr.ToFunciones().FirstOrDefault();
        }
        public static List<Funcion> ToFunciones(this SqlDataReader rdr)
        {
            List<Funcion> list = new List<Funcion>();
            while (rdr.Read())
            {
                list.Add(new Funcion()
                {
                    Id = (int)rdr["funcion_id"],
                    Descripcion = (string)rdr["funcion_descripcion"],
                    //Activo = (bool)rdr["funcionXrol_activo"]
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region ESPECIALIDAD
        public static Especialidad ToEspecialidades(this SqlDataReader rdr)
        {
            return rdr.ToEspecialidad().FirstOrDefault();
        }

        public static List<Especialidad> ToEspecialidad(this SqlDataReader rdr)
        {
            List<Especialidad> list = new List<Especialidad>();
            while (rdr.Read())
            {
                list.Add(new Especialidad()
                {
                    Descripcion = (string)rdr["especialidad_descripcion"],
                    Id = (string)rdr["especialidad_codigo"],
                    //Tipo = (string)rdr["especialidad_tipo"]
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

        #region FRANJA
        public static List<Franja> ToFranja(this SqlDataReader rdr)
        {
            List<Franja> list = new List<Franja>();
            while (rdr.Read())
            {
                list.Add(new Franja()
                {
                    Dia = (string)rdr["dia"],
                    HoraInicio = (string)rdr["hora_inicio"],
                    MinutoInicio = (string)rdr["minuto_inicio"],
                    HoraFin = (string)rdr["hora_fin"],
                    MinutoFin = (string)rdr["minuto_fin"],
                    Id = (string)rdr["id"]
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

    }
}
