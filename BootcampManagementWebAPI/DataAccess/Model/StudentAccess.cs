using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class StudentAccess : BaseModel
    {
        public virtual Student Students { get; set; }
        public virtual Access Accesses { get; set; }
    }
}
