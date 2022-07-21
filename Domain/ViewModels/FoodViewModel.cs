using CommonCodes;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Domain.ViewModels
{
    public class FoodViewModel
    {
        public string FoodName { get; set; } = "";

        public int Count { get; set; } = 0;

        public double Price { get; set; } = 0;

    }

    public static class ExtentionMethods_FoodViewModel
    {
        public static DataTable convert_to_datatable(this List<FoodViewModel> items,
            DateTime from_date, DateTime to_date, List<Customer> customers)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("نام محصول");
            dt.Columns.Add("تعداد");
            dt.Columns.Add("قیمت");

            if (items == null || items.Count <= 0)
                return dt;

            foreach (var item in items)
                dt.Rows.Add(item.FoodName, item.Count.ToString(), item.Price);

            dt.Rows.Add("از تاریخ", from_date.ToPersianLongDateString());
            dt.Rows.Add("تا تاریخ", to_date.ToPersianLongDateString());

            dt.Rows.Add("کد مشتری", "نام مشتری");

            foreach (var item in customers)
                dt.Rows.Add(item.ID.ToString(), item.FullName);

            return dt;
        }
    }
}
