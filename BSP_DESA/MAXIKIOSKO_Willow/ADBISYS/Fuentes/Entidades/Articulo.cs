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
    class Articulo
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";

        public DataSet obtenerArticulos()
        {
            try
            {
                cadenaSql = "EXEC adp_obtener_articulos";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerInfoRubros()
        {
            try
            {
                cadenaSql = "EXEC adp_info_rubros";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public DataSet validarExistenciaArticulo(string codigo)
        {
            try
            {
                cadenaSql = "EXEC adp_verificoExistencia_articulo @Codigo = " + fg.fcSql(codigo, "String");
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public void eliminarArticulo(string id_articulo)
        {
            try
            {
                string usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_eliminar_articulo @Id_articulo = " + fg.fcSql(id_articulo, "String");
                if (usuario != "")
                { cadenaSql = cadenaSql + ",@Articulo_Login = " + fg.fcSql(usuario, "String"); }
                
                objConect.ejecutarQuery(cadenaSql);

            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
    }
}
