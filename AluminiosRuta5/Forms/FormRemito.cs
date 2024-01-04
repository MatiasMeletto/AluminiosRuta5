using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public partial class FormRemito : Form
    {
        private static string dbCommand = "";
        private static BindingSource bindingSrc;

        private static string dbPath = Application.StartupPath + "\\" + "aluminioStock.db;";
        private static string conString = "Data Source=" + dbPath + "Version=3;New=False;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;
        private List<Label> listaLabels = new List<Label>();
        private FormPrincipal form;
        private List<Perfil> listaPerfiles = new List<Perfil>();
        private List<Perfil> listaPerfilesPresupuestados = new List<Perfil>();
        private void CargarPerfiles(SQLiteCommand cmd = null)
        {
            dbCommand = "SELECT";

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
            Label label = listaLabels.Where(l => l.Name == button.Name).SingleOrDefault();
            Perfil perfil = listaPerfilesPresupuestados.Where(p => p.PerfilId == Convert.ToInt16(label.Tag)).SingleOrDefault();
            listaLabels.Remove(label);
            listaPerfilesPresupuestados.Remove(perfil);
            CargarLabels(listaLabels);
            SumarCantidades();
            if (listaLabels.Count == 0)
            {
                btnConfirmar.Enabled = false;
            }
        }
        public FormRemito(FormPrincipal f)
        {
            InitializeComponent();
            form = f;
            btnConfirmar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) || numericUpDownCantTiras.Value == 0)
            {
                MessageBox.Show("Complete los campos por favor");
                return;
            }
            OpenConnection();
            try
            {
                Perfil p = listaPerfiles.Where(l => l.Codigo == textBoxCodigo.Text).SingleOrDefault();

                if (p != null)
                {
                    p.Import = numericUpDownImporte.Value;
                    p.KgXPaquete = numericUpDownKilos.Value;
                    ModuloStock.ListaLabels(listaLabels, p, Convert.ToInt16(numericUpDownCantTiras.Value));
                    p.CantidadTiras = Convert.ToInt16(numericUpDownCantTiras.Value);
                    listaPerfilesPresupuestados.Add(p);

                    CargarLabels(listaLabels);
                    textBoxCodigo.Text = string.Empty;
                    numericUpDownCantTiras.Value = 0;
                    numericUpDownKilos.Value = 0;
                    numericUpDownImporte.Value = 0;
                    if (!btnConfirmar.Enabled)
                    {
                        btnConfirmar.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro el codigo");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se encontro el codigo");
                return;
            }
            finally
            {
                CloseConnection();
            }
            SumarCantidades();
        }
        private void SumarCantidades()
        {
            decimal sumaTiras = 0;
            decimal importe = 0;
            decimal kg = 0;
            foreach (var item in listaPerfilesPresupuestados)
            {
                sumaTiras += item.CantidadTiras;
                importe += item.Import * item.KgXPaquete;
                kg += item.KgXPaquete;
            }
            labelTotalImporte.Text = "Total importe = " + importe.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            labelTotalTiras.Text = "Total tiras = " + sumaTiras.ToString();
            labelTotalKg.Text = "Total KG = " + kg.ToString();
        }

        private void FormRemito_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetearEleccion();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            OpenConnection();
            foreach (var p in listaPerfilesPresupuestados)
            {
                sql = "SELECT * FROM perfiles ";
                sql += "WHERE PerfilId = " + p.PerfilId;

                command.CommandText = sql;

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Perfiles");

                bindingSrc = new BindingSource();
                bindingSrc.DataSource = ds.Tables["Perfiles"];
                DataRowView dr = bindingSrc[0] as DataRowView;

                if ((Convert.ToInt16(dr[4]) - p.CantidadTiras) >= 0)
                {
                    sql = $"UPDATE perfiles SET CantidadTiras = {Convert.ToInt16(dr[4]) - p.CantidadTiras} WHERE PerfilId = {dr[0]}";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("No hay sufientes tiras de " + dr[1].ToString());
                    return;
                }
            }
            listaLabels.Clear();
            listaPerfilesPresupuestados.Clear();
            CargarPerfiles();
            panel1.Controls.Clear();
            SumarCantidades();
            CloseConnection();
        }
    }
}
