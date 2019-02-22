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
    public class RegencyController : ApiController
    {
        // GET: api/Regency
        private readonly IRegencyService _regencyService;
        public RegencyController(IRegencyService regencyService)
        {
            _regencyService = regencyService;
        } 
        public IEnumerable<Regency> Get()
        {
            return _regencyService.Get();
        }

        public IEnumerable<Regency> GetRegency(int Id)
        {
            return _regencyService.GetRegency(Id);
        }

        //GET: api/Regency/5
        public Regency Get(int id)
        {
            return _regencyService.Get(id);
        }

        // POST: api/Regency
        public void Post(RegencyParam regencyParam)
        {
            _regencyService.insert(regencyParam);
        }

        // PUT: api/Regency/5
        public void Put(int id, RegencyParam regencyParam)
        {
            _regencyService.update(id, regencyParam);
        }

        // DELETE: api/Regency/5
        public void Delete(int id)
        {
            _regencyService.delete(id);
        }
    }
}
