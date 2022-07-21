using Domain.BaseClasses;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Person_Debt : Form
    {
        private IEnumerable<Customer> _customers;
        private ICustomerService _customerService;
        private IOrderService _orderService;

        public Person_Debt(ICustomerService customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;

            InitializeComponent();

            Task.Factory.StartNew(load_info);
        }

        private void Person_Debt_Load(object sender, EventArgs e)
        {
            load_info();

            show_customers(_customers);
        }

        private void show_customers(IEnumerable<Customer> customers)
        {
            cmb_customers.DataSource = customers;
            cmb_customers.DisplayMember = "FullName";
            cmb_customers.ValueMember = "ID";
        }

        private void load_info()
        {
            _customers = _customerService.select_active_items();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (cmb_customers.SelectedValue != null && (int)cmb_customers.SelectedValue > 0)
            {
                int customer_id = (int)cmb_customers.SelectedValue;

                var orders = _orderService.Eager_Select(s => s.CustomerID == customer_id).ToList();

                var result = orders.Calculate_Debt();

                lbl_Payable_Amount.Text = string.Format("{0:#,##0}", result.payable_amount);
                lbl_Paying_Amount.Text = string.Format("{0:#,##0}", result.paying_amount);
                lbl_debt.Text = string.Format("{0:#,##0}", result.debt_by_paying);

                if (result.debt_by_paying != result.debt_by_credit_amount)
                    MessageBox.Show("خطای بسیار مهمی در برنامه رخ داده لطفا همین الان با 09120245247 تماس بگیرید.");
            }
        }
    }
}
