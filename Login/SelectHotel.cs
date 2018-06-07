using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class SelectHotel : Form
    {
        public SelectHotel()
        {
            InitializeComponent();
        }

        private void SelectHotel_Load(object sender, EventArgs e)
        {
            var hotels = DBHandler.Query("SELECT h.idHotel, nombre, calle, nroCalle, ciudad FROM MATOTA.Hotel h" +
                                " INNER JOIN MATOTA.HotelesUsuario hu ON hu.idHotel = h.idHotel "+
                                "WHERE hu.idUsuario = " + Login.LoggedUsedID);

            hotels.ForEach(hotel => {
                dataGridViewHotels.Rows.Add(new object[] { hotel["idHotel"], hotel["nombre"], hotel["calle"], hotel["nroCalle"], hotel["ciudad"] });
            });
        }
    }
}
