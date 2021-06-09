using Domain.BaseClasses;
using Domain.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_UI
{
    public partial class Report_Ingredient : Form
    {
        private IOrderService _orderService;

        public Report_Ingredient(IOrderService orderService)
        {
            InitializeComponent();

            _orderService = orderService;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            DateTime from_date = dat_tim_picker_from_date.Value.Date;
            DateTime to_date = dat_tim_picker_to_date.Value.Date;

            var data = _orderService.Eager_Select(s => EntityFunctions.TruncateTime(s.Insert_time) >=
                EntityFunctions.TruncateTime(from_date) && EntityFunctions.TruncateTime(s.Insert_time) <=
                EntityFunctions.TruncateTime(to_date) && s.Deleted == false).ToList();

            Dictionary<Ingredient, double> ingredient = new Dictionary<Ingredient, double>();

            if (data != null)
                foreach (var item in data)
                {
                    if (item.OrderItems != null)
                        foreach (var order_item in item.OrderItems)
                        {
                            if (order_item.Food != null && order_item.Food.Consumes != null)
                            {
                                foreach (var consume in order_item.Food.Consumes)
                                {
                                    double volume = 0;
                                    
                                    if (ingredient.ContainsKey(consume.Ingredient))
                                        volume = ingredient[consume.Ingredient];

                                    volume += order_item.Count * consume.Volume;
                                    ingredient[consume.Ingredient] = volume;
                                }
                            }
                        }
                }

            List<ConsumeViewModel> all_consume = new List<ConsumeViewModel>();

            foreach (var item in ingredient)
            {
                ConsumeViewModel model = new ConsumeViewModel();
                model.Volume = Math.Round(item.Value, 2);
                model.IngredientName = item.Key.Name;
                model.UnitName = item.Key.Unit.Name;

                all_consume.Add(model);
            }

            dt_gd_viw_reportlist.DataSource = all_consume;
            dt_gd_viw_reportlist.Columns["IngredientName"].HeaderText = "محصول";
            dt_gd_viw_reportlist.Columns["Volume"].HeaderText = "مقدار";
            dt_gd_viw_reportlist.Columns["UnitName"].HeaderText = "واحد";
        }
    }
}
