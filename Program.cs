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
                MessageBox.Show("Hubo un error al leer el archivo de configuracion.\n" + e.Message + "\nImposible ejecutar el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Application.Run(new RegistrarConsumible.SelectCantidad(new RegistrarConsumible.Consumible { descripcion = "1", precio = "2" }));
            Application.Run(new Form1());
            //Application.Run(new GenerarModificacionReserva.Listado());

            //Application.Run(new RegistrarConsumible.Registrar("96946", "12"));
            //Application.Run(new ListadoEstadistico.SeleccionarListado());
            //Application.Run(new AbmCliente.Listado());
            //Application.Run(new GenerarModificacionReserva.Modificacion("106945","1","2018-06-10","2018-06-11","1","5",new List<string>{"0","2"}));
        }
    }
}
