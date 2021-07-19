using Atf.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    }
}
