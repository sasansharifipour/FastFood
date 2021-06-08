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
    public interface IIngredientDAO : IBaseDAO<Ingredient>
    {

    }

    public class IngredientDAO : IIngredientDAO
    {
        private IBaseDAO<Ingredient> _crud_operator;

        public IngredientDAO(IBaseDAO<Ingredient> crud_operator)
        {
            _crud_operator = crud_operator;
        }

        public bool Add(Ingredient data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(Ingredient data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<Ingredient> Select(Expression<Func<Ingredient, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(Ingredient data)
        {
            return _crud_operator.Update(data);
        }
    }
}
