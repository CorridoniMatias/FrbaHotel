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

namespace FrbaHotel.AbmHabitacion
{
    public partial class Listado : Form
    {
        private string idHotel;
        private List<string> habitaciones;
        private List<string> habitacionesRemovidas;
        public HabitacionReservada habitacionReservada { get; private set; }
        private HabitacionReservada habitacionesDisp { get; set; }
        public DataGridView dataGridReserva {get; set;}
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        public Listado(string idHotel,List<string> habitaciones,DateTime fechaDesde,DateTime fechaHasta)
        {
            this.idHotel = idHotel;
            this.habitaciones = habitaciones;
            this.fechaHasta = fechaHasta;
            this.fechaDesde = fechaDesde;
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            this.setGridValuesHabitacion();
        }


        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.setGridValuesHabitacion();
            if (!dataGridView1.Columns.Contains("Agregar"))
            {
                FormHandler.crearBotonesParaHabitacionesReserva(dataGridView1);
            }
        }
        private void setGridValuesHabitacion()
        {
            try
            {
                var data = DBHandler.SPWithResultSet("MATOTA.HabitacionesNoReservadas",
                    new List<SqlParameter> { 
                        new SqlParameter("@idHotel", idHotel),
                        new SqlParameter("@fechaDesde", fechaDesde),
                        new SqlParameter("@fechaHasta", fechaHasta)
                    }
                    );
                if (data.Count == 0)
                {
                    MessageBox.Show("No hay habitaciones libres en el hotel en el período seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                var newdata = data.Select(row =>
                {
                    var orig = new List<string>() { row["nroHabitacion"].ToString(), 
                                                        row["Tipo"].ToString(), 
                                                        row["Ubicacion"].ToString() };

                    orig.Add("Agregar");
                    orig.Add("Quitar");
                    return orig;
                }).ToList();

                newdata.ForEach(row =>
                        dataGridView1.Rows.Add(row.ToArray())
                    );

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar las habitaciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var nroHab = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("ColumnAgregar"))
                {
                    if (habitaciones.Contains(nroHab))
                        MessageBox.Show("Ya seleccionó esta habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        habitaciones.Add(nroHab);
                        MessageBox.Show("Habitacion " + nroHab.ToString() + " agregada", "Habitación agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        habitacionReservada = new HabitacionReservada()
                        {
                            nroHabitacion = nroHab,
                            tipoHabitacion = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            ubicacion = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        };
                        dataGridReserva.Rows.Add(habitacionReservada.nroHabitacion, habitacionReservada.tipoHabitacion, habitacionReservada.ubicacion);
                    }
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("ColumnQuitar"))
                {
                    if (habitaciones.Contains(nroHab))
                    {
                        habitaciones.Remove(nroHab);
                        if(!habitacionesRemovidas.Contains(nroHab))
                            habitacionesRemovidas.Add(nroHab);
                        MessageBox.Show("Habitacion " + nroHab.ToString() + " quitada", "Habitación quitada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridReserva.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Usted nunca agregó esta habitación a la lista de habitaciones de la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
    }
        public void setHabitacionesRemovidas(List<string> habitaciones)
        {
            habitacionesRemovidas = habitaciones;
        }
}
}
