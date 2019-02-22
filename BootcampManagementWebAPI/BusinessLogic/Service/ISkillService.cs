using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ISkillService
    {
        bool insert(SkillParam skillParam);
        bool update(int? id, SkillParam skillParam);
        bool delete(int? id);
        List<Skill> Get();
        Skill Get(int? id);
    }
}
