using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace DAO
{
    public interface IOrderItemDAO : IBaseDAO<OrderItem>
    {

    }

    public class OrderItemDAO : IOrderItemDAO
    {
        private IDbContextFactory<DBContext> _db_factory;
        private IBaseDAO<OrderItem> _crud_operator;

        public OrderItemDAO(IDbContextFactory<DBContext> db_factory, IBaseDAO<OrderItem> crud_operator)
        {
            _db_factory = db_factory;
            _crud_operator = crud_operator;
        }

        public bool Add(OrderItem data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(OrderItem data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<OrderItem> Select(Expression<Func<OrderItem, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }
    }
}
