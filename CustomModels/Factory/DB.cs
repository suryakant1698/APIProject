using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeAPI.CustomModels.Factory
{
    public class DB
    {
        public DBOperations getDBInstance()
        {
            return new DBOperations();
        }
    }
}