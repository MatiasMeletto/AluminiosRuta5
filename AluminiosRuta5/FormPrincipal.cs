using AluminiosRuta5.Forms;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AluminiosRuta5
{
    public partial class FormPrincipal : Form
    {
        private FormEleccion formElec = null;
        public void CambiarForm(Form f,Form form)
        {
            f.Close();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(form);
            panelPrincipal.Tag = form;
            form.BringToFront();
            form.Show();
        }
        public void GetCambiarFormStock()
        {
            CambiarForm(formElec, new FormStock(this));
        }
        public void GetCambiarFormPresupuesto()
        {
            CambiarForm(formElec, new FormPresupuesto(this));
        }
        public void GetCambiarFormRemito()
        {
            CambiarForm(formElec, new FormRemito(this));
        }
        public FormPrincipal()
        {
            InitializeComponent();
            ResetearEleccion();
        }

        public void ResetearEleccion()
        {
            FormEleccion formEleccion = new FormEleccion(this);
            formEleccion.TopLevel = false;
            formEleccion.FormBorderStyle = FormBorderStyle.None;
            formEleccion.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(formEleccion);
            panelPrincipal.Tag = formEleccion;
            formEleccion.BringToFront();
            formEleccion.Show();
            formElec = formEleccion;
        }

        internal void ResetForm()
        {
            CambiarForm(formElec, new FormStock(this));
        }

        internal void GetCambiarFormEstadisticas()
        {
            CambiarForm(formElec, new FormEstadisticas(this));
        }
    }
}
