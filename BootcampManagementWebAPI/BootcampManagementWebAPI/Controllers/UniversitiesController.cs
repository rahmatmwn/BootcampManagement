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
    public class UniversitiesController : ApiController
    {
        // GET: api/Universities
        private readonly IUniversityService _universityService;
        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }
        public IEnumerable<University> Get()
        {
            return _universityService.Get();
        }

        // GET: api/Universities/5
        public University Get(int id)
        {
            return _universityService.Get(id);
        }

        // POST: api/Universities
        public void Post(UniversityParam universityParam)
        {
            _universityService.insert(universityParam);
        }

        // PUT: api/Universities/5
        public void Put(int id, UniversityParam universityParam)
        {
            _universityService.update(id, universityParam);
        }

        // DELETE: api/Universities/5
        public void Delete(int id)
        {
            _universityService.delete(id);
        }
    }
}
