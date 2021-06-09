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

namespace Windows_UI
{
    public partial class Add_Food_Ingredient : Form
    {
        private IFoodService _foodService;
        private IUnitService _unitService;
        private IIngredientService _ingredientService;

        public Add_Food_Ingredient(IFoodService foodService, IIngredientService ingredientService, IUnitService unitService)
        {
            InitializeComponent();

            _foodService = foodService;
            _unitService = unitService;
            _ingredientService = ingredientService;
        }

        private void load_info()
        {
            cmb_food_list.DisplayMember = "Name";
            cmb_food_list.ValueMember = "ID";
            cmb_food_list.DataSource = _foodService.select_active_items();

            cmb_data_list.DisplayMember = "Name";
            cmb_data_list.ValueMember = "ID";
            cmb_data_list.DataSource = _ingredientService.select_active_items();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void Add_Food_Ingredient_Load(object sender, EventArgs e)
        {
            load_info();
        }

        private void cmb_data_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ingredient_id = (int)cmb_data_list.SelectedValue;

                var selected_ingredient = _ingredientService.find(ingredient_id);
                var unit = _unitService.find(selected_ingredient.UnitID);

                lbl_unit_name.Text = unit.Name;
            }
            catch (Exception ex) { }
        }

        private void cmb_food_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int food_id = (int)cmb_food_list.SelectedValue;

                var data =_foodService.Eager_Select(s => s.ID == food_id).FirstOrDefault();
                var consumeViewModels = data.ConsumeViewModels();

                dt_gd_viw_consume.DataSource = consumeViewModels;
                dt_gd_viw_consume.Columns["IngredientName"].HeaderText = "مواد اولیه";
                dt_gd_viw_consume.Columns["Volume"].HeaderText = "مقدار";
                dt_gd_viw_consume.Columns["UnitName"].HeaderText = "واحد";
            }
            catch(Exception ex) { 
            }
        }
    }
}
