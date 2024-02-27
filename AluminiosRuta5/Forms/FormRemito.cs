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
        string nroRemitoActual;
        decimal importe = 0;
        decimal kg = 0;
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
        private void AddCmdParameters(int n)
        {
            command.Parameters.Clear();
            command.CommandText = sql;

            command.Parameters.AddWithValue("Fecha", DateTime.Now.ToString("ddMMyyyy"));
            command.Parameters.AddWithValue("TotalPesos", importe.ToString());
            command.Parameters.AddWithValue("TotalKilos", kg.ToString());
            command.Parameters.AddWithValue("NroRemito", n + 1);
        }
        private void CrearRemito()
        {
            sql = "SELECT NroRemito,MAX(RemitoId) FROM remitos";
            command.CommandText = sql;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Remitos");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Remitos"];


            sql = "INSERT INTO remitos (Fecha,TotalPesos,TotalKilos,NroRemito) " +
                "VALUES (@Fecha,@TotalPesos,@TotalKilos,@NroRemito)";
            if (bindingSrc.Count > 0)
            {
                DataRowView dr = bindingSrc[0] as DataRowView;
                if (Convert.ToInt16(dr[0]) != 9999)
                {
                    AddCmdParameters(Convert.ToInt16(dr[0]));
                    nroRemitoActual = Convert.ToString(Convert.ToInt16(dr[0]) + 1);
                }
                else
                { 
                    AddCmdParameters(0);
                    nroRemitoActual = "0";
                }
            }
            else
            {
                AddCmdParameters(0);
                nroRemitoActual = "0";
            }
            command.ExecuteNonQuery();
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
                textBoxNombre.Enabled = false;
            }
        }
        public FormRemito(FormPrincipal f)
        {
            InitializeComponent();
            CargarPerfiles();
            form = f;
            btnConfirmar.Enabled = false;
            textBoxNombre.Enabled = false;
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
                    Label l = listaLabels.Where(la => Convert.ToInt16(la.Tag) == p.PerfilId).SingleOrDefault();
                    if (l != null)
                    {
                        Perfil pe = listaPerfilesPresupuestados.Where(le => le.Codigo == textBoxCodigo.Text).SingleOrDefault();
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
                        listaLabels[listaLabels.IndexOf(l)].Text = new string(chars) + (Convert.ToInt16(a) + numericUpDownCantTiras.Value).ToString();
                        pe.Import = numericUpDownImporte.Value.ToString();
                        pe.KgXPaquete = (Convert.ToDecimal(pe.KgXPaquete) + numericUpDownKilos.Value).ToString();
                        pe.CantidadTiras += Convert.ToInt16(numericUpDownCantTiras.Value);
                    }
                    else
                    {
                        p.Import = numericUpDownImporte.Value.ToString();
                        p.KgXPaquete = numericUpDownKilos.Value.ToString();
                        ModuloStock.ListaLabels(listaLabels, p, Convert.ToInt16(numericUpDownCantTiras.Value));
                        p.CantidadTiras = Convert.ToInt16(numericUpDownCantTiras.Value);
                        listaPerfilesPresupuestados.Add(p);
                    }

                    CargarLabels(listaLabels);
                    textBoxCodigo.Text = string.Empty;
                    numericUpDownCantTiras.Value = 0;
                    numericUpDownKilos.Value = 0;
                    numericUpDownImporte.Value = 0;
                    if (!btnConfirmar.Enabled)
                    {
                        btnConfirmar.Enabled = true;
                        textBoxNombre.Enabled = true;
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
            importe = 0;
            kg = 0;

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetearEleccion();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text.Trim()))
            {
                MessageBox.Show("Ingrese un nombre por favor");
            }
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
            CrearRemito();
            string paginahtml = Application.StartupPath + "\\HTMLModelo\\html.html";
            paginahtml_texto = Application.StartupPath + "\\HTMLModelo\\htmlModificado.txt";

            StreamReader str = new StreamReader(paginahtml);
            StreamWriter sw = new StreamWriter(paginahtml_texto);

            string line = str.ReadLine();

            while (line != null)
            {
                if (line.Contains("@NRO"))
                {
                    line = line.Replace("@NRO", (Convert.ToDecimal(nroRemitoActual)).ToString("0000"));
                }
                if (line.Contains("@NOMBRECLIENTEEEEEEEEEEEEEEEEEE"))
                {
                    char[] chars = textBoxNombre.Text.ToCharArray();
                    if (textBoxNombre.Text.Trim().Length == 31)
                    {
                        line = line.Replace("@NOMBRECLIENTEEEEEEEEEEEEEEEEEE", textBoxNombre.Text);
                    }
                    if (textBoxNombre.Text.Trim().Length < 31)
                    {
                        char[] chars2 = line.ToCharArray();
                        line = "";
                        for (int i = 0; i < 105; i++)
                        {
                            if (i > 49 && i < chars.Length + 50)
                            {
                                line += chars[i - 50];
                            }
                            else if (i < 50 || i > 80)
                            {
                                line += chars2[i];
                            }
                            else
                            {
                                line += "&nbsp;";
                            }
                        }
                    }
                }
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
                        sw.WriteLine("<td>" + Convert.ToDecimal(l.Import).ToString("C", CultureInfo.CreateSpecificCulture("en-US")) + "</td>");
                        sw.WriteLine("<td>" + l.KgXPaquete + "</td>");
                        sw.WriteLine("<td>" + (Convert.ToDecimal(l.KgXPaquete) * Convert.ToDecimal(l.Import)).ToString("C", CultureInfo.CreateSpecificCulture("en-US")) + "</td>");
                        sw.WriteLine("</tr>");
                    }
                }
                sw.WriteLine(line);
                line = str.ReadLine();
            }
            str.Close();
            sw.Close();

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.Day.ToString()+"_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "-" + (Convert.ToDecimal(nroRemitoActual)).ToString("0000") + ".pdf";

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
            else
            {
                return;
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
            }
            btnConfirmar.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxNombre.Text = string.Empty;
            MessageBox.Show("Se resto correctamente del stock");
            listaLabels.Clear();
            listaPerfilesPresupuestados.Clear();
            panel1.Controls.Clear();
            SumarCantidades();
            CloseConnection();
        }
    }
}
