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
    public class WeeklyScoresController : ApiController
    {
        private readonly IWeeklyScoreService _weeklyScoreService;
        public WeeklyScoresController(IWeeklyScoreService weeklyScoreService)
        {
            _weeklyScoreService = weeklyScoreService;
        }
        // GET: api/WeeklyScores
        public IEnumerable<WeeklyScore> Get()
        {
            return _weeklyScoreService.Get();
        }

        // GET: api/WeeklyScores/5
        public WeeklyScore Get(int id)
        {
            return _weeklyScoreService.Get(id);
        }

        // POST: api/WeeklyScores
        public void Post(WeeklyScoreParam weeklyScoreParam)
        {
            _weeklyScoreService.insert(weeklyScoreParam);
        }

        // PUT: api/WeeklyScores/5
        public void Put(int id, WeeklyScoreParam weeklyScoreParam)
        {
            _weeklyScoreService.update(id, weeklyScoreParam);
        }

        // DELETE: api/WeeklyScores/5
        public void Delete(int id)
        {
            _weeklyScoreService.delete(id);
        }
    }
}
