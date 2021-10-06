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
using System.Data.Entity.Migrations;

namespace DAO
{
    public interface IConsumeDAO : IBaseDAO<Consume>
    {

    }

    public class ConsumeDAO : IConsumeDAO
    {
        public bool Add(Consume data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Consumes.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(Consume data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    db.Consumes.Remove(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        deleted = true;
                }
            }
            catch (Exception e)
            {
            }

            return deleted;
        }

        public IEnumerable<Consume> Select(Expression<Func<Consume, bool>> filter)
        {
            IEnumerable<Consume> result = new List<Consume>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.Consumes.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<Consume>();

            return result;
        }

        public bool Update(Consume data)
        {
            bool added = false;

            try
            {
                using (var db = new DBContext())
                {
                    var new_data = db.Entry(data);
                    new_data.State = System.Data.Entity.EntityState.Modified;
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        added = true;
                }
            }
            catch (Exception e)
            {
            }

            return added;
        }
    }
}
