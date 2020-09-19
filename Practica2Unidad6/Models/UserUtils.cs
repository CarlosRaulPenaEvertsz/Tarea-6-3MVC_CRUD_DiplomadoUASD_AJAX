using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_AJAX.Models
{
    public class UserUtils
    {
        public static SqlConnection con()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStrDB"].ConnectionString);
            cnn.Open();
            return cnn;
        }

        //string cs = ConfigurationManager.ConnectionStrings["ConnectionStrDB"].ConnectionString;

        public static int AddUser(User u)
        {
            int retorno = 0;
            using (SqlConnection conexion = con())
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Users (Name, LastName, UserName, Password)" +
                                                 $"VALUES('{u.Name}','{u.LastName}','{u.UserName}','{u.Password}')", conexion);
                retorno = cmd.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int EditarUser(User u)
        {
            int retorno = 0;
            using (SqlConnection conexion = con())
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Users SET Name = '{u.Name}', " +
                                            $"LastName = '{u.LastName}', UserName = '{u.UserName}', " +
                                            $"Password = '{u.Password}', Email = '{u.Email}' " +
                                            $"WHERE IdUser = '{u.IdUser}'", conexion);
                retorno = cmd.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int DelUser(int id)
        {
            int retorno = 0;
            using (SqlConnection conexion = con())
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM Users WHERE IdUser = '{id}'", conexion);
                retorno = cmd.ExecuteNonQuery();
            }

            return retorno;
        }
    }
}