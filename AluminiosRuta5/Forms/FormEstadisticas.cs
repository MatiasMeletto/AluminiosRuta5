using AluminiosRuta5.Objects;
using iTextSharp.text;
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
using System.Xml.Schema;

namespace AluminiosRuta5.Forms
{
    public partial class FormEstadisticas : Form
    {
        private static BindingSource bindingSrc;

        private static string dbPath = Application.StartupPath + "\\" + "aluminioStock.db;";
        private static string conString = "Data Source=" + dbPath + "Version=3;New=False;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;
        private FormPrincipal form;
        private List<Perfil> listaPerfiles = new List<Perfil>();
        private List<Remito> remitos = new List<Remito>();
        private int indice;

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
        private void CargarPerfiles(SQLiteCommand cmd = null)
        {
            OpenConnection();
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
            CloseConnection();
        }
        public FormEstadisticas(FormPrincipal f)
        {
            InitializeComponent();
            form = f;
            dateTimePicker1.Value = (DateTime.Now.Date).AddMonths(-1);
            dateTimePicker1.MaxDate = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
            dateTimePicker2.MaxDate = DateTime.Now.Date;
            CargarPerfiles();
            CargarLabelsKg();
            CargarListaRemitos();
            CargarLabelsRemitos();
            buttonFiltrar_Click(this, EventArgs.Empty); 
        }
        private void CargarListaRemitos()
        {
            remitos.Clear();
            sql = "SELECT * FROM remitos";

            command.CommandText = sql;

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Remitos");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Remitos"];

