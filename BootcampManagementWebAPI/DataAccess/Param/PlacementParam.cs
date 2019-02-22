using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class PlacementParam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; } 
        public int? Village_Id { get; set; }
    }
}
