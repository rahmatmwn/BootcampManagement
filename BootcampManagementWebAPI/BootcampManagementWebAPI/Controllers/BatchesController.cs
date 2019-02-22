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
    public class BatchesController : ApiController
    {
        // GET: api/Batch
        private readonly IBatchService _batchService;
        public BatchesController(IBatchService batchService)
        {
            _batchService = batchService;
        }
        public IEnumerable<Batch> Get()
        {
            return _batchService.Get();
        }

        // GET: api/Batch/5
        public Batch Get(int id)
        {
            return _batchService.Get(id);
        }

        // POST: api/Batch
        public void Post(BatchParam batchParam)
        {
            _batchService.insert(batchParam);
        }

        // PUT: api/Batch/5
        public void Put(int id, BatchParam batchParam)
        {
            _batchService.update(id, batchParam);
        }

        // DELETE: api/Batch/5
        public void Delete(int id)
        {
            _batchService.delete(id);
        }
    }
}
