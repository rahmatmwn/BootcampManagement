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
    public class HistoryEducationsController : ApiController
    {
        private readonly IHistoryEducationService _historyEducationService;
        public HistoryEducationsController(IHistoryEducationService historyEducationService)
        {
            _historyEducationService = historyEducationService;
        }
        // GET: api/HistoryEducations
        public IEnumerable<HistoryEducation> Get()
        {
            return _historyEducationService.Get();
        }

        // GET: api/HistoryEducations/5
        public HistoryEducation Get(int id)
        {
            return _historyEducationService.Get(id);
        }

        // POST: api/HistoryEducations
        public void Post(HistoryEducationParam historyEducationParam)
        {
            _historyEducationService.insert(historyEducationParam);
        }

        // PUT: api/HistoryEducations/5
        public void Put(int id, HistoryEducationParam historyEducationParam)
        {
            _historyEducationService.update(id, historyEducationParam);
        }

        // DELETE: api/HistoryEducations/5
        public void Delete(int id)
        {
            _historyEducationService.delete(id);
        }
    }
}
