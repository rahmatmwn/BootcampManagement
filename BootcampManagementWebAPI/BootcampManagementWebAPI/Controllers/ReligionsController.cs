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
    public class ReligionsController : ApiController
    {
        // GET: api/Religions
        private readonly IReligionService _religionService;
        public ReligionsController(IReligionService religionService)
        {
            _religionService = religionService;
        }
        public IEnumerable<Religion> Get()
        {
            return _religionService.Get();
        }

        // GET: api/Religions/5
        public Religion Get(int id)
        {
            return _religionService.Get(id);
        }

        // POST: api/Religions
        public void Post(ReligionParam religionParam)
        {
            _religionService.insert(religionParam);
        }

        // PUT: api/Religions/5
        public void Put(int id, ReligionParam religionParam)
        {
            _religionService.update(id, religionParam);
        }

        // DELETE: api/Religions/5
        public void Delete(int id)
        {
            _religionService.delete(id);
        }
    }
}
