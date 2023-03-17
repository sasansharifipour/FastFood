using Domain.BaseClasses;
using PosInterface;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Add_Order : SpecialForm
    {
        private IUnitOfWork _unitOfWork;
        private IEnumerable<Food> _foods = new List<Food>();
        private IEnumerable<Customer> _customers;
        private string button_prefix_name = "food_button_";
        private string special_button_prefix_name = "special_food_button_";
        private BindingList<OrderItem> _order_items;
        private IConfigService _configFile;
        private IPrintService _printService;
        private Form _delete_order;
        private Form _edit_order;
        private Create_Special_Food _Special_Food;
        private Order _saved_order;
        PCPos pcpos = new PCPos();
        ITransactionDoneAdvanceHandler _posResult;

        int free_number = 0;

        public Add_Order( IConfigService configFile
            , [Dependency("delete_order")] Form delete_order
            , [Dependency("edit_order")] Form edit_order
            , IUnitOfWork unitOfWork
            , Create_Special_Food special_Food
            , ITransactionDoneAdvanceHandler posResult
            , IPrintService printService
            , [Dependency("login_form")] Form login_form)
            : base(login_form)
        {
            _configFile = configFile;
            _delete_order = delete_order;
            _printService = printService;
            _edit_order = edit_order;
            _Special_Food = special_Food;
            _unitOfWork = unitOfWork;

            _posResult = posResult;

            InitializeComponent();

            Task.Factory.StartNew(load_info);

            pcpos.InitLAN("192.168.1.40", 17000);
        }

        private void load_info()
        {
            get_free_number();
            _foods = _unitOfWork.Foods.GetAll().ToList();
            _customers = _unitOfWork.Customers.GetAll().ToList();
        }

        private void show_customers(IEnumerable<Customer> customers)
        {
            cmb_customers.DataSource = customers;
            cmb_customers.DisplayMember = "FullName";
            cmb_customers.ValueMember = "ID";
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

                string price = string.Format("{0:#,##0}", item.Price);
                button.Text = String.Format("{0} - {1}", item.Name, price);
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

        private void Button_special_Click(object sender, EventArgs e)
        {
            try
            {
                _Special_Food.remove_all_listeners();
            }
            catch
            {
            }
            _Special_Food.select_food_Event += _Special_Food_select_food_Event;

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

        private void add_item_to_order(int item_id)
        {
            var food = _unitOfWork.Foods.Get(item_id);

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
                    Count = 1,
                    FoodOptions = _unitOfWork.FoodOptions.Find(s => s.DefaultExist).ToList()
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
            string net_price_txt = string.Format("{0:#,##0}", net_price);

            lbl_order_number.Text = free_number.ToString();

            lbl_sum_price.Text = String.Format("{0} {1}", txt, _configFile.get_currency_title());
            lbl_net_price.Text = String.Format("{0} {1}", net_price_txt, _configFile.get_currency_title());

            TB_Paying.Text = net_price_txt;


            if (chb_credit.Checked)
                TB_Paying.Text = "";
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
            catch {
            }

            _Special_Food.select_food_Event += _Special_Food_select_food_Event;
            _order_items = new BindingList<OrderItem>();

            load_info();

            show_foods(_foods);
            show_customers(_customers);
            show_order_list(_order_items);

            chb_credit.Checked = false;
            chb_Is_Serving_In_Saloon.Checked = false;
            TB_discount.Text = "";
        }

        private void dt_gd_viw_orderlist_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            OrderItem current = ((BindingList<OrderItem>)dt_gd_viw_orderlist.DataSource)[e.RowIndex];
            int new_count = 0;
            int.TryParse(e.Value.ToString(), out new_count);

            current.Count = new_count;
        }

        private void get_free_number()
        {
            free_number = Math.Max(1, _unitOfWork.Orders.get_free_number());

            lbl_order_number.Text = free_number.ToString();
        }

        private void btn_save_order_Click(object sender, EventArgs e)
        {
            _saved_order = null;
            btn_print.Enabled = false;
            btn_cart_eghtesad.Enabled = false;

            bool credit = chb_credit.Checked;

            int customer_id = 0;
            int.TryParse(cmb_customers.SelectedValue.ToString(), out customer_id);

            int discount = 0;
            int.TryParse(TB_discount.Text.Replace(",","").Trim(), out discount);

            int paying_amount = 0;
            int.TryParse(TB_Paying.Text.Replace(",", "").Trim(), out paying_amount);

            get_free_number();

            if (customer_id <= 0)
                return;

            Order order = new Order()
            {
                CustomerID = customer_id,
                Is_Serving_In_Saloon = chb_Is_Serving_In_Saloon.Checked,
                OrderItems = get_order_items(_order_items),
                Number = free_number,
                discount = discount,
                credit = credit,
                User_Registered = LoginInfo.User,
                paying_amount = paying_amount,
                Insert_time = DateTime.Now
            };

            _unitOfWork.Orders.Add(order);

            bool register = _unitOfWork.Complete() > 0 ? true : false;

            if (register)
            {
                _saved_order = order;
                btn_print.Enabled = true;
                btn_cart_eghtesad.Enabled = true;
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

        private void btn_new_order_Click(object sender, EventArgs e)
        {
            _saved_order = null;
            btn_print.Enabled = false;
            btn_cart_eghtesad.Enabled = false;
            TB_discount.Text = "";
            chb_credit.Checked = false;
            chb_Is_Serving_In_Saloon.Checked = false;
            free_number = _unitOfWork.Orders.get_free_number();
            _order_items = new BindingList<OrderItem>();

            show_order_list(_order_items);
            update_order_show();
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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            _edit_order.ShowDialog();
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
        }

        private void Pnl_Foods_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_cart_eghtesad_Click(object sender, EventArgs e)
        {

            if (PCPos.IsExecutionInProgress)
            {
                MessageBox.Show("دستگاه کارتخوان مشغول است");
                return;
            }

            _posResult.set_order(_saved_order);
            pcpos.DoASyncPayment(_saved_order.paying_amount.ToString(),"", "", DateTime.Now, _posResult);
        }
    }

    public interface ITransactionDoneAdvanceHandler : ITransactionDoneHandler
    {
        void set_order(Order saved_order);
    }

    public class PosResult : ITransactionDoneAdvanceHandler
    {
        private Order _saved_order;
        private PrintService _printService;
        private IUnitOfWork _unitOfWork;

        public PosResult(PrintService printService, IUnitOfWork unitOfWork)
        {
            _printService = printService;
            _unitOfWork = unitOfWork;
        }

        public void set_order(Order saved_order)
        {
            _saved_order = saved_order;
        }

        public void OnFinish(string message)
        {
            //MessageBox.Show(message);
        }

        public void OnTransactionDone(TransactionResult result)
        {
            try
            {
                _unitOfWork.PosTransactionResults.Add(new PosTransactionResult()
                {
                    OrderID = _saved_order.ID,
                    TranType = result.TranType,
                    MerchantId = result.MerchantId,
                    MessageId = result.MessageId,
                    PaymentAmount = result.PaymentAmount,
                    RRN = result.RRN,
                    Stan = result.Stan,
                    ErrorMsg = result.ErrorMsg,
                    ErrorCode = result.ErrorCode,
                    CardNumber = result.CardNumber,
                    DateTime = result.DateTime,
                    TerminalId = result.TerminalId,
                    SoftwareExecutionTime = DateTime.Now
                });

                _unitOfWork.Complete();
            }
            catch(Exception ex)
            {
            }

            if (result.ErrorCode == 0 && result.ErrorMsg == "تراکنش موفق")
            {
                var result_button = MessageBox.Show("تراکنش موفق به مبلغ : " + result.PaymentAmount + " پرینت سفارش چاپ شود؟", "موفق", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result_button == DialogResult.Yes)
                {
                    _printService.Print(_saved_order);
                }
            }
            else
            {
                MessageBox.Show("تراکنش ناموفق بود : " + result.ErrorMsg, "خظا" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
