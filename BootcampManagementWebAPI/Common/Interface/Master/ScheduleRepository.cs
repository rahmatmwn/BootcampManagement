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
    public class ScheduleRepository : IScheduleRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Schedule schedule = new Schedule();
        public bool delete(int? id)
        {
            var result = 0;
            schedule = myContext.Schedules.Find(id);
            schedule.IsDelete = true;
            schedule.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Schedule> Get()
        {
            var getAll = myContext.Schedules.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Schedule Get(int? id)
        {
            var get = myContext.Schedules.Find(id);
            return get;
        }

        public bool insert(ScheduleParam scheduleParam)
        {
            var result = 0;
            schedule.DateStart = scheduleParam.DateStart;
            schedule.DateEnd = scheduleParam.DateEnd;
            var getLesson = myContext.Lessons.Find(scheduleParam.Lesson_Id);
            schedule.Lessons = getLesson;
            var getClass = myContext.Classes.Find(scheduleParam.Class_Id);
            schedule.Classes = getClass;
            var getRoom = myContext.Rooms.Find(scheduleParam.Room_Id);
            schedule.Rooms = getRoom;
            schedule.CreateDate = DateTimeOffset.Now.LocalDateTime;
            schedule.IsDelete = false;
            myContext.Schedules.Add(schedule);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, ScheduleParam scheduleParam)
        {
            var result = 0;
            schedule = myContext.Schedules.Find(id);
            schedule.DateStart = scheduleParam.DateStart;
            schedule.DateEnd = scheduleParam.DateEnd;
            var getLesson = myContext.Lessons.Find(scheduleParam.Lesson_Id);
            schedule.Lessons = getLesson;
            var getClass = myContext.Classes.Find(scheduleParam.Class_Id);
            schedule.Classes = getClass;
            var getRoom = myContext.Rooms.Find(scheduleParam.Room_Id);
            schedule.Rooms = getRoom;
            schedule.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
