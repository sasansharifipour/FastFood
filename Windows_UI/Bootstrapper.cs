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
            container.RegisterSingleton<DBContext, DBContext>();
            container.RegisterSingleton<DbContext, DBContext>();

            container.RegisterSingleton<IConfigFile, ConfigFile>();

            container.RegisterSingleton<IBaseDAO<Customer>, BaseDAO<Customer>>();
            container.RegisterSingleton<ICustomerDAO, CustomerDAO>();
            container.RegisterSingleton<ICustomerService, CustomerService>();

            container.RegisterSingleton<IBaseDAO<Food>, BaseDAO<Food>>();
            container.RegisterSingleton<IFoodDAO, FoodDAO>();
            container.RegisterSingleton<IFoodService, FoodService>();

            container.RegisterSingleton<IBaseDAO<Order>, BaseDAO<Order>>();
            container.RegisterSingleton<IOrderDAO, OrderDAO>();
            container.RegisterSingleton<IOrderService, OrderService>();

            container.RegisterSingleton<IBaseDAO<OrderItem>, BaseDAO<OrderItem>>();
            container.RegisterSingleton<IOrderItemDAO, OrderItemDAO>();
            container.RegisterSingleton<IOrderItemService, OrderItemService>();

            container.RegisterSingleton<IBaseDAO<Unit>, BaseDAO<Unit>>();
            container.RegisterSingleton<IUnitDAO, UnitDAO>();
            container.RegisterSingleton<IUnitService, UnitService>();

            container.RegisterSingleton<IBaseDAO<Ingredient>, BaseDAO<Ingredient>>();
            container.RegisterSingleton<IIngredientDAO, IngredientDAO>();
            container.RegisterSingleton<IIngredientService, IngredientService>();

            container.RegisterSingleton<Form, Form1>("Form1");
            container.RegisterSingleton<Form, Add_Food>("add_food");
            container.RegisterSingleton<Form, Add_Unit>("add_unit");
            container.RegisterSingleton<Form, Add_Order>("add_order");
            container.RegisterSingleton<Form, Add_Customer>("add_customer");
            container.RegisterSingleton<Form, Add_Ingredient>("add_ingredient");
            container.RegisterSingleton<Form, Add_Food_Ingredient>("add_food_ingredient");
            container.RegisterSingleton<Form, Delete_Order>("delete_order");

            return container;
        }
    }
}
