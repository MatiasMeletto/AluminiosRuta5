using System;
using System.Windows.Forms;

namespace AluminiosRuta5.Forms
{
    public partial class FormEleccion : Form
    {
        private FormPrincipal f;

        public FormEleccion(FormPrincipal form)
        {
            InitializeComponent();
            f = form;
        }

        private void FormEleccion_Load(object sender, EventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            f.GetCambiarFormStock();
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            f.GetCambiarFormPresupuesto();
        }
    }
}
