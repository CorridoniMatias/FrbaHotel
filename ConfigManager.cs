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

        public static bool ConfigCargada { get; private set; }

        public static string ConfigFile { get; set; }

        private static List<string> fields = new List<string> { "FechaSistema", "SQLServer", "SQLUsername", "SQLPassword", "SQLDatabase" };

        static ConfigManager()
        {
            FechaSistema = DateTime.Now;
            ConfigCargada = false;
            ConfigFile = System.IO.Directory.GetParent(Application.StartupPath).Parent.Parent.FullName + "/FrbaHotel.exe.config";
        }

        public static void ReadConfig()
        {
            ConfigCargada = false;

            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            //Intentar levantar la configuracion desde /src
            configMap.ExeConfigFilename = ConfigFile;
            Configuration configManager = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            string config = null, field = "";

            if (configManager.AppSettings.Settings.AllKeys.Count() == 0)
                throw new Exception("Imposible cargar configuracion, archivo no encontrado.");

            if (fields.Any(f => { field = f; return !configManager.AppSettings.Settings.AllKeys.Contains(f); }))
            {
                throw new Exception("Imposible cargar configuracion, falta " + field);
            }
                
            config = configManager.AppSettings.Settings["FechaSistema"].Value;
            
            if(!string.IsNullOrEmpty(config))
                FechaSistema = DateTime.Parse(config);
            else
                throw new Exception("Imposible cargar configuracion, falta FechaSistema.");

            config = configManager.AppSettings.Settings["SQLServer"].Value;

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLServer.");
            else
                SQLServer = config;

            config = configManager.AppSettings.Settings["SQLUsername"].Value;

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLUsername.");
            else
                SQLUsername = config;

            config = configManager.AppSettings.Settings["SQLPassword"].Value;

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLPassword.");
            else
                SQLPassword = config;

            config = configManager.AppSettings.Settings["SQLDatabase"].Value;

            if (string.IsNullOrEmpty(config))
                throw new Exception("Imposible cargar configuracion, falta SQLDatabase.");
            else
                SQLDatabase = config;

            ConfigCargada = true;
        }

        //public static void WriteDefaults()
        //{
        //    ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
        //    configMap.ExeConfigFilename = ConfigFile;
        //    Configuration configManager = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

        //}
    }
}
