using CommonCodes;
using Domain.BaseClasses;
using Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Edit_Order : Form
    {
        private ICustomerService _customerService;
        private IFoodService _foodService;
        private IFoodOptionService _foodOptionService;
        private IEnumerable<Food> _foods = new List<Food>();
        private IEnumerable<Customer> _customers;
        private string button_prefix_name = "food_button_";
        private string special_button_prefix_name = "special_food_button_";
        private BindingList<OrderItem> _order_items;
        private List<OrderItem> _first_order_items = new List<OrderItem>();
        private IConfigService _configFile;
        private IOrderService _orderService;
        private IPrintService _printService;
        private Form _delete_order;
        private Order _saved_order;
        private Order _first_order;
        private Create_Special_Food _Special_Food;

        public Edit_Order(ICustomerService customerService, IFoodService foodService, IConfigService configFile
            , IOrderService orderService, [Dependency("delete_order")] Form delete_order
            , [Dependency("login_form")] Form login_form
            , IFoodOptionService foodOptionService
            , Create_Special_Food special_Food
            , IPrintService printService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _foodService = foodService;
            _configFile = configFile;
            _delete_order = delete_order;
            _printService = printService;
            _Special_Food = special_Food;
            _foodOptionService = foodOptionService;

            InitializeComponent();

            dat_tim_picker_order_date.Value = DateTime.Now;
            Task.Factory.StartNew(load_info);
        }

        private void load_info()
        {
            _foods = _foodService.select_active_items();
            _customers = _customerService.select_active_items();
        }

        private void show_customers(IEnumerable<Customer> customers)
        {
            cmb_customers.DataSource = customers;
            cmb_customers.DisplayMember = "FullName";
            cmb_customers.ValueMember = "ID";
        }

        private void Button_special_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string button_name = button.Name;
            string food_id_string = button_name.Replace(special_button_prefix_name, "");

            int food_id = 0;
            int.TryParse(food_id_string, out food_id);

            _Special_Food.set_food_id(food_id);
            _Special_Food.ShowDialog();
        }

        private void _Special_Food_select_food_Event(OrderItem orderItem)
        {
            var order_item = _order_items.Where(s => s.FoodID == orderItem.FoodID && s.Name == orderItem.Name
            && s.Price == orderItem.Price).FirstOrDefault();

            if (order_item == null || order_item.FoodID <= 0)
                _order_items.Add(orderItem);
            else
                order_item.Count++;

            show_order_list(_order_items);
        }

        private void show_foods(IEnumerable<Food> foods)
        {
            pnl_Foods.Controls.Clear();

            Size button_size = _configFile.get_button_size();
            Size special_button_size = _configFile.get_special_button_size();

            int width = pnl_Foods.Width;
            int height = pnl_Foods.Height;

            int x = 10;
            int y = 10;

            foreach (var item in foods)
            {
                Button button = new Button();
                Button button_special = new Button();

                button.Text = item.Name;
                button.Name = String.Format("{0}{1}", button_prefix_name, item.ID.ToString());
                button_special.Text = "..";
                button_special.Name = String.Format("{0}{1}", special_button_prefix_name, item.ID.ToString());

                button.Click += Button_Click;
                button.Size = button_size;
                button_special.Click += Button_special_Click;
                button_special.Size = special_button_size;
                button_special.BackgroundImage = global::Windows_UI.Properties.Resources.download;
                button_special.BackgroundImageLayout = ImageLayout.Stretch;

                if (x + button_size.Width >= width)
                {
                    x = 10;
                    y += button_size.Height + 10;
                }

                button.Location = new Point(x, y);
                button_special.Location = new Point(x + button_size.Width - special_button_size.Width
                    , y + button_size.Height - special_button_size.Height);

                pnl_Foods.Controls.Add(button_special);
                pnl_Foods.Controls.Add(button);

                x += button_size.Width + 10;
            }
        }

        private void add_item_to_order(int item_id)
        {
            var food = _foodService.select(s => s.ID == item_id).FirstOrDefault();

            if (food == null || food.ID <= 0)
                return;

            var order_item = _order_items.Where(s => s.FoodID == food.ID && s.Name == food.Name
            && s.Price == food.Price).FirstOrDefault();

            if (order_item == null || order_item.FoodID <= 0)
                _order_items.Add(new OrderItem()
                {
                    FoodID = food.ID,
                    Name = food.Name,
                    Price = food.Price,
                    Count = 1 ,
                    FoodOptions = _foodOptionService.select_active_items().Where(s => s.DefaultExist).ToList()
                });
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
            dt_gd_viw_orderlist.Columns["Deleted"].Visible = false;
            dt_gd_viw_orderlist.Columns["FoodID"].Visible = false;
            dt_gd_viw_orderlist.Columns["ID"].Visible = false;

            dt_gd_viw_orderlist.Columns["All_Price"].DefaultCellStyle.Format = "N0";
            dt_gd_viw_orderlist.Columns["Price"].DefaultCellStyle.Format = "N0";

            dt_gd_viw_orderlist.Columns["All_Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dt_gd_viw_orderlist.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_orderlist.Columns["Count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_orderlist.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            update_order_show();
        }

        private void remove_zero_count_order_items()
        {
            List<OrderItem> order_item_should_removes = _order_items.Where(x => (x.Count <= 0)).ToList();

            foreach (OrderItem item in order_item_should_removes)
                _order_items.Remove(item);
        }

        private void update_order_show()
        {
            remove_zero_count_order_items();

            dt_gd_viw_orderlist.Refresh();

            double discount = 0;
            double.TryParse(TB_discount.Text.Trim(), out discount);

            double sum_price = _order_items.Sum(s => Math.Abs(s.All_Price));
            double net_price = sum_price - discount;

            string txt = string.Format("{0:#,##0}", sum_price);
            lbl_sum_price.Text = String.Format("{0} {1}", txt, _configFile.get_currency_title());

            string net_price_txt = string.Format("{0:#,##0}", net_price);
            lbl_sum_price.Text = String.Format("{0} {1}", txt, _configFile.get_currency_title());
            lbl_net_price.Text = String.Format("{0} {1}", net_price_txt, _configFile.get_currency_title());

            
            if (_saved_order != null)
                    TB_Paying.Text = _saved_order.paying_amount.ToString();

            TB_Paying.Text = net_price_txt;
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
            try
            {
                _Special_Food.remove_all_listeners();
            }
            catch { }

            _Special_Food.select_food_Event += _Special_Food_select_food_Event;
            _order_items = new BindingList<OrderItem>();

            load_info();

            show_foods(_foods);
            show_customers(_customers);
            show_order_list(_order_items);

            chb_credit.Checked = false;
            TB_discount.Text = "";
        }

        private void dt_gd_viw_orderlist_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            OrderItem current = ((BindingList<OrderItem>)dt_gd_viw_orderlist.DataSource)[e.RowIndex];
            int new_count = 0;
            int.TryParse(e.Value.ToString(), out new_count);

            current.Count = new_count;
        }

        private void btn_save_order_Click(object sender, EventArgs e)
        {
            if (_saved_order == null)
                return;

            btn_print.Enabled = false;

            bool credit = chb_credit.Checked;

            int customer_id = 0;
            int.TryParse(cmb_customers.SelectedValue.ToString(), out customer_id);

            int discount = 0;
            int.TryParse(TB_discount.Text.Replace(",", "").Trim(), out discount);

            int paying_amount = 0;
            int.TryParse(TB_Paying.Text.Replace(",", "").Trim(), out paying_amount);

            if (customer_id <= 0)
                return;

            _saved_order.paying_amount = paying_amount;
            _saved_order.CustomerID = customer_id;
            _saved_order.discount = discount;
            _saved_order.credit = credit;

            _saved_order.OrderItems = get_order_items(_order_items);

            bool register = _orderService.update(_saved_order);

            if (register)
            {
                btn_print.Enabled = true;
                _first_order = (Order)_saved_order.Clone();
                _first_order_items = _saved_order.OrderItems;
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<OrderItem> get_order_items(BindingList<OrderItem> order_items)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var item in order_items)
            {
                orderItems.Add(new OrderItem()
                {
                    ID = item.ID,
                    Count = item.Count,
                    Deleted = item.Deleted,
                    Food = item.Food,
                    FoodID = item.FoodID,
                    Name = item.Name,
                    Price = item.Price,
                    FoodOptions = item.FoodOptions
                });
            }

            return orderItems;
        }

        private void dt_gd_viw_orderlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            update_order_show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            _delete_order.ShowDialog();
        }

        private void Add_Order_Resize(object sender, EventArgs e)
        {
            show_foods(_foods);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            _printService.Print(_saved_order);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            btn_print.Enabled = false;
            int order_number = 0;

            int.TryParse(txt_order_number.Text.Trim(), out order_number);

            DateTime selected_date = dat_tim_picker_order_date.Value.Value.Date;

            _saved_order = _orderService.Eager_Select(s => s.Number == order_number && EntityFunctions.TruncateTime(s.Insert_time) ==
                EntityFunctions.TruncateTime(selected_date)).FirstOrDefault();

            if (_saved_order == null)
            {
                _saved_order = new Order();
                clean_form();
                return;
            }
            _first_order = _saved_order;
            _first_order_items = (List<OrderItem>)_first_order.OrderItems.Clone<OrderItem>();
            show_order(_saved_order);
        }

        private void clean_form()
        {
            lbl_sum_price.Text = "";
            TB_discount.Text = "";
            TB_Paying.Text = "";

            chb_credit.Checked = false;
            dt_gd_viw_orderlist.DataSource = null;
            dt_gd_viw_orderlist.Refresh();
        }

        private void show_order(Order order)
        {
            _order_items = new BindingList<OrderItem>(order.OrderItems);
            _saved_order = order;
            cmb_customers.SelectedValue = order.CustomerID;
            TB_discount.Text = order.discount.ToString();
            chb_credit.Checked = order.credit;
            TB_Paying.Text = order.paying_amount.ToString();

            btn_print.Enabled = true;
            show_order_list(_order_items);
        }

        private void Edit_Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _saved_order = _first_order;
                _saved_order.OrderItems = _first_order_items;
                _order_items = new BindingList<OrderItem>(_first_order_items);
            }
            catch (Exception ex) { }
        }

        private void TB_discount_TextChanged(object sender, EventArgs e)
        {
            string text = TB_discount.Text;
            double value = 0;
            double.TryParse(text, out value);
            string txt = string.Format("{0:#,##0}", value);

            if (txt.Trim() == "0")
                txt = "";

            TB_discount.Text = txt;
            TB_discount.Select(TB_discount.Text.Length, 0);

            update_order_show();
        }

        private void TB_Paying_TextChanged(object sender, EventArgs e)
        {
            string text = TB_Paying.Text;
            double value = 0;
            double.TryParse(text, out value);
            string txt = string.Format("{0:#,##0}", value);

            if (txt.Trim() == "0")
                txt = "";

            TB_Paying.Text = txt;
            TB_Paying.Select(TB_Paying.Text.Length, 0);
        }

        private void Chb_credit_CheckedChanged(object sender, EventArgs e)
        {
            update_order_show();

            if (chb_credit.Checked)
                TB_Paying.Text = "";
        }
    }
}
