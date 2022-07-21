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
        public static DataTable convert_to_datatable(this List<Order> _data,
            DateTime from_date, DateTime to_date, List<Customer> customers)
        {
            string from_date_string = from_date.ToPersianLongDateString();
            string to_date_string = to_date.ToPersianLongDateString();

            DataTable dt = new DataTable();
            dt.Columns.Add("از تاریخ");
            dt.Columns.Add("تا تاریخ");
            dt.Columns.Add("کد مشتری");
            dt.Columns.Add("نام مشتری");
            dt.Columns.Add("جمع کل");
            dt.Columns.Add("تخفیف");
            dt.Columns.Add("مبلغ قابل پرداخت");
            dt.Columns.Add("کل مبالغ پرداخت شده");
            dt.Columns.Add("کل مبلغ قرضی");
            dt.Columns.Add("کل مبلغ برگشتی قرضی");

            foreach (var item in customers)
            {
                var data = _data.Where(s => s.CustomerID == item.ID).ToList();

                var all_consume = data.Extract_Food();
                double sum_price = all_consume.Sum(s => s.Price);

                double discount = data.Sum(s => s.discount);
                double paying_amount = data.Sum(s => s.paying_amount);
                double credit_amount = data.Sum(s => s.credit_amount);
                double credit_amount_payment = data.Sum(s => s.credit_amount_payment);

                if (sum_price > 0 || paying_amount > 0 || credit_amount > 0 || credit_amount_payment > 0)
                    dt.Rows.Add(from_date_string, to_date_string, item.ID.ToString(), item.FullName, sum_price.ToString(),
                    discount.ToString(), (sum_price - discount).ToString(), paying_amount.ToString(), 
                    credit_amount.ToString(), credit_amount_payment.ToString());
            }
            
            var _all_consume = _data.Extract_Food();
            double _sum_price = _all_consume.Sum(s => s.Price);

            double _discount = _data.Sum(s => s.discount);
            double _paying_amount = _data.Sum(s => s.paying_amount);
            double _credit_amount = _data.Sum(s => s.credit_amount);
            double _credit_amount_payment = _data.Sum(s => s.credit_amount_payment);

            if (_sum_price > 0 || _paying_amount > 0 || _credit_amount > 0 || _credit_amount_payment > 0)
                dt.Rows.Add(from_date_string, to_date_string, "", "جمع کل", _sum_price.ToString(),
                _discount.ToString(), (_sum_price - _discount).ToString(), _paying_amount.ToString(),
                _credit_amount.ToString(), _credit_amount_payment.ToString());

            return dt;
        }
    }
}
