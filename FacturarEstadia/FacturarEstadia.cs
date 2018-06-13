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

namespace FrbaHotel.FacturarEstadia
{
    public partial class FacturarEstadia : Form
    {
        List<string> idEstadias;
        List<string> idReservaHabitaciones;
        List<string> nroHabitacionValidas;

        public FacturarEstadia()
        {
            InitializeComponent();
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxHabitaciones.ToString().Trim()))
            {
                string[] nroHabitaciones = textBoxHabitaciones.ToString().Split(';');
                for (int i = 0; i < nroHabitaciones.Length; i++)
                {
                    nroHabitaciones[i] = nroHabitaciones[i].Trim();
                }

<<<<<<< HEAD
                idEstadias.Clear();
                idReservaHabitaciones.Clear();
                nroHabitacionValidas.Clear();
                int temp = 0;

                foreach (var nroHabitacion in nroHabitaciones)
=======
                /*try
>>>>>>> acc5a7f0d1c955952533f8aa17d592415d0100ec
                {
                    var idEstadia = new SqlParameter("@idEstadia", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var idReservaHabitacion = new SqlParameter("@idReservaHabitacion", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    int result = 0;
                    
                    try
                    {
                        result = DBHandler.SPWithValue("MATOTA.GetEstadiaForHabitacion",
                            new List<SqlParameter> {
                            new SqlParameter("@nroHabitacion", nroHabitacion) { Direction = ParameterDirection.Input },
                            new SqlParameter("@idHotel", Login.Login.LoggedUserSessionHotelID) { Direction = ParameterDirection.Input },
                            new SqlParameter("@fechaSistema", ConfigManager.FechaSistema.ToString("yyyy-MM-dd") ) { Direction = ParameterDirection.Input },
                            idEstadia,
                            idReservaHabitacion
                        }
                        );
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Imposible cerrar la habitación " + nroHabitacion + ". Ocurrió un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    if (string.IsNullOrEmpty(idEstadia.ToString()) || string.IsNullOrEmpty(idReservaHabitacion.ToString()))
                    {
                        MessageBox.Show("Imposible cerrar la habitación " + nroHabitacion + ". La habitación no existe en el hotel o está mal escrito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    else
                    {
                        idEstadias[temp] = idEstadia.ToString();
                        idReservaHabitaciones[temp] = idReservaHabitacion.ToString();
                        nroHabitacionValidas[temp] = nroHabitacion;
                        temp++;
                    }
                }

<<<<<<< HEAD
                if (verificarEstadia(idEstadias) != 0)
                {
                    MessageBox.Show("Las habitaciones ingresadas no son de una única estadía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    for (int i = 0; i < idEstadias.Count; i++)
                    {
                        new RegistrarConsumible.Registrar(idReservaHabitaciones[i], nroHabitacionValidas[i]);
                    }
                    new GenerarFactura(idEstadias[0], idReservaHabitaciones);
                }
=======
                }*/
>>>>>>> acc5a7f0d1c955952533f8aa17d592415d0100ec
            }
        }

        private void FacturarEstadia_Load(object sender, EventArgs e)
        {
            if (Login.Login.LoggedUserSessionHotelID == -1)
            {
                var result = new AbmHotel.Listado().ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Abort)
                {// FALLO LA OBTENCION!
                    MessageBox.Show("Fallo en la obtención de un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel) // USUARIO CERRO LA VENTANA!
                {
                    MessageBox.Show("Se ha cerrado la ventana sin seleccionar un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                    Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                    textBoxNombreHotel.Text = DBHandler.Query(nombreHotel.Build()).ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al agregar el nombre del hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int verificarEstadia(List<string> estadias)
        {
            var idEstadia = estadias[0];
            foreach (var estadia in estadias)
            {
                if (!idEstadia.Equals(estadia))
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}
