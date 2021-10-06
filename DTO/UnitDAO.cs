using DAO;
using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAO
{
    public interface IUnitDAO : IBaseDAO<Unit>
    {

    }

    public class UnitDAO : IUnitDAO
    {
        public bool Add(Unit data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Units.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(Unit data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    data.Deleted = true;
                    db.Units.AddOrUpdate(data);
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

        public IEnumerable<Unit> Select(Expression<Func<Unit, bool>> filter)
        {
            IEnumerable<Unit> result = new List<Unit>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.Units.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<Unit>();

            return result;
        }

        public bool Update(Unit data)
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
