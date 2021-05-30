using DAO;
using Domain.BaseClasses;
using Model;
using Service;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;
using Unity;

namespace Windows_UI
{
    public static class Bootstrapper
    {
        public static IUnityContainer Init()
        {
            var container = new UnityContainer();
            container.RegisterType<DBContext, DBContext>();
            container.RegisterType<DbContext, DBContext>();
            container.RegisterSingleton<IDbContextFactory<DBContext>, DbContextFactory>();
            container.RegisterSingleton<IDbContextFactory<DbContext>, DbContextFactory>();

            container.RegisterSingleton<IBaseDAO<Customer>, BaseDAO<Customer>>();
            container.RegisterSingleton<ICustomerDAO, CustomerDAO>();
            container.RegisterSingleton<ICustomerService, CustomerService>();


            container.RegisterSingleton<IBaseDAO<Food>, BaseDAO<Food>>();
            container.RegisterSingleton<IFoodDAO, FoodDAO>();
            container.RegisterSingleton<IFoodService, FoodService>();

            container.RegisterType<Form, Form1>("Form1");

            return container;
        }
    }
}
