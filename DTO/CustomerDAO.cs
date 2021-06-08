﻿using Domain.BaseClasses;
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
        private IBaseDAO<Customer> _crud_operator;

        public CustomerDAO(IBaseDAO<Customer> crud_operator)
        {
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

        public bool Update(Customer data)
        {
            return _crud_operator.Update(data);
        }
    }
}
