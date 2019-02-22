using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class HistoryPlacement : BaseModel

    {
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public virtual Placement Placements { get; set; }
        public virtual Student Students { get; set; }

    }
}
