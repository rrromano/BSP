using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Conexion;

namespace ADBISYS.Entidades
{
    class Rubros
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql,usuario = "";

        public void nuevoRubro(string descripcion)
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_nuevo_rubro";
                cadenaSql = cadenaSql + " @Rubro_Descripcion = " + fg.fcSql(descripcion, "String");
                cadenaSql = cadenaSql + ",@Rubro_Login = " + fg.fcSql(usuario, "String");

                objConect.ejecutarQuery(cadenaSql);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public DataSet obtenerMaximoRubro()
        {
            try
            {
                cadenaSql = "EXEC adp_maximo_rubro";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet verificarRubro(string descripcion)
        {
            try
            {
                cadenaSql = "EXEC adp_verifico_rubro_existente @Rubro_Descripcion = " + fg.fcSql(descripcion, "String");
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
    }
}
