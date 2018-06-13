using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private List<string> habitaciones;
        private string idHotel;
        public Listado()
        {
            InitializeComponent();
            habitaciones = new List<string>();
            if (Login.Login.LoggedUsedID == -1)
            {
                textBoxHotel.Hide();
                FormHandler.setHotelesHabilitados(comboBoxHotel);
                comboBoxHotel.SelectedIndex = -1; 
            }
            else
            {
                comboBoxHotel.Hide();
                try
                {
                    var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                    Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                    textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al agregar el nombre del hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            FormHandler.listarRegimenes(comboBoxRegimen);
            comboBoxRegimen.SelectedIndex = -1;
            poblador = new PobladorReservas(textBoxIdReserva, comboBoxHotel, comboBoxRegimen, dataGridView1, new List<string> { "Modificar"});
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
            //if (string.IsNullOrEmpty(textBoxHotel.Text) || comboBoxHotel.SelectedIndex == -1)
            //{
            //    MessageBox.Show("No seleccionó ningún hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    if (Login.Login.LoggedUsedID == -1)
                        idHotel = "1";
                    else
                        idHotel = Login.Login.LoggedUserSessionHotelID.ToString();
                    if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Modificar"))
                    {
                        this.obtenerListaHabitaciones();
                        new Modificacion(
                                senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                                idHotel,
                                senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[7].Value.ToString(),
                                habitaciones).ShowDialog();
                    }
                }
                //}
            }
        }
        private void obtenerListaHabitaciones()
        {
            DBHandler.SPWithResultSet("MATOTA.GetHabitacionesReserva ", new List<SqlParameter> { new SqlParameter("@idReserva", textBoxIdReserva.Text) })
                                     .ForEach(hab => habitaciones.Add(hab["nroHabitacion"].ToString()));
        }
    }
}
