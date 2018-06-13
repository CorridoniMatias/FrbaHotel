using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.FacturarEstadia
{
    public partial class GenerarFactura : Form
    {
        string idEstadia;
        List<string> idReservaHabitaciones;

        public GenerarFactura(string idEstadia, List<string> idReservaHabitaciones)
        {
            this.idEstadia = idEstadia;
            this.idReservaHabitaciones = idReservaHabitaciones;
            InitializeComponent();
        }
    }
}
