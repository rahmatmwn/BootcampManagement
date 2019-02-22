using BusinessLogic.Service;
using Common.Interface;
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
    public class DepartmentsController : ApiController
    {
        // GET: api/Department
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IEnumerable<Department> Get()
        {
            return _departmentService.Get();
        }

        // GET: api/Department/5
        public Department Get(int id)
        {
            return _departmentService.Get(id);
        }

        // POST: api/Department
        public void Post(DepartmentParam departmentParam)
        {
            _departmentService.insert(departmentParam);
        }

        // PUT: api/Department/5
        public void Put(int id, DepartmentParam departmentParam)
        {
            _departmentService.update(id, departmentParam);
        }

        // DELETE: api/Department/5
        public void Delete(int id)
        {
            _departmentService.delete(id);
        }
    }
}
