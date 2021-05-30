using Domain.BaseClasses;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Form1 : Form
    {
        private IOrderService _orderService;
        private IOrderItemService _orderItemService;

        public Form1(IOrderService orderService, IOrderItemService orderItemService)
        {
            InitializeComponent();

            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void add_food_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Food add_food_frm = new Add_Food();
            add_food_frm.ShowDialog();
        }
    }
}
