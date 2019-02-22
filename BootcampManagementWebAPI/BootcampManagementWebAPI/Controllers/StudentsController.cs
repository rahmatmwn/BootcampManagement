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
    public class StudentsController : ApiController
    {
        // GET: api/Student
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        } 
        public IEnumerable<Student> Get()
        {
            return _studentService.Get();
        }

        // GET: api/Student/5
        public Student Get(int id)
        {
            return _studentService.Get(id);
        }

        // POST: api/Student
        public void Post(StudentParam studentParam)
        {
            _studentService.insert(studentParam);
        }

        // PUT: api/Student/5
        public void Put(int id, StudentParam studentParam)
        {
            _studentService.update(id, studentParam);
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
            _studentService.delete(id);
        }
    }
}
