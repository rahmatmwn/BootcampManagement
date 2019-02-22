using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class WorkExperienceParam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public int? Student_Id { get; set; }

    }
}
