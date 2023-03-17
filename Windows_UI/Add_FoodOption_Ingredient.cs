using Domain.BaseClasses;
using Domain.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Add_FoodOption_Ingredient : SpecialForm
    {
        private IUnitOfWork _unitOfWork;

        public Add_FoodOption_Ingredient(IUnitOfWork unitOfWork
            , [Dependency("login_form")] Form login_form)
            : base(login_form)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
        }

        private void load_info()
        {
            cmb_foodOption_list.DisplayMember = "Name";
            cmb_foodOption_list.ValueMember = "ID";
            cmb_foodOption_list.DataSource = _unitOfWork.FoodOptions.GetAll().ToList(); ;

            cmb_data_list.DisplayMember = "Name";
            cmb_data_list.ValueMember = "ID";
            cmb_data_list.DataSource = _unitOfWork.Ingredients.GetAll().ToList();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var selected_ingredient = get_selected_ingredient();
            var selected_foodOption = get_selected_foodOption();
            var selected_consumeFoodOption = get_selected_consumeFoodOption(selected_foodOption, selected_ingredient);

            if (selected_foodOption == null || selected_foodOption.ID <= 0)
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selected_ingredient == null || selected_ingredient.ID <= 0)
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double amount = 0;
            double.TryParse(txt_amount.Text.Replace('.', '/').Trim(), out amount);

            bool register = false;

            if (selected_consumeFoodOption == null || selected_consumeFoodOption.ID <= 0)
                _unitOfWork.ConsumeFoodOptions.Add(new ConsumeFoodOption()
                {
                    FoodOptionID = selected_foodOption.ID,
                    IngredientID = selected_ingredient.ID,
                    Volume = amount
                });
            else
                selected_consumeFoodOption.Volume = amount;

            register = _unitOfWork.Complete() > 0 ? true : false;

            if (register)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                change_foodOption_ingredient();
            }
            else
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_FoodOption_Ingredient_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_data_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_foodOption_ingredient();
        }

        private void update_ingredient_info(Ingredient selected_ingredient)
        {
            try
            {
                var unit = _unitOfWork.Units.Get(selected_ingredient.UnitID);

                lbl_unit_name.Text = unit.Name;
            }
            catch (Exception ex)
            {

            }
        }

        private Ingredient get_selected_ingredient()
        {
            try
            {
                if (cmb_data_list.SelectedValue == null)
                    return new Ingredient();

                int ingredient_id = (int)cmb_data_list.SelectedValue;

                return _unitOfWork.Ingredients.Get(ingredient_id);
            }
            catch (Exception ex)
            {
                return new Ingredient();
            }
        }

        private void cmb_foodOption_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_foodOption_ingredient();
        }

        private FoodOption get_selected_foodOption()
        {
            try
            {
                if (cmb_foodOption_list.SelectedValue == null)
                    return new FoodOption();

                int foodOption_id = (int)cmb_foodOption_list.SelectedValue;
                return _unitOfWork.FoodOptions.Get(foodOption_id);
            }
            catch (Exception ex)
            {
                return new FoodOption();
            }
        }

        private void update_consumeFoodOption_data_grid_view(FoodOption data)
        {
            var consumeFoodOptionViewModels = data.ConsumeViewModels();

            dt_gd_viw_consumeFoodOption.DataSource = consumeFoodOptionViewModels;
            dt_gd_viw_consumeFoodOption.Columns["IngredientName"].HeaderText = "مواد اولیه";
            dt_gd_viw_consumeFoodOption.Columns["Volume"].HeaderText = "مقدار";
            dt_gd_viw_consumeFoodOption.Columns["UnitName"].HeaderText = "واحد";

            dt_gd_viw_consumeFoodOption.Columns["IngredientName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dt_gd_viw_consumeFoodOption.Columns["UnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_consumeFoodOption.Columns["Volume"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void change_foodOption_ingredient()
        {
            try
            {
                var selected_ingredient = get_selected_ingredient();
                var selected_foodOption = get_selected_foodOption();
                var selected_consumeFoodOption = get_selected_consumeFoodOption(selected_foodOption, selected_ingredient);

                update_consumeFoodOption_data_grid_view(selected_foodOption);
                update_ingredient_info(selected_ingredient);
                update_consumeFoodOption_info(selected_consumeFoodOption);
            }
            catch (Exception ex)
            {

            }
        }

        private void update_consumeFoodOption_info(ConsumeFoodOption consumeFoodOption)
        {
            try
            {
                if (consumeFoodOption == null || consumeFoodOption.ID <= 0)
                {
                    txt_amount.Text = "";
                    txt_amount.Select();
                }
                else
                {
                    txt_amount.Text = consumeFoodOption.Volume.ToString();
                    txt_amount.Select();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private ConsumeFoodOption get_selected_consumeFoodOption(FoodOption foodOption, Ingredient ingredient)
        {
            try
            {
                return foodOption.ConsumeFoodOptions.Where(s => s.IngredientID == ingredient.ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new ConsumeFoodOption();
            }
        }
    }
}
