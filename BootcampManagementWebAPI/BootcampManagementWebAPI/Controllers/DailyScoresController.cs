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
    public class DailyScoresController : ApiController
    {
        private readonly IDailyScoreService _dailyScoreService;
        public DailyScoresController(IDailyScoreService dailyScoreService)
        {
            _dailyScoreService = dailyScoreService;
        }
        // GET: api/DailyScores
        public IEnumerable<DailyScore> Get()
        {
            return _dailyScoreService.Get();
        }

        // GET: api/DailyScores/5
        public DailyScore Get(int id)
        {
            return _dailyScoreService.Get(id);
        }

        // POST: api/DailyScores
        public void Post(DailyScoreParam dailyScoreParam)
        {
            _dailyScoreService.insert(dailyScoreParam);
        }

        // PUT: api/DailyScores/5
        public void Put(int id, DailyScoreParam dailyScoreParam)
        {
            _dailyScoreService.update(id, dailyScoreParam);
        }

        // DELETE: api/DailyScores/5
        public void Delete(int id)
        {
            _dailyScoreService.delete(id);
        }
    }
}
