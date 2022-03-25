using Atf.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonCodes
{
    public static class ExtensionMethodClass
    {
        public static string ToPersianLongDateString(this DateTime date)
        {
            DateTimeSelector datetimeselector = new DateTimeSelector();
            datetimeselector.UsePersianFormat = true;
            datetimeselector.Value = date;
            return datetimeselector.GetText("dddd dd MMMM ماه yyyy");
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static void convert_object_to_csv(this DataTable dt, string file_path)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);

            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }
            var writer = new StreamWriter(File.OpenWrite(file_path), Encoding.UTF8);

            writer.Write(sb.ToString());

            writer.Close();
        }
    }
}
