using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IWorkExperienceService
    {
        bool insert(WorkExperienceParam workExperienceParam);
        bool update(int? id, WorkExperienceParam workExperienceParam);
        bool delete(int? id);
        List<WorkExperience> Get();
        WorkExperience Get(int? id);
    }
}
