using BusinessLogic.Service;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BootcampManagementWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/Employees
        public IEnumerable<Employee> Get()
        {
            return _employeeService.Get();
        }

        // GET: api/Employees/5
        public Employee Get(int id)
        {
            return _employeeService.Get(id);
        }

        // POST: api/Employees
        public void Post(EmployeeParam employeeParam)
    {
            _employeeService.insert(employeeParam);
    }

    // PUT: api/Employees/5
    public void Put(int id, EmployeeParam employeeParam)
    {
            _employeeService.update(id, employeeParam);
    }

    // DELETE: api/Employees/5
    public void Delete(int id)
    {
            _employeeService.delete(id);
    }
}
}
