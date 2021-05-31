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

        public Form1(IOrderService orderService, IOrderItemService orderItemService, [Dependency("add_food")] Form add_food)
        {
            InitializeComponent();

            _orderService = orderService;
            _orderItemService = orderItemService;
            _add_food = add_food;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void add_food_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _add_food.ShowDialog();
        }
    }
}
