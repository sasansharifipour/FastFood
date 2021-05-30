using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace DAO
{

    public interface ICustomerDAO : IBaseDAO<Customer>
    {

    }

    public class CustomerDAO : ICustomerDAO
    {
        private IDbContextFactory<DBContext> _db_factory;
        private IBaseDAO<Customer> _crud_operator;

        public CustomerDAO(IDbContextFactory<DBContext> db_factory, IBaseDAO<Customer> crud_operator)
        {
            _db_factory = db_factory;
            _crud_operator = crud_operator;
        }

        public bool Add(Customer data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(Customer data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<Customer> Select(Expression<Func<Customer, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }
    }
}
