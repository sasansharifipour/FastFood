using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IConsumeService
    {
        Consume find(int id);

        bool add(Consume data);

        bool update(Consume data);

        bool delete(Consume data);

        IEnumerable<Consume> select(Expression<Func<Consume, bool>> filter);
    }

    public class ConsumeService : IConsumeService
    {
        private IConsumeDAO _dao; 

        public ConsumeService(IConsumeDAO dao)
        {
            _dao = dao;
        }

        public bool add(Consume data)
        {
            return _dao.Add(data);
        }

        public bool update(Consume data)
        {
            return _dao.Update(data);
        }

        public bool delete(Consume data)
        {
            return _dao.Update(data);
        }

        public IEnumerable<Consume> select(Expression<Func<Consume, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public Consume find(int id)
        {
            Consume item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new Consume();

            return item;
        }
    }
}
