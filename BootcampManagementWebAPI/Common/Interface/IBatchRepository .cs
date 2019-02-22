using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IBatchRepository
    {
        bool insert(BatchParam batchParam);
        bool update(int? id, BatchParam batchParam);
        bool delete(int? id);
        List<Batch> Get();
        Batch Get(int? id);
    }
}
