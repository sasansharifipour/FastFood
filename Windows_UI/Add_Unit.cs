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
    public partial class Add_Unit : Form
    {
        private IUnitService _UnitService;

        public Add_Unit(IUnitService UnitService)
        {
            InitializeComponent();

            _UnitService = UnitService;

            Task.Factory.StartNew(load_info);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int ID = (int)cmb_data_list.SelectedValue;
            string Unit_Name = txt_name.Text.Trim();
            Unit Unit;

            bool register = false;

            if (ID > 0)
            {
                Unit = _UnitService.find(ID);
                Unit.Name = Unit_Name;
                register = _UnitService.update(Unit);
            }
            else
            {
                Unit = new Unit() { Name = Unit_Name };
                register = _UnitService.add(Unit);
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
            cmb_data_list.DisplayMember = "Name";
            cmb_data_list.ValueMember = "ID";
            var data = _UnitService.select_active_items().ToList();

            data.Insert(0, new Unit() { ID = 0, Name = "افزودن یک آیتم جدید" });

            cmb_data_list.DataSource = data;
        }

        private void Add_Unit_Load(object sender, EventArgs e)
        {
            load_info();
            txt_name.Select();
        }

        private void cmb_Unit_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_data_list.SelectedValue;
            var Unit = _UnitService.find(selected_id);

            if (Unit == null || Unit.ID <= 0)
            {
                clean_form();
                return;
            }

            set_data(Unit);
        }

        private void clean_form()
        {
            txt_name.Text = "";
            txt_name.Focus();
        }

        private void set_data(Unit data)
        {
            txt_name.Text = data.Name;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {

                int selected_id = (int)cmb_data_list.SelectedValue;

                Unit Unit = _UnitService.find(selected_id);

                bool deleted = false;

                if (Unit == null || Unit.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                deleted = _UnitService.delete(Unit);

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
