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

        IEnumerable<Customer> select(Expression<Func<Customer, bool>> filter);
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerDAO _customer_dao; 

        public CustomerService(ICustomerDAO customer_dao)
        {
            _customer_dao = customer_dao;
        }

        public bool add(Customer customer)
        {
            return _customer_dao.Add(customer);
        }

        public IEnumerable<Customer> select(Expression<Func<Customer, bool>> filter)
        {
            return _customer_dao.Select(filter);
        }
    }
}
