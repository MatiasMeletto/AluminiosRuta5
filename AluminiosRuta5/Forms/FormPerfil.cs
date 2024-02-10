using AluminiosRuta5.Objects;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
        int indice = -1;
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
                string.IsNullOrEmpty(textBox1Tira.Text.Trim()))
            {
                MessageBox.Show("Complete los campos por favor");
                return;
            }
            OpenConnection();
            sql = "SELECT * FROM perfiles WHERE Codigo = '" + textBoxCodigo.Text+ "'";
            command.CommandText = sql;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Perfiles");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Perfiles"];
            if (bindingSrc.Count > 0)
            {
                MessageBox.Show("El codigo ya existe");
                return;
            }
            if (editando)
            {
                sql = "UPDATE perfiles SET Codigo = @Codigo, Descripcion = @Descripcion, CantidadTiras = @CantidadTiras, KgXPaquete = @KgXPaquete, KgXTira = @KgXTira, CategoriaId = @CategoriaId WHERE PerfilId = " + indice;
            }
            else if (!editando)
            {
                dbCommand = "INSERT";

                sql = "INSERT INTO perfiles (Codigo,Descripcion,CantidadTiras,KgXPaquete,KgXTira,CategoriaId) " +
                    "VALUES (@Codigo,@Descripcion,@CantidadTiras,@KgXPaquete,@KgXTira,@CategoriaId)";
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
            textBoxCodigo.DataBindings.Clear();
            textBoxDescripcion.DataBindings.Clear();
            textBoxKg.DataBindings.Clear();
            textBox1Tira.DataBindings.Clear();
            numericUpDownTiras.DataBindings.Clear();
            textBoxCodigo.Text = string.Empty;
            textBoxDescripcion.Text = string.Empty;
            textBoxKg.Text = string.Empty;
            numericUpDownTiras.Value = 0;
            textBox1Tira.Text = string.Empty;
            editando = false;
            indice = -1;
            btnAgregar.Text = "Agregar";
        }

        private void UpdateDataBinding(SQLiteCommand cmd = null)
        {
            dbCommand = "SELECT";

            sql = "SELECT * FROM perfiles WHERE CategoriaId = " + c.CategoriaId.ToString() + " ORDER BY PerfilId ASC;";

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
            command.Parameters.AddWithValue("KgXTira", Convert.ToDecimal(textBox1Tira.Text.Trim()));
            command.Parameters.AddWithValue("CantidadTiras", numericUpDownTiras.Value);
            command.Parameters.AddWithValue("KgXPaquete", Convert.ToDecimal(textBoxKg.Text.Trim()));
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
            if (dataGridViewStock.SelectedRows.Count > 0)
            {
                LimpiarCampos();
                string codigo = dataGridViewStock.CurrentRow.Cells[0].Value.ToString();

                sql = "SELECT * FROM perfiles ";
                sql += "WHERE Codigo = '" + codigo + "'";

                command.CommandText = sql;

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Perfiles");

                bindingSrc = new BindingSource();
                bindingSrc.DataSource = ds.Tables["Perfiles"];

                textBoxCodigo.DataBindings.Add("Text", bindingSrc[0], "Codigo");
                textBoxDescripcion.DataBindings.Add("Text", bindingSrc[0], "Descripcion");
                textBoxKg.DataBindings.Add("Text", bindingSrc[0], "KgXPaquete");
                numericUpDownTiras.DataBindings.Add("Text", bindingSrc[0], "CantidadTiras");
                textBox1Tira.DataBindings.Add("Text", bindingSrc[0], "KgXTira");
                btnAgregar.Text = "Actualizar";
                editando = true;
                DataRowView dr = bindingSrc[0] as DataRowView;
                indice = Convert.ToInt16(dr[0]);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void textBoxBuscar_Leave(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text.Trim() == "")
            {
                textBoxBuscar.Text = "Buscar...";
                textBoxBuscar.ForeColor = Color.Silver;
            }
            UpdateDataBinding();
        }

        private void textBoxBuscar_Enter(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text.Trim() == "Buscar...")
            {
                textBoxBuscar.Text = "";
                textBoxBuscar.ForeColor = Color.Black;
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            OpenConnection();
            if (string.IsNullOrEmpty(textBoxBuscar.Text.Trim()) ||
                textBoxBuscar.Text.Trim() == "Buscar...")
            {
                UpdateDataBinding();
                dataGridViewStock.DataSource = bindingSrc;
                CloseConnection();
                return;
            }
            else if (double.TryParse(textBoxBuscar.Text, out double val))
            {
                sql = "SELECT * FROM perfiles";
                sql += " WHERE Codigo LIKE '" + textBoxBuscar.Text + "%'";
                sql += " OR Descripcion LIKE '" + textBoxBuscar.Text + "%'";
                sql += " OR KgXTira = " + val;
                sql += " OR CantidadTiras = " + val;
                sql += " OR KgXPaquete = " + val;
            }
            else
            {
                sql = "SELECT * FROM perfiles";
                sql += " WHERE Codigo LIKE '" + textBoxBuscar.Text + "%'";
                sql += " OR Descripcion LIKE '" + textBoxBuscar.Text + "%'";
            }

            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Parameters.Clear();

            UpdateDataBinding(command);
            dataGridViewStock.DataSource = bindingSrc;

            CloseConnection();
        }
    }
}
