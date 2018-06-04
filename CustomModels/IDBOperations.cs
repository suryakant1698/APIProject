using PracticeAPI.Models.DBModels;
using System.Collections.Generic;

namespace PracticeAPI.CustomModels
{
    public interface IDBOperations
    {
        IEnumerable<tblEmployee> getList();
        tblEmployee getById(int id);
        void addEmployee(Employee newEmployee);
        bool deleteEmployee(int id);
        bool updateEmployee(int id,Employee employee);
    }
}
