using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class SkillStudent : BaseModel
    {

        public virtual Skill Skills { get; set; }
        public virtual Student Students { get; set; }
    }
}
