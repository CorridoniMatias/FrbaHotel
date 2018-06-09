using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class Suspender : Form
    {

        private string idHotel, nombreHotel;

        public Suspender(string idHotel, string nombreHotel)
        {
            InitializeComponent();
            this.idHotel = idHotel;
            this.nombreHotel = nombreHotel;

            this.groupBoxInactividad.Text += " " + this.nombreHotel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMotivo.Text.Trim()))
            {
                MessageBox.Show("Debe especificar el motivo de inactividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerDesde.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("No se puede suspender el hotel en una fecha pasada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerHasta.Value.Date < DateTime.Now.Date || dateTimePickerHasta.Value.Date < dateTimePickerDesde.Value.Date)
            {
                MessageBox.Show("No se puede finalizar la inactividad antes de que comience.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }


    }
}
