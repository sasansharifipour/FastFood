using DTO;
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
        private IUnitOfWork _unitOfWork;

        public Show_All_Foods(IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
        }

        private void Show_All_Foods_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _unitOfWork.Foods.GetAll().ToList();

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

                var food = _unitOfWork.Foods.Get(ID);
                food.Name = Name;
                food.Price = Price;
                food.Deleted = Deleted;

                _unitOfWork.Complete();
            }
            catch(Exception)
            {
                MessageBox.Show("خطایی رخ داده است");
            }
        }
    }
}
