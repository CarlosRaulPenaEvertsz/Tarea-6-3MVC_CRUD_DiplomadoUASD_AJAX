using MVC_CRUD_DiplomadoUASD_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_AJAX.Controllers
{
    public class UserUtil
    {
        public static SqlConnection con()
        {
            SqlConnection cnn = new SqlConnection("Data Source=LAPTOP-VI2SDCNA;Initial Catalog=LoginDB; Integrated Security=true");
            cnn.Open();
            return cnn;
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