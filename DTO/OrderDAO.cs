using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DAO
{
    public interface IOrderDAO : IBaseDAO<Order>
    {
        IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> filter);
    }

    public class OrderDAO : IOrderDAO
    {

        public bool Add(Order data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    data.Customer = db.Customers.FirstOrDefault(s => s.ID == data.CustomerID);

                    foreach (var orderItem in data.OrderItems)
                    {
                        List<FoodOption> foodOptions = new List<FoodOption>();

                        foreach (var item in orderItem.FoodOptions)
                            foodOptions.Add(db.FoodOptions.FirstOrDefault(s => s.ID == item.ID));

                        orderItem.Food = db.Foods.FirstOrDefault(s => s.ID == orderItem.FoodID);
                        orderItem.FoodOptions = foodOptions;
                    }

                    db.Orders.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(Order data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    db.Orders.Remove(data);
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

        public IEnumerable<Order> Select(Expression<Func<Order, bool>> filter)
        {
            IEnumerable<Order> result = new List<Order>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.Orders.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<Order>();

            return result;
        }

        public bool Update(Order data)
        {
            bool added = false;

            try
            {
                using (var db = new DBContext())
                {
                    var dbOrder = db.Orders.Include(x => x.OrderItems).Single(c => c.ID == data.ID);
                    data.Customer = db.Customers.FirstOrDefault(s => s.ID == data.CustomerID);

                    db.Entry(dbOrder).CurrentValues.SetValues(data);

                    foreach (var dbOrderItems in dbOrder.OrderItems.ToList())
                        if (!data.OrderItems.Any(s => s.ID == dbOrderItems.ID))
                            db.OrderItems.Remove(dbOrderItems);

                    foreach (var newOrderItems in data.OrderItems)
                    {
                        List<FoodOption> foodOptions = new List<FoodOption>();

                        foreach (var item in newOrderItems.FoodOptions)
                            foodOptions.Add(db.FoodOptions.FirstOrDefault(s => s.ID == item.ID));

                        newOrderItems.FoodOptions = foodOptions;
                        newOrderItems.Food = db.Foods.FirstOrDefault(s => s.ID == newOrderItems.FoodID);

                        var dbOrderItems = db.OrderItems.Include(x => x.FoodOptions)
                            .SingleOrDefault(s => s.ID == newOrderItems.ID);

                        if (dbOrderItems != null)
                            db.Entry(dbOrderItems).CurrentValues.SetValues(newOrderItems);
                        else
                            dbOrder.OrderItems.Add(newOrderItems);
                    }

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

        public IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> filter)
        {
            IEnumerable<Order> result = new List<Order>();

            using (var db= new DBContext())
            {
                result = db.Orders.Where(filter).Include(x => x.Customer).Include(x => x.OrderItems)
                    .Include(x => x.OrderItems.Select(s => s.FoodOptions.Select(p => p.ConsumeFoodOptions)))
                    .Include(x => x.OrderItems.Select(s => s.Food.Consumes.Select(p => p.Ingredient.Unit)))
                    .Include(x => x.OrderItems.Select(s => s.FoodOptions.Select(p => p.ConsumeFoodOptions.Select(q => q.Ingredient.Unit))))
                    .ToList();

                if (result == null)
                    result = new List<Order>();

            }


            return result;
        }
    }
}
