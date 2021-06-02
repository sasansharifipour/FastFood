using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Linq;
using System.Data.Entity;

namespace DAO
{
    public interface IOrderDAO : IBaseDAO<Order>
    {
        IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> filter);
    }

    public class OrderDAO : IOrderDAO
    {
        private IDbContextFactory<DBContext> _db_factory;
        private IBaseDAO<Order> _crud_operator;

        public OrderDAO(IDbContextFactory<DBContext> db_factory, IBaseDAO<Order> crud_operator)
        {
            _db_factory = db_factory;
            _crud_operator = crud_operator;
        }

        public bool Add(Order data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(Order data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<Order> Select(Expression<Func<Order, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(Order data)
        {
            return _crud_operator.Update(data);
        }

        public IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> filter)
        {
            IEnumerable<Order> result = new List<Order>();

            using (var db = _db_factory.Create())
            {
                result = db.Orders.Where(filter).Include("Customer").Include("OrderItems").ToList();
            }

            if (result == null)
                result = new List<Order>();

            return result;
        }
    }
}
