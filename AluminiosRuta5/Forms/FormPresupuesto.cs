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
                MessageBox.Show("Por favor complete: Código, Cantidad de Tiras e Importe por Kilo.");
                return;
            }

            try
            {
                Perfil perfilDb = listaPerfiles.Where(l => l.Codigo == textBox1.Text).SingleOrDefault();

                if (perfilDb != null)
                {
                    int cantidadIngresada = Convert.ToInt32(textBoxTiras.Text);
                    decimal precioPorKilo = Convert.ToDecimal(textBoxImporte.Text);
                    decimal pesoUnitarioPorTira = Convert.ToDecimal(perfilDb.KgXTira);

                    // Cálculo del peso total de esta línea
                    decimal pesoTotalLinea = pesoUnitarioPorTira * cantidadIngresada;

                    // Verificar si ya existe visualmente
                    Label labelExistente = listaLabels.Where(la => Convert.ToInt16(la.Tag) == perfilDb.PerfilId).SingleOrDefault();

                    if (labelExistente != null)
                    {
                        // ACTUALIZAR EXISTENTE
                        var itemEnLista = listaPerfilesPresupuestados.Find(x => x.PerfilId == perfilDb.PerfilId);

                        itemEnLista.CantidadTiras += cantidadIngresada;

                        // Recalcular peso total acumulado
                        decimal pesoTotalAcumulado = pesoUnitarioPorTira * itemEnLista.CantidadTiras;
                        itemEnLista.KgXPaquete = pesoTotalAcumulado.ToString();

                        itemEnLista.Import = textBoxImporte.Text;

                        ActualizarTextoLabel(labelExistente, itemEnLista);
                    }
                    else
                    {
                        // CREAR NUEVO
                        Perfil nuevoItem = new Perfil
                        {
                            PerfilId = perfilDb.PerfilId,
                            Codigo = perfilDb.Codigo,
                            Descripcion = perfilDb.Descripcion,
                            CantidadTiras = cantidadIngresada,
                            Import = textBoxImporte.Text,
                            KgXTira = perfilDb.KgXTira,
                            KgXPaquete = pesoTotalLinea.ToString() // Guardamos el peso total aquí
                        };

                        CrearLabelVisual(nuevoItem);
                        listaPerfilesPresupuestados.Add(nuevoItem);
                    }

                    // Limpieza
                    textBox1.Text = "";
                    textBoxTiras.Text = "";
                    textBoxImporte.Text = "";
                    textBox1.Focus();
                    buttonReset.Enabled = true;
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

        // --- MÉTODOS VISUALES (FORMATO ANTIGUO RESTAURADO) ---

        private void CrearLabelVisual(Perfil p)
        {
            CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
            decimal precioKg = Convert.ToDecimal(p.Import);
            decimal pesoTotal = Convert.ToDecimal(p.KgXPaquete); // KgXPaquete tiene el total calculado
            decimal totalPesos = pesoTotal * precioKg;

            Label l = new Label();
            l.Tag = p.PerfilId;
            l.Name = listaLabels.Count.ToString();
            l.AutoSize = true;
            l.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13); // Fuente original más grande
            l.Location = new Point(0, 30 * listaLabels.Count); // Posición original (X=0)

            // FORMATO RESTAURADO:
            // "* CODIGO --- DESCRIPCION --- KG: 99.99 --- $ por kilo: 99.99 --- total $: $999.99 --- x99"
            l.Text = $"* {p.Codigo} --- {p.Descripcion} ---  KG: {pesoTotal.ToString("N2", us)} ---  $ por kilo: {precioKg.ToString("N2", us)} --- total $: {totalPesos.ToString("C", us)} ---  x{p.CantidadTiras}";

            panel1.Controls.Add(l);
            listaLabels.Add(l);

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

        private void ActualizarTextoLabel(Label l, Perfil p)
        {
            CultureInfo us = CultureInfo.CreateSpecificCulture("en-US");
            decimal precioKg = Convert.ToDecimal(p.Import);
            decimal pesoTotal = Convert.ToDecimal(p.KgXPaquete);
            decimal totalPesos = pesoTotal * precioKg;

            // Misma lógica de formato para actualizar
            l.Text = $"* {p.Codigo} --- {p.Descripcion} ---  KG: {pesoTotal.ToString("N2", us)} ---  $ por kilo: {precioKg.ToString("N2", us)} --- total $: {totalPesos.ToString("C", us)} ---  x{p.CantidadTiras}";

            // Actualizar posición del botón X
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
            Label lbl = listaLabels.Find(x => x.Name == btn.Name);

            if (lbl != null)
            {
                int idPerfil = Convert.ToInt32(lbl.Tag);
                var item = listaPerfilesPresupuestados.Find(x => x.PerfilId == idPerfil);

                listaPerfilesPresupuestados.Remove(item);
                listaLabels.Remove(lbl);

                // Redibujar lista para quitar huecos
                panel1.Controls.Clear();
                listaLabels.Clear();

                foreach (var perfil in listaPerfilesPresupuestados)
                {
                    CrearLabelVisual(perfil);
                }

                SumarCantidades();
            }
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

                decimal pesoItem = Convert.ToDecimal(item.KgXPaquete);
                totalKilos += pesoItem;

                decimal precioKg = Convert.ToDecimal(item.Import);
                totalDinero += pesoItem * precioKg;
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
                            // Saltamos las líneas del template HTML vacio
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
                                // 1. Convertimos los valores correctamente para evitar el error de "3.500 kg"
                                // Import viene del TextBox (formato local de tu PC)
                                decimal precio = decimal.Parse(l.Import);
                                // KgXPaquete lo calculamos nosotros con punto (Invariant) en el btnAgregar
                                decimal pesoTotal = decimal.Parse(l.KgXPaquete, CultureInfo.InvariantCulture);

                                sw.WriteLine("<tr style=\"height: 30px;\">");
                                sw.WriteLine("<td>" + l.CantidadTiras + "</td>");
                                sw.WriteLine("<td>" + l.Codigo + "</td>");
                                sw.WriteLine("<td>" + precio.ToString("C0", us) + "</td>");
                                sw.WriteLine("<td>" + pesoTotal.ToString("N2", us) + "</td>");

                                // Lógica idéntica al Remito:
                                if (l.PerfilId != 0) // Si es Perfil -> Precio x Peso
                                {
                                    sw.WriteLine("<td>" + (pesoTotal * precio).ToString("C0", us) + "</td>");
                                }
                                if (l.PerfilId == 0) // Si es Accesorio -> Precio x Cantidad
                                {
                                    sw.WriteLine("<td>" + (l.CantidadTiras * precio).ToString("C0", us) + "</td>");
                                }

                                sw.WriteLine("</tr>");
                            }
                            // Aquí NO ponemos el bloque de 'textBoxPlata' porque es Presupuesto
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetearEleccion();
        }

        // --- ARREGLO DE LOS ERRORES DEL DISEÑADOR ---
        // Este método es invocado por los eventos KeyPress de Tiras e Importe
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

        // Nombres exactos que busca el Designer.cs
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