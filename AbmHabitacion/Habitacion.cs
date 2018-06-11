using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmHabitacion
{
    public class Habitacion
    {
        public string idHotel { get; set; }
        public string nroHabitacion { get; set; }
        public string piso { get; set; }
        public string idUbicacion { get; set; }
        public string idTipoHabitacion { get; set; }
        public string descripcion { get; set; }
        public string comodidades { get; set; }
        public bool habilitado { get; set; }
    }
}
