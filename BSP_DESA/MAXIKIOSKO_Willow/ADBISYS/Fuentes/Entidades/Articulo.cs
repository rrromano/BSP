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
        #region Declaraciones
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";
        #endregion

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
        public DataSet obtenerArticulos(String Id_Articulo)
        {
            try
            {
                cadenaSql = "EXEC dbo.adp_obtener_articulos";
                cadenaSql = cadenaSql + " @Id_Articulo = " + fg.fcSql(Id_Articulo,"STRING");
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
        public DataSet validarExistenciaArticulo(String Codigo)
        {
            try
            {
                cadenaSql = "EXEC adp_verificoExistencia_articulo @Codigo = " + fg.fcSql(Codigo, "String");
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
        public void eliminarArticulo(String Id_articulo)
        {
            try
            {
                string usuario = Properties.Settings.Default.UsuarioLogueado.ToString();
                
                // Primero paso los articulos a la tabla Articulos_Eliminados.
                cadenaSql = "EXEC adp_articulos_eliminados @Id_articulo = " + fg.fcSql(Id_articulo, "String");
                if (usuario != "")
                { cadenaSql = cadenaSql + ",@Articulo_Login = " + fg.fcSql(usuario, "String"); }
                objConect.ejecutarQuery(cadenaSql);

                // Se eliminan los articulos (delete).
                cadenaSql = "EXEC adp_eliminar_articulo @Id_articulo = " + fg.fcSql(Id_articulo, "String");
                objConect.ejecutarQuery(cadenaSql);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
        public DataSet obtenerCamposArticulos()
        {
            try
            {
                cadenaSql = "EXEC adp_cboBusqueda_Articulos";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
        public DataSet BusquedaManualArticulo(String Descripcion_Articulo)
        {
            try
            {
                cadenaSql = "EXEC dbo.adp_busquedaArticuloPorDescripcion";
                cadenaSql = cadenaSql + " @DescripcionArticulo = " + fg.fcSql(Descripcion_Articulo, "STRING");
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
