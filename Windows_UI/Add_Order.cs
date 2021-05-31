using Domain.BaseClasses;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Add_Order : Form
    {
        private ICustomerService _customerService;
        private IFoodService _foodService;
        private IEnumerable<Food> _foods;
        private IEnumerable<Customer> _customers;
        private string button_prefix_name = "food_button_";

        public Add_Order(ICustomerService customerService, IFoodService foodService)
        {
            InitializeComponent();

            _customerService = customerService;
            _foodService = foodService;
        }

        private void load_info()
        {
            _foods = _foodService.select(s => s.ID > 0);
            _customers = _customerService.select(s => s.ID > 0);
        }

        private void show_customers(IEnumerable<Customer> customers)
        {
            cmb_customers.DataSource = customers;
            cmb_customers.DisplayMember = "FullName";
            cmb_customers.ValueMember = "ID";
        }

        private void show_foods(IEnumerable<Food> foods)
        {
            Size button_size = new Size(150, 100);

            int width = pnl_Foods.Width;

            int height = pnl_Foods.Height;

            int x = 10;
            int y = 10;

            foreach (var item in foods)
            {
                Button button = new Button();

                button.Text = item.Name;
                button.Name = String.Format("{0}{1}", button_prefix_name, item.ID.ToString());

                button.Click += Button_Click;
                button.Size = button_size;

                if (x + button_size.Width >= width)
                {
                    x = 10;
                    y += button_size.Height + 10;
                }

                button.Location = new Point(x, y);

                pnl_Foods.Controls.Add(button);

                x += button_size.Width + 10;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string button_name = button.Name;
            button_name.Replace(button_prefix_name, "");

            int food_id = 0;
            int.TryParse(button_name, out food_id);

        }

        private void Order_Load(object sender, EventArgs e)
        {
            load_info();

            show_foods(_foods);
            show_customers(_customers);
        }
    }
}
