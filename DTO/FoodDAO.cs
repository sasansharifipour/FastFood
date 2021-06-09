using DAO;
using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;

namespace DAO
{
    public interface IFoodDAO : IBaseDAO<Food>
    {
        IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> filter);

    }

    public class FoodDAO : IFoodDAO
    {
        private DbContext _db;
        private IBaseDAO<Food> _crud_operator;

        public FoodDAO(DbContext db, IBaseDAO<Food> crud_operator)
        {
            _db = db;
            _crud_operator = crud_operator;
        }

        public bool Add(Food data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(Food data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> filter)
        {
            IEnumerable<Food> result = new List<Food>();

            var context = _db.Set<Food>();
            result = context.Where(filter).Include(x => x.Consumes ).Include(x => x.Consumes.Select(s => s.Ingredient)).ToList();

            if (result == null)
                result = new List<Food>();

            return result;
        }

        public IEnumerable<Food> Select(Expression<Func<Food, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(Food data)
        {
            return _crud_operator.Update(data);
        }
    }
}
