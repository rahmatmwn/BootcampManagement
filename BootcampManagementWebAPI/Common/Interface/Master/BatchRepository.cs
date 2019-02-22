using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class BatchRepository : IBatchRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Batch batch = new Batch();
        public bool delete(int? id)
        {
            var result = 0;
            batch = myContext.Batches.Find(id);
            batch.IsDelete = true;
            batch.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Batch> Get()
        {
            var getAll = myContext.Batches.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Batch Get(int? id)
        {
            var get = myContext.Batches.Find(id);
            return get;
        }

        public bool insert(BatchParam batchParam)
        {
            var result = 0;
            batch.Name = batchParam.Name;
            batch.DateStart = batchParam.DateStart;
            batch.DateEnd = batchParam.DateEnd;
            batch.CreateDate = DateTimeOffset.Now.LocalDateTime;
            batch.IsDelete = false;
            myContext.Batches.Add(batch);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, BatchParam batchParam)
        {
            var result = 0;
            batch = myContext.Batches.Find(id);
            batch.Name = batchParam.Name;
            batch.DateStart = batchParam.DateStart;
            batch.DateEnd = batchParam.DateEnd;
            batch.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
