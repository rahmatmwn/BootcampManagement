using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class SkillRepository : ISkillRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Skill batch = new Skill();
        public bool delete(int? id)
        {
            var result = 0;
            batch = myContext.Skills.Find(id);
            batch.IsDelete = true;
            batch.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Skill> Get()
        {
            var getAll = myContext.Skills.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Skill Get(int? id)
        {
            var get = myContext.Skills.Find(id);
            return get;
        }

        public bool insert(SkillParam skillParam)
        {
            var result = 0;
            batch.Name = skillParam.Name;
            batch.CreateDate = DateTimeOffset.Now.LocalDateTime;
            batch.IsDelete = false;
            myContext.Skills.Add(batch);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, SkillParam skillParam)
        {
            var result = 0;
            batch = myContext.Skills.Find(id);
            batch.Name = skillParam.Name;
            batch.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
