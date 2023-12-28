using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public partial class FormCategoria : Form
    {
        private static string dbCommand = "";
        private static BindingSource bindingSrc;

        private static string dbPath = Application.StartupPath + "\\" + "aluminioStock.db;";
        private static string conString = "Data Source=" + dbPath + "Version=3;New=False;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;
        public FormCategoria(FormStock form)
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            dbCommand = "SELECT";

            sql = "SELECT * FROM categorias ORDER BY CategoriaId ASC;";

            command.CommandText = sql;

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Categorias");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Categorias"];
            dataGridViewStock.DataSource = bindingSrc;
        }

        private void dataGridViewStock_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.DataBindings.Clear();
            dbCommand = "SELECT";

            sql = "SELECT * FROM categorias ORDER BY CategoriaId ASC;";

            command.CommandText = sql;

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Categorias");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Categorias"];

            textBox1.DataBindings.Add("Text", bindingSrc[dataGridViewStock.SelectedRows[0].Index],"Nombre");
            btnAgregar.Text = "Actualizar";
        }
    }
}
