using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IStudentService
    {
        bool insert(StudentParam studentParam);
        bool update(int? id, StudentParam studentParam);
        bool delete(int? id);
        List<Student> Get();
        Student Get(int? id);
    }
}
