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
    public class StudentLockerRepository : IStudentLockerRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        StudentLocker studentLocker = new StudentLocker();
        public bool delete(int? id)
        {
            var result = 0;
            studentLocker = myContext.StudentLockers.Find(id);
            studentLocker.IsDelete = true;
            studentLocker.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public List<StudentLocker> Get()
        {
            var getAll = myContext.StudentLockers.Where(x => x.IsDelete == false).ToList();
            return getAll;

        }

        public StudentLocker Get(int? id)
        {
            var get = myContext.StudentLockers.Find(id);
            return get;
        }

        public bool insert(StudentLockerParam studentLockerParam)
        {
            var result = 0;
          
            var getStudent = myContext.Students.Find(studentLockerParam.Student_Id);
            studentLocker.Students= getStudent;
            var getLocker = myContext.Lockers.Find(studentLockerParam.Locker_Id);
            studentLocker.Lockers = getLocker;
            studentLocker.CreateDate = DateTimeOffset.Now.LocalDateTime;
            studentLocker.IsDelete = false;
            myContext.StudentLockers.Add(studentLocker);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public bool update(int? id, StudentLockerParam studentLockerParam)
        {
            var result = 0;
            var getStudent = myContext.Students.Find(studentLockerParam.Student_Id);
            studentLocker.Students = getStudent;
            var getLocker = myContext.Lockers.Find(studentLockerParam.Locker_Id);
            studentLocker.Lockers = getLocker;
            studentLocker.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.StudentLockers.Add(studentLocker);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
