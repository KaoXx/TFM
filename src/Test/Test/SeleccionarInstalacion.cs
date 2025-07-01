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
    public partial class SeleccionarInstalacion : Form
    {
        public SeleccionarInstalacion()
        {
            InitializeComponent();
            button2.Select();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalirInstalacion salirInstalacion = new SalirInstalacion();
            salirInstalacion.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Form formularioAnterior = Application.OpenForms["Licencia"];
            formularioAnterior?.Show(); // Muestra el formulario anterior si existe
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeleccionComponentes se = new SeleccionComponentes();
            se.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona la carpeta de destino";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void SeleccionarInstalacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            SalirInstalacion salir = new SalirInstalacion();
            salir.Show();
        }

        private void SeleccionarInstalacion_Load(object sender, EventArgs e)
        {

        }
    }
}
