using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class HistoryEducationParam
    {
        public int? Id { get; set; }
        public string Degree { get; set; }
        public string StudyProgram { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public string Ipk { get; set; }
        public int? Universities_Id { get; set; }
        //public int? Students_Id { get; set; } //uncomment this when student model is available
    }
}
