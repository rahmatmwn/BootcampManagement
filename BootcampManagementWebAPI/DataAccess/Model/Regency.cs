using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Regency : BaseModel
    {
        public string Name { get; set; }
        public virtual Province Provinces { get; set; }
    }
}
