using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class ListadoSeleccion : Form
    {

        public Cliente SelectedClient { get; private set; }
        public bool existeCliente { get; private set; }
        public ListadoSeleccion()
        {
            InitializeComponent();
        }

        private PobladorCliente poblador;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                this.SelectedClient = new Cliente()
                {
                    idCliente = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    nombre = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    apellido = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
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

        private void ListadoSeleccion_Load(object sender, EventArgs e)
        {
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
            existeCliente = true;
            poblador = new PobladorCliente(new List<TextBox>() { textBoxNombre, textBoxMail, textBoxApellido, textBoxNumDoc }, comboBoxTipoDoc,dataGridView1, new List<string> { "Seleccionar" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }

        private void buttonAgregarCliente_Click(object sender, EventArgs e)
        {
            existeCliente = false;
            this.Close();
        }
    }
}
