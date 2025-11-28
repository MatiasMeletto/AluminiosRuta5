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
using iTextSharp.tool.xml.html;

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
        decimal importeBB = 0;
        decimal importeBA = 0;
        decimal importeNE = 0;
        decimal importeNA = 0;
        decimal importeR = 0;
        decimal kg = 0;
        decimal kgBB = 0;
        decimal kgBA = 0;
        decimal kgNE = 0;
        decimal kgNA = 0;
        decimal kgR = 0;
        private static string sql;
        private List<Label> listaLabels = new List<Label>();
        private FormPrincipal form;
        private List<Perfil> listaPerfiles = new List<Perfil>();
        private List<Perfil> listaPerfilesPresupuestados = new List<Perfil>();

        // Ya no necesitamos listaPerfilesNoRestar porque usaremos IDs negativos.

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
            command.Parameters.AddWithValue("TotalKilosBlancoB", kgBB.ToString());
            command.Parameters.AddWithValue("TotalKilosBlancoA", kgBA.ToString());
            command.Parameters.AddWithValue("TotalKilosNatural", kgNA.ToString());
            command.Parameters.AddWithValue("TotalKilosNegroSemiMate", kgNE.ToString());
            command.Parameters.AddWithValue("TotalKilosReciclado", kgR.ToString());
            command.Parameters.AddWithValue("TotalPesosBlancoB", importeBB.ToString());
            command.Parameters.AddWithValue("TotalPesosBlancoA", importeBA.ToString());
            command.Parameters.AddWithValue("TotalPesosNatural", importeNA.ToString());
            command.Parameters.AddWithValue("TotalPesosNegroSemiMate", importeNE.ToString());
            command.Parameters.AddWithValue("TotalPesosReciclado", importeR.ToString());
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


            sql = "INSERT INTO remitos (Fecha,TotalPesos,TotalKilos,NroRemito,TotalKilosBlancoB,TotalKilosBlancoA,TotalKilosNatural,TotalKilosNegroSemiMate,TotalKilosReciclado,TotalPesosBlancoB,TotalPesosBlancoA,TotalPesosNatural,TotalPesosNegroSemiMate,TotalPesosReciclado) " +
                "VALUES (@Fecha,@TotalPesos,@TotalKilos,@NroRemito,@TotalKilosBlancoB,@TotalKilosBlancoA,@TotalKilosNatural,@TotalKilosNegroSemiMate,@TotalKilosReciclado,@TotalPesosBlancoB,@TotalPesosBlancoA,@TotalPesosNatural,@TotalPesosNegroSemiMate,@TotalPesosReciclado)";
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

            // Buscamos el label visual por su Nombre (que coincide con el botón)
            Label label = listaLabels.Where(l => l.Name == button.Name).SingleOrDefault();

            if (label != null)
            {
                // Eliminamos por INDICE para evitar conflictos con IDs repetidos o negativos
                int index = listaLabels.IndexOf(label);

                if (index >= 0 && index < listaPerfilesPresupuestados.Count)
                {
                    // Al borrar por índice, no importa si el ID es positivo o negativo, 
                    // borramos exactamente el que el usuario clickeó.
                    listaPerfilesPresupuestados.RemoveAt(index);
                    listaLabels.RemoveAt(index);
                }

                CargarLabels(listaLabels);
                SumarCantidades();

                if (listaLabels.Count == 0)
                {
                    btnConfirmar.Enabled = false;
                    textBoxNombre.Enabled = false;
                    textBoxLocalidad.Enabled = false;
                    textBoxPlata.Enabled = false;
                }
            }
        }
        public FormRemito(FormPrincipal f)
        {
            InitializeComponent();
            CargarPerfiles();
            form = f;
            btnConfirmar.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxLocalidad.Enabled = false;
            textBoxPlata.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCodigo.Text.Trim()) || string.IsNullOrEmpty(textBoxKilos.Text.Trim()) || string.IsNullOrEmpty(textBoxImporte.Text.Trim()) || string.IsNullOrEmpty(textBoxTiras.Text.Trim()))
            {
                if (checkBox1.Checked || checkBoxStock.Checked)
                    goto Agregar;
                MessageBox.Show("Complete los campos por favor");
                return;
            }
            OpenConnection();

        Agregar:
            // Buscamos en el catálogo maestro
            Perfil pCatalogo = listaPerfiles.Where(l => l.Codigo == textBoxCodigo.Text).SingleOrDefault();

            if (pCatalogo != null || checkBox1.Checked)
            {
                if (checkBox1.Checked)
                {
                    // Lógica ACCESORIOS (ID 0)
                    Perfil perfil = new Perfil()
                    {
                        PerfilId = 0,
                        Codigo = textBoxCodigo.Text,
                        CantidadTiras = Convert.ToInt16(textBoxTiras.Text),
                        Import = textBoxImporte.Text,
                        KgXTira = "0",
                        KgXPaquete = "0",
                        // Asignamos una categoría por defecto si es necesario, o 0
                        CategoriaId = 0
                    };
                    ListaLabels(listaLabels, perfil, Convert.ToInt16(textBoxTiras.Text), checkBox1.Checked);
                    listaPerfilesPresupuestados.Add(perfil);
                }
                else
                {
                    // Lógica STOCK (Normal o Desligado)

                    // Definimos el ID objetivo: 
                    // Si checkBoxStock es true -> ID negativo (Desligado)
                    // Si checkBoxStock es false -> ID positivo (Ligado)
                    int targetId = checkBoxStock.Checked ? (pCatalogo.PerfilId * -1) : pCatalogo.PerfilId;

                    // Buscamos si ya existe este perfil específico en la lista actual
                    var perfilExistente = listaPerfilesPresupuestados.FirstOrDefault(x => x.PerfilId == targetId);

                    if (perfilExistente != null)
                    {
                        // Si existe, actualizamos cantidades sobre el objeto existente
                        int index = listaPerfilesPresupuestados.IndexOf(perfilExistente);
                        Label l = listaLabels[index];

                        char[] chars = l.Text.ToCharArray();
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

                        // Actualizamos visual
                        l.Text = new string(chars) + (Convert.ToInt16(a) + Convert.ToDecimal(textBoxTiras.Text)).ToString();

                        // Actualizamos datos
                        int tirasNuevas = Convert.ToInt16(textBoxTiras.Text);

                        // Calculamos el peso a sumar dependiendo del tipo
                        // Si el ID es positivo (Stock normal), confiamos en el TextBox (por si lo editaste manual).
                        // Si el ID es negativo (Desligado), usamos el catálogo directo porque el TextBox está deshabilitado.
                        decimal pesoUnitario = (perfilExistente.PerfilId > 0)
                                                ? Convert.ToDecimal(textBoxKilos.Text)
                                                : Convert.ToDecimal(pCatalogo.KgXTira);

                        decimal pesoASumar = pesoUnitario * tirasNuevas;

                        // Actualizamos el objeto
                        perfilExistente.Import = textBoxImporte.Text;
                        perfilExistente.KgXPaquete = (Convert.ToDecimal(perfilExistente.KgXPaquete) + pesoASumar).ToString();
                        perfilExistente.KgXTira = perfilExistente.KgXPaquete;
                        perfilExistente.CantidadTiras += tirasNuevas;
                    }
                    else
                    {
                        // Si es NUEVO en la lista, creamos una INSTANCIA NUEVA copiando los datos del catálogo
                        // Es vital crear "new Perfil()" para no modificar el objeto del catálogo pCatalogo
                        Perfil nuevoPerfil = new Perfil
                        {
                            PerfilId = targetId, // Aquí asignamos el ID positivo o negativo
                            Codigo = pCatalogo.Codigo,
                            Descripcion = pCatalogo.Descripcion,
                            CategoriaId = pCatalogo.CategoriaId,
                            Import = textBoxImporte.Text,
                            KgXTira = targetId > 0 ? textBoxKilos.Text : (Convert.ToDouble(listaPerfiles.Where(p => p.PerfilId == (targetId * -1)).FirstOrDefault().KgXTira) * Convert.ToInt16(textBoxTiras.Text)).ToString(),
                            KgXPaquete = targetId > 0 ? textBoxKilos.Text : (Convert.ToDouble(listaPerfiles.Where(p => p.PerfilId == (targetId * -1)).FirstOrDefault().KgXTira) * Convert.ToInt16(textBoxTiras.Text)).ToString(),
                            CantidadTiras = Convert.ToInt16(textBoxTiras.Text)
                        };

                        // Agregamos visual y a la lista
                        ListaLabels(listaLabels, nuevoPerfil, Convert.ToInt16(textBoxTiras.Text), checkBox1.Checked);
                        listaPerfilesPresupuestados.Add(nuevoPerfil);
                    }
                }

                CargarLabels(listaLabels);
                textBoxCodigo.Text = string.Empty;
                textBoxTiras.Text = string.Empty;
                textBoxKilos.Text = string.Empty;
                textBoxImporte.Text = string.Empty;

                checkBox1.Checked = false;
                checkBoxStock.Checked = false;

                if (!btnConfirmar.Enabled)
                {
                    btnConfirmar.Enabled = true;
                    textBoxNombre.Enabled = true;
                    textBoxLocalidad.Enabled = true;
                    textBoxPlata.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("No se encontro el codigo");
            }

            CloseConnection();
            SumarCantidades();
        }

        public static void ListaLabels(List<Label> lista, Perfil perfil, int cantidadTiras, bool acc)
        {
            if (acc)
            {
                Label label = new Label
                {
                    Tag = perfil.PerfilId,
                    Name = lista.Count().ToString(),
                    Text = $"* {perfil.Codigo} ---  $ por unidad: {perfil.Import} --- total $: {(cantidadTiras * Convert.ToDecimal(perfil.Import)).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))} ---  x{cantidadTiras}",
                    Location = new Point(0, 30 * lista.Count()),
                    Font = new System.Drawing.Font("Microsoft JhengHei UI", 13),
                    AutoSize = true
                };
                label.BringToFront();
                label.Show();
                lista.Add(label);
            }
            else
            {
                Label label = new Label
                {
                    Tag = perfil.PerfilId,
                    Name = lista.Count().ToString(),
                    Text = $"* {perfil.Codigo} --- {perfil.Descripcion} ---  KG: {perfil.KgXTira} ---  $ por kilo: {perfil.Import} --- total $: {(Convert.ToDecimal(perfil.KgXTira) * Convert.ToDecimal(perfil.Import)).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))} ---  x{cantidadTiras}",
                    Location = new Point(0, 30 * lista.Count()),
                    Font = new System.Drawing.Font("Microsoft JhengHei UI", 13),
                    AutoSize = true
                };
                label.BringToFront();
                label.Show();
                lista.Add(label);
            }
        }
        private void SumarCantidades()
        {
            decimal sumaTiras = 0;
            importe = 0;
            importeBB = 0;
            importeBA = 0;
            importeNE = 0;
            importeNA = 0;
            importeR = 0;
            kg = 0;
            kgBA = 0;
            kgBB = 0;
            kgNA = 0;
            kgNE = 0;
            kgR = 0;

            foreach (var item in listaPerfilesPresupuestados)
            {
                if (item.PerfilId == 0) // Accesorio
                {
                    importe += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.CantidadTiras);
                }
                else // Perfil (Ligado o Desligado, ambos suman plata y kilos al remito)
                {
                    sumaTiras += item.CantidadTiras;
                    importe += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.KgXPaquete);
                    kg += Convert.ToDecimal(item.KgXPaquete);

                    if (item.CategoriaId == 24)
                    {
                        kgBB += Convert.ToDecimal(item.KgXPaquete);
                        importeBB += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.KgXPaquete);
                    }
                    else if (item.CategoriaId == 25)
                    {
                        kgR += Convert.ToDecimal(item.KgXPaquete);
                        importeR += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.KgXPaquete);
                    }
                    else if (item.CategoriaId == 27)
                    {
                        kgNE += Convert.ToDecimal(item.KgXPaquete);
                        importeNE += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.KgXPaquete);
                    }
                    else if (item.CategoriaId == 28)
                    {
                        kgBA += Convert.ToDecimal(item.KgXPaquete);
                        importeBA += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.KgXPaquete);
                    }
                    else if (item.CategoriaId == 29)
                    {
                        kgNA += Convert.ToDecimal(item.KgXPaquete);
                        importeNA += Convert.ToDecimal(item.Import) * Convert.ToDecimal(item.KgXPaquete);
                    }
                }
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
                // Si es accesorio (Id 0) O ID Negativo (Desligado), saltamos la validación de stock
                // Como usamos IDs negativos para desligar, basta con verificar p.PerfilId <= 0
                if (p.PerfilId <= 0)
                    continue;

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
                else if (line.Contains("@NOMBRECLIENTEEEEEEEEEEEEEEEE"))
                {
                    char[] chars = textBoxNombre.Text.ToCharArray();
                    if (textBoxNombre.Text.Trim().Length == 29)
                    {
                        line = line.Replace("@NOMBRECLIENTEEEEEEEEEEEEEEEE", textBoxNombre.Text);
                    }
                    if (textBoxNombre.Text.Trim().Length < 29)
                    {
                        char[] chars2 = line.ToCharArray();
                        line = "";
                        for (int i = 0; i < 103; i++)
                        {
                            if (i > 49 && i < chars.Length + 50)
                            {
                                line += chars[i - 50];
                            }
                            else if (i < 50 || i > 78)
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
                else if (line.Contains("@DI"))
                {
                    line = line.Replace("@DI", DateTime.Now.Day.ToString());
                }
                else if (line.Contains("@M"))
                {
                    line = line.Replace("@M", DateTime.Now.Month.ToString());
                }
                else if (line.Contains("@A"))
                {
                    line = line.Replace("@A", DateTime.Now.Year.ToString());
                }
                else if (line.Contains("@LOCALIDADDDDD"))
                {
                    char[] chars = textBoxLocalidad.Text.ToCharArray();
                    if (textBoxLocalidad.Text.Trim().Length == 14)
                    {
                        line = line.Replace("@LOCALIDADDDDD", textBoxLocalidad.Text);
                    }
                    if (textBoxLocalidad.Text.Trim().Length < 29)
                    {
                        char[] chars2 = line.ToCharArray();
                        line = "";
                        for (int i = 0; i < 88; i++)
                        {
                            if (i > 49 && i < chars.Length + 50)
                            {
                                line += chars[i - 50];
                            }
                            else if (i < 50 || i > 63)
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
                else if (line.Contains("id=\"tabla\""))
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
                        if (l.PerfilId != 0)
                            sw.WriteLine("<td>" + (Convert.ToDecimal(l.KgXPaquete) * Convert.ToDecimal(l.Import)).ToString("C", CultureInfo.CreateSpecificCulture("en-US")) + "</td>");
                        if (l.PerfilId == 0)
                            sw.WriteLine("<td>" + (Convert.ToDecimal(l.CantidadTiras) * Convert.ToDecimal(l.Import)).ToString("C", CultureInfo.CreateSpecificCulture("en-US")) + "</td>");
                        sw.WriteLine("</tr>");
                    }
                    if (textBoxPlata.Text.Trim().Length > 0)
                    {
                        sw.WriteLine("<tr style=\"height: 30px;border:0px\">");
                        sw.WriteLine("<td style=\"border:0px\"> </td>");
                        sw.WriteLine("<td style=\"border:0px\"> </td>");
                        sw.WriteLine("<td style=\"border:0px\"> </td>");
                        sw.WriteLine("<td style=\"border:0px\"> </td>");
                        sw.WriteLine("<td style=\"border:0px\"> </td>");
                        sw.WriteLine("<td style=\"border:0px\"> </td>");
                        sw.WriteLine("</tr>");
                        sw.WriteLine("<tr style=\"height: 30px;\">");
                        if (!checkBoxPlataAFavorOEnContra.Checked)
                            sw.WriteLine("<td colspan=\"2\" >" + "Plata a favor del cliente" + "</td>");
                        else
                            sw.WriteLine("<td colspan=\"2\" >" + "Plata adeudada " + "</td>");
                        sw.WriteLine("<td colspan=\"3\" style=\"text-align: right;\" >" + (Convert.ToDecimal(textBoxPlata.Text)).ToString("C", CultureInfo.CreateSpecificCulture("en-US")) + "</td>");
                        sw.WriteLine("</tr>");
                    }

                }
                else if (line.Contains("@TOTALKG"))
                {
                    line = line.Replace("@TOTALKG", kg.ToString());
                }
                else if (line.Contains("@TOTALPESOS"))
                {
                    if (textBoxPlata.Text.Trim().Length > 0)
                    {
                        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                        culture.NumberFormat.CurrencyNegativePattern = 1;
                        if (checkBoxPlataAFavorOEnContra.Checked)
                            line = line.Replace("@TOTALPESOS", (Convert.ToDecimal(textBoxPlata.Text) + Convert.ToDecimal(importe)).ToString("C", culture));
                        else
                            line = line.Replace("@TOTALPESOS", (Convert.ToDecimal(importe) - Convert.ToDecimal(textBoxPlata.Text)).ToString("C", culture));
                    }
                    else
                    {
                        line = line.Replace("@TOTALPESOS", (Convert.ToDecimal(importe)).ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                    }
                }
                sw.WriteLine(line);
                line = str.ReadLine();
            }
            str.Close();
            sw.Close();

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "-" + (Convert.ToDecimal(nroRemitoActual)).ToString("0000") + "-" + textBoxNombre.Text + ".pdf";

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
                // Si es accesorio (Id 0) O ID Negativo (Desligado), saltamos el update
                if (p.PerfilId <= 0)
                    continue;

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
            textBoxLocalidad.Enabled = false;
            textBoxLocalidad.Text = string.Empty;
            textBoxPlata.Enabled = false;
            textBoxPlata.Text = string.Empty;
            MessageBox.Show("Se resto correctamente del stock");
            listaLabels.Clear();
            listaPerfilesPresupuestados.Clear();
            // listaPerfilesNoRestar.Clear(); // Ya no existe
            panel1.Controls.Clear();
            SumarCantidades();
            CloseConnection();
        }

        private void textBoxImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                lImporte.Text = "Importe x unidad";
                lTiras.Text = "Cantidad";
                textBoxKilos.Enabled = false;
            }
            else
            {
                lImporte.Text = "Importe por kilo";
                lTiras.Text = "Cantidad tiras";
                textBoxKilos.Enabled = true;
            }
        }

        private void checkBoxPlataAFavorOEnContra_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPlataAFavorOEnContra.Checked)
            {
                labelPlata.Text = "Plata en contra";
            }
            else
            {
                labelPlata.Text = "Plata a favor";
            }
        }

        private void textBoxPlata_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void checkBoxStock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStock.Checked)
            {
                textBoxKilos.Enabled = false;
            }
            else
            {
                textBoxKilos.Enabled = true;
            }
        }
    }
}