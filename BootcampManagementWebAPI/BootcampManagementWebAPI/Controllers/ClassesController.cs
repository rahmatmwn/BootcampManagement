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
    public class ClassesController : ApiController
    {
        // GET: api/Class
        private readonly IClassService _classService;
        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }
        public IEnumerable<Class> Get()
        {
            return _classService.Get();
        }

        // GET: api/Class/5
        public Class Get(int id)
        {
            return _classService.Get(id);
        }

        // POST: api/Class
        public void Post(ClassParam classParam)
        {
            _classService.insert(classParam);
        }

        // PUT: api/Class/5
        public void Put(int id, ClassParam classParam)
        {
            _classService.update(id, classParam);
        }

        // DELETE: api/Class/5
        public void Delete(int id)
        {
            _classService.delete(id);
        }
    }
}