            foreach (DataRowView b in bindingSrc.List)
            {
                if (b[1].ToString().Length != 8)
                    continue;
                Remito r = new Remito
                {
                    RemitoId = Convert.ToInt16(b[0]),
                    Fecha = b[1].ToString(),
                    TotalPesos = b[2].ToString(),
                    TotalKilos = b[3].ToString(),
                    NroRemito = Convert.ToInt16(b[4]),
                    TotalKilosBlancoB = b[5].ToString(),
                    TotalKilosBlancoA = b[6].ToString(),
                    TotalKilosNatural = b[7].ToString(),
                    TotalKilosNegroSemiMate = b[8].ToString(),
                    TotalKilosReciclado = b[9].ToString(),
                    TotalPesosBlancoB = b[10].ToString(),
                    TotalPesosBlancoA = b[11].ToString(),
                    TotalPesosNatural = b[12].ToString(),
                    TotalPesosNegroSemiMate = b[13].ToString(),
                    TotalPesosReciclado = b[14].ToString(),
                };
                remitos.Add(r);
            }
        }
        private void CargarLabelsRemitos()
        {
            panelRemitos.Controls.Clear();
            decimal TotalPesosR = 0;
            decimal TotalPesosRBB = 0;
            decimal TotalPesosRBA = 0;
            decimal TotalPesosRNA = 0;
            decimal TotalPesosRNE = 0;
            decimal TotalPesosRR = 0;
            decimal TotalKG = 0;
            decimal TotalKGBB = 0;
            decimal TotalKGBA = 0;
            decimal TotalKGNA = 0;
            decimal TotalKGNE = 0;
            decimal TotalKGR = 0;
            foreach (var r in remitos)
            {
                TotalPesosR += Convert.ToDecimal(r.TotalPesos);
                TotalKG += Convert.ToDecimal(r.TotalKilos);
                TotalKGBB += Convert.ToDecimal(r.TotalKilosBlancoB);
                TotalKGBA += Convert.ToDecimal(r.TotalKilosBlancoA);
                TotalKGNA += Convert.ToDecimal(r.TotalKilosNatural);
                TotalKGNE += Convert.ToDecimal(r.TotalKilosNegroSemiMate);
                TotalKGR += Convert.ToDecimal(r.TotalKilosReciclado);
                TotalPesosRBB += Convert.ToDecimal(r.TotalPesosBlancoB);
                TotalPesosRBA += Convert.ToDecimal(r.TotalPesosBlancoA);
                TotalPesosRNA += Convert.ToDecimal(r.TotalPesosNatural);
                TotalPesosRNE += Convert.ToDecimal(r.TotalPesosNegroSemiMate);
                TotalPesosRR += Convert.ToDecimal(r.TotalPesosReciclado);
            }

            //labels temporales
            Label labelTodosP = new Label()
            {
                Text = $" Total entre todos los remitos:  {TotalPesosR.ToString("C0", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 60),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 40,
            };
            Label labelTodosK = new Label()
            {
                Text = $" Total KG todos los remitos:  {TotalKG.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 50 * 2),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 40,
            };
            Label labelBBP = new Label()
            {
                Text = $" -------------------------------------------------------------\n Total entre todos los remitos de blanco brill. :  {TotalPesosRBB.ToString("C0", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 47 * 3),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelBBK = new Label()
            {
                Text = $" Total KG todos los remitos de blanco brill. :  {TotalKGBB.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 42 * 5),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelRP = new Label()
            {
                Text = $" -------------------------------------------------------------\n Total entre todos los remitos de reciclado:  {TotalPesosRR.ToString("C0", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 50 * 5),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelRK = new Label()
            {
                Text = $" Total KG todos los remitos de reciclado:  {TotalKGR.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 53 * 6),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelNEP = new Label()
            {
                Text = $" -------------------------------------------------------------\n Total entre todos los remitos de negro s/m:  {TotalPesosRNE.ToString("C0", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 52 * 7),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelNEK = new Label()
            {
                Text = $" Total KG todos los remitos de negro s/m:  {TotalKGNE.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 53 * 8),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelBAP = new Label()
            {
                Text = $" -------------------------------------------------------------\n Total entre todos los remitos de blanco aluar:  {TotalPesosRBA.ToString("C0", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 52 * 9),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelBAK = new Label()
            {
                Text = $" Total KG todos los remitos de blanco aluar:  {TotalKGBA.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 54 * 10),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelNP = new Label()
            {
                Text = $" -------------------------------------------------------------\n Total entre todos los remitos de natural:  {TotalPesosRNA.ToString("C0", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 53 * 11),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            Label labelNK = new Label()
            {
                Text = $" Total KG todos los remitos de natural:  {TotalKGNA.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, 54 * 12),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 580,
                Height = 50,
            };
            panelRemitos.Controls.Add(labelTodosP);
            panelRemitos.Controls.Add(labelTodosK);
            panelRemitos.Controls.Add(labelBBP);
            panelRemitos.Controls.Add(labelBBK);
            panelRemitos.Controls.Add(labelRP);
            panelRemitos.Controls.Add(labelRK);
            panelRemitos.Controls.Add(labelNEP);
            panelRemitos.Controls.Add(labelNEK);
            panelRemitos.Controls.Add(labelBAP);
            panelRemitos.Controls.Add(labelBAK);
            panelRemitos.Controls.Add(labelNP);
            panelRemitos.Controls.Add(labelNK);
        }

        private void CargarLabelsKg(SQLiteCommand cmd = null)
        {
            OpenConnection();
            decimal TotalKg = 0;
            decimal TotalKgTodos = 0;
            sql = "SELECT * FROM categorias ORDER BY CategoriaId ASC;";

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
            adapter.Fill(ds, "Categorias");

            bindingSrc = new BindingSource();
            bindingSrc.DataSource = ds.Tables["Categorias"];

            foreach (DataRowView b in bindingSrc.List)
            {
                indice = Convert.ToInt16(b[0]);

                List<Perfil> perfils = listaPerfiles.Where(p => p.CategoriaId == indice).ToList();

                foreach (Perfil p in perfils)
                {
                    string aux = p.CantidadTiras.ToString();
                    string aux2 = p.KgXTira.ToString();
                    TotalKg += Convert.ToDecimal(aux) * Convert.ToDecimal(aux2);
                }
                TotalKgTodos += TotalKg;
                Label la = new Label()
                {
                    Text = $" Total de kilos de {b[1]}:  {TotalKg.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                    Location = new Point(15, (50 * (bindingSrc.List.IndexOf(b) + 1)) + 10),
                    Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                    Width = 2000,
                    Height = 40,
                };
                panelKilos.Controls.Add(la);
                TotalKg = 0;
            }
            TotalKgTodos += TotalKg;
            Label l = new Label()
            {
                Text = $" Total de kilos entre todas las categorias:  {TotalKgTodos.ToString("#.#", CultureInfo.CreateSpecificCulture("en-US"))}",
                Location = new Point(15, (50 * (bindingSrc.List.Count + 1)) + 10),
                Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))),
                Width = 2000,
                Height = 40,
            };
            panelKilos.Controls.Add(l);
            TotalKgTodos = 0;
            CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ResetearEleccion();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("La fecha seleccionada en 'Desde' es posterior a la del 'Hasta'");
                return;
            }

            remitos = remitos.Where(re => DateTime.ParseExact(re.Fecha, "ddMMyyyy", CultureInfo.CreateSpecificCulture("fr-FR")).Date >= dateTimePicker1.Value.Date && DateTime.ParseExact(re.Fecha, "ddMMyyyy", CultureInfo.CreateSpecificCulture("fr-FR")).Date <= dateTimePicker2.Value.Date).ToList();
            CargarLabelsRemitos();
            CargarListaRemitos();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            CargarListaRemitos();
            CargarLabelsRemitos();
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
        }
    }
}
