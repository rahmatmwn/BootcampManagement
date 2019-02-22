using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IHistoryPlacementRepository
    {
        bool insert(HistoryPlacementParam historyPlacementParam);
        bool update(int? id, HistoryPlacementParam historyPlacementParam);
        bool delete(int? id);
        List<HistoryPlacement> Get();
        HistoryPlacement Get(int? id);
    }
}
