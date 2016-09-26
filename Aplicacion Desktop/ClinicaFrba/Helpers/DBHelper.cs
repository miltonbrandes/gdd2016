
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Helpers
{
    //http://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C
    public static class DBHelper
    {
        //DB: DataBase
        public static SqlConnection DB;
        static string conn = ConfigurationManager.AppSettings["connection-string"];
        static DateTime fecha = DateTime.Parse(ConfigurationManager.AppSettings["fecha"]);

        static DBHelper()
        {
            DB = new SqlConnection(conn);
        }

        //SP: StoredProcedure
        public static void ExecuteNonQuery(string SP, Dictionary<string, object> parametros = null)
        {
            if (parametros == null) parametros = new Dictionary<string, object>();
            DB.Open();
            SqlCommand command = new SqlCommand("NOT_NULL." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }

            command.ExecuteNonQuery();
            DB.Close();
        }

        public static SqlDataReader ExecuteReader(string SP, Dictionary<string, object> parametros = null)
        {
            if (parametros == null) parametros = new Dictionary<string, object>();
            DB.Open();
            SqlCommand command = new SqlCommand("NOT_NULL." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }
            SqlDataReader result = command.ExecuteReader();
            return result;
        }
    }
}