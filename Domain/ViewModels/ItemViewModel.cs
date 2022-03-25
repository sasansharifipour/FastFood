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
        public static DataTable convert_to_datatable(this List<ItemViewModel> items)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");

            foreach (var item in items)
                dt.Rows.Add(item.Name, item.Value.Replace(",",""));

            return dt;
        }
    }
}
