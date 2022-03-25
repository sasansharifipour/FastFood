using CommonCodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Domain.ViewModels
{
    public class ConsumeViewModel
    {
        public string IngredientName { get; set; } = "";

        public double Volume { get; set; } = 0;

        public string UnitName { get; set; } = "";
    }


    public static class ExtentionMethods_ConsumeViewModel
    {
        public static DataTable convert_to_datatable(this List<ConsumeViewModel> items,
            DateTime from_date, DateTime to_date)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("نام");
            dt.Columns.Add("مقدار");
            dt.Columns.Add("واحد");

            foreach (var item in items)
                dt.Rows.Add(item.IngredientName, item.Volume.ToString(), item.UnitName);

            dt.Rows.Add("از تاریخ", from_date.ToPersianLongDateString());
            dt.Rows.Add("تا تاریخ", to_date.ToPersianLongDateString());
            
            return dt;
        }
    }
}
