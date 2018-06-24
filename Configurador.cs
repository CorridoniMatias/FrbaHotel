using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Configurador : Form
    {
        public Configurador()
        {
            InitializeComponent();
        }

        private void buttonSelect_Click(object sender, EventArgs ev)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Title = "Seleccione archivo de configuración";
            openFileDialog.Filter = "Archivos de config. (*.config)|*.config";
            openFileDialog.CheckFileExists = true;

            openFileDialog.ShowDialog();

            textBoxConfigPath.Text = openFileDialog.FileName;
            ConfigManager.ConfigFile = textBoxConfigPath.Text;
            try
            {

                ConfigManager.ReadConfig();
                UpdateValues();
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error al leer el archivo de configuracion.\n\n" + e.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Configurador_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Configurador_Load(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void UpdateValues()
        {
            textBoxConfigPath.Text = ConfigManager.ConfigFile;
            textBoxHora.Text = ConfigManager.FechaSistema.ToString("yyyy-MM-dd");
            textBoxServer.Text = ConfigManager.SQLServer;
            textBoxDB.Text = ConfigManager.SQLDatabase;
            textBoxUser.Text = ConfigManager.SQLUsername;
            textBoxPassword.Text = ConfigManager.SQLPassword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
