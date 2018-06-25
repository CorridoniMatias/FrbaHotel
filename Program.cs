using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.AbmCliente;
using System.Configuration;
namespace FrbaHotel
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                ConfigManager.ReadConfig();
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error al leer el archivo de configuracion.\n\n" + e.Message + "\n\nUtilice la opc. Configurar para cargar una nueva config.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Application.Run(new Form1());
            //Application.Run(new RegistrarConsumible.Registrar("99403", "2", true));

        }
    }
}
