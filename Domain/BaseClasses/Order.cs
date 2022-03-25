using CommonCodes;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class Order : ICloneable
    {
        public int ID { get; set; } = 0;

        public int CustomerID { get; set; } = 0;

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public DateTime Insert_time { get; set; }

        public DateTime? Deliver_time { get; set; }

        public int Number { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public double discount { get; set; } = 0;

        public double paying_amount { get; set; } = 0;

        public bool credit { get; set; } = false;

        public virtual double credit_amount { get {
                return Math.Max(0, OrderItems.Sum(s => s.All_Price) - discount - paying_amount);
            } }
        public virtual double credit_amount_payment
        {
            get
            {
                return Math.Max(0, paying_amount - OrderItems.Sum(s => s.All_Price));
            }
        }

        public object Clone()
        {
            Order order = new Order()
            {
                ID = ID,
                Customer = Customer,
                discount = discount,
                CustomerID = CustomerID,
                Deleted = Deleted,
                Deliver_time = Deliver_time,
                Insert_time = Insert_time,
                Number = Number,
                OrderItems = (List<OrderItem>)OrderItems.Clone<OrderItem>()
            };

            return order;
        }
    }

    public static class OrderExtentionMethods
    {
        public static List<FoodViewModel> Extract_Food(this List<Order> data)
        {
            Dictionary<Food, FoodViewModel> foods = new Dictionary<Food, FoodViewModel>();


            if (data != null)
                foreach (var item in data)
                {
                    if (item.OrderItems != null)
                        foreach (var order_item in item.OrderItems)
                            if (order_item.Food != null)
                            {
                                FoodViewModel model = new FoodViewModel();

                                if (foods.ContainsKey(order_item.Food))
                                {
                                    model = foods[order_item.Food];
                                    model.Count += order_item.Count;
                                    model.Price += order_item.Price * order_item.Count;
                                }
                                else
                                {
                                    model.FoodName = order_item.Food.Name;
                                    model.Count = order_item.Count;
                                    model.Price = order_item.Price * order_item.Count;
                                }

                                foods[order_item.Food] = model;
                            }
                }

            return foods.Values.ToList();
        }

        public static List<ItemViewModel> Create_Payment_Data( this List<Order> data)
        {
            List<ItemViewModel> payment_data = new List<ItemViewModel>();

            var all_consume = data.Extract_Food();

            double sum_price = all_consume.Sum(s => s.Price);

            double discount = data.Sum(s => s.discount);
            double paying_amount = data.Sum(s => s.paying_amount);
            double credit_amount = data.Sum(s => s.credit_amount);
            double credit_amount_payment = data.Sum(s => s.credit_amount_payment);

            string txt = string.Format("{0:#,##0}", sum_price);
            string discount_txt = string.Format("{0:#,##0}", discount);
            string all_paying_txt = string.Format("{0:#,##0}", sum_price - discount);
            string paying_amount_txt = string.Format("{0:#,##0}", paying_amount);
            string credit_amount_txt = string.Format("{0:#,##0}", credit_amount);
            string credit_amount_payment_txt = string.Format("{0:#,##0}", credit_amount_payment);

            payment_data.Add(new ItemViewModel() { Name = "جمع کل", Value = txt });
            payment_data.Add(new ItemViewModel() { Name = "تخفیف", Value = discount_txt });
            payment_data.Add(new ItemViewModel() { Name = "مبلغ قابل پرداخت", Value = all_paying_txt });
            payment_data.Add(new ItemViewModel() { Name = "کل مبالغ پرداخت شده", Value = paying_amount_txt });
            payment_data.Add(new ItemViewModel() { Name = "کل مبلغ قرضی", Value = credit_amount_txt });
            payment_data.Add(new ItemViewModel() { Name = "کل مبلغ برگشتی قرضی", Value = credit_amount_payment_txt });

            return payment_data;
        }
    }
}
