using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class Modificacion : Form
    {
        private string idHotel;
        private string numHabitacion;
        public Modificacion(string idHotel, string numHabitacion)
        {
            this.idHotel = idHotel;
            this.numHabitacion = numHabitacion;
            InitializeComponent();
        }
    }
}
