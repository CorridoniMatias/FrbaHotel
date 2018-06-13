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
            //if (comboBoxTipo.SelectedIndex >= 0 && comboBoxTipo.SelectedIndex <= 2)
            //{
            //    new ListadoEstadisticoHotel(comboBoxTrimestre.SelectedIndex + 1, dateTimePickerAño.Value.Year, comboBoxTipo.SelectedIndex).Show(this);
            //}

            switch (comboBoxTipo.SelectedIndex)
            {
                case 3:
                    new ListadoEstadisticoHabitacion(comboBoxTrimestre.SelectedIndex + 1, dateTimePickerAño.Value.Year).Show(this);
                    break;
                case 4:
                    new ListadoEstadisticoCliente(comboBoxTrimestre.SelectedIndex + 1, dateTimePickerAño.Value.Year).Show(this);
                    break;
                default:
                    new ListadoEstadisticoHotel(comboBoxTrimestre.SelectedIndex + 1, dateTimePickerAño.Value.Year, comboBoxTipo.SelectedIndex).Show(this);
                    break;
            }
            
        }
    }
}
