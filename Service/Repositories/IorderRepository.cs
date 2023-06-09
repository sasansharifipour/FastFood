﻿using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service.Repositories
{
    public interface IOrderRepository  : IRepository<Order>
    {
        IEnumerable<Order> Eager_Select(Expression<Func<Order, bool>> predicate);

        int GetFreeNumber();
    }
}
