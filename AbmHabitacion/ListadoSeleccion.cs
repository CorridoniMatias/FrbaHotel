using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class ListadoSeleccion : Form
    {
        public Habitacion SelectedHab { get; private set; }

        public ListadoSeleccion()
        {
            InitializeComponent();
        }

        private PobladorHabitacion poblador;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                this.SelectedHab = new Habitacion()
                {
                    idHotel = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    nroHabitacion = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    piso = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    idUbicacion = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    idTipoHabitacion = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(),
                    descripcion = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(),
                    comodidades = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(),
                    habilitado = (bool)dataGridView1.Rows[e.RowIndex].Cells[8].Value
                };

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            poblador.Poblar();
        }

        private void ListadoSeleccion_Load(object sender, EventArgs e)
        {
            FormHandler.listarHoteles(comboBoxHotel);
            comboBoxHotel.SelectedIndex = -1;
            FormHandler.listarTipoUbicacion(comboBoxUbicacion);
            comboBoxUbicacion.SelectedIndex = -1;
            FormHandler.listarTipoHabitacion(comboBoxHabitacion);
            comboBoxHabitacion.SelectedIndex = -1;
            poblador = new PobladorHabitacion(new List<TextBox>() { textBoxNroHabitacion, textBoxPiso, textBoxcomodidades, textBoxDescripcion },
                new List<ComboBox>() { comboBoxHotel, comboBoxUbicacion, comboBoxHabitacion }, dataGridView1, new List<string> { "Seleccionar" });
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }
    }
}
