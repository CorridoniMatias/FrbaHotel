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
    public partial class Modificacion : Form
    {
        private string idHotel;

        public Modificacion(string idHotel, string nombre, string mail, string tel, string cantEstrellas, string fechaCreacion, string calle, string nrocalle, string ciudad, string pais)
        {
            InitializeComponent();
            this.idHotel = idHotel;
            this.textBoxCalle.Text = calle;
            this.textBoxCantEstrellas.Text = cantEstrellas;
            this.textBoxCiudad.Text = ciudad;
            this.textBoxMail.Text = mail;
            this.textBoxNombre.Text = nombre;
            this.textBoxNroCalle.Text = nrocalle;
            this.textBoxPais.Text = pais;
            this.textBoxTelefono.Text = tel;
            if(!string.IsNullOrEmpty(fechaCreacion))
                this.dateTimePickerCreado.Value = DateTime.Parse(fechaCreacion);
        }
    }
}
