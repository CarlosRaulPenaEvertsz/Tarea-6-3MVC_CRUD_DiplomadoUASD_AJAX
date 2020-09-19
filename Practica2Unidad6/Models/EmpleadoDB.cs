using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVC_CRUD_DiplomadoUASD_AJAX.Models
{
    public class EmpleadoDB
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionStrDB"].ConnectionString;
        //"Data Source=LAPTOP-VI2SDCNA;Initial Catalog=EmpleadoDB;Integrated Security=true";


        #region Optener listado de todos los empleados
        public List<Empleado> ListAll()
        {
            List<Empleado> list = new List<Empleado>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectEmpleado", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(new Empleado
                    {
                        EmpleadoID = Convert.ToInt32(rdr["EmpleadoID"]),
                        Nombres = rdr["Nombres"].ToString(),
                        Apellidos = rdr["Apellidos"].ToString(),
                        Edad = Convert.ToInt32(rdr["Edad"]),
                        EstadoCivil = rdr["EstadoCivil"].ToString(),
                        Pais = rdr["Pais"].ToString()
                    }
                    );
                }
            }
            return list;
        }
        #endregion

        #region Insertar un empleado
        public int Add(Empleado emp)
        {
            int i;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmpleado", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.EmpleadoID);
                com.Parameters.AddWithValue("@Nombres", emp.Nombres);
                com.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                com.Parameters.AddWithValue("@Edad", emp.Edad);
                com.Parameters.AddWithValue("@EstadoCivil", emp.EstadoCivil);
                com.Parameters.AddWithValue("@Pais", emp.Pais);
                com.Parameters.AddWithValue("@Opt", 0);
                i = com.ExecuteNonQuery();


                //SqlCommand cmd = new SqlCommand($"InsertupdateEmpleado" +
                //                                $"@ID = '{0}'," +
                //                                $"@Nombres = '{emp.Nombres}'," +
                //                                $"@Apellidos = '{emp.Apellidos}'," +
                //                                $"@Edad = '{emp.Edad}'," +
                //                                $"@EstadoCivil = '{emp.EstadoCivil}'," +
                //                                $"@Pais = '{emp.Pais}'," +
                //                                $"@Opt = '{0}'", con);
                //i = cmd.ExecuteNonQuery();
            }

            return i;
        }
        #endregion

        #region Actualizar empleado
        public int Update(Empleado emp)
        {
            int i;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmpleado", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.EmpleadoID);
                com.Parameters.AddWithValue("@Nombres", emp.Nombres);
                com.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                com.Parameters.AddWithValue("@Edad", emp.Edad);
                com.Parameters.AddWithValue("@EstadoCivil", emp.EstadoCivil);
                com.Parameters.AddWithValue("@Pais", emp.Pais);
                com.Parameters.AddWithValue("@Opt", 1);
                i = com.ExecuteNonQuery();

                //con.Open();
                //SqlCommand cmd = new SqlCommand($"InsertupdateEmpleado" +
                //                                $"@ID = '{emp.EmpleadoID}'," +
                //                                $"@Nombres = '{emp.Nombres}'," +
                //                                $"@Apellidos = '{emp.Apellidos}'," +
                //                                $"@Edad = '{emp.Edad}'," +
                //                                $"@EstadoCivil = '{emp.EstadoCivil}'," +
                //                                $"@Pais = '{emp.Pais}'," +
                //                                $"@Opt = '{1}'", con);
                //i = cmd.ExecuteNonQuery();
            }

            return i;
        }
        #endregion

        #region Eliminar un empleado
        public int Delete(int ID)
        {
            int i;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"DeleteEmpleado @Id = '{ID}'", con);
                i = cmd.ExecuteNonQuery();
            }

            return i;
        }
        #endregion
    }
}