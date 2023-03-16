using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Consume> Consumes { get; }
        IRepository<ConsumeFoodOption> ConsumeFoodOptions { get; }
        IRepository<Customer> Customers { get; }
        IFoodRepository Foods { get; }
        IRepository<FoodOption> FoodOptions { get; }
        IRepository<Ingredient> Ingredients { get; }
        IOrderRepository Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<PosTransactionResult> PosTransactionResults { get; }
        IRepository<Unit> Units { get; }
        IRepository<User> Users { get; }


        int Complete();
    }
}
