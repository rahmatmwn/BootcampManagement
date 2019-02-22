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
    public class DailyScoreRepository : IDailyScoreRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        DailyScore dailyscore = new DailyScore();
        public bool delete(int? id)
        {
            var result = 0;
            dailyscore = myContext.DailyScores.Find(id);
            dailyscore.IsDelete = true;
            dailyscore.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<DailyScore> Get()
        {
            var getAll = myContext.DailyScores.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public DailyScore Get(int? id)
        {
            var get = myContext.DailyScores.Find(id);
            return get;
        }

        public bool insert(DailyScoreParam dailyScoreParam)
        {
            var result = 0;
            dailyscore.Date = dailyScoreParam.Date;
            dailyscore.Score1 = dailyScoreParam.Score1;
            dailyscore.Score2 = dailyScoreParam.Score2;
            dailyscore.Score3 = dailyScoreParam.Score3;
            //var getStudent = myContext.Students.Find(dailyScoreParam.Students_Id);
            //dailyscore.Students = getStudent;
            //var getLesson = myContext.Lessons.Find(dailyScoreParam.Lessons_Id);
            //dailyscore.Lessons = getLesson;
            var getEmployee = myContext.Employees.Find(dailyScoreParam.Employees_Id);
            dailyscore.Employees = getEmployee;
            dailyscore.CreateDate = DateTimeOffset.Now.LocalDateTime;
            dailyscore.IsDelete = false;
            myContext.DailyScores.Add(dailyscore);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, DailyScoreParam dailyScoreParam)
        {
            var result = 0;
            dailyscore = myContext.DailyScores.Find(id);
            dailyscore.Date = dailyScoreParam.Date;
            dailyscore.Score1 = dailyScoreParam.Score1;
            dailyscore.Score2 = dailyScoreParam.Score2;
            dailyscore.Score3 = dailyScoreParam.Score3;
            //var getStudent = myContext.Students.Find(dailyScoreParam.Students_Id);
            //dailyscore.Students = getStudent;
            //var getLesson = myContext.Lessons.Find(dailyScoreParam.Lessons_Id);
            //dailyscore.Lessons = getLesson;
            var getEmployee = myContext.Employees.Find(dailyScoreParam.Employees_Id);
            dailyscore.Employees = getEmployee;
            dailyscore.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
