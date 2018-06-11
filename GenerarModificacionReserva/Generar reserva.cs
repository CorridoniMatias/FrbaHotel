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
                idHotel = Login.Login.LoggedUserSessionHotelID.ToString();
                var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                    Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", this.idHotel);
                textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).ToString();
            }
        }
        private void setHotelesHabilitados()
        {
            var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("h.idHotel,h.nombre").Table("MATOTA.Hotel h").
                AddJoin("LEFT OUTER JOIN MATOTA.InactividadHotel i ON (h.idHotel = i.idHotel)").Build();
            comboBoxHotel.DataSource = DBHandler.QueryForComboBox(query);
            comboBoxHotel.ValueMember = "idHotel";
            comboBoxHotel.DisplayMember = "nombre";
        }

        private void setRegimenes()
        {
            var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("r.idRegimen,r.nombre").Table("MATOTA.Regimen r").
                AddJoin("JOIN MATOTA.RegimenHotel rh ON (rh.idRegimen = r.idRegimen AND rh.idHotel =" + idHotel + ")").Build();
            comboBoxRegimen.DataSource = DBHandler.QueryForComboBox(query);
            comboBoxRegimen.DisplayMember = "nombre";
            comboBoxRegimen.ValueMember = "idRegimen";
            comboBoxRegimen.SelectedIndex = -1;
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
            if (this.cantNoches() == 0)
            {
                MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBHandler.SPWithValue("MATOTA.ActualizarReservasVencidas", new List<SqlParameter> { new SqlParameter("@fechaSistema", ConfigManager.FechaSistema) });
                DBHandler.SPWithValue("MATOTA.habilitarHabitacionesDeReservasVencidas", new List<SqlParameter> { new SqlParameter("@fechaSistema", ConfigManager.FechaSistema) });
                MessageBox.Show("El precio total de la reserva es de U$S " + this.precioPorNoche() * this.cantNoches(), "Precio Total", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var idCliente = this.getIdCliente();
                var idReserva = DBHandler.SPWithValue("MATOTA.AltaReserva",
                    new List<SqlParameter>{ new SqlParameter("@idHotel",idHotel),
                                        new SqlParameter("@fechaReserva",ConfigManager.FechaSistema),
                                        new SqlParameter("@fechaDesde",dateTimePickerFechaDesde.Value),
                                        new SqlParameter("@fechaHasta",dateTimePickerFechaHasta.Value),
                                        new SqlParameter("@cantidadNoches",this.cantNoches()),
                                        new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue),
                                        new SqlParameter("@idCliente",idCliente),
                                        new SqlParameter("@precioBase",this.precioPorNoche()*this.cantNoches()),
                                        new SqlParameter("@cantidadPersonas",textBoxCantPersonas.Text),});
                habitaciones.ForEach(hab => DBHandler.SPWithValue("MATOTA.agregarHabitacionesReservadas",
                    new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                MessageBox.Show("Reserva realizada con éxito, el código de su reserva es: " + idReserva, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private float precioPorNoche()
        {
            var precio = habitaciones.Sum(habitacion => DBHandler.SPWithValue("MATOTA.PrecioHabitacion",
                new List<SqlParameter> { new SqlParameter("@idHotel", idHotel), new SqlParameter("@nroHabitacion", habitacion), 
                    new SqlParameter("@cantPersonas", this.cantidadPersonasHabitacion(habitacion)), new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue)}));
            return precio;
        }
        private int cantidadPersonasHabitacion(string habitacion)
        {
            var cantMaxPersonasHabitacion = this.getPersonasMaxHabitacion(habitacion);
            int aux;
                if (cantPersonasReserva - cantMaxPersonasHabitacion > 0)
                {
                    cantPersonasReserva -= cantMaxPersonasHabitacion;
                    return cantMaxPersonasHabitacion;
                }
                else
                {
                    aux = cantPersonasReserva;
                    cantPersonasReserva = Math.Max(0, cantPersonasReserva - cantMaxPersonasHabitacion);
                    return aux;
                }
        }
        private int cantNoches()
        {
            return DBHandler.SPWithValue("MATOTA.CantNoches",
                new List<SqlParameter> { new SqlParameter("@fechaInicio", dateTimePickerFechaDesde.Value), new SqlParameter("@fechaFin", dateTimePickerFechaHasta.Value) });
        }

        private void buttonSeleccionarHab_Click(object sender, EventArgs e)
        {
            if (comboBoxHotel.SelectedIndex == -1)
                MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                new AbmHabitacion.Listado(idHotel, this).ShowDialog();
                if(!string.IsNullOrEmpty(textBoxCantPersonas.Text))
                    cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
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
        public void agregarHabitacion(string nroHab)
        {
            if (habitaciones.Contains(nroHab))
                MessageBox.Show("Ya seleccionó esta habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                habitaciones.Add(nroHab);
            }

        }
        public void quitarHabitacion(string nroHab)
        {
            habitaciones.Remove(nroHab);
        }

        private int getPersonasMaxHabitacion(string nroHab)
        {
           return DBHandler.SPWithValue("MATOTA.personasHabitacion", new List<SqlParameter> { new SqlParameter("@idHotel", idHotel), new SqlParameter("@nroHabitacion", nroHab) });
       
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
                else
                {
                    var precio = this.precioPorNoche();
                    textBoxPrecioPorNoche.Text = "U$S " + precio.ToString();
                    var cantNoches = this.cantNoches();
                    textBoxCantNoches.Text = cantNoches.ToString();
                }
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