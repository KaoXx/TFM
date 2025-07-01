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
    public partial class SeleccionComponentes : Form
    {

        private Dictionary<CheckBox, double> componentes = new Dictionary<CheckBox, double>();
        public SeleccionComponentes()
        {
            InitializeComponent();
            button2.Select();
            componentes.Add(checkBox1, 7.0);
            componentes.Add(checkBox2, 0.8);
            componentes.Add(checkBox3, 1.4);
            componentes.Add(checkBox4, 0.1);
            componentes.Add(checkBox5, 8.0);
            componentes.Add(checkBox6, 0.1);
            comboBox1.SelectedIndex = 0;

            foreach (var cb in componentes.Keys)
            {
                cb.CheckedChanged += ActualizarEspacioRequerido;
            }
        }
        private void ActualizarEspacioRequerido(object sender, EventArgs e)
        {
            double totalMB = 0;
            foreach (var item in componentes)
            {
                if (item.Key.Checked) totalMB += item.Value;
                //comboBox1.SelectedIndex = 2;
            }
            label4.Text = $"La selección actual requiere almenos {totalMB} MB de espacio en disco.";
        }
        private void checkBoxCompleta_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = false;
            foreach (var cb in componentes.Keys) cb.Checked = isChecked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) // "Seleccionar todos"
            {
                foreach (var cb in componentes.Keys)
                {
                    cb.Checked = true; // Marcar todos los CheckBox
                    cb.Enabled = false;

                }
            }
            else if (comboBox1.SelectedIndex == 1) // "Solo el primero"
            {
                // Desmarcar todos primero
                foreach (var cb in componentes.Keys)
                {
                    cb.Checked = false;
                }

                // Marcar solo el primer CheckBox (checkBox1)
                if (componentes.Count > 0)
                {
                    componentes.Keys.First().Checked = true; // Primero en el Dictionary
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                foreach (var cb in componentes.Keys)
                {
                    cb.Enabled = true;
                }
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SeleccionComponentes_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void SeleccionComponentes_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            SalirInstalacion salir = new SalirInstalacion();
            salir.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalirInstalacion salirInstalacion = new SalirInstalacion();
            salirInstalacion.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Form formularioAnterior = Application.OpenForms["SeleccionarInstalacion"];
            formularioAnterior?.Show(); // Muestra el formulario anterior si existe
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TareasAdicionales tareasAdicionales = new TareasAdicionales();
            tareasAdicionales.Show();
            this.Hide();
        }
    }


}
