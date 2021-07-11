using Service;
using System;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;
using System.ComponentModel;
using Domain.BaseClasses;
using System.Collections.Generic;
using CommonCodes;

namespace Windows_UI
{
    public partial class Delete_Order : Form
    {
        private IOrderService _orderService;
        private IConfigFile _configFile;
        private IPrintService _printService;
        private Order _order;

        public Delete_Order(IOrderService orderService,IConfigFile configFile, IPrintService printService)
        {
            InitializeComponent();

            _orderService = orderService;
            _configFile = configFile;
            _printService = printService;

            dat_tim_picker_order_date.Value = DateTime.Now;
        }

        [Obsolete]
        private void btn_search_Click(object sender, EventArgs e)
        {
            btn_print.Enabled = false;
            int order_number = 0;

            int.TryParse(txt_order_number.Text.Trim(), out order_number);

            DateTime selected_date = dat_tim_picker_order_date.Value.Value.Date;

            _order = _orderService.Eager_Select(s => s.Number == order_number && EntityFunctions.TruncateTime(s.Insert_time) ==
                EntityFunctions.TruncateTime(selected_date)).FirstOrDefault();

            if (_order == null)
            {
                _order = new Order();
                clean_form();
                return;
            }

            show_order(_order);
        }

        private void clean_form()
        {
            lbl_time.Text = "";
            lbl_sum_price.Text = "";
            lbl_order_number.Text = "";
            lbl_date.Text = "";
            lbl_customer_name.Text = "";
            lbl_order_status.Text = "";
            lbl_customer_code.Text = "";
            dt_gd_viw_orderlist.DataSource = null;
            dt_gd_viw_orderlist.Refresh();
        }

        private void show_order(Order order)
        {
            btn_print.Enabled = true;
            update_order_show(order);
            show_order_list(order.OrderItems);
        }

        private void show_order_list(List<OrderItem> orderItems)
        {
            dt_gd_viw_orderlist.DataSource = orderItems;

            dt_gd_viw_orderlist.Columns["Name"].HeaderText = "غذا";
            dt_gd_viw_orderlist.Columns["Price"].HeaderText = "فی";
            dt_gd_viw_orderlist.Columns["Count"].HeaderText = "تعداد";
            dt_gd_viw_orderlist.Columns["All_Price"].HeaderText = "قیمت";

            dt_gd_viw_orderlist.Columns["Name"].ReadOnly = true;
            dt_gd_viw_orderlist.Columns["Price"].ReadOnly = true;
            dt_gd_viw_orderlist.Columns["Count"].ReadOnly = true;
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

            dt_gd_viw_orderlist.Refresh();
        }

        private void update_order_show(Order order)
        {
            lbl_order_number.Text = order.Number.ToString();

            if (order.Deleted)
                lbl_order_status.Text = "حذف شده";
            else
                lbl_order_status.Text = "عادی";

            if (order.Customer == null)
                lbl_customer_name.Text = "ناشناس";
            else
                lbl_customer_name.Text = order.Customer.FullName;

            lbl_customer_code.Text = order.CustomerID.ToString();
            lbl_date.Text = order.Insert_time.ToPersianLongDateString();
            lbl_time.Text = order.Insert_time.ToLongTimeString();

            double sum_price = order.OrderItems.Sum(s => s.All_Price);
            string txt = string.Format("{0:#,##0}", sum_price);

            lbl_sum_price.Text = String.Format("{0} {1}", txt, _configFile.get_currency_title());
        }

        private void Delete_Order_Load(object sender, EventArgs e)
        {
            txt_order_number.Text = "";
            clean_form();
            txt_order_number.Select();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (_order == null || _order.ID <= 0)
            {
                MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {
                bool deleted = false;

                deleted = _orderService.delete(_order);

                if (deleted)
                {
                    MessageBox.Show(null, "اطلاعات با موفقیت حذف گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show_order(_order);
                }
                else
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            _printService.Print(_order);
        }
    }
}
