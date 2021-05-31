using Domain.BaseClasses;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Add_Food : Form
    {
        private IConfigFile _configFile;
        private IFoodService _foodService;

        public Add_Food(IConfigFile configFile, IFoodService foodService)
        {
            InitializeComponent();

            _configFile = configFile;
            _foodService = foodService;
            lbl_currency_title.Text = _configFile.get_currency_title();
        }
        
        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            string text = txt_price.Text;
            double value = 0;
            double.TryParse(text, out value);
            string txt = string.Format("{0:#,##0}", value);

            if (txt.Trim() == "0")
                txt = "";

            txt_price.Text = txt;
            txt_price.Select(txt_price.Text.Length, 0);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            double value = 0;
            double.TryParse(txt_price.Text, out value);
            Food food = new Food() { Name = txt_name.Text.Trim() , Price = value};

            bool added = _foodService.add(food);

            if (added)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_name.Text = "";
                txt_price.Text = "";
                txt_name.Focus();
            }
            else
            {
                MessageBox.Show(null,"در ثبت اطلاعات خطایی رخ داده است","خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
