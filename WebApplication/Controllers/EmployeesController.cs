using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using EmployeeDataAccess1;
using System.Data.Entity;
using EmployeeDataAccess;

namespace WebApplication.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            List<Employee> ddd = new List<Employee>();
           // DbSet<Employee> dbset = null;
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                foreach (var item in entities.Employees.ToList())
                {
                    Employee employee = new Employee();
                    employee.Address = item.Address;
                    employee.FirstName = item.FirstName;
                    employee.LastName = item.LastName;
                    employee.EmployeeID = item.EmployeeID;

                    ddd.Add(employee);

                }
            }

            return ddd;

            //foreach
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {


            List<Employee> ddd = new List<Employee>();
            // DbSet<Employee> dbset = null;
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                foreach (var item in entities.Employees.ToList())
                {
                    Employee employee = new Employee();
                    employee.Address = item.Address;
                    employee.EmployeeID = item.EmployeeID;

                    ddd.Add(employee);

                }
            }
            return ddd.FirstOrDefault(e => e.EmployeeID == id);
            //using (EmployeeDBEntities entities = new EmployeeDBEntities()) {
            //    return entities.Employees.FirstOrDefault(e => e.EmployeeID == id);
            //        }
            //}
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            //List<Employee> ddd = new List<Employee>();
            // DbSet<Employee> dbset = null;
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {

                    entities.Employees.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.EmployeeID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
    
}