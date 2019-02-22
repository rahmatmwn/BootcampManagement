using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class LessonParam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public DateTimeOffset Date { get; set; }
        public string LinkFile { get; set; }
        public int? Department_Id { get; set; }
        public int? Employee_Id{ get; set; }
    }
}
