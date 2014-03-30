using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;           //Se utiliza para la conexion con SQL.
using System.Data.SqlClient; //Se utiliza para la conexion con SQL.

namespace ADBISYS.Conexion
{
    public partial class ConectarBD
    {
        SqlConnection conexion = new SqlConnection();
        DataSet dataSet = new DataSet();

        public void conectar() //Metodo para abrir la conexion
        {
            conexion = new SqlConnection("Data Source=.\\SQLSERVER2008;initial catalog = ADBISYS; user id = bsp; password = bspadmin; Connect Timeout=120");
            conexion.Open();
        }

        public void cerrar() //Metodo para cerrar la conexion
        {
            conexion.Close();
        }

        private void dispose() //Metodo para vaciar la conexion
        {
            conexion.Dispose();
        }

        private void verificarConexionCerrada() //Metodo de verificacion de conexion cerrada
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conectar();
            }
        }

        public DataSet ejecutarQuerySelect(string query) //Metodo que ejecuta querys de Selects
        {
            try
            {
                dataSet.Reset();
                verificarConexionCerrada();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);
                dataAdapter.Fill(dataSet);
            }
            catch (Exception)
            {

            }
            finally
            {
                dispose();
            }
            return dataSet;
        }

        public bool ejecutarReader(string query, string user, string password) //Metodo que se ejecuta en el login
        {
            bool resultado = false;
            try
            {
                verificarConexionCerrada();
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string log = rdr.GetValue(0).ToString();
                    string pass = rdr.GetValue(1).ToString();
                    if (user == log && password == pass) //si el login y password es = entonces es correcto
                    {
                        resultado = true;
                        break; //rompemos el ciclo while
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error: " + ex.Message);
            }
            dispose();
            return resultado; //regresamos el resultado
        }

        public void ejecutarQuery(string query) //Metodo para ejecutar exec con stored procedure
        {
            try
            {
                verificarConexionCerrada();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write("Error -> " + e.Message.ToString());
            }
            finally
            {
                dispose();
            }
        }

    }
}
