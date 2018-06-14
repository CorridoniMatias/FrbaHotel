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
        private PobladorFacturas poblador;
        private string idEstadia;
        private List<string> idReservaHabitaciones;

        public GenerarFactura(string idEstadia, List<string> idReservaHabitaciones)
        {
            this.idEstadia = idEstadia;
            this.idReservaHabitaciones = idReservaHabitaciones;
            InitializeComponent();
        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {
            FormHandler.listarFormaDePago(comboBoxFormaDePago);
            comboBoxFormaDePago.SelectedIndex = -1;
            poblador = new PobladorFacturas(dataGridView1, idEstadia, idReservaHabitaciones);
            poblador.Poblar();
            textBoxTotal.Text = poblador.getPrecioE().ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxFormaDePago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
