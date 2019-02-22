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
    public class LockersController : ApiController
    {

        // GET: api/Locker
        // GET: api/Lockers
        private readonly ILockerService _lockerService;
        public LockersController(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }
        public IEnumerable<Locker> Get()
        {
            return _lockerService.Get();
        }

        // GET: api/Lockers/5
        public Locker Get(int id)
        {
            return _lockerService.Get(id);
        }

        // POST: api/Lockers
        public void Post(LockerParam lockerParam)
        {
            _lockerService.insert(lockerParam);
        }

        // PUT: api/Lockers/5
        public void Put(int id, LockerParam lockerParam)
        {
            _lockerService.update(id, lockerParam);

        }

        // DELETE: api/Lockers/5
        public void Delete(int id)
        {
            _lockerService.delete(id);
        }
    }
}
