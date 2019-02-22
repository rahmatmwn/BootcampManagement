using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Student : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public System.Nullable<DateTimeOffset>  DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public System.Nullable<bool> Status { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string HiringLocation { get; set; }
        [Required]
        public virtual Class Classes { get; set; }
        public virtual Religion Religions { get; set; }
        public virtual Village Villages { get; set; }
    }
}
