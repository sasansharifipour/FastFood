using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IIngredientService
    {
        Ingredient find(int id);

        bool add(Ingredient Ingredient);

        bool update(Ingredient data);

        bool delete(Ingredient data);

        IEnumerable<Ingredient> select_active_items();

        IEnumerable<Ingredient> select(Expression<Func<Ingredient, bool>> filter);
    }

    public class IngredientService : IIngredientService
    {
        private IIngredientDAO _dao; 

        public IngredientService(IIngredientDAO dao)
        {
            _dao = dao;
        }

        public bool add(Ingredient Ingredient)
        {
            return _dao.Add(Ingredient);
        }

        public bool delete(Ingredient data)
        {
            data.Deleted = true;
            return _dao.Update(data);
        }

        public Ingredient find(int id)
        {
            Ingredient item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new Ingredient();

            return item;
        }

        public IEnumerable<Ingredient> select_active_items()
        {
            return _dao.Select(s => s.Deleted == false && s.ID > 0);
        }

        public IEnumerable<Ingredient> select(Expression<Func<Ingredient, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public bool update(Ingredient data)
        {
            return _dao.Update(data);
        }
    }
}
