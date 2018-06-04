using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Http;
using PracticeAPI.Models.DBModels;
using PracticeAPI.CustomModels.Factory;
using PracticeAPI.CustomModels;
namespace PracticeAPI.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {

        DB getFactoryInstance;
        IDBOperations getData;

        EmployeesController()
        {
            getFactoryInstance = new DB();
            getData = getFactoryInstance.getDBInstance();
        }

        [HttpGet]
        public IEnumerable<tblEmployee> Get()
        {
            return getData.getList();
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var entity = getData.getById(id);
            if (entity != null)
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + " Not found");

        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
            {
                getData.addEmployee(employee);
                var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (getData.deleteEmployee(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No employee with id " + id + "available");
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id,[FromBody]Employee employee)
        {
            try
            {
                if (getData.updateEmployee(id, employee))
                {

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No employees with id " + id + " Found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }
    }
}
