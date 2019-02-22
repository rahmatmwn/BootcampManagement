using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ErrorBankParam
    {
        public int? Id { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Department_Id { get; set; }
        public int Student_Id { get; set; }
    }
}
