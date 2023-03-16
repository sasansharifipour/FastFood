using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DTO
{
    public interface IFoodRepository : IRepository<Food>
    {
        IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> predicate);
    }
}
