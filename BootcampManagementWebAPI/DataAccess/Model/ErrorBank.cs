using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ErrorBank : BaseModel
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public DateTimeOffset Date { get; set; }
        public virtual Department Departments { get; set; }
        public virtual Student Students { get; set; }
    }
}
