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
    public class PlacementsController : ApiController
    {
        
        // GET: api/Placements
        private readonly IPlacementService _placementService;
        public PlacementsController(IPlacementService placementService)
        {
            _placementService = placementService;
        }
        public IEnumerable<Placement> Get()
        {
            return _placementService.Get();
        }

        // GET: api/Placements/5
        public Placement Get(int id)
        {
            return _placementService.Get(id);
        }

        // POST: api/Placements
        public void Post(PlacementParam placementParam)
        {
            _placementService.insert(placementParam);
        }

        // PUT: api/Placements/5
        public void Put(int id, PlacementParam placementParam)
        {
            _placementService.update(id, placementParam);

        }

        // DELETE: api/Placements/5
        public void Delete(int id)
        {
            _placementService.delete(id);
        }
    }
}
