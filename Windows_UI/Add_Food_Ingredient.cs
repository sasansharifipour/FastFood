using Domain.BaseClasses;
using Service;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public partial class Add_Food_Ingredient : SpecialForm
    {
        private IUnitOfWork _unitOfWork;

        public Add_Food_Ingredient(IUnitOfWork unitOfWork
            , [Dependency("login_form")] Form login_form)
            : base(login_form)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
        }

        private void load_info()
        {
            cmb_food_list.DisplayMember = "Name";
            cmb_food_list.ValueMember = "ID";
            cmb_food_list.DataSource = _unitOfWork.Foods.GetAll().ToList();

            cmb_data_list.DisplayMember = "Name";
            cmb_data_list.ValueMember = "ID";
            cmb_data_list.DataSource = _unitOfWork.Ingredients.GetAll().ToList();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var selected_ingredient = get_selected_ingredient();
            var selected_food = get_selected_food();
            var selected_consume = get_selected_consume(selected_food, selected_ingredient);

            if (selected_food == null || selected_food.ID <= 0 )
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
            double.TryParse(txt_amount.Text.Replace('.','/').Trim(), out amount);
            
            bool register = false;

            if (selected_consume == null || selected_consume.ID <= 0)
                _unitOfWork.Consumes.Add(new Consume()
                {
                    FoodID = selected_food.ID,
                    IngredientID = selected_ingredient.ID,
                    Volume = amount
                });
            else
                selected_consume.Volume = amount;

            register = _unitOfWork.Complete() > 0 ? true : false;

            if (register)
            {
                MessageBox.Show(null, "اطلاعات با موفقیت ثبت گردید", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                change_food_ingredient();
            }
            else
            {
                MessageBox.Show(null, "در ثبت اطلاعات خطایی رخ داده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Food_Ingredient_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_data_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_food_ingredient();
        }

        private void update_ingredient_info(Ingredient selected_ingredient)
        {
            try
            {
                var unit = _unitOfWork.Units.Get(selected_ingredient.UnitID);

                lbl_unit_name.Text = unit.Name;
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                return new Ingredient();
            }
        }

        private void cmb_food_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            change_food_ingredient();
        }

        private Food get_selected_food()
        {
            try
            {
                if (cmb_food_list.SelectedValue == null)
                    return new Food();

                int food_id = (int)cmb_food_list.SelectedValue;
                return _unitOfWork.Foods.Eager_Select(s => s.ID == food_id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                return new Food();
            }
        }

        private void update_consume_data_grid_view(Food data)
        {
            var consumeViewModels = data.ConsumeViewModels();

            dt_gd_viw_consume.DataSource = consumeViewModels;
            dt_gd_viw_consume.Columns["IngredientName"].HeaderText = "مواد اولیه";
            dt_gd_viw_consume.Columns["Volume"].HeaderText = "مقدار";
            dt_gd_viw_consume.Columns["UnitName"].HeaderText = "واحد";

            dt_gd_viw_consume.Columns["IngredientName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dt_gd_viw_consume.Columns["UnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dt_gd_viw_consume.Columns["Volume"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void change_food_ingredient()
        {
            try
            {
                var selected_ingredient = get_selected_ingredient();
                var selected_food = get_selected_food();
                var selected_consume = get_selected_consume(selected_food, selected_ingredient);

                update_consume_data_grid_view(selected_food);
                update_ingredient_info(selected_ingredient);
                update_consume_info(selected_consume);
            }
            catch(Exception ex)
            {

            }
        }

        private void update_consume_info(Consume consume)
        {
            try
            {
                if (consume == null || consume.ID<= 0)
                {
                    txt_amount.Text = "";
                    txt_amount.Select();
                }
                else
                {
                    txt_amount.Text = consume.Volume.ToString();
                    txt_amount.Select();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private Consume get_selected_consume(Food food, Ingredient ingredient)
        {
            try
            {
                return food.Consumes.Where(s => s.IngredientID == ingredient.ID).FirstOrDefault();
            }
            catch(Exception ex)
            {
                return new Consume();
            }
        }
    }
}
