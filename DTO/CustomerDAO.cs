using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace DAO
{

    public interface ICustomerDAO
    {
        bool Add(Customer data);

        bool Delete(Customer data);

        IEnumerable<Customer> Select(Expression<Func<Customer, bool>> filter);

        bool Update(Customer data);
    }

    public class CustomerDAO : ICustomerDAO
    {
        public bool Add(Customer data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Customers.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e) 
            { }

            return false;
        }

        public bool Delete(Customer data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    data.Deleted = true;
                    db.Customers.AddOrUpdate(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        deleted = true;
                }
            }
            catch (Exception e)
            {
            }

            return deleted;
        }

        public IEnumerable<Customer> Select(Expression<Func<Customer, bool>> filter)
        {
            IEnumerable<Customer> result = new List<Customer>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.Customers.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<Customer>();

            return result;
        }

        public bool Update(Customer data)
        {
            bool added = false;

            try
            {
                using (var db = new DBContext())
                {
                    var new_data = db.Entry(data);
                    new_data.State = System.Data.Entity.EntityState.Modified;
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        added = true;
                }
            }
            catch (Exception e)
            {
            }

            return added;
        }
    }
}
