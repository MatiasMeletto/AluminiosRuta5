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

        private void btnStock_Click(object sender, EventArgs e)
        {
            f.GetCambiarFormStock();
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            f.GetCambiarFormPresupuesto();
        }

        private void btnRemitos_Click(object sender, EventArgs e)
        {
            f.GetCambiarFormRemito();
        }

        private void buttonEstadisticas_Click(object sender, EventArgs e)
        {
            f.GetCambiarFormEstadisticas();
        }
    }
}
