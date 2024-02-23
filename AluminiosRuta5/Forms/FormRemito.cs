using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using iTextSharp.text.pdf.parser;


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

        string paginahtml_texto;
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
        public static string ReplaceFirst(string str, string term, string replace)
        {
            int position = str.IndexOf(term);
            if (position < 0)
            {
                return str;
            }
            str = str.Substring(0, position) + replace + str.Substring(position + term.Length);
            return str;
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
                    Font = new System.Drawing.Font("Microsoft JhengHei UI", 10),
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
            if (string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) || numericUpDownCantTiras.Value == 0 || numericUpDownKilos.Value == 0)
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
                    p.Import = numericUpDownImporte.Value.ToString();
                    p.KgXPaquete = numericUpDownKilos.Value.ToString();
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
                importe += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.KgXPaquete);
                kg += Convert.ToDecimal(item.KgXPaquete);
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

                if ((Convert.ToInt16(dr[3]) - p.CantidadTiras) >= 0)
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("No hay sufientes tiras de " + dr[1].ToString());
                    return;
                }
            }
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

                sql = $"UPDATE perfiles SET CantidadTiras = {Convert.ToInt16(dr[3]) - p.CantidadTiras} WHERE PerfilId = {dr[0]}";
                command.CommandText = sql;
                command.ExecuteNonQuery();

                string paginahtml = Application.StartupPath + "\\HTMLModelo\\html.html";
                paginahtml_texto = Application.StartupPath + "\\HTMLModelo\\htmlModificado.txt";

                StreamReader str = new StreamReader(paginahtml);
                StreamWriter sw = new StreamWriter(paginahtml_texto);

                string line = str.ReadLine();

                while (line != null)
                {
                    if (line.Contains("id=\"tabla\""))
                    {
                        line = str.ReadLine();
                        line = str.ReadLine();
                        line = str.ReadLine();
                        line = str.ReadLine();
                        line = str.ReadLine();
                        line = str.ReadLine();
                        line = str.ReadLine();
                        foreach (var l in listaPerfilesPresupuestados)
                        {
                            sw.WriteLine("<tr style=\"height: 30px;\">");
                            sw.WriteLine("<td>" + l.CantidadTiras + "</td>");
                            sw.WriteLine("<td>" + l.Codigo + "</td>");
                            sw.WriteLine("<td>" + l.Import + "</td>");
                            sw.WriteLine("<td>" + l.KgXPaquete + "</td>");
                            sw.WriteLine("<td>" + Convert.ToDecimal(l.KgXPaquete) * Convert.ToDecimal(l.Import) + "</td>");
                            sw.WriteLine("</tr>");
                        }
                    }
                    sw.WriteLine(line);
                    line = str.ReadLine();
                }
                str.Close();
                sw.Close();
            }
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "remitonr.pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    using (StreamReader sr = new StreamReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
            }
            btnConfirmar.Enabled = false;
            MessageBox.Show("Se resto correctamente del stock");
            listaLabels.Clear();
            listaPerfilesPresupuestados.Clear();
            CargarPerfiles();
            panel1.Controls.Clear();
            SumarCantidades();
            CloseConnection();
        }
    }
}
