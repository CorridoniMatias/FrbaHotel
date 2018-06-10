using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class ComprobadorReserva : Form
    {
        public ComprobadorReserva()
        {
            InitializeComponent();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReserva.Text))
            {
                MessageBox.Show("Por favor ingrese el numero de reserva a verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ret = DBHandler.SPWithBool("MATOTA.ReservaEsValida",
                new List<SqlParameter> { 
                    new SqlParameter("@idReserva", textBoxReserva.Text.Trim()),
                    new SqlParameter("@idHotel", Login.Login.LoggedUserSessionHotelID),
                    new SqlParameter("@fechaSistema", "2017-01-01") //ConfigManager.FechaSistema.ToString("yyyy-MM-dd")
                }
                );

            if (!ret)
            {
                MessageBox.Show("La reserva ingresada no es valida para hacer check-in en este momento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxReserva.Text = string.Empty;
                return;
            }

            this.Hide();
            new AltaEstadia(textBoxReserva.Text.Trim()).ShowDialog(this);
            this.Close();
        }

        private void ComprobadorReserva_Load(object sender, EventArgs e)
        {
            if(Login.Login.LoggedUserSessionHotelID == -1)
                if (new AbmHotel.Listado().ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Debe seleccionar el hotel donde se encuentra trabajando para continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
        }
    }
}
