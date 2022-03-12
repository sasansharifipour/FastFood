using Domain.BaseClasses;
using Domain.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Report_Orders : Form
    {
        private IOrderService _orderService;
        private IConfigFile _configFile;
        private ICustomerService _customerService;
        private List<Customer> _customers = new List<Customer>();

        public Report_Orders(IOrderService orderService, IConfigFile configFile, ICustomerService customerService)
        {
            InitializeComponent();

            _orderService = orderService;
            _configFile = configFile;
            _customerService = customerService;

            dat_tim_picker_from_date.Value = DateTime.Now;
            dat_tim_picker_to_date.Value = DateTime.Now;

            dat_tim_picker_from_date.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            dat_tim_picker_from_date.CustomFormat = "dddd dd MMMM ماه yyyy";

            dat_tim_picker_to_date.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            dat_tim_picker_to_date.CustomFormat = "dddd dd MMMM ماه yyyy";
        }

        private void show_customers(List<Customer> customers, CheckedListBox checkedListBox)
        {
            checkedListBox.Items.Clear();

            foreach (var item in customers)
                checkedListBox.Items.Add(String.Format("{0}-{1}", item.ID, item.FullName));
        }

        private List<Customer> get_selected_customers(List<Customer> customers, CheckedListBox checkedListBox)
        {
            List<Customer> selected_customers = new List<Customer>();
            foreach (var item in checkedListBox.CheckedItems)
            {
                var item_title_list = item.ToString().Split('-');
                int id = 0;

                if (item_title_list != null && item_title_list.Length > 0)
                {
                    int.TryParse(item_title_list[0], out id);

                    var customer = customers.FirstOrDefault(s => s.ID == id);

                    if (customer != null || customer.ID > 0)
                        selected_customers.Add(customer);
                }
            }

            return selected_customers;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<Customer> selected_customers = get_selected_customers(_customers, chkblst_customers);
            DateTime from_date = dat_tim_picker_from_date.Value.Value.Date;
            DateTime to_date = dat_tim_picker_to_date.Value.Value.Date;

            double sum_price = 0;
            double discount = 0;

            var data = _orderService.Eager_Select(s => EntityFunctions.TruncateTime(s.Insert_time) >=
                EntityFunctions.TruncateTime(from_date) && EntityFunctions.TruncateTime(s.Insert_time) <=
                EntityFunctions.TruncateTime(to_date) && s.Deleted == false ).ToList();

            Dictionary<Food, FoodViewModel> foods = new Dictionary<Food, FoodViewModel>();

            if (data != null)
                foreach (var item in data)
                    if (selected_customers.Select(s => s.ID).Contains(item.Customer.ID))
                    {
                        discount += item.discount;

                        if (item.OrderItems != null)
                            foreach (var order_item in item.OrderItems)
                                if (order_item.Food != null)
                                {
                                    FoodViewModel model = new FoodViewModel();

                                    if (foods.ContainsKey(order_item.Food))
                                    {
                                        model = foods[order_item.Food];
                                        model.Count += order_item.Count;
                                        model.Price += order_item.Price * order_item.Count;
                                    }
                                    else
                                    {
                                        model.FoodName = order_item.Food.Name;
                                        model.Count = order_item.Count;
                                        model.Price = order_item.Price * order_item.Count;
                                    }

                                    foods[order_item.Food] = model;
                                }
                    }

            List<FoodViewModel> all_consume = new List<FoodViewModel>();


            foreach (var item in foods)
            {
                all_consume.Add(item.Value);
                sum_price += item.Value.Price;
            }

            dt_gd_viw_reportlist.DataSource = all_consume;
            dt_gd_viw_reportlist.Columns["FoodName"].HeaderText = "محصول";
            dt_gd_viw_reportlist.Columns["Count"].HeaderText = "مقدار";
            dt_gd_viw_reportlist.Columns["Price"].HeaderText = "قیمت";

            dt_gd_viw_reportlist.Columns["Price"].DefaultCellStyle.Format = "N0";

            dt_gd_viw_reportlist.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_reportlist.Columns["Count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_reportlist.Columns["FoodName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            string txt = string.Format("{0:#,##0}", sum_price);
            lbl_sum_price.Text = String.Format("{0} {1}", txt, _configFile.get_currency_title());

            string discount_txt = string.Format("{0:#,##0}", discount);
            lbl_sum_discount.Text = String.Format("{0} {1}", discount_txt, _configFile.get_currency_title());

            string all_paying_txt = string.Format("{0:#,##0}", sum_price - discount);
            lbl_sum_paying.Text = String.Format("{0} {1}", all_paying_txt, _configFile.get_currency_title());
        }

        private void Report_Orders_Load(object sender, EventArgs e)
        {
            _customers = _customerService.select_active_items().ToList();
            show_customers(_customers, chkblst_customers);
        }
    }
}
