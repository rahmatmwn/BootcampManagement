using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class StudentRepository : IStudentRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Student student = new Student();
        public bool delete(int? id)
        {
            var result = 0;
            student = myContext.Students.Find(id);
            student.IsDelete = true;
            student.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Student> Get()
        {
            var getAll = myContext.Students.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Student Get(int? id)
        {
            var get = myContext.Students.Find(id);
            return get;
        }

        public bool insert(StudentParam studentParam)
        {
            var result = 0;
            student.FirstName = studentParam.FirstName;
            student.LastName = studentParam.LastName;
            student.DateOfBirth = studentParam.DateOfBirth;
            student.PlaceOfBirth = studentParam.PlaceOfBirth;
            student.Gender = studentParam.Gender;
            student.Address = studentParam.Address;
            student.Phone = studentParam.Phone;
            student.Email = studentParam.Email;
            student.Username = studentParam.Username;
            student.Password = studentParam.Password;
            student.Status = studentParam.Status;
            student.SecretQuestion = studentParam.SecretQuestion;
            student.SecretAnswer = studentParam.SecretAnswer;
            student.HiringLocation = studentParam.HiringLocation;
            var getReligion = myContext.Religions.Find(studentParam.Religion_Id);
            student.Religions = getReligion;
            var getClass = myContext.Classes.Find(studentParam.Class_Id);
            student.Classes = getClass;
            var getVillage = myContext.Villages.Find(studentParam.Village_Id);
            student.Villages = getVillage;
            student.CreateDate = DateTimeOffset.Now.LocalDateTime;
            student.IsDelete = false;
            myContext.Students.Add(student);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, StudentParam studentParam)
        {
            var result = 0;
            student = myContext.Students.Find(id);
            student.FirstName = studentParam.FirstName;
            student.LastName = studentParam.LastName;
            student.DateOfBirth = studentParam.DateOfBirth;
            student.PlaceOfBirth = studentParam.PlaceOfBirth;
            student.Gender = studentParam.Gender;
            student.Address = studentParam.Address;
            student.Phone = studentParam.Phone;
            student.Email = studentParam.Email;
            student.Status = studentParam.Status;
            student.HiringLocation = studentParam.HiringLocation;
            var getReligion = myContext.Religions.Find(studentParam.Religion_Id);
            student.Religions = getReligion;
            var getClass = myContext.Classes.Find(studentParam.Class_Id);
            student.Classes = getClass;
            var getVillage = myContext.Villages.Find(studentParam.Village_Id);
            student.Villages = getVillage;
            student.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
