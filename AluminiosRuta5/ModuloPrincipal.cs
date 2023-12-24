using System;
using System.Collections.Generic;
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
            form.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.BringToFront();
            form.Show();
            return form;
        }
        public static void CambiarDeForm(Form form)
        {
            form.Close();
        }
    }
}
