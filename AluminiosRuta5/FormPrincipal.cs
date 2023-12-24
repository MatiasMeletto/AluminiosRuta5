using AluminiosRuta5.Forms;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AluminiosRuta5
{
    public partial class FormPrincipal : Form
    {
        FormStock formStock = new FormStock();
        public void CambiarForm(Form f)
        {
            f.SuspendLayout();
            formStock.TopLevel = false;
            formStock.FormBorderStyle = FormBorderStyle.None;
            formStock.Dock = DockStyle.Fill;
            formStock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelPrincipal.Controls.Add(formStock);
            panelPrincipal.Tag = formStock;
            formStock.BringToFront();
            formStock.Show();
        }
        public void GetCambiarForm()
        {
            CambiarForm(f: panelPrincipal.FindForm());
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
