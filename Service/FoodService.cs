using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Service
{
    public interface IFoodService
    {
        bool add(Food data);

        bool update(Food data);

        IEnumerable<Food> select(Expression<Func<Food, bool>> filter);
    }

    public class FoodService : IFoodService
    {
        private IFoodDAO _dao; 

        public FoodService(IFoodDAO dao)
        {
            _dao = dao;
        }

        public bool add(Food data)
        {
            return _dao.Add(data);
        }

        public bool update(Food data)
        {
            return _dao.Update(data);
        }

        public IEnumerable<Food> select(Expression<Func<Food, bool>> filter)
        {
            return _dao.Select(filter);
        }
    }
}
