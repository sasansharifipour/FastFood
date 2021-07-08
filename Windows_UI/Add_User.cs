using CommonCodes;
using Domain.BaseClasses;
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

namespace Windows_UI
{
    public partial class Add_User : Form
    {
        private IUserService _userService;

        public Add_User(IUserService userService)
        {
            InitializeComponent();

            _userService = userService;
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
                data = _userService.find(ID);
                data.Name = Name;
                data.Family = Family;
                data.Password = Password;
                register = _userService.update(data);
            }
            else
            {
                data = new User() { Name = Name, Family = Family, Password = Password };
                register = _userService.add(data);
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
            cmb_data_list.DisplayMember = "FullName";
            cmb_data_list.ValueMember = "ID";
            var data = _userService.select_active_items().ToList();

            data.Insert(0, new User() { ID = 0, Name = "افزودن", Family = "کاربر" });

            cmb_data_list.DataSource = data;
        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_customer_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_data_list.SelectedValue;

            var item = _userService.find(selected_id);

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
            txt_name.Focus();
        }

        private void set_data(User data)
        {
            txt_name.Text = data.Name;
            txt_family.Text = data.Family;
            txt_password.Text = "";
            txt_code.Text = data.ID.ToString();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {

                int selected_id = (int)cmb_data_list.SelectedValue;

                var item = _userService.find(selected_id);

                bool deleted = false;

                if (item == null || item.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                deleted = _userService.delete(item);

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
