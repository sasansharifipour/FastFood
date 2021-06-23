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
    public interface IUserDAO : IBaseDAO<User>
    {

    }

    public class UserDAO : IUserDAO
    {
        private DbContext _db;
        private IBaseDAO<User> _crud_operator;

        public UserDAO(DbContext db, IBaseDAO<User> crud_operator)
        {
            _db = db;
            _crud_operator = crud_operator;
        }

        public bool Add(User data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(User data)
        {
            return _crud_operator.Delete(data);
        }


        public IEnumerable<User> Select(Expression<Func<User, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(User data)
        {
            return _crud_operator.Update(data);
        }
    }
}
