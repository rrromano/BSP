using System;
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
        string query;
        public string mensajeErrorCatch = "No se puede realizar la accion pedida. Por favor, intente más tarde.";

        public string fcSql(string cadena, string tipoDato)
        {
            switch (tipoDato)
            {
                case "String":
                    cadena = "'" + cadena + "'";
                    break;
                case "Integer":
                    break;
                case "DateTime":
                    cadena = "'" + cadena + "'";
                    break;
                default:
                    break;
            }
            return cadena;
        }

        public ComboBox cargarComboBox(string tipo, ComboBox comboBox)
        {
            //Metodo para cargar combo box
            comboBox = vaciarComboBox(comboBox);
            dataSet.Reset();
            dataSet = conexion.ejecutarQuerySelect(query);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                comboBox.Items.Add(dataRow[0]);
            }
            return comboBox;
        }
        private ComboBox vaciarComboBox(ComboBox comboBox)
        {
            //Metodo para vaciar combo box
            comboBox.Items.Clear();
            return comboBox;
        }

        public CheckedListBox cargarCheckedListBox(string tipo, CheckedListBox checkedListBox, string rol)
        {

            query = "SELECT DISTINCT ";

            if (tipo == "ITEM_FUNCIONALIDAD")
            {
                query += "Nombre";
            }

            query += " FROM [LOS_MEJORES].[" + tipo + "]";
            dataSet.Reset();
            checkedListBox.Items.Clear();
            dataSet = conexion.ejecutarQuerySelect(query);

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                checkedListBox.Items.Add(dataRow[0].ToString());
            }

            query = "SELECT * FROM LOS_MEJORES.FUNCIONALIDAD FN";
            query = query + " INNER JOIN LOS_MEJORES.ITEM_FUNCIONALIDAD IFN ON (FN.ID_FUNCIONALIDAD = IFN.ID_FUNCIONALIDAD)";
            query = query + " INNER JOIN LOS_MEJORES.ROL ROL ON (ROL.ID_ROL = FN.ID_ROL)";
            query = query + " WHERE ROL.NOMBRE = " + "'" + rol + "'";

            dataSet.Reset();
            dataSet = conexion.ejecutarQuerySelect(query);

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                {
                    if (checkedListBox.Items[i].ToString() == dataSet.Tables[0].Rows[j][4].ToString())
                    {
                        checkedListBox.SetItemChecked(i, true);
                    }
                }
            }
            return checkedListBox;
        }

        public string darFormatoFecha(string fechaTextBox)
        {
            //Metodo para dar formato a la fecha
            string[] fecha = fechaTextBox.Split('/');
            string fechaCompra = fecha[1] + "/" + fecha[0] + "/" + fecha[2];
            return fechaCompra;
        }

        public DataGridView agregarBotones(DataGridView dataGridView, string tipo)
        {
            //Metodo para agregar botones a los datagridview

            if (tipo == "Modificar")
            {
                DataGridViewButtonColumn botonModificar = new DataGridViewButtonColumn();
                botonModificar.HeaderText = "Modificar";
                botonModificar.Text = "Modificar";
                botonModificar.Name = "botonModificar";
                botonModificar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                botonModificar.FlatStyle = FlatStyle.Standard;
                botonModificar.DisplayIndex = dataGridView.Columns.Count;
                botonModificar.CellTemplate.Style.BackColor = Color.Honeydew;
                botonModificar.UseColumnTextForButtonValue = true;
                if (dataGridView.Columns["botonModificar"] == null)
                {
                    dataGridView.Columns.Add(botonModificar);
                }
                else
                {
                    dataGridView.Columns.Remove(dataGridView.Columns["botonModificar"]);
                    dataGridView.Columns.Add(botonModificar);
                }

                DataGridViewCheckBoxColumn Seleccionar = new DataGridViewCheckBoxColumn();
                Seleccionar.HeaderText = "Seleccionar";
                Seleccionar.Name = "Seleccionar";
                Seleccionar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Seleccionar.FlatStyle = FlatStyle.Standard;
                Seleccionar.DisplayIndex = dataGridView.Columns.Count;
                Seleccionar.CellTemplate.Style.BackColor = Color.Honeydew;
                if (dataGridView.Columns["Seleccionar"] == null)
                {
                    dataGridView.Columns.Add(Seleccionar);
                }
                else
                {
                    dataGridView.Columns.Remove(dataGridView.Columns["Seleccionar"]);
                    dataGridView.Columns.Add(Seleccionar);
                }
                return dataGridView;
            }

            if (tipo == "Seleccionar")
            {
                DataGridViewCheckBoxColumn Seleccionar = new DataGridViewCheckBoxColumn();
                Seleccionar.HeaderText = "Seleccionar";
                Seleccionar.Name = "Seleccionar";
                Seleccionar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Seleccionar.FlatStyle = FlatStyle.Standard;
                Seleccionar.DisplayIndex = dataGridView.Columns.Count;
                Seleccionar.CellTemplate.Style.BackColor = Color.Honeydew;
                if (dataGridView.Columns["Seleccionar"] == null)
                {
                    dataGridView.Columns.Add(Seleccionar);
                }
                else
                {
                    dataGridView.Columns.Remove(dataGridView.Columns["Seleccionar"]);
                    dataGridView.Columns.Add(Seleccionar);

                }
                return dataGridView;
            }

            if (tipo == "Cantidad")
            {
                DataGridViewButtonColumn botonCantidad = new DataGridViewButtonColumn();
                botonCantidad.HeaderText = "Cantidad";
                botonCantidad.Text = "Cantidad";
                botonCantidad.Name = "botonCantidad";
                botonCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                botonCantidad.FlatStyle = FlatStyle.Standard;
                botonCantidad.DisplayIndex = dataGridView.Columns.Count;
                botonCantidad.CellTemplate.Style.BackColor = Color.Honeydew;
                botonCantidad.UseColumnTextForButtonValue = true;
                if (dataGridView.Columns["botonCantidad"] == null)
                {
                    dataGridView.Columns.Add(botonCantidad);
                }
                else
                {
                    dataGridView.Columns.Remove(dataGridView.Columns["botonCantidad"]);
                    dataGridView.Columns.Add(botonCantidad);
                }
                DataGridViewCheckBoxColumn Seleccionar = new DataGridViewCheckBoxColumn();
                Seleccionar.HeaderText = "Seleccionar";
                Seleccionar.Name = "Seleccionar";
                Seleccionar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Seleccionar.FlatStyle = FlatStyle.Standard;
                Seleccionar.DisplayIndex = dataGridView.Columns.Count;
                Seleccionar.CellTemplate.Style.BackColor = Color.Honeydew;
                if (dataGridView.Columns["Seleccionar"] == null)
                {
                    dataGridView.Columns.Add(Seleccionar);
                }
                else
                {
                    dataGridView.Columns.Remove(dataGridView.Columns["Seleccionar"]);
                    dataGridView.Columns.Add(Seleccionar);
                }
                return dataGridView;
            }
            return dataGridView;
        }


        public DataGridView cargarDataGridView(DataGridView dataGridView, string tipo, string query)
        {
            //Metodo para cargar los datagridview
            dataSet.Reset();
            dataSet = conexion.ejecutarQuerySelect(query);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.DataSource = dataSet.Tables[0];
            dataGridView = agregarBotones(dataGridView, tipo);
            return dataGridView;
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
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(inputBytes);
            return BitConverter.ToString(result);
        }

        public void keyPressAlfanumerico(KeyPressEventArgs e)
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

        public void keyPressLetras(KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras en dicho campo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        public void keyPressNumeros(KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números en dicho campo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        public void keyPressNoEscribe(KeyPressEventArgs e)
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

        public void keyPressSinEspacios(KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

        }
    }
}
