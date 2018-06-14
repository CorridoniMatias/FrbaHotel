using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class Listado : Form
    {
        private PobladorUsuarios poblador;
        private AbmHotel.Hotel hotel;
        private int idHotelAdmin;

        public Listado(int hotelAdmin, AbmHotel.Hotel hotel = null)
        {
            this.idHotelAdmin = hotelAdmin;
            this.hotel = hotel;
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            FormHandler.listarRoles(comboBoxRol);
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
            poblador = new PobladorUsuarios(new List<TextBox> { textBoxUsername, textBoxNombre, textBoxApellido, textBoxMail, textBoxNumDoc }, new List<ComboBox> { comboBoxRol, comboBoxTipoDoc }, checkBoxHabilitado, dataGridViewUsuarios, new List<String> { "Modificar", "Eliminar" });

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxFiltros);

            textBoxHotel.Text = "";
            hotel = null;

            dataGridViewUsuarios.Rows.Clear();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridViewUsuarios.Rows.Clear();

            poblador.Poblar(hotel);
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Modificar"))
                {
                    if (idHotelAdmin.ToString() == senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString() || String.IsNullOrEmpty(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()))
                        new Modificacion(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()).ShowDialog(this);
                    else
                    {
                        MessageBox.Show("No podes modificar un usuario de un hotel en el que no estas loggeado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Eliminar"))
                {
                    try
                    {
                        if (idHotelAdmin.ToString() == senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString() || String.IsNullOrEmpty(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()))
                            DBHandler.Query("UPDATE MATOTA.Usuario SET habilitado=0 WHERE idUsuario =" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                        else
                        {
                            MessageBox.Show("No podes eliminar un usuario de un hotel en el que no estas loggeado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                dataGridViewUsuarios.Rows.Clear();
                poblador.Poblar();
            }
        }

        private void buttonBuscarHotel_Click(object sender, EventArgs e)
        {
            var selector = new AbmHotel.Listado(false);

            if (selector.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                hotel = selector.SelectedHotel;
                textBoxHotel.Text = hotel.idHotel;

            }
        }
    }
}
