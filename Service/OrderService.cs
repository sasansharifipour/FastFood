using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IOrderService
    {
        bool add(Order data);

        int get_free_number();

        IEnumerable<Order> select(Expression<Func<Order, bool>> filter);

        IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> filter);
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

        public IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> filter)
        {
            return _dao.Eager_Select(filter);
        }

        [Obsolete]
        public int get_free_number()
        {
            int free_number = 0;

            var last_order_today = _dao.Select(s => EntityFunctions.TruncateTime(s.Insert_time) ==
                EntityFunctions.TruncateTime(DateTime.Now)).OrderByDescending(s => s.Number).FirstOrDefault();

            if (last_order_today == null || last_order_today.ID <= 0)
                free_number = 1;
            else
                free_number = last_order_today.Number + 1;

            return free_number;
        }

        public IEnumerable<Order> select(Expression<Func<Order, bool>> filter)
        {
            return _dao.Select(filter);
        }
    }
}
