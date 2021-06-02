using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IUnitService
    {
        Unit find(int id);

        bool add(Unit Unit);

        bool update(Unit data);

        bool delete(Unit data);

        IEnumerable<Unit> select_active_items();

        IEnumerable<Unit> select(Expression<Func<Unit, bool>> filter);
    }

    public class UnitService : IUnitService
    {
        private IUnitDAO _dao; 

        public UnitService(IUnitDAO dao)
        {
            _dao = dao;
        }

        public bool add(Unit Unit)
        {
            return _dao.Add(Unit);
        }

        public bool delete(Unit data)
        {
            data.Deleted = true;
            return _dao.Update(data);
        }

        public Unit find(int id)
        {
            Unit item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new Unit();

            return item;
        }

        public IEnumerable<Unit> select_active_items()
        {
            return _dao.Select(s => s.Deleted == false && s.ID > 0);
        }

        public IEnumerable<Unit> select(Expression<Func<Unit, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public bool update(Unit data)
        {
            return _dao.Update(data);
        }
    }
}
