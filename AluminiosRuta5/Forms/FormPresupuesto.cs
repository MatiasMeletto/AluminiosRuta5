using AluminiosRuta5.Objects;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public partial class FormPresupuesto : Form
    {
        // Configuración de la base de datos
        private static string dbPath = Application.StartupPath + "\\" + "aluminioStock.db";
        private static string conString = "Data Source=" + dbPath + ";Version=3;New=False;Compress=True;";

        private FormPrincipal form;
        private List<Label> listaLabels = new List<Label>();
        private List<Perfil> listaPerfiles = new List<Perfil>();
        private List<Perfil> listaPerfilesPresupuestados = new List<Perfil>();

        public FormPresupuesto(FormPrincipal f)
        {
            InitializeComponent();
            form = f;
            CargarPerfiles();

            // Asignar evento al checkbox para cambiar textos visuales
            checkBoxAccesorio.CheckedChanged += CheckBoxAccesorio_CheckedChanged;
        }

        private void CheckBoxAccesorio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAccesorio.Checked)
            {
                labelTiras.Text = "Cantidad:";
                labelImporte.Text = "Precio x Unidad:";
                textBoxTiras.Enabled = true;
            }
            else
            {
                labelTiras.Text = "Cantidad Tiras:";
                labelImporte.Text = "Precio x Kilo:";
                textBoxTiras.Enabled = true;
            }
        }

        // 1. CARGAR BASE DE DATOS
        private void CargarPerfiles()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(conString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM perfiles ORDER BY PerfilId ASC;";

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "Perfiles");

                        BindingSource bindingSrc = new BindingSource();
                        bindingSrc.DataSource = ds.Tables["Perfiles"];

                        listaPerfiles = ModuloStock.CargarPerfiles(bindingSrc);

                        textBox1.AutoCompleteCustomSource.Clear();
                        foreach (DataRowView b in bindingSrc.List)
                        {
                            textBox1.AutoCompleteCustomSource.Add(b[1].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        // 2. BOTÓN AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) ||
                string.IsNullOrEmpty(textBoxTiras.Text.Trim()) ||
                string.IsNullOrEmpty(textBoxImporte.Text.Trim()))
            {
                MessageBox.Show("Por favor complete los campos.");
                return;
            }

            try
            {
                // Buscamos en el catálogo
                Perfil perfilDb = listaPerfiles.Where(l => l.Codigo == textBox1.Text).SingleOrDefault();

                // LÓGICA PRINCIPAL: Si existe en DB O es un Accesorio (manual), procedemos.
                if (perfilDb != null || checkBoxAccesorio.Checked)
                {
                    int cantidadIngresada = Convert.ToInt32(textBoxTiras.Text);

                    if (checkBoxAccesorio.Checked)
                    {
                        // --- MODO ACCESORIO (Venta por unidad) ---
                        // No validamos duplicados para accesorios (se agregan siempre nuevos para permitir distintos precios/descripciones)

                        string descripcion = "Accesorio";
                        if (perfilDb != null) descripcion = perfilDb.Descripcion;

                        Perfil nuevoItem = new Perfil
                        {
                            PerfilId = 0, // ID 0 para identificar accesorios
                            Codigo = textBox1.Text,
                            Descripcion = descripcion,
                            CantidadTiras = cantidadIngresada,
                            Import = textBoxImporte.Text,
                            KgXTira = "0",
                            KgXPaquete = "0"
                        };

                        CrearLabelVisual(nuevoItem);
                        listaPerfilesPresupuestados.Add(nuevoItem);
                    }
                    else
                    {
                        // --- MODO PERFIL (Venta por peso) ---

                        if (perfilDb == null)
                        {
                            MessageBox.Show("El código ingresado no existe en la base de datos.");
                            return;
                        }

                        // Buscamos si ya existe este perfil en la lista
                        var perfilExistente = listaPerfilesPresupuestados.FirstOrDefault(x => x.PerfilId == perfilDb.PerfilId);

                        if (perfilExistente != null)
                        {
                            // ACTUALIZAR EXISTENTE
                            int index = listaPerfilesPresupuestados.IndexOf(perfilExistente);
                            Label l = listaLabels[index]; // Obtenemos el label por índice seguro

                            perfilExistente.CantidadTiras += cantidadIngresada;

                            // Recalcular peso total acumulado
                            decimal pesoUnitarioPorTira = Convert.ToDecimal(perfilDb.KgXTira);
                            decimal pesoTotalAcumulado = pesoUnitarioPorTira * perfilExistente.CantidadTiras;

                            perfilExistente.KgXPaquete = pesoTotalAcumulado.ToString();
                            perfilExistente.Import = textBoxImporte.Text; // Actualizamos precio al último ingresado

                            ActualizarTextoLabel(l, perfilExistente);
                        }
                        else
                        {
                            // CREAR NUEVO
                            decimal pesoUnitarioPorTira = Convert.ToDecimal(perfilDb.KgXTira);
                            decimal pesoTotalLinea = pesoUnitarioPorTira * cantidadIngresada;

                            Perfil nuevoItem = new Perfil
                            {
                                PerfilId = perfilDb.PerfilId,
                                Codigo = perfilDb.Codigo,
                                Descripcion = perfilDb.Descripcion,
                                CantidadTiras = cantidadIngresada,
                                Import = textBoxImporte.Text,
                                KgXTira = perfilDb.KgXTira,
                                KgXPaquete = pesoTotalLinea.ToString()
                            };

                            CrearLabelVisual(nuevoItem);
                            listaPerfilesPresupuestados.Add(nuevoItem);
                        }
                    }

                    // Limpieza
                    textBox1.Text = "";
                    textBoxTiras.Text = "";
                    textBoxImporte.Text = "";
                    textBox1.Focus();
                    buttonReset.Enabled = true;

                    checkBoxAccesorio.Checked = false;
                }
                else
                {
                    MessageBox.Show("El código ingresado no existe en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar ítem: " + ex.Message);
            }

            SumarCantidades();
        }

        // --- MÉTODOS VISUALES ---

        private void CrearLabelVisual(Perfil p)
        {
            CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
            decimal precio = Convert.ToDecimal(p.Import);
            decimal totalPesos = 0;

            string textoLabel = "";

            if (p.PerfilId == 0) // Es Accesorio
            {
                totalPesos = precio * p.CantidadTiras;
                textoLabel = $"* {p.Codigo} --- {p.Descripcion} ---  Unidad: {precio.ToString("C", us)} --- Cantidad: {p.CantidadTiras} --- Total: {totalPesos.ToString("C", us)}";
            }
            else // Es Perfil
            {
                decimal pesoTotal = Convert.ToDecimal(p.KgXPaquete);
                totalPesos = pesoTotal * precio;
                textoLabel = $"* {p.Codigo} --- {p.Descripcion} ---  KG: {pesoTotal.ToString("N2", us)} ---  $ por kilo: {precio.ToString("N2", us)} --- total $: {totalPesos.ToString("C", us)} ---  x{p.CantidadTiras}";
            }

            Label l = new Label();
            l.Tag = p.PerfilId;
            l.Name = listaLabels.Count.ToString(); // El nombre es el índice inicial
            l.AutoSize = true;
            l.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13);
            l.Location = new Point(0, 30 * listaLabels.Count);
            l.Text = textoLabel;

            panel1.Controls.Add(l);
            listaLabels.Add(l);

            Button btnX = new Button();
            btnX.Text = "X";
            btnX.Name = l.Name; // El botón tiene el mismo nombre (índice) que el label
            btnX.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10);
            btnX.Size = new Size(20, 20);
            btnX.AutoSize = true;
            btnX.FlatStyle = FlatStyle.Popup;
            btnX.FlatAppearance.BorderSize = 0;
            btnX.Location = new Point(l.Right + 20, l.Top);
            btnX.Click += EliminarLabel_Click;
            panel1.Controls.Add(btnX);
        }

        private void ActualizarTextoLabel(Label l, Perfil p)
        {
            CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
            decimal precio = Convert.ToDecimal(p.Import);
            decimal pesoTotal = Convert.ToDecimal(p.KgXPaquete);
            decimal totalPesos = pesoTotal * precio;

            l.Text = $"* {p.Codigo} --- {p.Descripcion} ---  KG: {pesoTotal.ToString("N2", us)} ---  $ por kilo: {precio.ToString("N2", us)} --- total $: {totalPesos.ToString("C", us)} ---  x{p.CantidadTiras}";

            // Recolocar el botón X si el texto cambió de tamaño
            foreach (Control c in panel1.Controls)
            {
                if (c is Button && c.Name == l.Name)
                {
                    c.Location = new Point(l.Right + 20, l.Top);
                    break;
                }
            }
        }

        private void EliminarLabel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Buscamos por nombre (que es el índice original)
            Label lbl = listaLabels.Find(x => x.Name == btn.Name);

            if (lbl != null)
            {
                // Obtenemos el índice REAL actual en la lista
                int index = listaLabels.IndexOf(lbl);

                if (index >= 0 && index < listaPerfilesPresupuestados.Count)
                {
                    // Eliminamos por índice para asegurar sincronización perfecta
                    listaPerfilesPresupuestados.RemoveAt(index);
                    listaLabels.RemoveAt(index);

                    // Redibujar la lista para quitar huecos y reasignar índices/nombres
                    CargarLabelsVisualesDeNuevo();
                    SumarCantidades();
                }
            }
        }

        private void CargarLabelsVisualesDeNuevo()
        {
            panel1.Controls.Clear();
            List<Label> nuevaListaLabels = new List<Label>(); // Lista temporal para reconstruir

            foreach (var perfil in listaPerfilesPresupuestados)
            {
                // Reutilizamos la lógica de crear, pero gestionando la lista manualmente
                // para no duplicar lógica, copiamos parte de CrearLabelVisual aquí adaptada

                CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
                decimal precio = Convert.ToDecimal(perfil.Import);
                decimal totalPesos = 0;
                string textoLabel = "";

                if (perfil.PerfilId == 0) // Accesorio
                {
                    totalPesos = precio * perfil.CantidadTiras;
                    textoLabel = $"* {perfil.Codigo} --- {perfil.Descripcion} ---  Unidad: {precio.ToString("C", us)} --- Cantidad: {perfil.CantidadTiras} --- Total: {totalPesos.ToString("C", us)}";
                }
                else // Perfil
                {
                    decimal pesoTotal = Convert.ToDecimal(perfil.KgXPaquete);
                    totalPesos = pesoTotal * precio;
                    textoLabel = $"* {perfil.Codigo} --- {perfil.Descripcion} ---  KG: {pesoTotal.ToString("N2", us)} ---  $ por kilo: {precio.ToString("N2", us)} --- total $: {totalPesos.ToString("C", us)} ---  x{perfil.CantidadTiras}";
                }

                Label l = new Label();
                l.Tag = perfil.PerfilId;
                l.Name = nuevaListaLabels.Count.ToString(); // Nuevo índice secuencial
                l.AutoSize = true;
                l.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13);
                l.Location = new Point(0, 30 * nuevaListaLabels.Count);
                l.Text = textoLabel;

                panel1.Controls.Add(l);
                nuevaListaLabels.Add(l);

                Button btnX = new Button();
                btnX.Text = "X";
                btnX.Name = l.Name;
                btnX.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10);
                btnX.Size = new Size(20, 20);
                btnX.AutoSize = true;
                btnX.FlatStyle = FlatStyle.Popup;
                btnX.FlatAppearance.BorderSize = 0;
                btnX.Location = new Point(l.Right + 20, l.Top);
                btnX.Click += EliminarLabel_Click;
                panel1.Controls.Add(btnX);
            }

            // Reemplazamos la lista vieja con la nueva, ordenada y sin huecos
            listaLabels = nuevaListaLabels;
        }

        // 3. CALCULAR TOTALES
        private void SumarCantidades()
        {
            decimal totalTiras = 0;
            decimal totalKilos = 0;
            decimal totalDinero = 0;

            foreach (var item in listaPerfilesPresupuestados)
            {
                totalTiras += item.CantidadTiras;

                if (item.PerfilId == 0) // Accesorio
                {
                    decimal precioUnidad = Convert.ToDecimal(item.Import);
                    totalDinero += item.CantidadTiras * precioUnidad;
                }
                else // Perfil
                {
                    decimal pesoItem = Convert.ToDecimal(item.KgXPaquete);
                    decimal precioKg = Convert.ToDecimal(item.Import);

                    totalKilos += pesoItem;
                    totalDinero += pesoItem * precioKg;
                }
            }

            CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");

            labelTotalTiras.Text = "Total tiras = " + totalTiras.ToString();
            labelTotalKg.Text = "Total KG = " + totalKilos.ToString("N2", us);
            labelTotalImporte.Text = "Total importe = " + totalDinero.ToString("C2", us);
        }

        // 4. GUARDAR PRESUPUESTO (PDF)
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text.Trim()))
            {
                MessageBox.Show("Por favor ingrese el Nombre del cliente.");
                textBoxNombre.Focus();
                return;
            }

            if (listaPerfilesPresupuestados.Count == 0)
            {
                MessageBox.Show("La lista está vacía.");
                return;
            }

            string paginahtml = Application.StartupPath + "\\HTMLModelo\\html.html";
            string paginahtml_temp = Application.StartupPath + "\\HTMLModelo\\htmlModificado.txt";

            if (!File.Exists(paginahtml))
            {
                MessageBox.Show("No se encuentra la plantilla HTML.");
                return;
            }

            try
            {
                using (StreamReader str = new StreamReader(paginahtml))
                using (StreamWriter sw = new StreamWriter(paginahtml_temp))
                {
                    string line;
                    while ((line = str.ReadLine()) != null)
                    {
                        if (line.Contains("N° @NRO"))
                            line = line.Replace("N° @NRO", "       ");

                        else if (line.Contains("REMITO"))
                            line = line.Replace("REMITO", "PRESUPUESTO");

                        else if (line.Contains("@NOMBRECLIENTEEEEEEEEEEEEEEEE"))
                            line = line.Replace("@NOMBRECLIENTEEEEEEEEEEEEEEEE", textBoxNombre.Text.PadRight(50).Substring(0, 50));

                        else if (line.Contains("@LOCALIDADDDDD"))
                            line = line.Replace("@LOCALIDADDDDD", textBoxLocalidad.Text);

                        else if (line.Contains("@DI")) line = line.Replace("@DI", DateTime.Now.Day.ToString());
                        else if (line.Contains("@M")) line = line.Replace("@M", DateTime.Now.Month.ToString());
                        else if (line.Contains("@A")) line = line.Replace("@A", DateTime.Now.Year.ToString());

                        else if (line.Contains("id=\"tabla\""))
                        {
                            line = str.ReadLine();
                            line = str.ReadLine();
                            line = str.ReadLine();
                            line = str.ReadLine();
                            line = str.ReadLine();
                            line = str.ReadLine();
                            line = str.ReadLine();

                            CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");

                            foreach (var l in listaPerfilesPresupuestados)
                            {
                                decimal precio = decimal.Parse(l.Import);
                                decimal pesoTotal = decimal.Parse(l.KgXPaquete);

                                sw.WriteLine("<tr style=\"height: 30px;\">");
                                sw.WriteLine("<td>" + l.CantidadTiras + "</td>");
                                sw.WriteLine("<td>" + l.Codigo + "</td>");
                                sw.WriteLine("<td>" + precio.ToString("C", us) + "</td>");

                                if (l.PerfilId != 0)
                                    sw.WriteLine("<td>" + pesoTotal.ToString("N2", us) + "</td>");
                                else
                                    sw.WriteLine("<td> - </td>");

                                if (l.PerfilId != 0)
                                {
                                    sw.WriteLine("<td>" + (pesoTotal * precio).ToString("C", us) + "</td>");
                                }
                                else
                                {
                                    sw.WriteLine("<td>" + (l.CantidadTiras * precio).ToString("C", us) + "</td>");
                                }

                                sw.WriteLine("</tr>");
                            }
                        }

                        else if (line.Contains("@TOTALKG"))
                        {
                            string totalKg = labelTotalKg.Text.Replace("Total KG =", "").Trim();
                            line = line.Replace("@TOTALKG", totalKg);
                        }
                        else if (line.Contains("@TOTALPESOS"))
                        {
                            string totalPesos = labelTotalImporte.Text.Replace("Total importe =", "").Trim();
                            line = line.Replace("@TOTALPESOS", totalPesos);
                        }

                        sw.WriteLine(line);
                    }
                }

                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = $"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}-PRESUPUESTO-{textBoxNombre.Text}.pdf";
                guardar.Filter = "PDF Files|*.pdf";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        using (StreamReader sr = new StreamReader(paginahtml_temp))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }
                        pdfDoc.Close();
                    }
                    MessageBox.Show("Presupuesto generado correctamente.");
                }
                buttonReset_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            listaPerfilesPresupuestados.Clear();
            panel1.Controls.Clear();
            listaLabels.Clear();
            SumarCantidades();
            buttonReset.Enabled = false;
            textBoxNombre.Text = "";
            textBoxLocalidad.Text = "";
            checkBoxAccesorio.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetearEleccion();
        }

        // --- VALIDACIONES ---
        private void ValidarInputNumerico(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            TextBox txt = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txt.Text.Contains(".") || txt.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void textBoxTiras_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarInputNumerico(sender, e);
        }

        private void textBoxImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarInputNumerico(sender, e);
        }
    }
}