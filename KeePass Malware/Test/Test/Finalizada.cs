using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Test
{
    public partial class Finalizada : Form
    {
        public Finalizada()
        {
            InitializeComponent();
            button1.Select();
        }

        private void Finalizada_Load(object sender, EventArgs e)
        {

        }

        private void Finalizada_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "KeePass.lnk");
                    if (File.Exists(shortcutPath))
                    {
                        Process.Start(shortcutPath);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el acceso directo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar el acceso directo: " + ex.Message);


                }

                Environment.Exit(0);
            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
