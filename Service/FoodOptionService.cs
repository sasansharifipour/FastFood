using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IFoodOptionService
    {
        FoodOption find(int id);

        bool add(FoodOption data);

        bool update(FoodOption data);

        bool delete(FoodOption data);

        IEnumerable<FoodOption> select_active_items();

        IEnumerable<FoodOption> select(Expression<Func<FoodOption, bool>> filter);
    }

    public class FoodOptionService : IFoodOptionService
    {
        private IFoodOptionDAO _dao; 

        public FoodOptionService(IFoodOptionDAO dao)
        {
            _dao = dao;
        }

        public bool add(FoodOption data)
        {
            return _dao.Add(data);
        }

        public bool update(FoodOption data)
        {
            return _dao.Update(data);
        }

        public bool delete(FoodOption data)
        {
            data.Deleted = true;
            return _dao.Update(data);
        }

        public IEnumerable<FoodOption> select_active_items()
        {
            return _dao.Select(s => s.Deleted == false && s.ID > 0);
        }

        public IEnumerable<FoodOption> select(Expression<Func<FoodOption, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public FoodOption find(int id)
        {
            FoodOption item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new FoodOption();

            return item;
        }

    }
}
