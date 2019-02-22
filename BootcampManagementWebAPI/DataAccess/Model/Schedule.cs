using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Schedule : BaseModel
    {
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public virtual Lesson Lessons { get; set; }
        public virtual Class Classes { get; set; }
        public virtual Room Rooms { get; set; }
    }
}
