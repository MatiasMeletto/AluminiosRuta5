using AluminiosRuta5.Forms;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AluminiosRuta5
{
    public partial class FormPrincipal : Form
    {
        public void CambiarForm(Form f,Form form)
        {
            f.SuspendLayout();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelPrincipal.Controls.Add(form);
            panelPrincipal.Tag = form;
            form.BringToFront();
            form.Show();
        }
        public void GetCambiarForm()
        {
            CambiarForm(f: panelPrincipal.FindForm(), new FormStock());
        }
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ModuloPrincipal.AbrirFormularioHijo(panelPrincipal, new FormEleccion(this), new FormEleccion(this));
        }

    }
}
