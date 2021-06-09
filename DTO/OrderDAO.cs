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
        private DbContext _db;
        private IBaseDAO<Order> _crud_operator;

        public OrderDAO(DbContext db, IBaseDAO<Order> crud_operator)
        {
            _db = db;
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

            var context = _db.Set<Order>();
            result = context.Where(filter).Include(x => x.Customer).Include(x => x.OrderItems)
                .Include(x => x.OrderItems.Select(s => s.Food.Consumes.Select(p => p.Ingredient.Unit))).ToList();

            if (result == null)
                result = new List<Order>();

            return result;
        }
    }
}
