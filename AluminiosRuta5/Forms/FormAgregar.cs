using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public partial class FormAgregar : Form
    {
        private static BindingSource bindingSrc;

        private static string dbPath = Application.StartupPath + "\\" + "aluminioStock.db;";
        private static string conString = "Data Source=" + dbPath + "Version=3;New=False;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;
        private List<Label> listaLabels = new List<Label>();
        private FormStock form;
        private List<Perfil> listaPerfiles = new List<Perfil>();
        private List<Perfil> listaPerfilesPresupuestados = new List<Perfil>();

        // --- 1. AGREGAMOS EL MÉTODO HELPER PARA PARSEO SEGURO ---
        private decimal ParseDecimal(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            // Reemplaza comas por puntos y usa InvariantCulture
            return decimal.Parse(input.Replace(",", "."), CultureInfo.InvariantCulture);
        }

        private void CargarPerfiles(SQLiteCommand cmd = null)
        {
            sql = "SELECT * FROM perfiles ORDER BY PerfilId ASC;";

            if (cmd == null)
            {
                command.CommandText = sql;
            }
            else
            {
                command = cmd;
            }

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Perfiles");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Perfiles"];

            listaPerfiles = ModuloStock.CargarPerfiles(bindingSrc);

            // Limpiamos antes de agregar para no duplicar si se recarga
            textBoxCodigo.AutoCompleteCustomSource.Clear();
            foreach (DataRowView b in bindingSrc.List)
            {
                textBoxCodigo.AutoCompleteCustomSource.Add(b[1].ToString());
            }
        }

        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        private void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void CargarLabels(List<Label> labels)
        {
            panel1.Controls.Clear();
            foreach (Label label in labels)
            {
                if (Convert.ToInt16(label.Name) != labels.IndexOf(label))
                {
                    label.Name = (labels.IndexOf(label)).ToString();
                    label.Location = new Point(0, 30 * labels.IndexOf(label));
                }
                panel1.Controls.Add(label);
                Button button = new Button()
                {
                    Name = label.Name,
                    Text = "X",
                    Font = new Font("Microsoft JhengHei UI", 10),
                    Size = new Size(20, 20),
                    AutoSize = true,
                    FlatStyle = FlatStyle.Popup,
                    Location = new Point(label.Right + 20, label.Top)
                };
                button.FlatAppearance.BorderSize = 0;
                button.Click += new EventHandler(EliminarLabel);
                panel1.Controls.Add(button);
            }
        }

        private void EliminarLabel(object sender, EventArgs e)
        {
            Button button = sender as Button;
            // Buscamos el label por nombre
            Label label = listaLabels.Where(l => l.Name == button.Name).SingleOrDefault();

            // Borramos usando el INDICE para asegurar que borramos el par correcto (Label y Perfil)
            if (label != null)
            {
                int index = listaLabels.IndexOf(label);
                if (index >= 0 && index < listaPerfilesPresupuestados.Count)
                {
                    listaLabels.RemoveAt(index);
                    listaPerfilesPresupuestados.RemoveAt(index);
                }
            }

            CargarLabels(listaLabels);
            SumarCantidades();
        }

        // --- 2. OPTIMIZACIÓN DE SUMA (Usando objetos y ParseDecimal) ---
        private void SumarCantidades()
        {
            decimal sumaTiras = 0;
            decimal totalImporte = 0;
            decimal totalKg = 0;

            // En lugar de leer el texto del label al revés, usamos la lista de objetos que es más segura
            foreach (var item in listaPerfilesPresupuestados)
            {
                // Cantidad de tiras
                sumaTiras += item.CantidadTiras;

                // Precios y Kilos usando ParseDecimal
                decimal precioUnitario = ParseDecimal(item.Import);
                decimal kgUnitario = ParseDecimal(item.KgXTira);

                // Cálculos (Cantidad * Precio) y (Cantidad * Kilos)
                totalImporte += precioUnitario * item.CantidadTiras;
                totalKg += kgUnitario * item.CantidadTiras;
            }

            labelTotalTiras.Text = "Total tiras = " + sumaTiras.ToString();

            // Mostramos formateado
            CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
            labelTotalKg.Text = "Total KG = " + totalKg.ToString("N2", us);
        }

        public FormAgregar(FormStock f)
        {
            InitializeComponent();
            form = f;
            CargarPerfiles();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) || string.IsNullOrEmpty(textBoxTiras.Text.Trim()))
            {
                MessageBox.Show("Complete los campos por favor");
                return;
            }

            OpenConnection();
            try
            {
                // Buscamos en el catálogo maestro
                Perfil pCatalogo = listaPerfiles.Where(l => l.Codigo == textBoxCodigo.Text).SingleOrDefault();

                if (pCatalogo != null)
                {
                    // --- 3. CREAMOS UNA COPIA ---
                    // IMPORTANTE: Creamos un 'nuevoPerfil' en lugar de modificar 'pCatalogo'.
                    // Si modificas 'pCatalogo' (que viene de listaPerfiles), estás ensuciando la memoria del catálogo.

                    int tirasAAgregar = Convert.ToInt32(textBoxTiras.Text);

                    // Buscamos si ya está en la lista de PRE-INGRESO (la que estamos armando ahora)
                    var perfilEnLista = listaPerfilesPresupuestados.FirstOrDefault(x => x.PerfilId == pCatalogo.PerfilId);

                    if (perfilEnLista != null)
                    {
                        // Si ya existe, sumamos
                        perfilEnLista.CantidadTiras += tirasAAgregar;

                        // Actualizamos el label visualmente
                        int index = listaPerfilesPresupuestados.IndexOf(perfilEnLista);

                        // Recalculamos el texto visual usando InvariantCulture para mostrar
                        CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
                        decimal kgTira = ParseDecimal(perfilEnLista.KgXTira); // Usamos helper
                        decimal costo = ParseDecimal(perfilEnLista.Import);

                        // Nota: Aquí mantengo tu lógica de visualización pero simplificada
                        listaLabels[index].Text = $"* {perfilEnLista.Codigo} (x{perfilEnLista.CantidadTiras})";
                    }
                    else
                    {
                        // Si es nuevo en la lista, creamos la instancia
                        Perfil nuevoPerfil = new Perfil()
                        {
                            PerfilId = pCatalogo.PerfilId,
                            Codigo = pCatalogo.Codigo,
                            CantidadTiras = tirasAAgregar,
                            Import = pCatalogo.Import,
                            KgXTira = pCatalogo.KgXTira,
                            // Calculamos el total del paquete solo si lo necesitas, sino dejamos 0 o calculamos
                            KgXPaquete = (tirasAAgregar * ParseDecimal(pCatalogo.KgXTira)).ToString(CultureInfo.InvariantCulture)
                        };

                        // Agregamos a listas
                        listaPerfilesPresupuestados.Add(nuevoPerfil);
                        ModuloStock.ListaLabels(listaLabels, nuevoPerfil, tirasAAgregar); // Asegúrate que ModuloStock use formato correcto
                    }

                    CargarLabels(listaLabels);
                }
                else
                {
                    MessageBox.Show("No se encontró el código");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
                return;
            }
            finally
            {
                CloseConnection();
            }

            SumarCantidades(); // Recalcula totales

            textBoxCodigo.Text = string.Empty;
            textBoxTiras.Text = string.Empty;
            textBoxCodigo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listaPerfilesPresupuestados.Count == 0) return;

            OpenConnection();

            foreach (var p in listaPerfilesPresupuestados)
            {
                // Obtenemos la cantidad ACTUAL de la base de datos para no pisar cambios de otros usuarios
                sql = "SELECT CantidadTiras FROM perfiles WHERE PerfilId = " + p.PerfilId;
                command.CommandText = sql;

                // Ejecutamos Scalar porque solo queremos 1 dato (CantidadTiras actual)
                object result = command.ExecuteScalar();
                int stockActual = (result != null) ? Convert.ToInt32(result) : 0;

                // Sumamos lo nuevo
                int stockNuevo = stockActual + p.CantidadTiras;

                // Actualizamos
                sql = $"UPDATE perfiles SET CantidadTiras = {stockNuevo} WHERE PerfilId = {p.PerfilId}";
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Se agregó correctamente al stock");

            listaLabels.Clear();
            listaPerfilesPresupuestados.Clear();

            // Recargamos catálogo por si queremos seguir agregando
            CargarPerfiles();

            panel1.Controls.Clear();
            SumarCantidades();
            CloseConnection();
        }

        private void textBoxTiras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // En "Cantidad de Tiras" usualmente son enteros, pero si permites decimales deja el punto
            // Si solo son enteros, borra el bloque de abajo.
        }
    }
}