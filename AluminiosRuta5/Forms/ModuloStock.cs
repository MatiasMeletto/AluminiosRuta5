using AluminiosRuta5.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                    Location = new Point(0, 50 * Convert.ToInt16(b[0].ToString())),
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
    }
}
