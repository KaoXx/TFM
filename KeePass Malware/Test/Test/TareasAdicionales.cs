using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class TareasAdicionales : Form
    {
        public TareasAdicionales()
        {
            InitializeComponent();
            button2.Select();
        }

        private void TareasAdicionales_Load(object sender, EventArgs e)
        {

        }

        private void TareasAdicionales_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            SalirInstalacion salir = new SalirInstalacion();
            salir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Form formularioAnterior = Application.OpenForms["SeleccionComponentes"];
            formularioAnterior?.Show(); // Muestra el formulario anterior si existe
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListoInstalar listoInstalar = new ListoInstalar();
            listoInstalar.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalirInstalacion salirInstalacion = new SalirInstalacion();
            salirInstalacion.Show();
        }
    }
}
