using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface ICustomerService
    {
        Customer find(int id);

        bool add(Customer customer);

        bool update(Customer data);

        bool delete(Customer data);

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

        public bool delete(Customer data)
        {
            data.Deleted = true;
            return _dao.Update(data);
        }

        public Customer find(int id)
        {
            Customer item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new Customer();

            return item;
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
