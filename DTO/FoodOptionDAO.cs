using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAO
{
    public interface IFoodOptionDAO : IBaseDAO<FoodOption>
    {

    }

    public class FoodOptionDAO : IFoodOptionDAO
    {
        private DbContext _db;
        private IBaseDAO<FoodOption> _crud_operator;

        public FoodOptionDAO(DbContext db, IBaseDAO<FoodOption> crud_operator)
        {
            _db = db;
            _crud_operator = crud_operator;
        }

        public bool Add(FoodOption data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(FoodOption data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<FoodOption> Select(Expression<Func<FoodOption, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(FoodOption data)
        {
            return _crud_operator.Update(data);
        }
    }
}
