﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography; //Para la encriptación de la clave.
using System.Data;                  //Se utiliza para la conexion con SQL.
using System.Data.SqlClient;        //Se utiliza para la conexion con SQL.
using System.Windows.Forms;
using System.Drawing;               //Para COLOR.
using System.IO;                    //STREAMREADER.
using ADBISYS.Conexion;             //para la conexion a la base.

namespace ADBISYS.FuncionesGenerales
{
    class FuncionesGenerales
    {
        ConectarBD conexion = new ConectarBD();
        DataSet dataSet = new DataSet();
        public string mensajeErrorCatch = "No se puede realizar la accion pedida. Por favor, intente más tarde.";

        public DateTime appFechaSistema()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                FuncionesGenerales fg = new FuncionesGenerales();
                DataSet Ds = new DataSet();
                String ssQL = "EXEC dbo.adp_FecSis";

                Ds = Conex.ejecutarQuerySelect(ssQL);
                return DateTime.Parse(Ds.Tables[0].Rows[0]["FECHA_SISTEMA"].ToString());
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
        }
        public DataGridView eliminarBotones(DataGridView dataGridView, String tipo)
        {
            if (tipo == "SELECCIONAR")
            {
                if (dataGridView.Columns["SELECCIONAR"] != null)
                {
                    dataGridView.Columns.Remove(dataGridView.Columns["Seleccionar"]);
                    dataGridView.DataSource = null;
                }
            }
            return dataGridView;
        }

        public DataGridView agregarBotones(DataGridView dataGridView, String tipo)
        {
            if (tipo == "SELECCIONAR")
            {
                DataGridViewCheckBoxColumn ColumnaSeleccionar = new DataGridViewCheckBoxColumn();
                ColumnaSeleccionar.HeaderText = "SEL";
                ColumnaSeleccionar.Name = "SELECCIONAR";
                ColumnaSeleccionar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ColumnaSeleccionar.FlatStyle = FlatStyle.Standard;
                ColumnaSeleccionar.DisplayIndex = dataGridView.Columns.Count;
                ColumnaSeleccionar.CellTemplate.Style.BackColor = Color.Honeydew;
                ColumnaSeleccionar.Width = 80;
                if (dataGridView.Columns["SELECCIONAR"] == null)
                {
                    dataGridView.Columns.Add(ColumnaSeleccionar);
                }
                else
                {
                    dataGridView.Columns.Remove(dataGridView.Columns["Seleccionar"]);
                    dataGridView.Columns.Add(ColumnaSeleccionar);
                }
            }

            return dataGridView;
        }

