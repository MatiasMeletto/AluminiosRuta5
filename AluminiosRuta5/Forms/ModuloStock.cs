using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public class ModuloStock
    {
        public static List<Button> CargarCategorias(BindingSource binding)
        {
            List<Button> list = new List<Button>();
            foreach (DataRowView b in binding.List)
            {
                Button button = new Button
                {
                    Width = 180,
                    Height = 50,
                    Location = new Point(0, 50 * list.Count()),
                    FlatStyle = FlatStyle.Popup,
                    BackColor = Color.FromArgb(29, 39, 57),
                    ForeColor = Color.Aqua,
                    Text = b[1].ToString(),
                    Name = "Boton" + b[1].ToString()
                };
                button.FlatAppearance.BorderSize = 1;
                button.BringToFront();
                button.Show();
                list.Add(button);
            }
            return list;
        }
        public static void ListaLabels(List<Label> lista, Perfil perfil, int cantidadTiras)
        {
            string auxKgXTira = perfil.KgXTira.Replace(".", ",");
            string auximporte = perfil.Import;
            Label label = new Label
            {
                Tag = perfil.PerfilId,
                Name = lista.Count().ToString(),
                Text = $"* {perfil.Codigo} --- {perfil.Descripcion} ---  KG: {Convert.ToDecimal(auxKgXTira) * cantidadTiras} ---  $ por kilo: {auximporte} --- total $: {(Convert.ToDecimal(auxKgXTira) * cantidadTiras * Convert.ToDecimal(auximporte)).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))} ---  x{cantidadTiras}",
                Location = new Point(0, 30 * lista.Count()),
                Font = new Font("Microsoft JhengHei UI", 13),
                AutoSize = true
            };
            label.BringToFront();
            label.Show();
            lista.Add(label);
        }
        public static List<Perfil> CargarPerfiles(BindingSource binding)
        {
            List<Perfil> list = new List<Perfil>();
            foreach (DataRowView b in binding.List)
            {
                Perfil perfil = new Perfil
                {
                    PerfilId = Convert.ToInt16(b[0]),
                    Codigo = b[1].ToString(),
                    Descripcion = b[2].ToString(),
                    CantidadTiras = Convert.ToInt16(b[3]),
                    KgXPaquete = b[4].ToString(),
                    KgXTira = b[5].ToString(),
                    CategoriaId = Convert.ToInt16(b[6]),
                };
                list.Add(perfil);
            }
            return list;
        }
    }
}
