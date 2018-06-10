using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.AbmCliente
{
    public class Cliente
    {
        public string idCliente { get;  set; }
        public string nombre { get;  set; }
        public string apellido { get;  set; }
        public string idTipoDocumento { get;  set; }
        public string numeroDocumento { get;  set; }
        public string mail { get;  set; }
        public string telefono { get;  set; }
        public string calle { get;  set; }
        public string nroCalle { get;  set; }
        public string piso { get;  set; }
        public string departamento { get;  set; }
        public string localidad { get;  set; }
        public string pais { get;  set; }
        public string nacionalidad { get;  set; }
        public string fechaNacimiento { get;  set; }
        public string habilitado { get;  set; }
        public string valido { get;  set; }
        public string NombreCompleto { get {
            return nombre + " " + apellido;
        } }

    }
}
