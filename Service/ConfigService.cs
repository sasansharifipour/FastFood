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
        string CurrencyTitle { get; }
        Size DefaultButtonSize { get; }
        Size SpecialButtonSize { get; }
        string FromEmailAddress { get; }
        List<string> ToEmailAddresses { get; }
        string EmailKey { get; }
        string CashDeskPrinterName { get; }
        string KitchenPrinterName { get; }
    }

    public class ConfigService : IConfigService
    {
        public string CurrencyTitle
        {
            get { return GetValueFromConfig("currency_title"); }
        }

        public Size DefaultButtonSize
        {
            get
            {
                int width;
                int height;
                if (!int.TryParse(GetValueFromConfig("button_width"), out width))
                    throw new ConfigurationErrorsException("Invalid button_width value in configuration file");
                if (!int.TryParse(GetValueFromConfig("button_height"), out height))
                    throw new ConfigurationErrorsException("Invalid button_height value in configuration file");
                return new Size(width, height);
            }
        }

        public Size SpecialButtonSize
        {
            get
            {
                int width;
                int height;
                if (!int.TryParse(GetValueFromConfig("special_button_width"), out width))
                    throw new ConfigurationErrorsException("Invalid special_button_width value in configuration file");
                if (!int.TryParse(GetValueFromConfig("special_button_height"), out height))
                    throw new ConfigurationErrorsException("Invalid special_button_height value in configuration file");
                return new Size(width, height);
            }
        }

        public string FromEmailAddress
        {
            get { return GetValueFromConfig("from_email_address"); }
        }

        public List<string> ToEmailAddresses
        {
            get { return GetValueFromConfig("to_email_address").Split(',').ToList(); }
        }

        public string EmailKey
        {
            get { return GetValueFromConfig("email_key"); }
        }

        public string CashDeskPrinterName
        {
            get { return GetValueFromConfig("cash_desk_printer_name"); }
        }


        public string KitchenPrinterName
        {
            get { return GetValueFromConfig("kitchen_printer_name"); }
        }

        private string GetValueFromConfig(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                return "";
            else
                return ConfigurationManager.AppSettings[key];
        }
    }
}
