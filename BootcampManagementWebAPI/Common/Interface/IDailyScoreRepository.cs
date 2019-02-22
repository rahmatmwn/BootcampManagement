using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IDailyScoreRepository
    {
        bool insert(DailyScoreParam dailyScoreParam);
        bool update(int? id, DailyScoreParam dailyScoreParam);
        bool delete(int? id);
        List<DailyScore> Get();
        DailyScore Get(int? id);
    }
}
