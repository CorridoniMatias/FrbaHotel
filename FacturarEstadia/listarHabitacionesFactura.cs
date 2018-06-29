using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.FacturarEstadia
{
    public partial class listarHabitacionesFactura : Form
    {

        private pobladorHabitacionFactura poblador;
        private string nroHabitacionSeleccionado;

        public listarHabitacionesFactura()
        {
            InitializeComponent();
            nroHabitacionSeleccionado = null;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                this.nroHabitacionSeleccionado = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            poblador.Poblar();
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }

        private void listarHabitacionesFactura_Load(object sender, EventArgs e)
        {
            if (Login.Login.LoggedUserSessionHotelID == -1)
            {
                var result = new AbmHotel.Listado().ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Abort)
                {// FALLO LA OBTENCION!
                    MessageBox.Show("Fallo en la obtención de un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel) // USUARIO CERRO LA VENTANA!
                {
                    MessageBox.Show("Se ha cerrado la ventana sin seleccionar un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

            try
            {
                var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                textBoxNombreHotel.Text = DBHandler.Query(nombreHotel.Build()).First()["nombre"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el nombre del hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            FormHandler.listarTipoUbicacion(comboBoxUbicacion);
            comboBoxUbicacion.SelectedIndex = -1;
            FormHandler.listarTipoHabitacion(comboBoxHabitacion);
            comboBoxHabitacion.SelectedIndex = -1;
            poblador = new pobladorHabitacionFactura(new List<TextBox>() { textBoxNroHabitacion, textBoxPiso },
                new List<ComboBox>() { comboBoxUbicacion, comboBoxHabitacion }, dataGridView1, new List<string> { "Seleccionar" });
        }

        public string getHabitacionSeleccionada()
        {
            return this.nroHabitacionSeleccionado;
        }
    }
}
