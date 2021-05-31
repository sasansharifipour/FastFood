using DAO;
using Domain.BaseClasses;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Service
{
    public interface IOrderService
    {
        bool add(Order data);

        int get_free_number();
    }

    public class OrderService : IOrderService
    {
        private IOrderDAO _dao; 

        public OrderService(IOrderDAO dao)
        {
            _dao = dao;
        }

        public bool add(Order data)
        {
            return _dao.Add(data);
        }

        [Obsolete]
        public int get_free_number()
        {
            int free_number = 0;

            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;

            var last_order_today = _dao.Select(s => EntityFunctions.TruncateTime(s.Insert_time) ==
                EntityFunctions.TruncateTime(DateTime.Now)).OrderByDescending(s => s.Number).FirstOrDefault();

            if (last_order_today == null || last_order_today.ID <= 0)
                free_number = 1;
            else
                free_number = last_order_today.Number + 1;

            return free_number;
        }
    }
}
