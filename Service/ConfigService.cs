using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Service
{

    public interface IConfigService
    {
        string get_currency_title();

        Size get_button_size();

        Size get_special_button_size();

        string get_from_email_address();

        List<string> get_to_email_address();

        string get_email_key();

        string get_value_from_config(string key);

        string get_cash_desk_printer_name();

        string get_kitchen_printer_name();
    }

    public class ConfigService : IConfigService
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

        public string get_from_email_address()
        {
            string key = "from_email_address";
            return get_value_from_config(key);
        }

        public List<string> get_to_email_address()
        {
            string key = "to_email_address";
            return get_value_from_config(key).Split(',').ToList();
        }

        public string get_email_key()
        {
            string key = "email_key";
            return get_value_from_config(key);
        }
        
        public string get_cash_desk_printer_name()
        {
            string key = "cash_desk_printer_name";
            return get_value_from_config(key);
        }
        
        public string get_kitchen_printer_name()
        {
            string key = "kitchen_printer_name";
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
