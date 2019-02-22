using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class HistoryEducation : BaseModel
    {
        public string Degree { get; set; }
        public string StudyProgram { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public string Ipk { get; set; }
        public virtual University Universities { get; set; }
        public virtual Student Students { get; set; } //uncomment this when student model is available

    }
}
