using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class SeleccionadorConsumible : Form
    {
        private PobladorConsumibles poblador;

        public Consumible ConsumibleSeleccionado { get; private set; }

        public SeleccionadorConsumible()
        {
            InitializeComponent();
            ConsumibleSeleccionado = null;
        }

        private void SeleccionadorConsumible_Load(object sender, EventArgs e)
        {
            poblador = new PobladorConsumibles(new List<TextBox>() { textBoxDesc }, dataGridView1, new List<string> { "Seleccionar" });
            poblador.Poblar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ConsumibleSeleccionado = new Consumible { 
                    codigoConsumible = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    descripcion = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    precio = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()
                };

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            poblador.Poblar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this.groupBox1);
        }
    }
}
