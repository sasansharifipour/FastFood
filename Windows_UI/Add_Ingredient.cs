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
using Domain.BaseClasses;

namespace Windows_UI
{
    public partial class Add_Ingredient : Form
    {
        private IIngredientService _IngredientService;
        private IUnitService _unitService;

        public Add_Ingredient(IIngredientService IngredientService, IUnitService unitService)
        {
            InitializeComponent();

            _IngredientService = IngredientService;
            _unitService = unitService;

            Task.Factory.StartNew(load_info);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int ID = (int)cmb_data_list.SelectedValue;
            int unit_id = (int)cmb_unit_list.SelectedValue;

            if (unit_id <= 0)
            {
                MessageBox.Show(null, "واحد شمارش به درستی انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ingredient Ingredient = new Ingredient() { Name = txt_name.Text.Trim(), UnitID = unit_id };

            bool register = false;

            if (ID > 0)
            {
                Ingredient.ID = ID;
                register = _IngredientService.update(Ingredient);
            }
            else
            {
                register = _IngredientService.add(Ingredient);
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
            var data = _IngredientService.select_active_items().ToList();
            data.Insert(0, new Ingredient() { ID = 0, Name = "افزودن آیتم جدید"});
            cmb_data_list.DataSource = data;

            cmb_unit_list.DisplayMember = "Name";
            cmb_unit_list.ValueMember = "ID";
            cmb_unit_list.DataSource = _unitService.select_active_items().ToList();
        }

        private void Add_Ingredient_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_data_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_data_list.SelectedValue;
            var Ingredient = _IngredientService.find(selected_id);

            if (Ingredient == null || Ingredient.ID <= 0)
            {
                clean_form();
                return;
            }

            set_data(Ingredient);
        }

        private void clean_form()
        {
            txt_name.Text = "";
            cmb_unit_list.SelectedIndex = -1;
            txt_name.Focus();
        }

        private void set_data(Ingredient data)
        {
            txt_name.Text = data.Name;
            cmb_unit_list.SelectedValue = data.UnitID;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var is_confirmed = MessageBox.Show(null, "آیا از حذف این آیتم اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (is_confirmed == DialogResult.Yes)
            {

                int selected_id = (int)cmb_data_list.SelectedValue;

                Ingredient Ingredient = _IngredientService.find(selected_id);

                bool deleted = false;

                if (Ingredient == null || Ingredient.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                deleted = _IngredientService.delete(Ingredient);

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
