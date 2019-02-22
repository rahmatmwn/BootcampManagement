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
    public class StudentLockersController : ApiController
    {
      
        // GET: api/StudentLockers
        private readonly IStudentLockerService _studentLockerService;
        public StudentLockersController(IStudentLockerService studentLockerService)
        {
            _studentLockerService = studentLockerService;
        }
        public IEnumerable<StudentLocker> Get()
        {
            return _studentLockerService.Get();
        }

        // GET: api/StudentLockers/5
        public StudentLocker Get(int id)
        {
            return _studentLockerService.Get(id);
        }

        // POST: api/StudentLockers
        public void Post(StudentLockerParam studentLockerParam)
        {
            _studentLockerService.insert(studentLockerParam);
        }

        // PUT: api/StudentLockers/5
        public void Put(int id, StudentLockerParam studentLockerParam)
        {
            _studentLockerService.update(id, studentLockerParam);

        }

        // DELETE: api/StudentLockers/5
        public void Delete(int id)
        {
            _studentLockerService.delete(id);
        }
    }
}
