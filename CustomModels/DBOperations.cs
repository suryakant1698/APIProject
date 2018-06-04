using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeAPI.Models.DBModels;
using System.Reflection;

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
                return employee.tblEmployees.ToList().FirstOrDefault(e => e.ID == id);
            }

        }
        public void addEmployee(Employee newEmployee)
        {
            using (practiceAPIEntities list = new practiceAPIEntities())
            {
                tblEmployee DbObject = new tblEmployee();
                DbObject.FirstName = newEmployee.FirstName;
                DbObject.LastName = newEmployee.LastName;
                DbObject.Gender = newEmployee.Gender;
                DbObject.Salary = newEmployee.Salary;
                // foreach (var property in DbObject.GetType().GetProperties())
                 //   property.SetValue(DbObject, property.GetValue(newEmployee));
                list.tblEmployees.Add(DbObject);
                list.SaveChanges();
            }
        }

        public bool deleteEmployee(int id)
        {
            using (practiceAPIEntities dbinstance = new practiceAPIEntities())
            {
                var targetItem = dbinstance.tblEmployees.FirstOrDefault(e => e.ID == id);
                if (targetItem == null)
                    return false;
                else
                {
                    dbinstance.tblEmployees.Remove(targetItem);
                    dbinstance.SaveChanges();
                    return true;
                }
            }
        }

        public bool updateEmployee(int id, Employee employee)
        {
            using (practiceAPIEntities oldObject = new practiceAPIEntities())
            {
               var oldEmployee= oldObject.tblEmployees.FirstOrDefault(e=>e.ID==id);
                if (oldEmployee == null)
                    return false;
                else
                {
                    oldEmployee.FirstName = employee.FirstName;
                    oldEmployee.LastName = employee.LastName;
                    oldEmployee.Salary = employee.Salary;
                    oldEmployee.Gender = employee.Gender;
                    oldObject.SaveChanges();
                    return true;
                }
            }
        }
    }
}