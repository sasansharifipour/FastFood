using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Windows_UI
{
    public interface IConfigFile
    {
        string get_currency_title();

        Size get_button_size();

        Size get_special_button_size();

        string get_value_from_config(string key);
    }

    public class ConfigFile : IConfigFile
    {
        public Size get_button_size()
        {
            int button_width = 0;
            int button_height = 0;

            string button_width_string = get_value_from_config("button_width");
            string button_height_string = get_value_from_config("button_height");

            int.TryParse(button_width_string, out button_width);
            int.TryParse(button_height_string, out button_height);

            return new Size(button_width, button_height);
        }

        public Size get_special_button_size()
        {
            int button_width = 0;
            int button_height = 0;

            string button_width_string = get_value_from_config("special_button_width");
            string button_height_string = get_value_from_config("special_button_height");

            int.TryParse(button_width_string, out button_width);
            int.TryParse(button_height_string, out button_height);

            return new Size(button_width, button_height);
        }

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
