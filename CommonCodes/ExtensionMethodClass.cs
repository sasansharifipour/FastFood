using Atf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCodes
{
    public static class ExtensionMethodClass
    {
        public static string ToPersianLongDateString(this DateTime date)
        {
            DateTimeSelector datetimeselector = new DateTimeSelector();
            datetimeselector.Value = date;
            return datetimeselector.GetText("yyyy/MM/dd");
        }
    }
}
