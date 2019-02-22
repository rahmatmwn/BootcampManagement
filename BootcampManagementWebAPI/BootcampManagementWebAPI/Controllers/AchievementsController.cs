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
    public class AchievementsController : ApiController
    {
        // GET: api/Achievements
        private readonly IAchievementService _achievementService;
        public AchievementsController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }
        public IEnumerable<Achievement> Get()
        {
            return _achievementService.Get();
        }

        // GET: api/Achievements/5
        public Achievement Get(int id)
        {
            return _achievementService.Get(id);
        }

        // POST: api/Achievements
        public void Post(AchievementParam achievementParam)
        {
            _achievementService.insert(achievementParam);
        }

        // PUT: api/Achievements/5
        public void Put(int id, AchievementParam achievementParam)
        {
            _achievementService.update(id, achievementParam);

        }

        // DELETE: api/Achievements/5
        public void Delete(int id)
        {
            _achievementService.delete(id);
        }
    }
}
