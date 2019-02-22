using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Achievement : BaseModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual Student Students { get; set; }
    }

}
