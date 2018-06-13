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
    public partial class GenerarReserva : Form
    {
        private string idHotel;
        public List<string> habitaciones { get; private set; }
        private int cantPersonasReserva;
        private float precioNoche;
        public GenerarReserva()
        {
            habitaciones = new List<string>();
            
            InitializeComponent();
            if (Login.Login.LoggedUsedID == -1)
            {
                textBoxHotel.Hide();
                this.setHotelesHabilitados();
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
        private void setHotelesHabilitados()
        {
            try
            {

                var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("h.idHotel,h.nombre").Table("MATOTA.Hotel h").
                    AddJoin("LEFT OUTER JOIN MATOTA.InactividadHotel i ON (h.idHotel = i.idHotel)").Build();
                comboBoxHotel.DataSource = DBHandler.QueryForComboBox(query);
                comboBoxHotel.ValueMember = "idHotel";
                comboBoxHotel.DisplayMember = "nombre";
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al listar los hoteles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void setRegimenes()
        {
            try
            {
                var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("r.idRegimen,r.nombre").Table("MATOTA.Regimen r").
                    AddJoin("JOIN MATOTA.RegimenHotel rh ON (rh.idRegimen = r.idRegimen AND rh.idHotel =" + idHotel + ")").Build();
                comboBoxRegimen.DataSource = DBHandler.QueryForComboBox(query);
                comboBoxRegimen.DisplayMember = "nombre";
                comboBoxRegimen.ValueMember = "idRegimen";
                comboBoxRegimen.SelectedIndex = -1;
            }
            catch (Exception) 
            {
                MessageBox.Show("Ocurrió un error al listar los régimenes del hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            comboBoxHotel.SelectedIndex = -1;
            comboBoxRegimen.SelectedIndex = -1;
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHotel.SelectedIndex != -1)
            {
                idHotel = comboBoxHotel.SelectedValue.ToString();
                this.habitaciones.Clear();
                this.setRegimenes();
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this);
            FormHandler.limpiar(groupBox2);
            FormHandler.limpiar(groupBox1);
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            var cantNoches = FormHandler.cantNoches(dateTimePickerFechaDesde, dateTimePickerFechaHasta);
            if (cantNoches <= 0)
            {
                MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DBHandler.SPWithValue("MATOTA.ActualizarReservasVencidas", new List<SqlParameter> { new SqlParameter("@fechaSistema", ConfigManager.FechaSistema) });
                    DBHandler.SPWithValue("MATOTA.habilitarHabitacionesDeReservasVencidas", new List<SqlParameter> { new SqlParameter("@fechaSistema", ConfigManager.FechaSistema) });
                    MessageBox.Show("El precio total de la reserva es de U$S " + precioNoche * cantNoches, "Precio Total", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var idCliente = this.getIdCliente();
                    var idReserva = DBHandler.SPWithValue("MATOTA.AltaReserva",
                        new List<SqlParameter>{ new SqlParameter("@idHotel",idHotel),
                                        new SqlParameter("@fechaReserva",ConfigManager.FechaSistema),
                                        new SqlParameter("@fechaDesde",dateTimePickerFechaDesde.Value),
                                        new SqlParameter("@fechaHasta",dateTimePickerFechaHasta.Value),
                                        new SqlParameter("@cantidadNoches",cantNoches),
                                        new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue),
                                        new SqlParameter("@idCliente",idCliente),
                                        new SqlParameter("@precioBase",precioNoche * cantNoches),
                                        new SqlParameter("@cantidadPersonas",textBoxCantPersonas.Text),});
                    habitaciones.ForEach(hab => DBHandler.SPWithValue("MATOTA.agregarHabitacionesReservadas",
                        new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    MessageBox.Show("Reserva realizada con éxito, el código de su reserva es: " + idReserva, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al realizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void buttonSeleccionarHab_Click(object sender, EventArgs e)
        {
            if (comboBoxHotel.SelectedIndex == -1)
                MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                var form = new AbmHabitacion.Listado(idHotel, habitaciones);
                form.setHabitacionesRemovidas(new List<string>());
                form.ShowDialog();
                if(!string.IsNullOrEmpty(textBoxCantPersonas.Text))
                    cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
            }
        }
        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            {
                if (comboBoxRegimen.SelectedIndex == -1)
                    new ListadoRegimenHotel(idHotel, comboBoxRegimen).ShowDialog();
                if (habitaciones.Count == 0)
                {
                    MessageBox.Show("No ingresó ninguna habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormHandler.limpiar(groupBox2);
                }
                var cantNoches = FormHandler.cantNoches(dateTimePickerFechaDesde, dateTimePickerFechaHasta);
                if (cantNoches <= 0)
                {
                    MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
                    precioNoche = FormHandler.precioPorNoche(habitaciones, idHotel, comboBoxRegimen,cantPersonasReserva);
                    textBoxPrecioPorNoche.Text = "U$S " + precioNoche.ToString();
                    textBoxCantNoches.Text = cantNoches.ToString();
                }
            }
        }
        private string getIdCliente()
        {
            var seleccion = new AbmCliente.ListadoSeleccion();
            seleccion.ShowDialog();
            if (seleccion.existeCliente)
                return seleccion.SelectedClient.idCliente;
            else
            {
                var alta = new AbmCliente.Alta();
                alta.ShowDialog();
                return alta.InsertedClient.idCliente;
            }

        }
        private void textBoxCantPersonas_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCantPersonas.Text))
                cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
            FormHandler.limpiar(groupBox2);

        } 
    }
}