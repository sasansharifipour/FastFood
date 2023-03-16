using Domain.BaseClasses;
using DTO;
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
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterSingleton<DbContext, DBContext>();
            container.RegisterSingleton<IPrintService, PrintService>();

            container.RegisterSingleton<IConfigService, ConfigService>();

            container.RegisterSingleton<IReportService, ReportService>();
            container.RegisterSingleton<ISendInformationService, SendEmailService>();

            container.RegisterSingleton<Form, Form1>("Form1");
            container.RegisterSingleton<Form, Add_Food>("add_food");
            container.RegisterSingleton<Form, Show_All_Foods>("all_foods");
            container.RegisterSingleton<Form, Add_FoodOption>("add_foodoption");
            container.RegisterSingleton<Form, Add_Unit>("add_unit");
            container.RegisterSingleton<Form, Add_Order>("add_order");
            container.RegisterSingleton<Form, Add_Customer>("add_customer");
            container.RegisterSingleton<Form, Person_Debt>("person_debt");
            container.RegisterSingleton<Form, Add_User>("add_user");
            container.RegisterSingleton<Form, Loggin_Form>("login_form");
            container.RegisterSingleton<Form, Add_Ingredient>("add_ingredient");
            container.RegisterSingleton<Form, Add_FoodOption_Ingredient>("add_foodoption_ingredient");
            container.RegisterSingleton<Form, Add_Food_Ingredient>("add_food_ingredient");
            container.RegisterSingleton<Form, Delete_Order>("delete_order");
            container.RegisterSingleton<Form, Edit_Order>("edit_order");
            container.RegisterSingleton<Form, Report_Ingredient>("report_ingredient");
            container.RegisterSingleton<Form, Report_Orders>("report_orders");
            container.RegisterSingleton<Create_Special_Food, Create_Special_Food>();
            container.RegisterSingleton<ITransactionDoneAdvanceHandler, PosResult>();

            return container;
        }
    }
}
