using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public partial class FormStock : Form
    {
        private static string dbCommand = "";
        private static BindingSource bindingSrc;

        private static string dbPath = Application.StartupPath + "\\" + "aluminioStock.db;";
        private static string conString = "Data Source=" + dbPath + "Version=3;New=False;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;
        private FormPrincipal form;
        private Button btnActual = null;
        private Form formularioActivo;

        public FormStock(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            form = formPrincipal;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetearEleccion();
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            OpenConnection();
            UpdateDataBinding();
            CloseConnection();
        }

        private void UpdateDataBinding(SQLiteCommand cmd = null)
        {
            try
            {
                dbCommand = "SELECT";

                sql = "SELECT * FROM categorias ORDER BY CategoriaId ASC;";

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
                adapter.Fill(ds, "Categorias");

                bindingSrc = new BindingSource();
                bindingSrc.DataSource = ds.Tables["Categorias"];

                List<Button> buttons = ModuloStock.CargarCategorias(bindingSrc);
                panelSeleccion.Controls.Clear();
                panelDecorativo.Height = 50 * Convert.ToInt16(bindingSrc.Count.ToString());
                foreach (var c in buttons)
                {
                    panelSeleccion.Controls.Add(c);
                    c.Click += new EventHandler(AbrirForm);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("DataBinding Error");
            }
        }

        private void AbrirForm(object sender, EventArgs e)
        {
            Button button = sender as Button;
            dbCommand = "SELECT";

            sql = "SELECT * FROM categorias ORDER BY CategoriaId ASC;";

            command.CommandText = sql;

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Categorias");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Categorias"];

            Categoria c = new Categoria()
            {
                Nombre = button.Text,
            };
            if (btnActual != null)
                btnActual = ModuloPrincipal.CambioColor(btnActual, btnActual, false);
            btnActual = ModuloPrincipal.PreAbrir(panelDecorativo, btnActual, button);
            formularioActivo = ModuloPrincipal.AbrirFormularioHijo(panelPerfiles, formularioActivo, new FormPerfil(c));
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

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            formularioActivo = ModuloPrincipal.AbrirFormularioHijo(panelPerfiles, formularioActivo, new FormCategoria(this));
            if (btnActual != null)
                btnActual = ModuloPrincipal.CambioColor(btnActual, btnActual, false);
            panelDecorativo.Location = new Point(0, 110);
            panelDecorativo.Height = 50 * Convert.ToInt16(bindingSrc.Count.ToString()); 
            if (btnActual != null)
                btnActual = ModuloPrincipal.CambioColor(btnActual, btnActual, false);
        }
    }
}
