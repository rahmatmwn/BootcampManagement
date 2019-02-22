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
    public class StudentAccessesController : ApiController
    {
        // GET: api/StudentAccesses
        
        private readonly IStudentAccessService _studentAccessService;
        public StudentAccessesController(IStudentAccessService studentAccessService)
        {
            _studentAccessService = studentAccessService;
        }
        public IEnumerable<StudentAccess> Get()
        {
            return _studentAccessService.Get();
        }

        // GET: api/StudentAccesses/5
        public StudentAccess Get(int id)
        {
            return _studentAccessService.Get(id);
        }

        // POST: api/StudentAccesses
        public void Post(StudentAccessParam studentAccessParam)
        {
            _studentAccessService.insert(studentAccessParam);
        }

        // PUT: api/StudentAccesses/5
        public void Put(int id, StudentAccessParam studentAccessParam)
        {
            _studentAccessService.update(id, studentAccessParam);

        }

        // DELETE: api/StudentAccesses/5
        public void Delete(int id)
        {
            _studentAccessService.delete(id);
        }
    }
}
