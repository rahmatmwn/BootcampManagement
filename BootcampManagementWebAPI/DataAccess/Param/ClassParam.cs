using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ClassParam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Department_Id { get; set; }
        public int? Batch_Id { get; set; }
        public int? Employee_Id { get; set; }
    }
}
