using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IPosTransactionResultService
    {
        PosTransactionResult find(int id);

        bool add(PosTransactionResult data);

        bool update(PosTransactionResult data);

        bool delete(PosTransactionResult data);

        IEnumerable<PosTransactionResult> select_active_items();

        IEnumerable<PosTransactionResult> select(Expression<Func<PosTransactionResult, bool>> filter);
    }

    public class PosTransactionResultService : IPosTransactionResultService
    {
        private IPosTransactionResultDAO _dao; 

        public PosTransactionResultService(IPosTransactionResultDAO dao)
        {
            _dao = dao;
        }

        public bool add(PosTransactionResult data)
        {
            return _dao.Add(data);
        }

        public bool update(PosTransactionResult data)
        {
            return _dao.Update(data);
        }

        public bool delete(PosTransactionResult data)
        {
            data.Deleted = true;
            return _dao.Update(data);
        }

        public IEnumerable<PosTransactionResult> select_active_items()
        {
            return _dao.Select(s => s.Deleted == false && s.ID > 0);
        }

        public IEnumerable<PosTransactionResult> select(Expression<Func<PosTransactionResult, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public PosTransactionResult find(int id)
        {
            PosTransactionResult item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new PosTransactionResult();

            return item;
        }

    }
}
