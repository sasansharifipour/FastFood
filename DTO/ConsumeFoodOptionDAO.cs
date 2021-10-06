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
    public interface IConsumeFoodOptionDAO : IBaseDAO<ConsumeFoodOption>
    {

    }

    public class ConsumeFoodOptionDAO : IConsumeFoodOptionDAO
    {
        public bool Add(ConsumeFoodOption data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.ConsumeFoodOptions.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(ConsumeFoodOption data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    db.ConsumeFoodOptions.Remove(data);
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

        public IEnumerable<ConsumeFoodOption> Select(Expression<Func<ConsumeFoodOption, bool>> filter)
        {
            IEnumerable<ConsumeFoodOption> result = new List<ConsumeFoodOption>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.ConsumeFoodOptions.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<ConsumeFoodOption>();

            return result;
        }

        public bool Update(ConsumeFoodOption data)
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
