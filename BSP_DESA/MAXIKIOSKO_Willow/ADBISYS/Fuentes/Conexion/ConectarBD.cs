using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;           //Se utiliza para la conexion con SQL.
using System.Data.SqlClient; //Se utiliza para la conexion con SQL.
using System.IO;
using System.Collections;

namespace ADBISYS.Conexion
{
    public partial class ConectarBD
    {
        SqlConnection conexion = new SqlConnection();
        DataSet dataSet = new DataSet();
        static String CONFIG_FILE_PATH = "..\\..\\..\\Config\\Config.ini";

        public String getPropertyFromConfigFile(String prop)
        {
            String property = "";
            StreamReader objReader = new StreamReader(CONFIG_FILE_PATH);
            String sLine = "";

            ArrayList arrText = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine.Contains(prop))
                {
                    arrText.Add(sLine);
                }
            }
            objReader.Close();
            foreach (string sOutput in arrText)
            {
                int ini = sOutput.LastIndexOf("=") + 1;
                property = sOutput.Substring(ini);
            }

            return property;
        }


        public void conectar() //Metodo para abrir la conexion
        {
            try
            {
                string data_source = getPropertyFromConfigFile("Data_Source=");
                string initial_catalog = getPropertyFromConfigFile("Initial_catalog=");
                string user_id = getPropertyFromConfigFile("User_id=");
                string password = getPropertyFromConfigFile("Password=");
                string connect_timeout = getPropertyFromConfigFile("Connect_Timeout=");

                string stringConexion = "Data Source=" + data_source;
                stringConexion = stringConexion + ";initial catalog=" + initial_catalog;
                stringConexion = stringConexion + "; user id =" + user_id;
                stringConexion = stringConexion + ";password=" + password;
                stringConexion = stringConexion + ";Connect Timeout=" + connect_timeout;

                conexion = new SqlConnection(stringConexion);
                conexion.Open();
            }
            catch (Exception r)
            {
                Console.Write("Error -> " + r.Message.ToString());
                throw new System.ArgumentException("[Error] -  [" + r.Message.ToString() + "]");
            }

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
            catch (Exception e)
            {
                Console.Write("Error -> " + e.Message.ToString());
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
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
                throw new System.ArgumentException("[Error] -  [" + ex.Message.ToString() + "]");
            }
            dispose();
            return resultado; //regresamos el resultado
        }

        public void ejecutarQuery(string query) //Metodo para ejecutar exec con stores procedures
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
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
            finally
            {
                dispose();
            }
        }

    }
}
