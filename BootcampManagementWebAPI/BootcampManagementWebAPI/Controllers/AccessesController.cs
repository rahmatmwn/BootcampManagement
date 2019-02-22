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
    public class AccessesController : ApiController
    {
        // GET: api/Access
        private readonly IAccessService _accessService;
        public AccessesController(IAccessService accessService)
        {
            _accessService = accessService;
        }
        
        public IEnumerable<Access> Get()
        {
            return _accessService.Get();
        }

        // GET: api/Access/5
        public Access Get(int id)
        {
            return _accessService.Get(id);
        }

        // POST: api/Access
        public void Post(AccessParam accessParam)
        {
            _accessService.insert(accessParam);
        }

        // PUT: api/Access/5
        public void Put(int id, AccessParam accessParam)
        {
            _accessService.update(id, accessParam);
        }

        // DELETE: api/Access/5
        public void Delete(int id)
        {
            _accessService.delete(id);
        }
    }
}
