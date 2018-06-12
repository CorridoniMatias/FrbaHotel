using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class Listado : Form
    {
        private PobladorReservas poblador;
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            FormHandler.listarHoteles(comboBoxHotel);
            comboBoxHotel.SelectedIndex = -1;
            FormHandler.listarRegimenes(comboBoxRegimen);
            comboBoxRegimen.SelectedIndex = -1;
            poblador = new PobladorReservas(textBoxIdReserva, comboBoxHotel, comboBoxRegimen, dataGridView1, new List<string> { "Modificar", "Cancelar" });
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            poblador.Poblar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            /*if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Modificar"))
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
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("ColumnSuspender"))
                {
                    new Suspender(
                        senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString()
                    ).ShowDialog(this);
                }
            }*/
        }
    }
}
