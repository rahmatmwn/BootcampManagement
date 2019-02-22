using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface.Master
{
    public class WeeklyScoreRepository : IWeeklyScoreRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        WeeklyScore weeklyscore = new WeeklyScore();
        public bool delete(int? id)
        {
            var result = 0;
            weeklyscore = myContext.WeeklyScores.Find(id);
            weeklyscore.IsDelete = true;
            weeklyscore.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<WeeklyScore> Get()
        {
            var getAll = myContext.WeeklyScores.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public WeeklyScore Get(int? id)
        {
            var get = myContext.WeeklyScores.Find(id);
            return get;
        }

        public bool insert(WeeklyScoreParam weeklyScoreParam)
        {
            var result = 0;
            weeklyscore.Name = weeklyScoreParam.Name;
            weeklyscore.Date = weeklyScoreParam.Date;
            weeklyscore.Score1 = weeklyScoreParam.Score1;
            weeklyscore.Score2 = weeklyScoreParam.Score2;
            weeklyscore.Score3 = weeklyScoreParam.Score3;
            weeklyscore.Score4 = weeklyScoreParam.Score4;
            weeklyscore.Score5 = weeklyScoreParam.Score5;
            //var getStudent = myContext.Students.Find(weeklyScoreParam.Students_Id);
            //weeklyscore.Students = getStudent;
            var getEmployee = myContext.Employees.Find(weeklyScoreParam.Employees_Id);
            weeklyscore.Employees = getEmployee;
            weeklyscore.CreateDate = DateTimeOffset.Now.LocalDateTime;
            weeklyscore.IsDelete = false;
            myContext.WeeklyScores.Add(weeklyscore);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, WeeklyScoreParam weeklyScoreParam)
        {
            var result = 0;
            weeklyscore = myContext.WeeklyScores.Find(id);
            weeklyscore.Name = weeklyScoreParam.Name;
            weeklyscore.Date = weeklyScoreParam.Date;
            weeklyscore.Score1 = weeklyScoreParam.Score1;
            weeklyscore.Score2 = weeklyScoreParam.Score2;
            weeklyscore.Score3 = weeklyScoreParam.Score3;
            weeklyscore.Score4 = weeklyScoreParam.Score4;
            weeklyscore.Score5 = weeklyScoreParam.Score5;
            //var getStudent = myContext.Students.Find(weeklyScoreParam.Students_Id);
            //weeklyscore.Students = getStudent;
            var getEmployee = myContext.Employees.Find(weeklyScoreParam.Employees_Id);
            weeklyscore.Employees = getEmployee;
            weeklyscore.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
