using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IStudentLockerRepository
    {
        bool insert(StudentLockerParam studentLockerParam);
        bool update(int? id, StudentLockerParam studentLockerParam);
        bool delete(int? id);
        List<StudentLocker> Get();
        StudentLocker Get(int? id);
    }
}
