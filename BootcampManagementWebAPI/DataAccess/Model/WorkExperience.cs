using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
   public class WorkExperience : BaseModel
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public virtual Student Students { get; set; }
    }
}
