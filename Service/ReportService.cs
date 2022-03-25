using Domain.BaseClasses;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IReportService
    {
        List<Order> Get_Orders_FromDate_ToDate_For_Some_Customers(DateTime from_date, DateTime to_date, List<int> customers);
    }

    public class ReportService : IReportService
    {
        private IOrderService _orderService;

        public ReportService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<Order> Get_Orders_FromDate_ToDate_For_Some_Customers(DateTime from_date, DateTime to_date, List<int> customers)
        {

            var data = _orderService.Eager_Select(s => EntityFunctions.TruncateTime(s.Insert_time) >=
                EntityFunctions.TruncateTime(from_date) && EntityFunctions.TruncateTime(s.Insert_time) <=
                EntityFunctions.TruncateTime(to_date) && s.Deleted == false &&
                customers.Contains(s.CustomerID)).ToList();

            return data;
        }
    }
}
