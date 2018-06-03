using System.Collections.Generic;

namespace PracticeAPI.CustomModels
{
    public interface IDBOperations
    {
        IEnumerable<tblEmployee> getList();
        tblEmployee getById(int id);
    }
}