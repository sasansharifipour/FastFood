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
        private Form _add_customer;
        private Form _delete_order;
        private Form _add_unit;

        public Form1(IOrderService orderService
            , IOrderItemService orderItemService
            , [Dependency("add_food")] Form add_food
            , [Dependency("add_order")] Form add_order
            , [Dependency("add_customer")] Form add_customer
            , [Dependency("delete_order")] Form delete_order
            , [Dependency("add_unit")] Form add_unit)
        {
            InitializeComponent();

            _orderService = orderService;
            _orderItemService = orderItemService;
            _add_food = add_food;
            _add_order = add_order;
            _add_customer = add_customer;
            _delete_order = delete_order;
            _add_unit = add_unit;
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
    }
}
