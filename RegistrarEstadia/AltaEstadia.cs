using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class AltaEstadia : Form
    {
        private string idReserva;

        public AltaEstadia(string idReserva)
        {
            InitializeComponent();
            this.idReserva = idReserva;
            this.textBoxReserva.Text = idReserva;
        }

        private void AltaEstadia_Load(object sender, EventArgs e)
        {

        }
    }
}
