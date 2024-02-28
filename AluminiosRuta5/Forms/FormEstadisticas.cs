using AluminiosRuta5.Objects;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
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
            CargarPerfiles();
            CargarLabels();
        }

        private void CargarLabels(SQLiteCommand cmd = null)
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
                    TotalKg += Convert.ToDecimal(p.CantidadTiras) * Convert.ToDecimal(p.KgXTira);
                }
                TotalKgTodos += TotalKg;
                Label la = new Label()
                {
                    Text = $" Total de kilos de {b[1].ToString()}:  {TotalKg}",
                    Location = new Point(15, (47 * (bindingSrc.List.IndexOf(b) + 1))+10),
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
                Text = $" Total de kilos entre todas las categorias:  {TotalKgTodos}",
                Location = new Point(15, (47 * (bindingSrc.List.Count+1))+10),
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

    }
}
