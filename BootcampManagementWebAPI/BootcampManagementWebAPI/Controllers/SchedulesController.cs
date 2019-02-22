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
    public class SchedulesController : ApiController
    {
        // GET: api/Schedule
        private readonly IScheduleService _scheduleService;
        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        } 
        public IEnumerable<Schedule> Get()
        {
            return _scheduleService.Get();
        }

        // GET: api/Schedule/5
        public Schedule Get(int id)
        {
            return _scheduleService.Get(id);
        }

        // POST: api/Schedule
        public void Post(ScheduleParam scheduleParam)
        {
            _scheduleService.insert(scheduleParam);
        }

        // PUT: api/Schedule/5
        public void Put(int id, ScheduleParam scheduleParam)
        {
            _scheduleService.update(id, scheduleParam);
        }

        // DELETE: api/Schedule/5
        public void Delete(int id)
        {
            _scheduleService.delete(id);
        }
    }
}
