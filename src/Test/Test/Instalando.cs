using IWshRuntimeLibrary;
using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Test
{
    public partial class Instalando : Form
    {
        private const bool V = true;

        public Instalando()
        {
            InitializeComponent();
            button1.Enabled = false;
            ExtraerZipYCrearAccesoDirecto();
            this.Load += async (sender, e) => await SimularInstalacionAsync();

        }
        private void ExtraerZipYCrearAccesoDirecto()
        {
            string extractPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Microsoft\\KeePass-2.58"
            );

            try
            {
                // Crear carpeta destino si no existe
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                // Nombre del recurso embebido: revisa con GetManifestResourceNames()
                string resourceName = "Test.KeePass-2.58.zip"; // Asegúrate de que es correcto

                using (Stream zipStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (zipStream == null)
                    {
                        MessageBox.Show("Recurso ZIP no encontrado. Revisa el nombre embebido.");
                        return;
                    }

                    string tempZipPath = Path.Combine(Path.GetTempPath(), "keeptemp.zip");

                    using (FileStream fs = new FileStream(tempZipPath, FileMode.Create, FileAccess.Write))
                    {
                        zipStream.CopyTo(fs);
                    }

                    if (Directory.Exists(extractPath))
                    {
                        // Opcional: limpiar contenido anterior
                        Directory.Delete(extractPath, true);
                        Directory.CreateDirectory(extractPath);
                    }

                    ZipFile.ExtractToDirectory(tempZipPath, extractPath);

                    System.IO.File.Delete(tempZipPath);
                }

                // Crear shortcut
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string shortcutPath = Path.Combine(desktopPath, "KeePass.lnk");
                string targetExe = Path.Combine(extractPath, "KeePass.exe");

                CreateShortcut(shortcutPath, targetExe, "KeePass Portable");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en extracción o creación de acceso directo: " + ex.Message);
            }
        }


        private void CreateShortcut(string shortcutPath, string targetPath, string description)
        {
            var shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.Description = description;
            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            shortcut.Save();
        }





        private async Task SimularInstalacionAsync()
        {
            var pasos = new[]
            {
                new { Texto = "Inicializando la instalación...", Porcentaje = 10, Delay = 200 },
                new { Texto = "Copiando archivos en C:\\Program Files\\KeePass Password Safe 2...", Porcentaje = 30, Delay = 500 },
                new { Texto = "Configurando componentes...", Porcentaje = 20, Delay = 300 },
                new { Texto = "Optimizando el rendimiento de KeePass Password Safe...", Porcentaje = 25, Delay = 800 },
                new { Texto = "Finalizando la instalación...", Porcentaje = 15, Delay = 100 }
            };

            int progresoActual = 0;

            foreach (var paso in pasos)
            {
                label3.Text = paso.Texto;

                // Avanzar progreso gradualmente dentro del paso
                for (int i = 0; i < paso.Porcentaje; i++)
                {
                    progresoActual++;
                    progressBar1.Value = progresoActual;
                    await Task.Delay(paso.Delay / paso.Porcentaje); // Divide el delay para animación suave
                }
            }
            // Esperar 2 segundos
            await Task.Delay(4000);
            Finalizada finalizada = new Finalizada();
            finalizada.Show();
            this.Hide();
        }





        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Instalando_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            SalirInstalacion salir = new SalirInstalacion();
            salir.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Instalando_Load(object sender, EventArgs e)
        {

        }
    }
}
