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
    public class StudentAccessRepository : IStudentAccessRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        StudentAccess studentAccess = new StudentAccess();
        public bool delete(int? id)
        {
            var result = 0;
            studentAccess = myContext.StudentAccesses.Find(id);
            studentAccess.IsDelete = true;
            studentAccess.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;


        }

        public List<StudentAccess> Get()
        {
            var getAll = myContext.StudentAccesses.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public StudentAccess Get(int? id)
        {
            var get = myContext.StudentAccesses.Find(id);
            return get; 
        }

        public bool insert(StudentAccessParam studentAccessParam)
        {
            var result = 0;
            var getStudent = myContext.Students.Find(studentAccessParam.Student_Id);
            studentAccess.Students = getStudent;
            var getAccess = myContext.Accesses.Find(studentAccessParam.Access_Id);
            studentAccess.Accesses = getAccess;
            studentAccess.CreateDate = DateTimeOffset.Now.LocalDateTime;
            studentAccess.IsDelete = false;
            myContext.StudentAccesses.Add(studentAccess);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, StudentAccessParam studentAccessParam)
        {
            var result = 0;

            var getStudent = myContext.Students.Find(studentAccessParam.Student_Id);
            studentAccess.Students = getStudent;
            var getAccess = myContext.Accesses.Find(studentAccessParam.Access_Id);
            studentAccess.Accesses = getAccess;
            studentAccess.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.StudentAccesses.Add(studentAccess);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
