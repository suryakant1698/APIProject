using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeAPI.CustomModels
{
    public class Login
    {
        public static bool LoginOperation(string username,string password)
        {
            using (practiceAPIEntities dbOperation=new practiceAPIEntities())
            {
                return dbOperation.tblUsers.Any(user=>user.Username.Equals(username,StringComparison.OrdinalIgnoreCase)&&user.Password==password);
            }
        }
    }
}