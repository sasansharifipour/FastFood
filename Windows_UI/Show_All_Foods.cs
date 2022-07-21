using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Show_All_Foods : Form
    {
        private IFoodService _foodService;

        public Show_All_Foods(IFoodService foodService)
        {
            InitializeComponent();

            _foodService = foodService;
        }

        private void Show_All_Foods_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _foodService.select_active_items();

            dataGridView1.Columns["ID"].HeaderText = "کد محصول";
            dataGridView1.Columns["Name"].HeaderText = "نام محصول";
            dataGridView1.Columns["Price"].HeaderText = "قیمت";
            dataGridView1.Columns["Deleted"].HeaderText = "حذف بشود؟";

            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "N0";
        }
        
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                    return;

                var drv = dataGridView1.CurrentRow;

                int ID = (int)drv.Cells["ID"].Value;
                string Name = drv.Cells["Name"].Value.ToString();
                double Price = (double)drv.Cells["Price"].Value;
                bool Deleted = (bool)drv.Cells["Deleted"].Value;

                _foodService.update(new Domain.BaseClasses.Food()
                {
                    ID = ID,
                    Name = Name,
                    Price = Price,
                    Deleted = Deleted
                });
            }
            catch(Exception)
            {
                MessageBox.Show("خطایی رخ داده است");
            }
        }
    }
}
