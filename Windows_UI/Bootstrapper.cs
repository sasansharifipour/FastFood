﻿using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
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
            container.RegisterSingleton<IDbContextFactory<DBContext>, DbContextFactory>();
            container.RegisterType<Form, Form1>("Form1");

            return container;
        }
    }
}
