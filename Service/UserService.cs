using DAO;
using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service
{
    public interface IUserService
    {
        User find(int id);

        bool add(User User);

        bool update(User data);

        bool delete(User data);

        IEnumerable<User> select_active_items();

        IEnumerable<User> select(Expression<Func<User, bool>> filter);
    }

    public class UserService : IUserService
    {
        private IUserDAO _dao; 

        public UserService(IUserDAO dao)
        {
            _dao = dao;
        }

        public bool add(User User)
        {
            return _dao.Add(User);
        }

        public bool delete(User data)
        {
            data.Deleted = true;
            return _dao.Update(data);
        }

        public User find(int id)
        {
            User item = _dao.Select(s => s.ID == id).FirstOrDefault();

            if (item == null)
                item = new User();

            return item;
        }

        public IEnumerable<User> select_active_items()
        {
            return _dao.Select(s => s.Deleted == false && s.ID > 0);
        }

        public IEnumerable<User> select(Expression<Func<User, bool>> filter)
        {
            return _dao.Select(filter);
        }

        public bool update(User data)
        {
            return _dao.Update(data);
        }
    }
}
