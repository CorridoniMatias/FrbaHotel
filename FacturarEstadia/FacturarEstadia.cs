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
    public partial class FacturarEstadia : Form
    {

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

                /*try
                {

                }*/
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
    }
}
