using Domain.BaseClasses;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Create_Special_Food : Form
    {
        private IFoodService _foodService;
        private IFoodOptionService _foodOptionService;
        private int selected_food_id = 0;
        private Food _food;
        private List<FoodOption> _foodOptions = new List<FoodOption>();
        private string food_option_prefix = "check_box_food_option_";

        public delegate void select_food(OrderItem orderItem);

        public event select_food select_food_Event;

        public Create_Special_Food(IFoodService foodService, IFoodOptionService foodOptionService)
        {
            _foodService = foodService;
            _foodOptionService = foodOptionService;

            InitializeComponent();
        }

        public void set_food_id(int food_id)
        {
            selected_food_id = food_id;
            _food = _foodService.find(food_id);

            show_original_food_info(_food);

            update_info();
        }

        private void Create_Special_Food_Load(object sender, EventArgs e)
        {
            _foodOptions = _foodOptionService.select_active_items().ToList();

            show_food_options(_foodOptions, panel2);
            update_info();
        }

        private void show_original_food_info(Food food)
        {
            if(_food == null)
            {
                lbl_original_name.Text = "";
                lbl_original_price.Text = "";
                return;
            }

            lbl_original_name.Text = food.Name;
            lbl_original_price.Text = food.Price.ToString("N0");
        }

        private void show_food_options(List<FoodOption> foodOptions, Panel panel)
        {
            panel.Controls.Clear();

            int x = 30;
            int y = 10;

            foreach (var item in foodOptions)
            {
                CheckBox checkBox = new CheckBox();

                checkBox.Name = String.Format("{0}{1}", food_option_prefix, item.ID.ToString());
                checkBox.Checked = item.DefaultExist;
                checkBox.Text = item.Name;
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                checkBox.Location = new Point(panel.Width - checkBox.Width - x, y);

                panel.Controls.Add(checkBox);

                y += checkBox.Height + 10;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            update_info();
        }

        private void update_info()
        {
            lbl_new_name.Text = get_new_name();
            lbl_new_price.Text = get_new_price().ToString();
        }

        private string get_new_name()
        {
            string name = "";

            if (_food != null)
                name = _food.Name;

            foreach (var item in _foodOptions)
            {
                string cntrl_name = String.Format("{0}{1}", food_option_prefix, item.ID);

                var chk_box = this.Controls.Find(cntrl_name, true);

                if(chk_box != null && chk_box.Count() > 0 && chk_box[0] is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)chk_box[0];

                    if (checkBox.Checked)
                    {
                        if (item.TitleIfExist.Trim() != "")
                            name += "," + item.TitleIfExist;
                    }
                    else
                    {
                        if (item.TitleIfNotExist.Trim() != "")
                            name += "," + item.TitleIfNotExist;
                    }
                }

            }

            return name;
        }

        private double get_new_price()
        {
            double price = 0;

            double percentage = 100;

            if (_food != null)
                price = _food.Price;

            foreach (var item in _foodOptions)
            {
                string cntrl_name = String.Format("{0}{1}", food_option_prefix, item.ID);

                var chk_box = this.Controls.Find(cntrl_name, true);

                if (chk_box != null && chk_box.Count() > 0 && chk_box[0] is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)chk_box[0];

                    if (checkBox.Checked)
                    {
                        price += item.PriceIfExist;
                        percentage += item.PercentPriceIfExist;
                    }
                    else
                    {
                        if (item.DefaultExist)
                        {
                            price -= item.PriceIfExist;
                            percentage -= item.PercentPriceIfExist;
                        }
                    }
                }

            }

            return price * (percentage / 100);
        }

        private List<FoodOption> get_selected_options()
        {
            List<FoodOption> selected_options = new List<FoodOption>();
            
            foreach (var item in _foodOptions)
            {
                string cntrl_name = String.Format("{0}{1}", food_option_prefix, item.ID);

                var chk_box = this.Controls.Find(cntrl_name, true);

                if (chk_box != null && chk_box.Count() > 0 && chk_box[0] is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)chk_box[0];

                    if (checkBox.Checked)
                        selected_options.Add(item);
                }

            }

            return selected_options;
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            var eventSubscribers = select_food_Event;
            if (eventSubscribers != null)
            {
                eventSubscribers(new OrderItem()
                {
                    Count = 1,
                    FoodID = _food.ID,
                    Food = _food,
                    Name = get_new_name(),
                    Price = get_new_price(),
                    FoodOptions = get_selected_options()
                });
            }

            this.Close();
        }
    }
}
