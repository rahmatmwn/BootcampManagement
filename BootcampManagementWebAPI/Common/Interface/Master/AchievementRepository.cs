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
    public class AchievementRepository : IAchievementRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Achievement achievement = new Achievement();
        public bool delete(int? id)
        {
            var result = 0;
            achievement = myContext.Achievements.Find(id);
            achievement.IsDelete = true;
            achievement.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Achievement> Get()
        {
            var getAll = myContext.Achievements.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Achievement Get(int? id)
        {
            var get = myContext.Achievements.Find(id);
            return get;
        }
       
        public bool insert(AchievementParam achievementParam)
        {
            var result = 0;
            achievement.Name = achievementParam.Name;
            achievement.Date = achievementParam.Date;
            achievement.CreateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, AchievementParam achievementParam)
        {
            var result = 0;
            achievement = myContext.Achievements.Find(id);
            achievement.Name = achievementParam.Name;
            achievement.Date = achievementParam.Date;
            achievement.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }
    }
}
