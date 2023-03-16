using Domain.BaseClasses;
using DTO;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Add_Customer : SpecialForm
    {
        private IUnitOfWork _unitOfWork;

        public Add_Customer(IUnitOfWork unitOfWork, [Dependency("login_form")] Form login_form) 
            : base(login_form)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
            Task.Factory.StartNew(load_info);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int ID = (int)cmb_customer_list.SelectedValue;
            string Name = txt_name.Text.Trim();
            string Family = txt_family.Text.Trim();
            string Mobile = txt_mobile.Text.Trim();
            string Address = txt_address.Text.Trim();
            Customer data;

            bool register = false;

            if (ID > 0)
            {
                data = _unitOfWork.Customers.Get(ID);
                data.Name = Name;
                data.Family = Family;
                data.Mobile = Mobile;
                data.Address = Address;
            }
            else
            {
                data = new Customer() { Name = Name, Family  = Family, Mobile = Mobile, Address = Address };
                _unitOfWork.Customers.Add(data);
            }

            register = _unitOfWork.Complete() > 0 ? true : false;
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
            var data = _unitOfWork.Customers.Find(s => !s.Deleted).ToList();

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

            var item = _unitOfWork.Customers.Get(selected_id);

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

                Customer item = _unitOfWork.Customers.Get(selected_id);

                bool deleted = false;

                if (item == null || item.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                item.Deleted = true;
                deleted = _unitOfWork.Complete() > 0 ? true : false;

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
