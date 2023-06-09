﻿using Domain.BaseClasses;
using Domain.ViewModels;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Service
{
    public interface IReportService
    {
        List<Order> Get_Orders_FromDate_ToDate_For_Some_Customers(DateTime from_date, DateTime to_date, List<int> customers);

        List<ConsumeViewModel> Get_Ingrediants_FromDate_ToDate(DateTime from_date, DateTime to_date);
    }

    public class ReportService : IReportService
    {
        private IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Order> Get_Orders_FromDate_ToDate_For_Some_Customers(DateTime from_date, DateTime to_date,
            List<int> customers)
        {
            List<Order> data = new List<Order>();

            if (customers == null || customers.Count <= 0)
                data = _unitOfWork.Orders.Eager_Select(s => EntityFunctions.TruncateTime(s.Insert_time) >=
                EntityFunctions.TruncateTime(from_date) && EntityFunctions.TruncateTime(s.Insert_time) <=
                EntityFunctions.TruncateTime(to_date) && s.Deleted == false).ToList();
            else
                data = _unitOfWork.Orders.Eager_Select(s => EntityFunctions.TruncateTime(s.Insert_time) >=
                EntityFunctions.TruncateTime(from_date) && EntityFunctions.TruncateTime(s.Insert_time) <=
                EntityFunctions.TruncateTime(to_date) && s.Deleted == false &&
                customers.Contains(s.CustomerID)).ToList();

            return data;
        }

        public List<ConsumeViewModel> Get_Ingrediants_FromDate_ToDate(DateTime from_date, DateTime to_date)
        {
            var data = Get_Orders_FromDate_ToDate_For_Some_Customers(from_date, to_date, new List<int>());

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

                            if (order_item.FoodOptions != null)
                                foreach (var order_option in order_item.FoodOptions)
                                {
                                    if (order_option.ConsumeFoodOptions != null)
                                    {
                                        foreach (var consume in order_option.ConsumeFoodOptions)
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

            return all_consume;
        }
    }
}
