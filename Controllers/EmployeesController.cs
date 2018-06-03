using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PracticeAPI.Models.DBModels;
using PracticeAPI.CustomModels.Factory;
using PracticeAPI.CustomModels;
namespace PracticeAPI.Controllers
{
    public class EmployeesController : ApiController
    {

        DB getFactoryInstance;
        IDBOperations getData;

        EmployeesController()
        {
            getFactoryInstance = new DB();
            getData = getFactoryInstance.getDBInstance();
        }

        public IEnumerable<tblEmployee> Get()
        {
            return getData.getList();
        }

        public tblEmployee Get(int id)
        {
            return getData.getById(id);
        }
    }
}
