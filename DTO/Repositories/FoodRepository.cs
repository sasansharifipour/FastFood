using Domain.BaseClasses;
using Model;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public FoodRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> predicate)
        {
            return DBContext.Foods.Where(predicate).Include(x => x.Consumes.Select(s => s.Ingredient)).ToList();
        }
        
        public DBContext DBContext
        {
            get { return _context as DBContext; }
        }
    }
}
