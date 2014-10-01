﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.FuncionesGenerales;
using ADBISYS.Conexion;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Articulos
{
    public partial class frmBusquedaArticulo : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet Ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, campoAnt, textoAnt = "";
        public bool estoyBuscando;
        public string campo, texto;
        public Dictionary<string, string> campos_tabla = new Dictionary<string, string>();
        
        public frmBusquedaArticulo()
        {
            InitializeComponent();
        }

        private void frmBusquedaArticulo_Load(object sender, EventArgs e)
        {
            cargarComboCampo();
            chkBusqueda.Checked = false;
            cboCampo.Text = campo;
            txtTexto.Text = texto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cargarComboCampo()
        {
            try
            {
                string campoSelec = cboCampo.Text;
                cboCampo.Items.Clear();
                campos_tabla.Clear();

                Entidades.Articulo entArticulos = new ADBISYS.Entidades.Articulo();
                Ds = entArticulos.obtenerCamposArticulos();

                foreach (DataRow dataRow in Ds.Tables[0].Rows)
                {
                    cboCampo.Items.Add(dataRow["CAMPO"]);

                    switch (dataRow["CAMPO"].ToString())
                    {
                        case "CÓDIGO":
                            campos_tabla.Add("ID_Articulo", (dataRow["CAMPO"].ToString()));
                            break;
                        case "DESCRIPCIÓN":
                            campos_tabla.Add("Descripcion", (dataRow["CAMPO"].ToString()));
                            break;
                        default:
                            campos_tabla.Add((dataRow["CAMPO"].ToString()), dataRow["CAMPO"].ToString());
                            break;
                    }
                }

                cboCampo.Text = campoSelec;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (chkBusqueda.Checked == true)
            {
                estoyBuscando = false;
                campo = "";
                texto = "";
                this.Close();
            }
            else
            {
                if (validoCampos()) return;
                busquedaArticulos();
            }
        }

        private void busquedaArticulos()
        {
            try
            {
                cadenaSql = "EXEC adp_busqueda_articulos";
                cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("ARTICULOS", "String");
                cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
                cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(txtTexto.Text, "String").Replace(",", ".");

                Ds.Reset();
                Ds = objConect.ejecutarQuerySelect(cadenaSql);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    estoyBuscando = true;
                    campo = cboCampo.Text;
                    texto = txtTexto.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se encontraron coincidencias.", "Búsqueda de Compras.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboCampo.Focus();
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private object obtenerCampoTabla()
        {
            try
            {
                foreach (KeyValuePair<string, string> campo in campos_tabla)
                {
                    if (cboCampo.Text == campo.Value)
                    {
                        return (campo.Key);
                    }
                }
                return "ok";
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "error";
            }
        }

        private bool validoCampos()
        {
            if (cboCampo.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Campo.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCampo.Focus();
                return true;
            }

            if (txtTexto.Text == "")
            {
                MessageBox.Show("El campo Texto a buscar es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTexto.Focus();
                return true;
            }
            return false;
        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void chkBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBusqueda.Checked == true)
            {
                campoAnt = cboCampo.Text;
                textoAnt = txtTexto.Text;
                //cboCampo.Items.Clear();
                //txtTexto.Text = "";
                cboCampo.Enabled = false;
                txtTexto.Enabled = false;
            }
            else
            {
                cboCampo.Enabled = true;
                txtTexto.Enabled = true;
                //cargarComboCampo();
                cboCampo.Text = campoAnt;
                txtTexto.Text = textoAnt;
            }
        }


    }
}
