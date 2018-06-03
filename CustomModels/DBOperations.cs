using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeAPI.CustomModels
{
    
    public class DBOperations : IDBOperations
    {
        
        public IEnumerable<tblEmployee> getList()
        {
        using (practiceAPIEntities list = new practiceAPIEntities())
            {
                return list.tblEmployees.ToList();
            }
        }
        public tblEmployee getById(int id)
        {
            using (practiceAPIEntities employee = new practiceAPIEntities())
            {
                return employee.tblEmployees.ToList().FirstOrDefault(e=>e.ID==id);
            }

        }
    }
}