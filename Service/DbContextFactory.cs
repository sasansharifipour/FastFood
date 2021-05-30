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
        public DBContext Create()
        {
            return new DBContext();
        }
    }
}
