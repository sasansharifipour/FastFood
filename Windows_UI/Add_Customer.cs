using Domain.BaseClasses;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Add_Customer : Form
    {
        private ICustomerService _customerService; 

        public Add_Customer(ICustomerService customerService)
        {
            InitializeComponent();

            _customerService = customerService;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int ID = (int)cmb_customer_list.SelectedValue;
            Customer data = new Customer()
            {
                Name = txt_name.Text.Trim(),
                Family = txt_family.Text.Trim(),
                Mobile = txt_mobile.Text.Trim(),
                Address = txt_address.Text.Trim()
            };

            bool register = false;

            if (ID > 0)
            {
                data.ID = ID;
                register = _customerService.update(data);
            }
            else
            {
                register = _customerService.add(data);
            }

            if (register)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_info();
                clean_form();
            }
            else
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load_info()
        {
            cmb_customer_list.DisplayMember = "FullName";
            cmb_customer_list.ValueMember = "ID";
            var data = _customerService.select_active_items().ToList();

            data.Insert(0, new Customer() { ID = 0, Name = "افزودن", Family = "مشتری" });

            cmb_customer_list.DataSource = data;
        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_customer_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_customer_list.SelectedValue;

            var item = _customerService.find(selected_id);

            if (item == null || item.ID <= 0)
            {
                clean_form();
                return;
            }

            set_data(item);
        }

        private void clean_form()
        {
            txt_name.Text = "";
            txt_family.Text = "";
            txt_mobile.Text = "";
            txt_address.Text = "";
            txt_name.Focus();
        }

        private void set_data(Customer data)
        {
            txt_name.Text = data.Name;
            txt_family.Text = data.Family;
            txt_mobile.Text = data.Mobile;
            txt_address.Text = data.Address;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {

                int selected_id = (int)cmb_customer_list.SelectedValue;

                Customer item = _customerService.find(selected_id);

                bool deleted = false;

                if (item == null || item.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                deleted = _customerService.delete(item);

                if (deleted)
                {
                    MessageBox.Show(null, "اطلاعات با موفقیت حذف گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_info();
                    clean_form();
                }
                else
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
