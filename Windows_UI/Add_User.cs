using CommonCodes;
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
    public partial class Add_User : SpecialForm
    {
        private IUnitOfWork _unitOfWork;

        public Add_User(IUnitOfWork unitOfWork
            , [Dependency("login_form")] Form login_form) : base(login_form)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
            Task.Factory.StartNew(load_info);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int ID = (int)cmb_data_list.SelectedValue;
            string Name = txt_name.Text.Trim();
            string Family = txt_family.Text.Trim();
            string Password = Hashing.Hash(txt_password.Text.Trim());
            User data;

            bool register = false;

            if (ID > 0)
            {
                data = _unitOfWork.Users.Get(ID);
                data.Name = Name;
                data.Family = Family;

                if (Password.Trim() == "")
                    Password = data.Password;

                data.Password = Password;
                data.Is_Admin = chb_Is_Admin.Checked;
                
            }
            else
            {
                if (Password.Trim() == "")
                    MessageBox.Show(null, "کلمه عبور را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _unitOfWork.Users.Add(new User()
                {
                    Name = Name,
                    Family = Family,
                    Password = Password,
                    Is_Admin = chb_Is_Admin.Checked
                });
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
            cmb_data_list.DisplayMember = "FullName";
            cmb_data_list.ValueMember = "ID";
            var data = _unitOfWork.Users.GetAll().ToList();

            data.Insert(0, new User() { ID = 0, Name = "افزودن", Family = "کاربر" });

            cmb_data_list.DataSource = data;

            if (LoginInfo.User == null)
                return;

            if (!LoginInfo.User.Is_Admin)
            {
                cmb_data_list.SelectedValue = LoginInfo.User.ID;
                cmb_data_list.Enabled = false;
                txt_name.Enabled = false;
                txt_family.Enabled = false;
                chb_Is_Admin.Enabled = false;
            }
            else
            {
                cmb_data_list.SelectedIndex = 0;
                cmb_data_list.Enabled = true;
                txt_name.Enabled = true;
                txt_family.Enabled = true;
                chb_Is_Admin.Enabled = true;
            }
        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_customer_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_data_list.SelectedValue == null)
                return;

            int selected_id = (int)cmb_data_list.SelectedValue;

            var item = _unitOfWork.Users.Get(selected_id);

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
            txt_password.Text = "";
            txt_code.Text = "";
            chb_Is_Admin.Checked = false;
            txt_name.Focus();
        }

        private void set_data(User data)
        {
            txt_name.Text = data.Name;
            txt_family.Text = data.Family;
            txt_password.Text = "";
            chb_Is_Admin.Checked = data.Is_Admin;
            txt_code.Text = data.ID.ToString();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {

                int selected_id = (int)cmb_data_list.SelectedValue;

                var item = _unitOfWork.Users.Get(selected_id);

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
