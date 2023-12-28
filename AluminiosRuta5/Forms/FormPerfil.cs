using AluminiosRuta5.Objects;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            if (string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) || 
                string.IsNullOrEmpty(textBoxDescripcion.Text.Trim()) ||
                string.IsNullOrEmpty(textBoxKg.Text.Trim()) ||
                numericUpDownImporte.Value == 0)
            {
                MessageBox.Show("Complete los campos por favor");
                return;
            }
            OpenConnection();
            if (editando)
            {
                dbCommand = "UPDATE";

                DataRowView dr = bindingSrc[dataGridViewStock.SelectedRows[0].Index] as DataRowView;
                sql = "UPDATE perfiles SET Codigo = @Codigo, Descripcion = @Descripcion, Import = @Importe, CantidadTiras = @CantidadTiras, KgXPaquete = @KgXPaquete, CategoriaId = @CategoriaId WHERE PerfilId = " + dr[0];
            }
            else if (!editando)
            {
                dbCommand = "INSERT";

                sql = "INSERT INTO perfiles (Codigo,Descripcion,Import,CantidadTiras,KgXPaquete,CategoriaId) " +
                    "VALUES (@Codigo,@Descripcion,@Importe,@CantidadTiras,@KgXPaquete,@CategoriaId)";
            }
            AddCmdParameters();
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
            textBoxKg.Text = string.Empty;
            numericUpDownTiras.Value = 0;
            numericUpDownImporte.Value = 0;
            editando = false;
            btnAgregar.Text = "Agregar";
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
            command.Parameters.AddWithValue("Importe", Convert.ToDecimal(numericUpDownImporte.Value.ToString()));
            command.Parameters.AddWithValue("CantidadTiras", numericUpDownTiras.Value);
            command.Parameters.AddWithValue("KgXPaquete", Convert.ToDecimal(textBoxKg.Text));
            command.Parameters.AddWithValue("CategoriaId", c.CategoriaId);
        }

        private void FormPerfil_Load(object sender, EventArgs e)
        {
            OpenConnection();
            UpdateDataBinding();
            dataGridViewStock.DataSource = bindingSrc;
            CloseConnection();  
        }

        private void textBoxKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                OpenConnection();

                dbCommand = "DELETE";

                DataRowView dr = bindingSrc[dataGridViewStock.SelectedRows[0].Index] as DataRowView;
                sql = "DELETE FROM perfiles WHERE PerfilId = " + dr[0];
                command.Parameters.Clear();
                command.CommandText = sql;

                int executeResult = command.ExecuteNonQuery();
                if (executeResult == 1)
                {
                    UpdateDataBinding();
                    dataGridViewStock.DataSource = bindingSrc;
                    LimpiarCampos();
                }
                CloseConnection();
            }
        }

        private void dataGridViewStock_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxCodigo.DataBindings.Clear();
            textBoxDescripcion.DataBindings.Clear();
            textBoxKg.DataBindings.Clear();
            numericUpDownImporte.DataBindings.Clear();
            numericUpDownTiras.DataBindings.Clear();
            dbCommand = "SELECT";

            sql = "SELECT * FROM perfiles ORDER BY PerfilId ASC;";

            command.CommandText = sql;

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Perfiles");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Perfiles"];

            textBoxCodigo.DataBindings.Add("Text", bindingSrc[dataGridViewStock.SelectedRows[0].Index], "Codigo");
            textBoxDescripcion.DataBindings.Add("Text", bindingSrc[dataGridViewStock.SelectedRows[0].Index], "Descripcion");
            textBoxKg.DataBindings.Add("Text", bindingSrc[dataGridViewStock.SelectedRows[0].Index], "KgXPaquete");
            numericUpDownTiras.DataBindings.Add("Text", bindingSrc[dataGridViewStock.SelectedRows[0].Index], "CantidadTiras");
            numericUpDownImporte.DataBindings.Add("Text", bindingSrc[dataGridViewStock.SelectedRows[0].Index], "Import");
            btnAgregar.Text = "Actualizar";
            editando = true;
        }
    }
}
