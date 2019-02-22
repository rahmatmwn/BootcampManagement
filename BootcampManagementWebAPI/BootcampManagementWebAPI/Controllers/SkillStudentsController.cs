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
    public class SkillStudentsController : ApiController
    {
        // GET: api/SkillStudent
        private readonly ISkillStudentService _skillStudentService;
        public SkillStudentsController(ISkillStudentService skillStudentService)
        {
            _skillStudentService = skillStudentService;
        } 
        public IEnumerable<SkillStudent> Get()
        {
            return _skillStudentService.Get();
        }

        // GET: api/SkillStudent/5
        public SkillStudent Get(int id)
        {
            return _skillStudentService.Get(id);
        }

        // POST: api/SkillStudent
        public void Post(SkillStudentParam skillStudentParam)
        {
            _skillStudentService.insert(skillStudentParam);
        }

        // PUT: api/SkillStudent/5
        public void Put(int id, SkillStudentParam skillStudentParam)
        {
            _skillStudentService.update(id, skillStudentParam);
        }

        // DELETE: api/SkillStudent/5
        public void Delete(int id)
        {
            _skillStudentService.delete(id);
        }
    }
}
