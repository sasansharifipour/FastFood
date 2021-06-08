using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Service
{
    public class DbContextFactory : IDbContextFactory<DBContext>
    {
        private DBContext _instance;

        public DbContextFactory()
        {
            if (_instance == null)
                _instance = new DBContext();
        }

        public DBContext Create()
        {
            if (_instance == null)
                _instance = new DBContext();

            return _instance;
        }
    }
}
