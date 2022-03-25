using CommonCodes;
using Domain.BaseClasses;
using Domain.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Report_Orders : Form
    {
        private IOrderService _orderService;
        private IConfigFile _configFile;
        private ICustomerService _customerService;
        private IReportService _reportService;
        private List<Customer> _customers = new List<Customer>();

        public Report_Orders(IOrderService orderService, IReportService reportService, IConfigFile configFile, ICustomerService customerService)
        {
            InitializeComponent();

            _reportService = reportService;
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

            if (selected_customers.Count <= 0)
                selected_customers = customers.ToList();

            return selected_customers;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<Customer> selected_customers = get_selected_customers(_customers, chkblst_customers);
            DateTime from_date = dat_tim_picker_from_date.Value.Value.Date;
            DateTime to_date = dat_tim_picker_to_date.Value.Value.Date;

            List<int> customers = selected_customers.Select(s => s.ID).ToList();

            List<Order> data = _reportService.Get_Orders_FromDate_ToDate_For_Some_Customers
                (from_date, to_date, customers);

            List<FoodViewModel> all_consume = data.Extract_Food();
            
            List<ItemViewModel> payment_data = data.Create_Payment_Data();

            fill_dt_gd_viw_report(all_consume);
            fill_dt_gd_viw_payment(payment_data);

            var dt_payment_data = payment_data.convert_to_datatable();
            dt_payment_data.convert_object_to_csv("test.csv");

            Task.Factory.StartNew(() => Email());
        }

        private void fill_dt_gd_viw_report(List<FoodViewModel> all_consume)
        {
            dt_gd_viw_reportlist.DataSource = all_consume;
            dt_gd_viw_reportlist.Columns["FoodName"].HeaderText = "محصول";
            dt_gd_viw_reportlist.Columns["Count"].HeaderText = "مقدار";
            dt_gd_viw_reportlist.Columns["Price"].HeaderText = "قیمت";

            dt_gd_viw_reportlist.Columns["Price"].DefaultCellStyle.Format = "N0";

            dt_gd_viw_reportlist.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_reportlist.Columns["Count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_reportlist.Columns["FoodName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void fill_dt_gd_viw_payment(List<ItemViewModel> payment_data)
        {
            dt_gd_viw_payment_data.DataSource = payment_data;
            dt_gd_viw_payment_data.Columns["Name"].HeaderText = "عنوان";
            dt_gd_viw_payment_data.Columns["Value"].HeaderText = "مقدار";

            dt_gd_viw_payment_data.Columns["Value"].DefaultCellStyle.Format = "N0";

            dt_gd_viw_payment_data.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_payment_data.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void Email()
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("chichi.fastfood.business@gmail.com");
                message.To.Add(new MailAddress("sasansharifipour@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true;  
                message.Body = "Test";
                message.Attachments.Add(new Attachment("test.csv"));
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";                
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("chichi.fastfood.business@gmail.com", "koad xnpq pbod vtbc");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }

        private void Report_Orders_Load(object sender, EventArgs e)
        {
            _customers = _customerService.select_active_items().ToList();
            show_customers(_customers, chkblst_customers);
        }
    }
}
