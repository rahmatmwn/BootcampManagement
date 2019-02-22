using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Employee : BaseModel
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTimeOffset Date_Of_Birth { get; set; }
        public string Place_Of_Birth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Secret_Question { get; set; }
        public string Secret_Answer { get; set; }
        public string Role { get; set; }
        public virtual Religion Religions { get; set; }
        public virtual Village Villages { get; set; }
    }
}
