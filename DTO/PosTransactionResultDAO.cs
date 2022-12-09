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
    public interface IPosTransactionResultDAO : IBaseDAO<PosTransactionResult>
    {

    }

    public class PosTransactionResultDAO : IPosTransactionResultDAO
    {
        public bool Add(PosTransactionResult data)
        {
            try
            {
                using (var db = new DBContext())
                {
                    db.PosTransactionResults.Add(data);
                    int cnt = db.SaveChanges();

                    if (cnt > 0)
                        return true;
                }
            }
            catch (Exception e)
            { }

            return false;
        }

        public bool Delete(PosTransactionResult data)
        {
            bool deleted = false;

            try
            {
                using (var db = new DBContext())
                {
                    data.Deleted = true;
                    db.PosTransactionResults.AddOrUpdate(data);
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

        public IEnumerable<PosTransactionResult> Select(Expression<Func<PosTransactionResult, bool>> filter)
        {
            IEnumerable<PosTransactionResult> result = new List<PosTransactionResult>();

            try
            {
                using (var db = new DBContext())
                {
                    result = db.PosTransactionResults.Where(filter).ToList();
                }
            }
            catch (Exception e)
            {
            }

            if (result == null)
                result = new List<PosTransactionResult>();

            return result;
        }

        public bool Update(PosTransactionResult data)
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
