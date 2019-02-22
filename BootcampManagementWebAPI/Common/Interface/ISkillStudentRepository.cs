using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface ISkillStudentRepository
    {
        bool insert(SkillStudentParam skillstudentParam);
        bool update(int? id, SkillStudentParam skillstudentParam);
        bool delete(int? id);
        List<SkillStudent> Get();
        SkillStudent Get(int? id);
    }
}
