using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    class Reserva
    {
        private string idHotel;
        private List<string> habitaciones;
        private string idRegimen;
        private int cantPersonas;
        private int cantPersonasReserva;
        public Reserva(string idHotel, List<string> habitaciones, string idRegimen, int cantPersonas)
        {
            this.idHotel = idHotel;
            this.habitaciones = habitaciones;
            this.idRegimen = idRegimen;
            this.cantPersonas = cantPersonas;
        }
        public float precioPorNoche()
        {
            return habitaciones.Sum(habitacion => DBHandler.SPWithValue("MATOTA.PrecioHabitacion",
                new List<SqlParameter> { new SqlParameter("@idHotel", idHotel), new SqlParameter("@nroHabitacion", habitacion), 
                    new SqlParameter("@cantPersonas", cantidadPersonasHabitacion(habitacion)), new SqlParameter("@idRegimen",idRegimen)}));
        }
        public int cantidadPersonasHabitacion(string habitacion)
        {
            var cantMaxPersonasHabitacion = getPersonasMaxHabitacion(habitacion);
            int aux;
            if (cantPersonas - cantMaxPersonasHabitacion > 0)
            {
                cantPersonas -= cantMaxPersonasHabitacion;
                return cantMaxPersonasHabitacion;
            }
            else
            {
                aux = cantPersonas;
                cantPersonas = Math.Max(0, cantPersonas - cantMaxPersonasHabitacion);
                return aux;
            }
        }
        public int cantNoches(DateTimePicker dateTimePickerFechaDesde, DateTimePicker dateTimePickerFechaHasta)
        {
            return DBHandler.SPWithValue("MATOTA.CantNoches",
                new List<SqlParameter> { new SqlParameter("@fechaInicio", dateTimePickerFechaDesde.Value), new SqlParameter("@fechaFin", dateTimePickerFechaHasta.Value) });
        }
        public int getPersonasMaxHabitacion(string nroHab)
        {
            return DBHandler.SPWithValue("MATOTA.personasHabitacion", new List<SqlParameter> { new SqlParameter("@idHotel", idHotel), new SqlParameter("@nroHabitacion", nroHab) });

        }
    }
}
