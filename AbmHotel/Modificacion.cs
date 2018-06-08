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

        private void buttonSave_Click(object sender, EventArgs e)
        {

            var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.UPDATE).Table("MATOTA.Hotel");


            var fields = String.Join(",",
                            new List<TextBox> { textBoxCalle, textBoxCantEstrellas, textBoxCiudad, textBoxMail, textBoxNombre, textBoxNroCalle, textBoxTelefono }
                                .FindAll(f => !string.IsNullOrEmpty(f.Text.Trim()))
                                .Select(f => f.Tag + "='" + f.Text.Trim() + "'")
                                .Union(new List<string> { dateTimePickerCreado.Tag + "='" +dateTimePickerCreado.Value.ToString("yyyy-MM-dd") + "'" }));

            builder.Fields(fields)
                    .AddEquals("idHotel", idHotel);

            var rows = DBHandler.QueryRowCount(builder.Build());

            if (rows == 0)
                MessageBox.Show("Error al actualizar hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show("Hotel actualizado con éxito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
