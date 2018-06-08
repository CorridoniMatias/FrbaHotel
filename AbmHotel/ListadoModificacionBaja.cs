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
    public partial class ListadoModificacionBaja : Form
    {
        private PobladorHoteles poblador;

        public ListadoModificacionBaja()
        {
            InitializeComponent();
        }

        private void ListadoModificacionBaja_Load(object sender, EventArgs e)
        {
            poblador = new PobladorHoteles(new List<TextBox>() { textBoxCantEstrellas, textBoxCiudad, textBoxNombre, textBoxPais, textBoxMail, textBoxTelefono }, dataGridView1, new List<string> { "Modificar", "Eliminar" });
            poblador.Filtro
            .AddJoin("INNER JOIN MATOTA.HotelesUsuario hu ON h.idHotel = hu.idHotel")
            .AddEquals("hu.idUsuario", Login.Login.LoggedUsedID.ToString());
            poblador.Poblar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Modificar"))
                {
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Eliminar"))
                {
                }

                try
                {
                    Login.Login.LoggedUserSessionHotelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                }
                catch (Exception)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    MessageBox.Show("Error al seleccionar hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            poblador.Poblar();
        }
    }
}
