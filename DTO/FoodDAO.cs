using DAO;
using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAO
{
    public interface IFoodDAO : IBaseDAO<Food>
    {

    }

    public class FoodDAO : IFoodDAO
    {
        private IDbContextFactory<DBContext> _db_factory;
        private IBaseDAO<Food> _crud_operator;

        public FoodDAO(IDbContextFactory<DBContext> db_factory, IBaseDAO<Food> crud_operator)
        {
            _db_factory = db_factory;
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

        public IEnumerable<Food> Select(Expression<Func<Food, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }
    }
}
