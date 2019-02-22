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
    public class SkillsController : ApiController
    {
        // GET: api/Skill
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        } 
        public IEnumerable<Skill> Get()
        {
            return _skillService.Get();
        }

        // GET: api/Skill/5
        public Skill Get(int id)
        {
            return _skillService.Get(id);
        }

        // POST: api/Skill
        public void Post(SkillParam skillParam)
        {
            _skillService.insert(skillParam);
        }

        // PUT: api/Skill/5
        public void Put(int id, SkillParam skillParam)
        {
            _skillService.update(id, skillParam);
        }

        // DELETE: api/Skill/5
        public void Delete(int id)
        {
            _skillService.delete(id);
        }
    }
}
