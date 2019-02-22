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
    public class WorkExperiencesController : ApiController
    {
        // GET: api/WorkExperiences
        // GET: api/WorkExperiences
        private readonly IWorkExperienceService _workExperienceService;
        public WorkExperiencesController(IWorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }
        public IEnumerable<WorkExperience> Get()
        {
            return _workExperienceService.Get();
        }

        // GET: api/WorkExperiences/5
        public WorkExperience Get(int id)
        {
            return _workExperienceService.Get(id);
        }

        // POST: api/WorkExperiences
        public void Post(WorkExperienceParam workExperienceParam)
        {
            _workExperienceService.insert(workExperienceParam);
        }

        // PUT: api/WorkExperiences/5
        public void Put(int id, WorkExperienceParam workExperienceParam)
        {
            _workExperienceService.update(id, workExperienceParam);

        }

        // DELETE: api/WorkExperiences/5
        public void Delete(int id)
        {
            _workExperienceService.delete(id);
        }
    }
}
