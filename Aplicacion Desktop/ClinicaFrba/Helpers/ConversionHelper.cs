using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Clases;

namespace Helpers
{
    public static class ConversionHelper
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

        #region AFILIADO
        public static Afiliado ToAfiliados(this SqlDataReader rdr)
        {
            return rdr.ToAfiliado().FirstOrDefault();
        }
        public static List<Afiliado> ToAfiliado(this SqlDataReader rdr)
        {
            List<Afiliado> list = new List<Afiliado>();
            while (rdr.Read())
            {
                list.Add(new Afiliado()
                {
                    Username = (string)rdr["usuario_id"], //definir si usuario va a tener id usuario
                    NroAfiliado = (int)rdr["afiliado_nro"],
                    Nombre = (string)rdr["afiliado_nombre"],
                    Apellido = (string)rdr["afiliado_apellido"],
                    Dni = (int)rdr["afiliado_dni"],
                    // = (string)rdr["clie_tipo_documento"], tipo documento
                    Mail = (string)rdr["afiliado_mail"],
                    Telefono = (string)rdr["afiliado_telefono"],
                    Direccion = (string)rdr["afiliado_direccion"],
                    EstadoCivil = (char)rdr["afiliado_estado_civil"],
                    //fecha = (DateTime)rdr["clie_fecha_nacimiento"], fecha nacimiento
                    Sexo = (char)rdr["afiliado_sexo"],
                    PlanUsuario = (int)rdr["afiliado_plan"],
                    CantBonosUsados = (int)rdr["afiliado_cant_bonos_consulta"],
                    Habilitado = (bool)rdr["afiliado_habilitado"],
                    CantidadHijos = (int)rdr["afiliado_cant_hijos"]
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
                    Descripcion = (string)rdr["funcion_descripcion"]
                });
            }
            DBHelper.DB.Close();
            return list;
        }
        #endregion

    }
}
