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
    public partial class Modificacion : Form
    {
        private string idReserva;
        private string idHotel;
        private int cantPersonasReserva;
        public List<string> habitaciones;
        public List<string> habitacionesRemovidas;
        private Reserva reserva{get; set;}
        public AbmHabitacion.HabitacionReservada habReservada { get; set; }
        public Modificacion(string idReserva,string fechaDesde, string fechaHasta, string idRegimen, string cantPersonas,string precioNoche, List<string> habitaciones,string regimen)
        {
            InitializeComponent();
            this.idReserva = idReserva;
            this.idHotel = DBHandler.Query("SELECT idHotel FROM MATOTA.RESERVA WHERE idReserva =" + idReserva).First().Values.First().ToString();
            dateTimePickerFechaDesde.Value = DateTime.Parse(fechaDesde);
            dateTimePickerFechaHasta.Value = DateTime.Parse(fechaHasta);
            FormHandler.listarRegimenes(comboBoxRegimen);
            comboBoxRegimen.Text = regimen;
            textBoxCantPersonas.Text = cantPersonas;
            textBoxPrecioNoche.Text = precioNoche;
            this.habitaciones = habitaciones;
            habitacionesRemovidas = new List<string>();
            reserva = new Reserva(idHotel, habitaciones, idRegimen, cantPersonasReserva);
            habitaciones.ForEach(hab => { crearHabitacionReservada(hab); dataGridView1.Rows.Add(habReservada.nroHabitacion, habReservada.tipoHabitacion, habReservada.ubicacion); });
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
        }
        
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
            FormHandler.limpiar(groupBox2);
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
           var form = new AbmHabitacion.Listado(idHotel, habitaciones,dateTimePickerFechaDesde.Value,dateTimePickerFechaHasta.Value);
           form.setHabitacionesRemovidas(habitacionesRemovidas);
           form.dataGridReserva = dataGridView1;
           form.ShowDialog();
        }
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var cantNoches = reserva.cantNoches(dateTimePickerFechaDesde,dateTimePickerFechaHasta);
            if (cantNoches <= 0)
            {
                MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DBHandler.SPWithBool("MATOTA.FechaCorrectaParaModificarReserva", new List<SqlParameter>{new SqlParameter("@idReserva",idReserva),
                                                                                                      new SqlParameter("@fechaSistema",ConfigManager.FechaSistema)}))
            {
                MessageBox.Show("Ya pasó la fecha límite para modificar esta reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
                var precioPorNoche = reserva.precioPorNoche();
                var ret = DBHandler.SPWithValue("Matota.UpdateReserva",
                    new List<SqlParameter>{new SqlParameter("@idReserva",idReserva),
                                       new SqlParameter("@fechaDesde",dateTimePickerFechaDesde.Value),
                                       new SqlParameter("@fechaHasta",dateTimePickerFechaHasta.Value),
                                       new SqlParameter("@cantNoches",cantNoches),
                                       new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue),
                                       new SqlParameter("@precioBaseReserva",precioPorNoche*cantNoches),
                                       new SqlParameter("@cantidadPersonas",textBoxCantPersonas.Text),});
                if (ret == 1)
                {
                    habitaciones.ForEach(hab => DBHandler.SPWithValue("MATOTA.agregarHabitacionesReservadas",
                        new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    if (habitacionesRemovidas.Count != 0)
                        habitacionesRemovidas.ForEach(hab => DBHandler.SPWithValue("MATOTA.QuitarHabitacionesReserva",
                            new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    MessageBox.Show("Modificación realizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en la modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void textBoxCantPersonas_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCantPersonas.Text))
                cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
            FormHandler.limpiar(groupBox2);
        }
        private void crearHabitacionReservada(string nroHab)
        {
            try
            {
                var queryTipoHab = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("th.descripcion").Table("MATOTA.TipoHabitacion th").
                                   AddJoin("JOIN MATOTA.Habitacion h ON(th.idTipoHabitacion = h.idTipoHabitacion)").AddEquals("h.nroHabitacion", nroHab).AddEquals("h.idHotel",idHotel).Build();
                var queryUbicacion = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("u.descripcion").Table("MATOTA.UbicacionHabitacion u").
                                     AddJoin("JOIN MATOTA.Habitacion h ON (h.idUbicacion = u.idUbicacion)").AddEquals("h.nroHabitacion", nroHab).AddEquals("h.idHotel",idHotel).Build();

                habReservada = new AbmHabitacion.HabitacionReservada()
                {
                    nroHabitacion = nroHab,
                    tipoHabitacion = DBHandler.Query(queryTipoHab).First().Values.First().ToString(),
                    ubicacion = DBHandler.Query(queryUbicacion).First().Values.First().ToString()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las habitaciones ya reservadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}