        public string fcSql(string cadena, string tipoDato)
        {
            try
            {
                switch (tipoDato.ToUpper())
                {
                    case "STRING":
                        cadena = "'" + cadena + "'";
                        break;
                    case  "DOUBLE":
                        cadena = "'" + cadena + "'";
                        break;
                    case "INTEGER":
                        break;
                    case "DATETIME":
                        String result = "";
                        String Dia = DateTime.Parse(cadena).Day.ToString();
                        String Mes = DateTime.Parse(cadena).Month.ToString();
                        String Anio = DateTime.Parse(cadena).Year.ToString();
                        
                        result = result + Anio;
                        switch (Mes.Length) { case 1: result = result + "0" + Mes; break; default: result = result + Mes; break; }
                        switch (Dia.Length) { case 1: result = result + "0" + Dia; break; default: result = result + Dia; break; }
                        
                        cadena = "'" + result + "'";
                        break;
                    default:
                        break;
                }
                return cadena;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
        }

        public DataGridView formatoGrilla(DataGridView Grilla, int Formato)
        {
            Grilla.AllowUserToAddRows = false;
            Grilla.AllowUserToDeleteRows = false;
            Grilla.AllowUserToOrderColumns = false;
            Grilla.AllowUserToResizeColumns = false;
            Grilla.AllowUserToResizeRows = false;
            Grilla.BackgroundColor = Color.White;
            Grilla.Font = new Font("Verdana",11);

            Grilla.StandardTab = true;
            Grilla.RowHeadersVisible = false;
            Grilla.MultiSelect = false;
            Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (Formato == 9) { Grilla.ReadOnly = false; } else { Grilla.ReadOnly = true;}

            for(int i=0;i < Grilla.Columns.Count;i++)
            {
                //Grilla.Columns["Priority"].SortMode = DataGridViewColumnSortMode.NotSortable;
                Grilla.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            

            switch (Formato)
            {
                case 1:
                    Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    break;
                case 2:
                    Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                default:
                    Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    break;
            }

            return Grilla;
        }

        public ComboBox cargarComboBox(String QuerySQL, ComboBox comboBox , String columna)
        {
            //Metodo para cargar combo box
            comboBox = vaciarComboBox(comboBox);
            dataSet.Reset();
            dataSet = conexion.ejecutarQuerySelect(QuerySQL);
            foreach (DataRow dataRow in dataSet.Tables[columna].Rows)
            {
                comboBox.Items.Add(dataRow[columna]);
            }

            return comboBox;
        }
        private ComboBox vaciarComboBox(ComboBox comboBox)
        {
            //Metodo para vaciar combo box
            comboBox.Items.Clear();
            return comboBox;
        }

        public string darFormatoFecha(string fechaTextBox)
        {
            try
            {
                //Metodo para dar formato a la fecha
                string[] fecha = fechaTextBox.Split('/');
                string fechaResult = fecha[1] + "/" + fecha[0] + "/" + fecha[2];
                return fechaResult;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }

        }

        public DataGridView cargarDataGridView(DataGridView dataGridView, string query)
        {
            try
            {
                //Metodo para cargar los datagridview
                dataSet.Reset();
                dataSet = conexion.ejecutarQuerySelect(query);
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.DataSource = dataSet.Tables[0];
                return dataGridView;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
        }


        internal CheckedListBox cargarCheckedListBoxVacia(string p, CheckedListBox ListBoxFuncionalidad)
        {
            {
                return ListBoxFuncionalidad;
            }
        }

        public string LeerArchivoConfig()
        {
            String respuesta;
            String path = ".\\archConfig.ini";
            StreamReader sr = new StreamReader(path);
            respuesta = sr.ReadLine();
            return respuesta;
        }

        public string ComputeHash(string input)
        {
            try
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] result;
                SHA256 shaM = new SHA256Managed();
                result = shaM.ComputeHash(inputBytes);
                return BitConverter.ToString(result);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }

        }

        public void keyPressAlfanumerico(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (e.KeyChar != (char)Keys.Back)
                {
                    MessageBox.Show("Solo se permiten letras y números en dicho campo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                }
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] -  [" + r.Message.ToString() + "]");
            }

        }

        public void keyPressLetras(KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] -  [" + r.Message.ToString() + "]");
            }
        }

        public void keyPressNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] -  [" + r.Message.ToString() + "]");
            }
        }

        public object obtenerCampoTabla(String Valor, Dictionary<string, string> Collection)
        {
            try
            {
                foreach (KeyValuePair<string, string> campo in Collection)
                {
                    if (Valor == campo.Value)
                    {
                        return (campo.Key);
                    }
                }
                return "ok";
            }

            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] -  [" + r.Message.ToString() + "]");
            }
        }

        public void keyPressNumerosDecimales(KeyPressEventArgs e, TextBox textBox)
        {
            try
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if (textBox.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] -  [" + r.Message.ToString() + "]");
            }
        }

        public void keyPressNoEscribe(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] -  [" + r.Message.ToString() + "]");
            }
        }

        public void keyPressSinEspacios(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] - [" + r.Message.ToString() + "]");
            }
        }

        public void keyPressNumericoDiezDosDecimales(KeyPressEventArgs e, int longitudActual, string texto)
        {
            try
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                if (longitudActual == 8 && e.KeyChar == 46)
                {
                    e.Handled = false;
                    return;                
                }

                if (longitudActual == 8 && (!(contieneComa(texto))))
                {
                    e.Handled = true;
                    return;
                }

            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] - [" + r.Message.ToString() + "]");
            }
        }

        private bool contieneComa(string texto)
        {
            try
            {
                for (int i = 0; i <= texto.Length; i++)
                {
                    if (texto.Substring(i, 1) == ".")
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception r)
            {
                return false;
                throw new System.ArgumentException("[Error] - [" + r.Message.ToString() + "]");
            }
        }

        public char keyPressMayusculas(KeyPressEventArgs e)
        {
            try
            {
                return char.Parse(e.KeyChar.ToString().ToUpper());
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] - [" + r.Message.ToString() + "]");
            }
        }

        internal Boolean esUnNumeroDecimal(String p) //Se le pasa un número decimal (o no) y devuelve si es o no un número correcto
        {
            try
            {
                p = p.Replace(",", ".");

                if (p == "." || p.Trim().EndsWith(@"."))
                {
                    return false;
                }

                foreach (char Caracter in p)
                {
                    if (!(char.IsNumber(Caracter) || Caracter == '.'))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception r)
            {
                throw new System.ArgumentException("[Error] - [" + r.Message.ToString() + "]");
            }
        }

        public void mostrarErrorTryCatch(Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }

        internal string DevolverCadenaCon2Decimales(string p)
        {
            string cadenaDespuesDeLaComa = "";
            string result = ""; 
            cadenaDespuesDeLaComa = p.Substring(p.IndexOf(",") + 1, p.Length - p.IndexOf(",") - 1);

            if (cadenaDespuesDeLaComa.Length == 1)
            {
                result = p + "0";
            }

            if (cadenaDespuesDeLaComa.Length >= 3)
            {
                result = p + ",00";
            }

            return result;
        }
    }
}
