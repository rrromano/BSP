using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADBISYS.Conexion;
using ADBISYS.Entidades;
using ADBISYS.FuncionesGenerales;

namespace ADBISYS.Entidades
{
    class MovimientoCaja
    {

        private Int32 tipoMovimiento;
        private String descripcion;
        private Double valor;
        private DateTime fecha;
        private String hora;

        public int m_tipoMovimiento
        {
            get { return tipoMovimiento; }
            set { tipoMovimiento = value; }
        }

        public String m_descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double m_valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public DateTime m_fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public String m_hora
        {
            get { return hora; }
            set { hora = value; }
        }

        public void modificarCajaInicial(DateTime Fecha,  Double Valor)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_modificarCajaInicial ";
                sSQL = sSQL + " @fecha = " + fg.fcSql(Fecha.ToString(), "DATETIME");
                sSQL = sSQL + " ,@Valor = " + fg.fcSql(Valor.ToString(), "DOUBLE");
                con.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public void registrarMovimientosCaja(DateTime Fecha, String Hora)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_registrar_movimientosCaja ";
                sSQL = sSQL + " @fecha = " + fg.fcSql(Fecha.ToString(), "DATETIME");
                sSQL = sSQL + ",@hora  = " + fg.fcSql(Hora, "STRING");
                con.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }


        }

        public void registrarMovimientoCaja(int tipoMovimiento, String descripcion, Double valor, DateTime fecha, String hora)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_registrar_mov_caja ";
                sSQL = sSQL + "     @Tipo_Movimiento = " + fg.fcSql(tipoMovimiento.ToString(), "STRING");
                sSQL = sSQL + " ,   @Descripcion     = " + fg.fcSql(descripcion, "STRING");
                sSQL = sSQL + " ,   @Valor           = " + fg.fcSql(valor.ToString(), "DOUBLE");
                sSQL = sSQL + " ,   @fecha           = " + fg.fcSql(fecha.ToString(), "DATETIME");
                sSQL = sSQL + " ,   @hora            = " + fg.fcSql(hora, "STRING");

                con.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }
    }
}
