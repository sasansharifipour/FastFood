using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IConsumeFoodOptionService
    {
        ConsumeFoodOption find(int id);

        bool add(ConsumeFoodOption data);

        bool update(ConsumeFoodOption data);

        bool delete(ConsumeFoodOption data);

        IEnumerable<ConsumeFoodOption> select(Expression<Func<ConsumeFoodOption, bool>> filter);
    }

    public class ConsumeFoodOptionService : IConsumeFoodOptionService
    {
        private IConsumeFoodOptionDAO _dao; 

        public ConsumeFoodOptionService(IConsumeFoodOptionDAO dao)
        {
            _dao = dao;
        }

        public bool add(ConsumeFoodOption data)
        {
            return _dao.Add(data);
        }

        public bool update(ConsumeFoodOption data)
        {
            return _dao.Update(data);
        }

        public bool delete(ConsumeFoodOption data)
        {
            return _dao.Update(data);
        }

        public IEnumerable<ConsumeFoodOption> select(Expression<Func<ConsumeFoodOption, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public ConsumeFoodOption find(int id)
        {
            ConsumeFoodOption item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new ConsumeFoodOption();

            return item;
        }
    }
}
