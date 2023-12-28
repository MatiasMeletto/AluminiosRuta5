using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluminiosRuta5
{
    public class ModuloPrincipal
    {
        public static Form AbrirFormularioHijo(Panel panel, Form formAct, Form form)
        {
            if (formAct != null)
                formAct.Close();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.BringToFront();
            form.Show();
            return form;
        }

        internal static Button CambioColor(Button act, Button button, bool seleccionado)
        {
            if (seleccionado)
            {
                button.BackColor = Color.FromArgb(39,49,67);
                return button;
            }
            else
                button.BackColor = Color.FromArgb(29, 39, 57);
            return act;
        }

        internal static Button PreAbrir(Panel panelNav, Button act, Button btn)
        {
            panelNav.Height = btn.Height;
            panelNav.Location = new Point(btn.Location.X, btn.Location.Y + 60);
            return CambioColor(act, btn, true);
        }
    }
}
