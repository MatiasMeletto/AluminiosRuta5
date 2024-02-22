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
    public partial class FormPresupuesto : Form
    {
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
        }

        public FormPresupuesto(FormPrincipal f)
        {
            InitializeComponent();
            form = f;
            buttonReset.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) || numericUpDown1.Value == 0 || numericUpDownImporte.Value == 0)
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
                    Label l = listaLabels.Where(la => Convert.ToInt16(la.Tag) == p.PerfilId).SingleOrDefault();
                    if (l != null)
                    {
                        char[] chars = listaLabels[listaLabels.IndexOf(l)].Text.ToCharArray();
                        Array.Reverse(chars);
                        string a = "";
                        List<char> lisTemp = chars.ToList();
                        foreach (char c in chars)
                        {
                            if (char.IsDigit(c))
                            {
                                a += c;
                                lisTemp.RemoveAt(lisTemp.IndexOf(c));
                            }
                            else
                                break;
                        }
                        chars = lisTemp.ToArray();  
                        Array.Reverse(chars);
                        if (a.Length > 1)
                        {
                            char[] chars2 = a.ToCharArray();
                            Array.Reverse(chars2);
                            a = new string(chars2);
                        }
                        listaLabels[listaLabels.IndexOf(l)].Text = new string(chars) + (Convert.ToInt16(a) + numericUpDown1.Value).ToString();
                    }
                    else
                    {
                        ModuloStock.ListaLabels(listaLabels, p, Convert.ToInt16(numericUpDown1.Value));
                        p.Import = numericUpDownImporte.Value.ToString();
                        listaPerfilesPresupuestados.Add(p);
                    }
                    CargarLabels(listaLabels);
                    textBoxCodigo.Text = string.Empty;
                    numericUpDown1.Value = 0;
                    numericUpDownImporte.Value = 0;
                    buttonReset.Enabled = true;
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
            foreach (var item in listaLabels)
            {
                char[] chars = item.Text.ToCharArray();
                Array.Reverse(chars);
                string a = "";
                foreach (char c in chars)
                {
                    if (char.IsDigit(c))
                        a += c;
                    else
                        break;
                }
                if (a.Length > 1)
                {
                    char[] chars2 = a.ToCharArray();
                    Array.Reverse(chars2);
                    a = new string(chars2);
                }
                sumaTiras += Convert.ToDecimal(a);
                kg += Convert.ToDecimal(listaPerfilesPresupuestados[listaLabels.IndexOf(item)].KgXTira.Replace(".", ",")) * Convert.ToDecimal(a);
                importe += Convert.ToDecimal(listaPerfilesPresupuestados[listaLabels.IndexOf(item)].Import) * kg;
            }
            labelTotalImporte.Text = "Total importe = " + importe.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            labelTotalTiras.Text = "Total tiras = " + sumaTiras.ToString();
            labelTotalKg.Text = "Total KG = " + kg.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetearEleccion();
        }

        private void FormPresupuesto_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            listaPerfilesPresupuestados.Clear();
            listaLabels.Clear();
            CargarLabels(listaLabels);
            SumarCantidades();
            buttonReset.Enabled = false;
        }
    }
}
