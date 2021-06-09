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
    public interface IConsumeDAO : IBaseDAO<Consume>
    {

    }

    public class ConsumeDAO : IConsumeDAO
    {
        private IBaseDAO<Consume> _crud_operator;

        public ConsumeDAO(IBaseDAO<Consume> crud_operator)
        {
            _crud_operator = crud_operator;
        }

        public bool Add(Consume data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(Consume data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<Consume> Select(Expression<Func<Consume, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(Consume data)
        {
            return _crud_operator.Update(data);
        }
    }
}
