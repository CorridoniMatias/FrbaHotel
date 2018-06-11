using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public class ConfigManager
    {
        public static DateTime FechaSistema { get; private set; }
        public static string SQLServer { get; private set; }
        public static string SQLUsername { get; private set; }
        public static string SQLPassword { get; private set; }
        public static string SQLDatabase { get; private set; }

        static ConfigManager()
        {
            FechaSistema = DateTime.Now;
        }

        public static void ReadConfig()
        {
            string config = System.Configuration.ConfigurationManager.AppSettings["FechaSistema"];

            if(!string.IsNullOrEmpty(config))
                FechaSistema = DateTime.Parse(config);
            else
                FechaSistema = DateTime.Now;

            config = System.Configuration.ConfigurationManager.AppSettings["SQLServer"];

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLServer.");
            else
                SQLServer = config;

            config = System.Configuration.ConfigurationManager.AppSettings["SQLUsername"];

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLUsername.");
            else
                SQLUsername = config;

            config = System.Configuration.ConfigurationManager.AppSettings["SQLPassword"];

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLPassword.");
            else
                SQLPassword = config;

            config = System.Configuration.ConfigurationManager.AppSettings["SQLDatabase"];

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLDatabase.");
            else
                SQLDatabase = config;
        }

        public static void WriteDefaults()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.Save(ConfigurationSaveMode.Full);
        }
    }
}
