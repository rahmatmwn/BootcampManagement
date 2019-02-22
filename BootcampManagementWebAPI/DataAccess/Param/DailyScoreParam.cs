using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class DailyScoreParam
    {
        public int? Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public int? Score3 { get; set; }
        public int? Students_Id { get; set; }
        public int? Lessons_Id { get; set; }
        public int? Employees_Id { get; set; }
    }
}
