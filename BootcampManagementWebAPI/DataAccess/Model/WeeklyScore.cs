using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class WeeklyScore : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public int? Score1 { get; set; }
        public int? Score2 { get; set; }
        public int? Score3 { get; set; }
        public int? Score4 { get; set; }
        public int? Score5 { get; set; }
        public virtual Student Students { get; set; }
        public virtual Employee Employees { get; set; }
    }
}
