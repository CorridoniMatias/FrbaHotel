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
        List<int> habitaciones = new List<int>();
        public GenerarReserva()
        {
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
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHotel.SelectedIndex != -1)
            {
                idHotel = comboBoxHotel.SelectedValue.ToString();
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
            DBHandler.SPWithValue("MATOTA.ActualizarReservasVencidas", new List<SqlParameter> { new SqlParameter("@fechaSistema", ConfigManager.FechaSistema) });
            DBHandler.SPWithValue("MATOTA.habilitarHabitacionesDeReservasVencidas");
            var nroHabitacion = DBHandler.SPWithResultSet("MATOTA.habitacionParaReserva", 
                new List<SqlParameter> { new SqlParameter("@idHotel", idHotel), new SqlParameter("@cantPersonasReserva", textBoxCantPersonas.Text) }).First().Values.First();
            habitaciones.Add(Convert.ToInt32(nroHabitacion.ToString()));
            var precio = this.precioPorNoche();
            textBoxPrecioPorNoche.Text = precio.ToString();
            var cantNoches = this.cantNoches();
            textBoxCantNoches.Text = cantNoches.ToString();
        }
        private float precioPorNoche()
        {
            return habitaciones.Sum(habitacion => DBHandler.SPWithValue("MATOTA.PrecioHabitacion",
                new List<SqlParameter>{new SqlParameter("@idHotel",idHotel),new SqlParameter("@nroHabitacion",habitacion),new SqlParameter("@cantPersonas",textBoxCantPersonas.Text)}));
        }
        private int cantNoches()
        {
            return DBHandler.SPWithValue("MATOTA.CantNoches", 
                new List<SqlParameter> { new SqlParameter("@fechaInicio", dateTimePickerFechaInicio.Value), new SqlParameter("@fechaFin", dateTimePickerFechaFin.Value) });
        }

        private void buttonSeleccionarHab_Click(object sender, EventArgs e)
        {
            if (comboBoxHotel.SelectedIndex == -1)
                MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            else 
                new AbmHabitacion.Listado(idHotel).ShowDialog();
        }
    }
}
