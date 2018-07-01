using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.ListadoEstadistico
{
    public partial class SeleccionarListado : Form
    {
        private bool hayError = false;
        public SeleccionarListado()
        {
            InitializeComponent();
            FormHandler.limpiar(groupBoxListado);

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxListado);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            hayError = false;
            if (comboBoxTrimestre.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un trimestre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hayError = true;
            }
            if (comboBoxTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de listado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hayError = true;
            }
            if (hayError)
            {
                return;
            }
            switch (comboBoxTipo.SelectedIndex)
            {
                case 3:
                    new ListadoEstadisticoHabitacion(comboBoxTrimestre.SelectedIndex + 1, dateTimePickerAño.Value.Year).ShowDialog(this);
                    break;
                case 4:
                    new ListadoEstadisticoCliente(comboBoxTrimestre.SelectedIndex + 1, dateTimePickerAño.Value.Year).ShowDialog(this);
                    break;
                default:
                    new ListadoEstadisticoHotel(comboBoxTrimestre.SelectedIndex + 1, dateTimePickerAño.Value.Year, comboBoxTipo.SelectedIndex).ShowDialog(this);
                    break;
            }
            
        }
    }
}
