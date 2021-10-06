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
    public interface IFoodDAO : IBaseDAO<Food>
    {
        IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> filter);

    }

    public class FoodDAO : IFoodDAO
    {
        public bool Add(Food data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Foods.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(Food data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    data.Deleted = true;
                    db.Foods.AddOrUpdate(data);
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

        public IEnumerable<Food> Select(Expression<Func<Food, bool>> filter)
        {
            IEnumerable<Food> result = new List<Food>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.Foods.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<Food>();

            return result;
        }

        public bool Update(Food data)
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
    
        public IEnumerable<Food> Eager_Select(Expression<Func<Food, bool>> filter)
        {
            IEnumerable<Food> result = new List<Food>();

            using (var db = new DBContext())
            {
                result = db.Foods.Where(filter).Include(x => x.Consumes.Select(s => s.Ingredient)).ToList();
            }
            
            if (result == null)
                result = new List<Food>();

            return result;
        }
    }
}
