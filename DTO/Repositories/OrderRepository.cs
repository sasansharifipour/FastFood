using Domain.BaseClasses;
using Model;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> predicate)
        {
            return DBContext.Orders.Where(predicate).Include(x => x.Customer)
                    .Include(x => x.User_Registered)
                    .Include(x => x.OrderItems)
                    .Include(x => x.OrderItems.Select(s => s.FoodOptions.Select(p => p.ConsumeFoodOptions)))
                    .Include(x => x.OrderItems.Select(s => s.Food.Consumes.Select(p => p.Ingredient.Unit)))
                    .Include(x => x.OrderItems.Select(s => s.FoodOptions.Select(p => p.ConsumeFoodOptions.Select(q => q.Ingredient.Unit))))
                    .ToList();
        }

        public int GetFreeNumber()
        {
            var lastOrderToday = DBContext.Orders
                .OrderByDescending(s => s.Number)
                .SingleOrDefault(s => s.Insert_time.Date == DateTime.Now.Date);

            return lastOrderToday == null || lastOrderToday.ID <= 0 ? 1 : lastOrderToday.Number + 1;
        }

        public DBContext DBContext
        {
            get { return _context as DBContext; }
        }
    }
}
