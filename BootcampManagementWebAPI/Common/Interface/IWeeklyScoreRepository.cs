using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IWeeklyScoreRepository
    {
        bool insert(WeeklyScoreParam weeklyScoreParam);
        bool update(int? id, WeeklyScoreParam weeklyScoreParam);
        bool delete(int? id);
        List<WeeklyScore> Get();
        WeeklyScore Get(int? id);
    }
}
