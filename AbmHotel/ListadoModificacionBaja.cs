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
            poblador = new PobladorHoteles(new List<TextBox>() { textBoxCantEstrellas, textBoxCiudad, textBoxNombre, textBoxPais, textBoxMail, textBoxTelefono, textBoxCalle, textBoxNroCalle }, dataGridView1, new List<string> { "Modificar", "Eliminar" }, dateTimePickerFilter);
            poblador.Poblar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("ColumnModificar"))
                {
                    if (new Modificacion(
                            senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[9].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[7].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[8].Value.ToString()
                        ).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        Reload();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("ColumnModificar"))
                {

                }
            }
        }

        private void Reload()
        {
            dataGridView1.Rows.Clear();
            poblador.Poblar();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Reload();
        }

    }
}
