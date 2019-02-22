using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class HistoryPlacementParam
    {
        
        public string Position { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public int Placement_Id { get; set; } 
        public int Student_Id { get; set; }

    }
}
