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

            int ret = 0;
            var fechaInicioReserva = new SqlParameter("@fechaInicio", SqlDbType.Date) { Direction = ParameterDirection.Output };
                var hotelDeLaReserva = new SqlParameter("@hotelReserva", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                var inhabilitadoHasta = new SqlParameter("@inhabilitadoHasta", SqlDbType.Date) { Direction = ParameterDirection.Output };
            try
            {
                

                ret = DBHandler.SPWithValue("MATOTA.ReservaEsValidaCheckIn",
                                    new List<SqlParameter> { 
                                            new SqlParameter("@idReserva", textBoxReserva.Text.Trim()),
                                            new SqlParameter("@idHotel", Login.Login.LoggedUserSessionHotelID),
                                            new SqlParameter("@fechaSistema", ConfigManager.FechaSistema.ToString("yyyy-MM-dd")),
                                            fechaInicioReserva,
                                            hotelDeLaReserva,
                                            inhabilitadoHasta
                                        }
                );
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar verificar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (ret)
            {
                case 1:
                    this.Hide();
                    new AltaEstadia(textBoxReserva.Text.Trim()).ShowDialog(this);
                    this.Close();
                break;
                case -1:
                    MostrarError("El hotel en el cual se encuentra radicada la reserva está inhabilitado hasta " + inhabilitadoHasta.Value);
                    return;
                case -2:
                    MostrarError("La reserva ingresada no fue encontrada en el sistema.");
                    return;
                case -3:
                    MostrarError("La reserva tiene fecha de inicio " + fechaInicioReserva.Value.ToString().Split(' ')[0] + " y la fecha del sistema es " + ConfigManager.FechaSistema.ToString().Split(' ')[0] + "\n\nSolo se puece hacer check-in el dia de inicio de la reserva.");
                    return;
                case -4:
                    MostrarError("La reserva ingresada esta radicada en el hotel " + hotelDeLaReserva.Value + ", que no es el mismo en el cual usted se encuentra trabajando.");
                    return;
                case -5:
                    MostrarError("La reserva que intenta efectivizar ya fue efectivizada.");
                    return;
                default:
                    MostrarError("Ocurrio un error inesperado al hacer el check-in.");
                    return;
            }
        }

        private void MostrarError(string msg)
        {
            MessageBox.Show("No se puede hacer check-in en este momento.\n\n"+msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBoxReserva.Text = string.Empty;
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
