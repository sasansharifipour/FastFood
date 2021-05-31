using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Windows_UI
{
    public interface IConfigFile
    {
        string get_currency_title();

        string get_value_from_config(string key);
    }

    public class ConfigFile : IConfigFile
    {
        public string get_currency_title()
        {
            string key = "currecny_title";
            return get_value_from_config(key);
        }

        public string get_value_from_config(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                return "";
            else
                return ConfigurationManager.AppSettings[key];
        }
    }
}
