using Service;
using System;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Delete_Order : Form
    {
        private IOrderService _orderService;

        public Delete_Order(IOrderService orderService)
        {
            InitializeComponent();

            _orderService = orderService;

            Application.CurrentCulture = new CultureInfo("fa-IR");
            dat_tim_picker_order_date.Format = DateTimePickerFormat.Custom;
            dat_tim_picker_order_date.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern;
        }

        [Obsolete]
        private void btn_search_Click(object sender, EventArgs e)
        {
            int order_number = 0;

            int.TryParse(txt_order_number.Text.Trim(), out order_number);

            DateTime selected_date = dat_tim_picker_order_date.Value.Date;

            var order = _orderService.Eager_Select(s => s.Number == order_number && EntityFunctions.TruncateTime(s.Insert_time) ==
                EntityFunctions.TruncateTime(selected_date)).FirstOrDefault();
        }

        private void Delete_Order_Load(object sender, EventArgs e)
        {
            txt_order_number.Focus();
        }
    }
}
