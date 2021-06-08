using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAO
{
    public interface IBaseDAO<T> where T : class
    {
        bool Add(T data);

        bool Delete(T data);

        bool Update(T data);

        IEnumerable<T> Select(Expression<Func<T, bool>> filter);
    }

    public class BaseDAO<T> : IBaseDAO<T> where T : class
    {
        private IDbContextFactory<DbContext> _db_factory;
        private DbContext _db;

        public BaseDAO(IDbContextFactory<DbContext> db_factory, DbContext db)
        {
            _db_factory = db_factory;
            _db = db;
        }

        public bool Add(T data)
        {
            bool added = false;

            try
            {
                var context = _db.Set<T>();
                context.Add(data);
                int cnt = _db.SaveChanges();

                if (cnt > 0)
                    added = true;
            }
            catch (Exception e)
            {
            }

            return added;
        }

        public bool Delete(T data)
        {
            bool deleted = false;

            try
            {
                var context = _db.Set<T>();
                context.Remove(data);
                int cnt = _db.SaveChanges();

                if (cnt > 0)
                    deleted = true;
            }
            catch (Exception e)
            {
            }

            return deleted;
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> filter)
        {
            IEnumerable<T> result = new List<T>();

            try
            {
                var context = _db.Set<T>();
                result = context.Where<T>(filter).ToList();
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<T>();

            return result;
        }

        public bool Update(T data)
        {
            bool added = false;

            try
            {
                _db.Entry(data);
                int cnt = _db.SaveChanges();

                if (cnt > 0)
                    added = true;
            }
            catch (Exception e)
            {
            }

            return added;
        }
    }
}
