using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public partial class FormPerfil : Form
    {
        private static string dbCommand = "";
        private static BindingSource bindingSrc;

        private static string dbPath = Application.StartupPath + "\\" + "aluminioStock.db;";
        private static string conString = "Data Source=" + dbPath + "Version=3;New=False;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;

        private bool editando = false;
        private Categoria c;
        public FormPerfil(Categoria c)
        {
            InitializeComponent();
            this.c = c;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddCmdParameters();
            if (string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) || 
                string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) ||
                numericUpDownKg.Value == 0 ||
                numericUpDownImporte.Value == 0 ||
                numericUpDownTiras.Value == 0)
            {
                MessageBox.Show("Complete los campos por favor");
                return;
            }
            OpenConnection();
            if (editando)
            {
                dbCommand = "UPDATE";

                DataRowView dr = bindingSrc[dataGridViewStock.SelectedRows[0].Index] as DataRowView;
                sql = "UPDATE perfiles SET Codigo = @Codigo, Descripcion = @Descripcion, Import = @Importe, CantidadTiras = @CantidadTiras, KgXPaquete = @KgXPaquete, CategoriaId = @CategoriaId WHERE PefilId = " + dr[0];

                AddCmdParameters();
            }
            else if (!editando)
            {
                dbCommand = "INSERT";

                sql = "INSERT INTO perfiles (Codigo,Descripcion,Import,CantidadTiras,KgXPaquete,CategoriaId) " +
                    "VALUES (@Codigo,@Descripcion,@Importe,@CantidadTiras,@KgXPaquete,@CategoriaId)";
                AddCmdParameters();
            }
            int executeResult = command.ExecuteNonQuery();
            if (executeResult != -1)
            {
                UpdateDataBinding();
                textBoxDescripcion.Text = "";
                btnAgregar.Text = "Agregar";
                dataGridViewStock.DataSource = bindingSrc;
                LimpiarCampos();
            }
            CloseConnection();
        }

        private void LimpiarCampos()
        {
            textBoxCodigo.Text = string.Empty;
            textBoxDescripcion.Text = string.Empty;
            numericUpDownKg.Value = 0;
            numericUpDownTiras.Value = 0;
            numericUpDownImporte.Value = 0;
            editando = false;
        }

        private void UpdateDataBinding(SQLiteCommand cmd = null)
        {
            dbCommand = "SELECT";

            sql = "SELECT * FROM perfiles WHERE CategoriaId = "+ c.CategoriaId.ToString() + " ORDER BY CategoriaId ASC;";

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

        private void AddCmdParameters()
        {
            command.Parameters.Clear();
            command.CommandText = sql;

            command.Parameters.AddWithValue("Codigo", textBoxCodigo.Text.Trim());
            command.Parameters.AddWithValue("Descripcion", textBoxDescripcion.Text.Trim());
            command.Parameters.AddWithValue("Importe", numericUpDownImporte.Value);
            command.Parameters.AddWithValue("CantidadTiras", numericUpDownTiras.Value);
            command.Parameters.AddWithValue("KgXPaquete", numericUpDownKg.Value);
            command.Parameters.AddWithValue("CategoriaId", c.CategoriaId);
        }

        private void FormPerfil_Load(object sender, EventArgs e)
        {
            OpenConnection();
            UpdateDataBinding();
            dataGridViewStock.DataSource = bindingSrc;
            CloseConnection();  
        }
    }
}
