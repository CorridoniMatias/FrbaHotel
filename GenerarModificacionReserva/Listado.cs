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
                    textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).First().Values.First().ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Seleccione un hotel en el que quiera realizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var result = new AbmHotel.Listado().ShowDialog();
                    idHotel = Login.Login.LoggedUserSessionHotelID.ToString();
                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        MessageBox.Show("Se ha cerrado la ventana sin seleccionar un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Load += cerrarFormEnConstructor;
                    }
                    else 
                    {
                        var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                        Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                        try
                        {
                            textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).First().Values.First().ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al obtener nombre de hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
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
            if (Login.Login.LoggedUsedID == -1 && string.IsNullOrEmpty(textBoxIdReserva.Text.Trim()))
            {
                MessageBox.Show("Debe proveer por lo menos su numero de reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Rows.Clear();
            poblador.Poblar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Modificar"))
                    {
                        this.obtenerListaHabitaciones();
                        new Modificacion(
                                senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString(),
                                senderGrid.Rows[e.RowIndex].Cells[7].Value.ToString(),
                                habitaciones,
                                senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()).ShowDialog();
                    }
                    this.Close();
                }
                //}
            }
        }
        private void obtenerListaHabitaciones()
        {
            DBHandler.SPWithResultSet("MATOTA.GetHabitacionesReserva ", new List<SqlParameter> { new SqlParameter("@idReserva", textBoxIdReserva.Text) })
                                     .ForEach(hab => habitaciones.Add(hab["nroHabitacion"].ToString()));
        }
        private void cerrarFormEnConstructor(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
