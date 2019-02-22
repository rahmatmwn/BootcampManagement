using BusinessLogic.Service;
using Common.Interface;
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
    public class ErrorBanksController : ApiController
    {
        // GET: api/ErrorBank
        private readonly IErrorBankService _errorBankService;
        public ErrorBanksController(IErrorBankService errorBankService)
        {
            _errorBankService = errorBankService;
        }
        public IEnumerable<ErrorBank> Get()
        {
            return _errorBankService.Get();
        }

        // GET: api/ErrorBank/5
        public ErrorBank Get(int id)
        {
            return _errorBankService.Get(id);
        }

        // POST: api/ErrorBank
        public void Post(ErrorBankParam errorBankParam)
        {
            _errorBankService.insert(errorBankParam);
        }

        // PUT: api/ErrorBank/5
        public void Put(int id, ErrorBankParam errorBankParam)
        {
            _errorBankService.update(id, errorBankParam);
        }

        // DELETE: api/ErrorBank/5
        public void Delete(int id)
        {
            _errorBankService.delete(id);
        }
    }
}
