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
    public partial class Licencia : Form
    {
        public Licencia()
        {
            InitializeComponent();
            textBox1.SelectionLength = 0;
        }

        private void Licencia_Load(object sender, EventArgs e)
        {
            this.ActiveControl = siguiente;
        }
        private void Licencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            siguiente.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            siguiente.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalirInstalacion salirInstalacion = new SalirInstalacion();
            salirInstalacion.Show();
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            SeleccionarInstalacion se = new SeleccionarInstalacion();
            se.Show();
            this.Hide();
        }

        private void Licencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            SalirInstalacion salir = new SalirInstalacion();
            salir.Show();

        }
    }
}
