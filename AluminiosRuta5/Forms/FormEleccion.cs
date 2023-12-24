using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            f.GetCambiarForm();
        }
    }
}
