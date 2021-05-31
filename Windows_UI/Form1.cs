using Domain.BaseClasses;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Form1 : Form
    {
        private IOrderService _orderService;
        private IOrderItemService _orderItemService;
        private Form _add_food;
        private Form _add_order;

        public Form1(IOrderService orderService
            , IOrderItemService orderItemService
            , [Dependency("add_food")] Form add_food
            , [Dependency("add_order")] Form add_order)
        {
            InitializeComponent();

            _orderService = orderService;
            _orderItemService = orderItemService;
            _add_food = add_food;
            _add_order = add_order;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void add_food_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_food.ShowDialog();
        }

        private void add_order_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_order.ShowDialog();
        }
    }
}
