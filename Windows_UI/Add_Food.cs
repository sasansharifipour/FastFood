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
            int ID = (int)cmb_food_list.SelectedValue;
            double value = 0;
            double.TryParse(txt_price.Text, out value);
            Food food = new Food() { Name = txt_name.Text.Trim() , Price = value};

            bool register = false;

            if (ID > 0)
            {
                food.ID = ID;
                register = _foodService.update(food);
            }
            else
            {
                register = _foodService.add(food);
            }

            if (register)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_info();
                clean_form();
            }
            else
            {
                MessageBox.Show(null,"در ثبت اطلاعات خطایی رخ داده است","خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_info()
        {
            cmb_food_list.DisplayMember = "Name";
            cmb_food_list.ValueMember = "ID";
            var data = _foodService.select(s => s.ID > 0).ToList();

            data.Insert(0, new Food() { ID = 0, Name = "افزودن محصول", Price = 0 });

            cmb_food_list.DataSource = data;
        }

        private void Add_Food_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_food_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_food_list.SelectedValue;

            if (selected_id == 0)
            {
                clean_form();
                return;
            }

            var item = _foodService.select(s => s.ID == selected_id).FirstOrDefault();
            set_data(item);
        }

        private void clean_form()
        {
            txt_name.Text = "";
            txt_price.Text = "";
            txt_name.Focus();
        }

        private void set_data(Food data)
        {
            txt_name.Text = data.Name;
            txt_price.Text = data.Price.ToString();
        }
    }
}
