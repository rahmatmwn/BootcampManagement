using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class WeeklyScoreParam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public int? Score3 { get; set; }
        public int? Score4 { get; set; }
        public int? Score5 { get; set; }
        //public int? Students_Id { get; set; }
        public int? Employees_Id { get; set; }
    }
}
