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
    public class LessonRepository : ILessonRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Lesson lesson = new Lesson();
        public bool delete(int? id)
        {
            var result = 0;
            lesson = myContext.Lessons.Find(id);
            lesson.IsDelete = true;
            lesson.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Lesson> Get()
        {
            var getAll = myContext.Lessons.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Lesson Get(int? id)
        {
            var get = myContext.Lessons.Find(id);
            return get;
        }

        public bool insert(LessonParam lessonParam)
        {
            var result = 0;
            lesson.Name = lessonParam.Name;
            lesson.Level = lessonParam.Level;
            lesson.LinkFile = lessonParam.LinkFile;
            lesson.Date = DateTimeOffset.Now.ToLocalTime();
            var getDepartment = myContext.Departments.Find(lessonParam.Department_Id);
            lesson.Departments = getDepartment;
            var getEmloyee = myContext.Employees.Find(lessonParam.Employee_Id);
            lesson.Employees = getEmloyee;
            
            lesson.CreateDate = DateTimeOffset.Now.LocalDateTime;
            lesson.IsDelete = false;
            myContext.Lessons.Add(lesson);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, LessonParam lessonParam)
        {
            var result = 0;
            lesson = myContext.Lessons.Find(id);
            lesson.Name = lessonParam.Name;
            lesson.Level = lessonParam.Level;
            lesson.LinkFile = lessonParam.LinkFile;
            lesson.Date = DateTimeOffset.Now.ToLocalTime();
            var getDepartment = myContext.Departments.Find(lessonParam.Department_Id);
            lesson.Departments = getDepartment;
            var getEmloyee = myContext.Employees.Find(lessonParam.Employee_Id);
            lesson.Employees = getEmloyee;
            lesson.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
