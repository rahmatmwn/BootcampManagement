using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IStudentAccessService
    {
        bool insert(StudentAccessParam studentAccessParam);
        bool update(int? id, StudentAccessParam studentAccessParam);
        bool delete(int? id);
        List<StudentAccess> Get();
        StudentAccess Get(int? id);
    }
}
