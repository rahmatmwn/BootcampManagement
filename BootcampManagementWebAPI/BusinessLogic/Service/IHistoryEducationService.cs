using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IHistoryEducationService
    {
        bool insert(HistoryEducationParam historyEducationParam);
        bool update(int? id, HistoryEducationParam historyEducationParam);
        bool delete(int? id);
        List<HistoryEducation> Get();
        HistoryEducation Get(int? id);
    }
}
