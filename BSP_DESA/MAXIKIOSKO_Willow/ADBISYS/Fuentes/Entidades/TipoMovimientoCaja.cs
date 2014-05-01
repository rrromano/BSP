using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADBISYS.Conexion;
using ADBISYS.Entidades;
using ADBISYS.FuncionesGenerales;
using System.Data;

namespace ADBISYS.Entidades
{
    public class TipoMovimientoCaja
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        private Int32 ID_TipoMovimiento;
        private String Descripcion;
        private Int32 entradaSalida; //1 Ingreso - 0 Salida

        public Int32 m_ID_TipoMovimiento
        {
            get { return ID_TipoMovimiento; }
            set { ID_TipoMovimiento = value; }
        }

        public String m_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public Int32 m_entradaSalida
        {
            get { return entradaSalida; }
            set { entradaSalida = value; }
        }

        internal DataSet obtenerTiposMovimientosCaja()
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

                String sSQL = "";
                sSQL = "EXEC dbo.adp_obtenerTiposMovsCaja";
                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                return Ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        internal void eliminarTipoMovCaja(int id_TipoMovCaja)
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL = "EXEC dbo.adp_eliminarTipoMovCaja @ID_TIPOMOVIMIENTO = " + id_TipoMovCaja;
                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        internal void eliminarTipoMovCajaDeHoy(int Id_TipoMovCaja, DateTime Fecsis)
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL = "EXEC dbo.adp_eliminarMovCajaPorFecha ";
                sSQL = sSQL + " @ID_TIPOMOVIMIENTO = " + Id_TipoMovCaja;
                sSQL = sSQL + " ,@FECHA_MOV = " + fg.fcSql(Fecsis.ToString(),"DATETIME");
                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
    }
}
