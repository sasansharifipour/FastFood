using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IFoodService
    {
        Food find(int id);

        bool add(Food data);

        bool update(Food data);

        bool delete(Food data);

        IEnumerable<Food> select_active_items();

        IEnumerable<Food> select(Expression<Func<Food, bool>> filter);

        IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> filter);
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

        public bool delete(Food data)
        {
            data.Deleted = true;
            return _dao.Update(data);
        }

        public IEnumerable<Food> select_active_items()
        {
            return _dao.Select(s => s.Deleted == false && s.ID > 0);
        }

        public IEnumerable<Food> select(Expression<Func<Food, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public Food find(int id)
        {
            Food item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new Food();

            return item;
        }

        public IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> filter)
        {
            return _dao.Eager_Select(filter);
        }
    }
}
