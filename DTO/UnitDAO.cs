﻿using DAO;
using Domain.BaseClasses;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        private IBaseDAO<Unit> _crud_operator;

        public UnitDAO(IBaseDAO<Unit> crud_operator)
        {
            _crud_operator = crud_operator;
        }

        public bool Add(Unit data)
        {
            return _crud_operator.Add(data);
        }

        public bool Delete(Unit data)
        {
            return _crud_operator.Delete(data);
        }

        public IEnumerable<Unit> Select(Expression<Func<Unit, bool>> filter)
        {
            return _crud_operator.Select(filter);
        }

        public bool Update(Unit data)
        {
            return _crud_operator.Update(data);
        }
    }
}