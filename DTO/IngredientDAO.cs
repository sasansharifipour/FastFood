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
    public interface IIngredientDAO : IBaseDAO<Ingredient>
    {

    }

    public class IngredientDAO : IIngredientDAO
    {
        public bool Add(Ingredient data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.Ingredients.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(Ingredient data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    data.Deleted = true;
                    db.Ingredients.AddOrUpdate(data);
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

        public IEnumerable<Ingredient> Select(Expression<Func<Ingredient, bool>> filter)
        {
            IEnumerable<Ingredient> result = new List<Ingredient>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.Ingredients.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<Ingredient>();

            return result;
        }

        public bool Update(Ingredient data)
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
