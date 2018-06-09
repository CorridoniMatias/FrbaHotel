using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public class ConfigManager
    {
        public static DateTime FechaSistema { get; private set; }

        static ConfigManager()
        {
            FechaSistema = DateTime.Now;
        }
    }
}
