using AluminiosRuta5.Forms;
using System;
using System.Windows.Forms;

namespace AluminiosRuta5
{
    public partial class FormPrincipal : Form
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
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormularioHijo(panelPrincipal,new FormEleccion(),new FormEleccion());
        }
    }
}
