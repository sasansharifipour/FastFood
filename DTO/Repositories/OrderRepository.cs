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
        public OrderRepository(DBContext context) : base(context)
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

        [Obsolete]
        public int get_free_number()
        {
            int free_number = 0;

            var last_order_today = DBContext.Orders.Where(s => EntityFunctions.TruncateTime(s.Insert_time) ==
                EntityFunctions.TruncateTime(DateTime.Now)).OrderByDescending(s => s.Number).FirstOrDefault();

            if (last_order_today == null || last_order_today.ID <= 0)
                free_number = 1;
            else
                free_number = last_order_today.Number + 1;

            return free_number;
        }

        public DBContext DBContext
        {
            get { return _context as DBContext; }
        }
    }
}
