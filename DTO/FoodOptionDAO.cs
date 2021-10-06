using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAO
{
    public interface IFoodOptionDAO : IBaseDAO<FoodOption>
    {

    }

    public class FoodOptionDAO : IFoodOptionDAO
    {
        public bool Add(FoodOption data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.FoodOptions.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(FoodOption data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    data.Deleted = true;
                    db.FoodOptions.AddOrUpdate(data);
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

        public IEnumerable<FoodOption> Select(Expression<Func<FoodOption, bool>> filter)
        {
            IEnumerable<FoodOption> result = new List<FoodOption>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.FoodOptions.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<FoodOption>();

            return result;
        }

        public bool Update(FoodOption data)
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
