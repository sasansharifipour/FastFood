using Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public static class LoginInfo
    {
        public static User User { get; set; } = null;

        public static bool IsLoggedIn()
        {
            return (User == null || User.ID <= 0) ? false : true;
        }
    }
}
