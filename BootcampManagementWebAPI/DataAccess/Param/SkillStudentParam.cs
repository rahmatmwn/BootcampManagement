using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class SkillStudentParam
    {
        public int? Id { get; set; }
        public int? Skill_Id { get; set; }
        public int? Student_Id { get; set; }
    }
}
