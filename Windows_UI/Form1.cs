using CommonCodes;
using Domain.BaseClasses;
using Domain.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Form1 : SpecialForm
    {
        private IReportService _reportService;
        private ISendInformationService _sendInformationService;
        private IUnitOfWork _unitOfWork;
        private List<Customer> _customers = new List<Customer>();
        private Form _add_food;
        private Form _all_foods;
        private Form _add_foodoption;
        private Form _add_order;
        private Form _add_customer;
        private Form _person_debt;
        private Form _add_user;
        private Form _delete_order;
        private Form _edit_order;
        private Form _add_unit;
        private Form _add_ingredient;
        private Form _add_food_ingredient;
        private Form _add_foodoption_ingredient;
        private Form _report_ingredient;
        private Form _report_orders;

        public Form1(IReportService reportService
            , ISendInformationService sendInformationService
            , IUnitOfWork unitOfWork
            , [Dependency("add_food")] Form add_food
            , [Dependency("all_foods")] Form all_foods
            , [Dependency("add_foodoption")] Form add_foodoption
            , [Dependency("add_order")] Form add_order
            , [Dependency("edit_order")] Form edit_order
            , [Dependency("add_customer")] Form add_customer
            , [Dependency("person_debt")] Form person_debt
            , [Dependency("add_user")] Form add_user
            , [Dependency("delete_order")] Form delete_order
            , [Dependency("add_unit")] Form add_unit
            , [Dependency("add_ingredient")] Form add_ingredient
            , [Dependency("add_food_ingredient")] Form add_food_ingredient
            , [Dependency("add_foodoption_ingredient")] Form add_foodoption_ingredient
            , [Dependency("report_ingredient")] Form report_ingredient
            , [Dependency("report_orders")] Form report_orders
            , [Dependency("login_form")] Form login_form)            : base(login_form)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
            _edit_order = edit_order;
            _add_food = add_food;
            _all_foods = all_foods;
            _add_foodoption = add_foodoption;
            _add_order = add_order;
            _add_customer = add_customer;
            _person_debt = person_debt;
            _delete_order = delete_order;
            _add_unit = add_unit;
            _add_user = add_user;
            _add_ingredient = add_ingredient;
            _add_food_ingredient = add_food_ingredient;
            _add_foodoption_ingredient = add_foodoption_ingredient;
            _report_ingredient = report_ingredient;
            _report_orders = report_orders;
            _sendInformationService = sendInformationService;
            _reportService = reportService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _customers = _unitOfWork.Customers.GetAll().ToList();
        }

        private void add_food_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_food.ShowDialog();
        }

        private void add_order_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_order.ShowDialog();
        }

        private void add_customer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_customer.ShowDialog();
        }

        private void delete_order_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _delete_order.ShowDialog();
        }

        private void add_unit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_unit.ShowDialog();
        }

        private void add_ingredient_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_ingredient.ShowDialog();
        }

        private void add_ingredient_to_food_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_food_ingredient.ShowDialog();
        }

        private void report_ingredient_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _report_ingredient.ShowDialog();
        }

        private void report_orders_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _report_orders.ShowDialog();
        }

        private void add_user_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_user.ShowDialog();
        }

        private void edit_order_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _edit_order.ShowDialog();
        }

        private void add_foodoption_toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _add_foodoption.ShowDialog();
        }

        private void addingredienttofoodoptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_foodoption_ingredient.ShowDialog();
        }

        private void Btn_send_email_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>() { };
            DateTime date = DateTime.Now;
            string date_time = date.ToString("yyyy-MM-dd-HH-mm-ss");

            List<int> customers = new List<int>();

            List<Order> data = _reportService.Get_Orders_FromDate_ToDate_For_Some_Customers
                (date, date, customers);

            List<ConsumeViewModel> all_ingredients = _reportService.Get_Ingrediants_FromDate_ToDate(date, date);
                        
            List<FoodViewModel> all_consume = data.Extract_Food();

            List<ItemViewModel> payment_data = data.Create_Payment_Data();

            var dt_ingrediants = all_ingredients.convert_to_datatable(date, date);
            var dt_payment_data = data.convert_to_datatable(date, date, _customers);
            var dt_consumes = all_consume.convert_to_datatable(date, date, _customers);

            string ingrediant_path = string.Format("{0}-{1}.{2}", "Consume", date_time, "csv");
            string consume_path = string.Format("{0}-{1}.{2}", "Sales", date_time, "csv");
            string payment_path = string.Format("{0}-{1}.{2}", "Payment", date_time, "csv");

            if (dt_ingrediants != null && dt_ingrediants.Rows != null && dt_ingrediants.Rows.Count > 0)
            {
                dt_ingrediants.convert_object_to_csv(ingrediant_path);
                files.Add(ingrediant_path);
            }

            if (dt_payment_data != null && dt_payment_data.Rows != null && dt_payment_data.Rows.Count > 0)
            {
                dt_payment_data.convert_object_to_csv(payment_path);
                files.Add(payment_path);
            }

            if (dt_consumes != null && dt_consumes.Rows != null && dt_consumes.Rows.Count > 0)
            {
                dt_consumes.convert_object_to_csv(consume_path);
                files.Add(consume_path);
            }


            if (files != null && files.Count > 0)
                Task.Factory.StartNew(() => _sendInformationService.Send_Email(files));

            MessageBox.Show("گزارش با موفقیت ارسال شد");
        }

        private void Exit_app_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var is_confirmed = MessageBox.Show(null, "آیا برای خروج اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {
                LoginInfo.User = null;
                base.OnLoad(null);
            }
        }

        private void All_Foods_List_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _all_foods.ShowDialog();
        }

        private void PersonDebtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _person_debt.ShowDialog();
        }
    }
}
