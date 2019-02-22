using BusinessLogic.Service;
using BusinessLogic.Service.Master;
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
    public class DistrictsController : ApiController
    {
        // GET: api/Districts
        private readonly IDistrictService _districtService;
        public DistrictsController(DistrictService districtService)
        {
            _districtService = districtService;
        }
        public IEnumerable<District> Get()
        {
            return _districtService.Get();
        }

   
        public IEnumerable<District> GetDistrict(int Id)
        {
            return _districtService.GetDistrict(Id);
        }

        // GET: api/Districts/5
        public District Get(int id)
        {
            return _districtService.Get(id);
        }

        // POST: api/Districts
        public void Post(DistrictParam districtParam)
        {
            _districtService.insert(districtParam);
        }

        // PUT: api/Districts/5
        public void Put(int id, DistrictParam districtParam)
        {
            _districtService.update(id, districtParam);
        }

        // DELETE: api/Districts/5
        public void Delete(int id)
        {
            _districtService.delete(id);
        }
    }
}
