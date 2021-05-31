using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Service
{
    public interface ICustomerService
    {
        bool add(Customer customer);

        bool update(Customer data);

        IEnumerable<Customer> select(Expression<Func<Customer, bool>> filter);
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerDAO _dao; 

        public CustomerService(ICustomerDAO dao)
        {
            _dao = dao;
        }

        public bool add(Customer customer)
        {
            return _dao.Add(customer);
        }

        public IEnumerable<Customer> select(Expression<Func<Customer, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public bool update(Customer data)
        {
            return _dao.Update(data);
        }
    }
}
