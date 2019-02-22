using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ScheduleParam
    {
        public int? Id { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public int? Lesson_Id { get; set; }
        public int? Class_Id { get; set; }
        public int? Room_Id { get; set; }
    }
}
