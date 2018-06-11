using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class SelectCantidad : Form
    {

        public int CantidadElegida { get; private set; }

        public SelectCantidad(Consumible consumible, int cantidadSeleccionada = 0)
        {
            InitializeComponent();

            textBoxConsumible.Text = consumible.descripcion;
            textBoxPrecio.Text = consumible.precio;

            if (cantidadSeleccionada > 0)
                numericUpDownCantidad.Value = cantidadSeleccionada;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            this.CantidadElegida = Convert.ToInt32(numericUpDownCantidad.Value);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


    }
}
