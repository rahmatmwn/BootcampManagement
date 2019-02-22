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
    public class ProvinceController : ApiController
    {
        // GET: api/Province
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        public IEnumerable<Province> Get()
        {
            return _provinceService.Get();
        }

        // GET: api/Province/5
        public Province Get(int id)
        {
            return _provinceService.Get(id);
        }

        // POST: api/Province
        public void Post(ProvinceParam provinceParam)
        {
            _provinceService.insert(provinceParam);
        }

        // PUT: api/Province/5
        public void Put(int id, ProvinceParam provinceParam)
        {
            _provinceService.update(id, provinceParam);
        }

        // DELETE: api/Province/5
        public void Delete(int id)
        {
            _provinceService.delete(id);
        }
    }
}
