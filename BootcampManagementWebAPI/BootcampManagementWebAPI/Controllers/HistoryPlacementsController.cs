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
    public class HistoryPlacementsController : ApiController
    {
        // GET: api/HistoryPlacements
        private readonly IHistoryPlacementService _historyPlacementService;
        public HistoryPlacementsController(IHistoryPlacementService historyPlacementService)
        {
            _historyPlacementService = historyPlacementService;
        }
        public IEnumerable<HistoryPlacement> Get()
        {
            return _historyPlacementService.Get();
        }

        // GET: api/HistoryPlacements/5
        public HistoryPlacement Get(int id)
        {
            return _historyPlacementService.Get(id);
        }

        // POST: api/HistoryPlacements
        public void Post(HistoryPlacementParam historyPlacementParam)
        {
            _historyPlacementService.insert(historyPlacementParam);
        }

        // PUT: api/HistoryPlacements/5
        public void Put(int id, HistoryPlacementParam historyPlacementParam)
        {
            _historyPlacementService.update(id, historyPlacementParam);
        }

        // DELETE: api/HistoryPlacements/5
        public void Delete(int id)
        {
            _historyPlacementService.delete(id);
        }
    }
}
