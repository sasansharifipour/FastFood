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
    public interface IConsumeFoodOptionDAO : IBaseDAO<ConsumeFoodOption>
    {

    }

    public class ConsumeFoodOptionDAO : IConsumeFoodOptionDAO
    {
        private IBaseDAO<ConsumeFoodOption> _crud_operator;

        public ConsumeFoodOptionDAO(IBaseDAO<ConsumeFoodOption> crud_operator)
        {
            _crud_operator = crud_operator;
        }

        public bool Add(ConsumeFoodOption data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(ConsumeFoodOption data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<ConsumeFoodOption> Select(Expression<Func<ConsumeFoodOption, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(ConsumeFoodOption data)
        {
            return _crud_operator.Update(data);
        }
    }
}
