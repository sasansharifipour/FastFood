using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.BaseClasses;
using Model;

namespace DTO
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;

        public UnitOfWork(DBContext context)
        {
            _context = context;

            Consumes = new Repository<Consume>(_context);
            ConsumeFoodOptions = new Repository<ConsumeFoodOption>(_context);
            Customers = new Repository<Customer>(_context);
            Foods = new FoodRepository(_context);
            FoodOptions = new Repository<FoodOption>(_context);
            Ingredients = new Repository<Ingredient>(_context);
            Orders = new OrderRepository(_context);
            OrderItems = new Repository<OrderItem>(_context);
            PosTransactionResults = new Repository<PosTransactionResult>(_context);
            Units = new Repository<Unit>(_context);
            Users = new Repository<User>(_context);
        }

        public IRepository<Consume> Consumes { get; private set; }
        public IRepository<ConsumeFoodOption> ConsumeFoodOptions { get; private set; }
        public IRepository<Customer> Customers { get; private set; }
        public IFoodRepository Foods { get; private set; }
        public IRepository<FoodOption> FoodOptions { get; private set; }
        public IRepository<Ingredient> Ingredients { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        public IRepository<PosTransactionResult> PosTransactionResults { get; private set; }
        public IRepository<Unit> Units { get; private set; }
        public IRepository<User> Users { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
