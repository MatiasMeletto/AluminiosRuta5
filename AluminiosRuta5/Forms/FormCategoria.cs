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

        private bool editando = false;
        private FormStock form;

        private void LimpiarCampos()
        {
            editando = false;
            textBox1.Text = "";
            btnAgregar.Text = "Agregar";
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
        public FormCategoria(FormStock form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            OpenConnection();
            UpdateDataBinding();
            dataGridViewStock.DataSource = bindingSrc;
            CloseConnection();
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

            textBox1.DataBindings.Add("Text", bindingSrc[dataGridViewStock.SelectedRows[0].Index], "Nombre");
            btnAgregar.Text = "Actualizar";
            editando = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            AddCmdParameters();
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Ponga un nombre por favor");
                return;
            }
            OpenConnection();
            if (editando)
            {
                dbCommand = "UPDATE";

                DataRowView dr = bindingSrc[dataGridViewStock.SelectedRows[0].Index] as DataRowView;
                sql = "UPDATE categorias SET Nombre = @Nombre WHERE CategoriaId = " + dr[0];

                AddCmdParameters();
            }
            else if (!editando)
            {
                dbCommand = "INSERT";

                sql = "INSERT INTO categorias (Nombre) " +
                    "VALUES (@Nombre)";
                AddCmdParameters();
            }
            int executeResult = command.ExecuteNonQuery();
            if (executeResult != -1)
            {
                UpdateDataBinding();
                textBox1.Text = "";
                btnAgregar.Text = "Agregar";
                dataGridViewStock.DataSource = bindingSrc;
                form.LoadForm();
                LimpiarCampos();
            }
            CloseConnection();

        }

        private void UpdateDataBinding(SQLiteCommand cmd = null)
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
        }

        private void AddCmdParameters()
        {
            command.Parameters.Clear();
            command.CommandText = sql;

            command.Parameters.AddWithValue("Nombre", textBox1.Text.Trim());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                OpenConnection();

                dbCommand = "DELETE";

                DataRowView dr = bindingSrc[dataGridViewStock.SelectedRows[0].Index] as DataRowView;
                sql = "DELETE FROM categorias WHERE CategoriaId = " + dr[0];
                command.Parameters.Clear();
                command.CommandText = sql;
                command.Parameters.AddWithValue("CategoriaId", textBox1.Text.Trim());

                int executeResult = command.ExecuteNonQuery();
                if (executeResult == 1)
                {
                    UpdateDataBinding();
                    dataGridViewStock.DataSource = bindingSrc;
                    form.LoadForm();
                    LimpiarCampos();
                }
                CloseConnection();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
