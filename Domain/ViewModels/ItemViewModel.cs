using CommonCodes;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Domain.ViewModels
{
    public class ItemViewModel
    {
        public string Name { get; set; } = "";

        public string Value { get; set; } = "";
    }

    public static class ExtentionMethods
    {
        public static DataTable convert_to_datatable(this List<ItemViewModel> items, 
            DateTime from_date, DateTime to_date, List<Customer> customers)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");

            foreach (var item in items)
                dt.Rows.Add(item.Name, item.Value.Replace(",",""));

            dt.Rows.Add("از تاریخ", from_date.ToPersianLongDateString());
            dt.Rows.Add("تا تاریخ", to_date.ToPersianLongDateString());

            dt.Rows.Add("کد مشتری", "نام مشتری");

            foreach (var item in customers)
                dt.Rows.Add( item.ID.ToString(), item.FullName);

            return dt;
        }
    }
}
