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
        private BindingList<OrderItem> _order_items;
        private IConfigFile _configFile;
        private IOrderService _orderService;
        int free_number = 0;

        public Add_Order(ICustomerService customerService, IFoodService foodService, IConfigFile configFile
            ,IOrderService orderService)
        {
            InitializeComponent();

            _customerService = customerService;
            _orderService = orderService;
            _foodService = foodService;
            _configFile = configFile;
        }

        private void load_info()
        {
            free_number = Math.Max(1, _orderService.get_free_number());
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
            Size button_size = _configFile.get_button_size();

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

        private void add_item_to_order(int item_id)
        {
            var food = _foodService.select(s => s.ID == item_id).FirstOrDefault();

            if (food == null || food.ID <= 0)
                return;

            var order_item = _order_items.Where(s => s.FoodID == food.ID).FirstOrDefault();

            if (order_item == null || order_item.FoodID <= 0)
                _order_items.Add(new OrderItem() { FoodID = food.ID, Name = food.Name, Price = food.Price, Count = 1 });
            else
                order_item.Count++;

            show_order_list(_order_items);
        }

        private void show_order_list(BindingList<OrderItem> orderItems)
        {
            dt_gd_viw_orderlist.DataSource = orderItems;

            dt_gd_viw_orderlist.Columns["Name"].HeaderText = "غذا";
            dt_gd_viw_orderlist.Columns["Price"].HeaderText = "فی";
            dt_gd_viw_orderlist.Columns["Count"].HeaderText = "تعداد";
            dt_gd_viw_orderlist.Columns["All_Price"].HeaderText = "قیمت";
            
            dt_gd_viw_orderlist.Columns["Name"].ReadOnly = true;
            dt_gd_viw_orderlist.Columns["Price"].ReadOnly = true;
            dt_gd_viw_orderlist.Columns["Count"].ReadOnly = false;
            dt_gd_viw_orderlist.Columns["All_Price"].ReadOnly = true;

            dt_gd_viw_orderlist.Columns["Food"].Visible = false;
            dt_gd_viw_orderlist.Columns["FoodID"].Visible = false;
            dt_gd_viw_orderlist.Columns["ID"].Visible = false;

            update_order_show();
        }

        private void update_order_show()
        {
            dt_gd_viw_orderlist.Refresh();

            double sum_price = _order_items.Sum(s => s.All_Price);
            string txt = string.Format("{0:#,##0}", sum_price);

            lbl_order_number.Text = free_number.ToString();

            lbl_sum_price.Text = String.Format("{0} {1}", txt, _configFile.get_currency_title());
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string button_name = button.Name;
            string food_id_string = button_name.Replace(button_prefix_name, "");

            int food_id = 0;
            int.TryParse(food_id_string, out food_id);

            add_item_to_order(food_id);
        }

        private void Order_Load(object sender, EventArgs e)
        {
            _order_items = new BindingList<OrderItem>();

            load_info();

            show_foods(_foods);
            show_customers(_customers);
            show_order_list(_order_items);
        }

        private void dt_gd_viw_orderlist_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            OrderItem current = ((BindingList<OrderItem>)dt_gd_viw_orderlist.DataSource)[e.RowIndex];
            int new_count = 0;
            int.TryParse(e.Value.ToString(), out new_count);

            current.Count = new_count;

            update_order_show();
        }

        private void btn_save_order_Click(object sender, EventArgs e)
        {
            int customer_id = 0;
            int.TryParse(cmb_customers.SelectedValue.ToString(), out customer_id);

            if (customer_id <= 0)
                return;

            Order order = new Order()
            {
                CustomerID = customer_id,
                OrderItems = _order_items.ToList(),
                Number = free_number,
                Insert_time = DateTime.Now
            };

            bool register = _orderService.add(order);

            if (register)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
