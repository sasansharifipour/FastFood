using Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.BaseClasses;
using Unity;

namespace Windows_UI
{
    public partial class Add_Ingredient : SpecialForm
    {
        private IUnitOfWork _unitOfWork;

        public Add_Ingredient(IUnitOfWork unitOfWork
            , [Dependency("login_form")] Form login_form)
            : base(login_form)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;

            Task.Factory.StartNew(load_info);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int ID = (int)cmb_data_list.SelectedValue;
            int unit_id = (int)cmb_unit_list.SelectedValue;
            string Name = txt_name.Text.Trim();

            if (unit_id <= 0)
            {
                MessageBox.Show(null, "واحد شمارش به درستی انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ingredient data;

            bool register = false;

            if (ID > 0)
            {
                data = _unitOfWork.Ingredients.Get(ID);
                data.Name = Name;
                data.UnitID = unit_id;
            }
            else
                _unitOfWork.Ingredients.Add(new Ingredient() { Name = Name, UnitID = unit_id });

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
            cmb_data_list.DisplayMember = "Name";
            cmb_data_list.ValueMember = "ID";
            var data = _unitOfWork.Ingredients.GetAll().ToList();
            data.Insert(0, new Ingredient() { ID = 0, Name = "افزودن آیتم جدید"});
            cmb_data_list.DataSource = data;

            cmb_unit_list.DisplayMember = "Name";
            cmb_unit_list.ValueMember = "ID";
            cmb_unit_list.DataSource = _unitOfWork.Units.GetAll().ToList();
        }

        private void Add_Ingredient_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_data_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected_id = (int)cmb_data_list.SelectedValue;
            var Ingredient = _unitOfWork.Ingredients.Get(selected_id);

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

                Ingredient Ingredient = _unitOfWork.Ingredients.Get(selected_id);

                bool deleted = false;

                if (Ingredient == null || Ingredient.ID <= 0)
                {
                    MessageBox.Show(null, "در حذف اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Ingredient.Deleted = true;
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
