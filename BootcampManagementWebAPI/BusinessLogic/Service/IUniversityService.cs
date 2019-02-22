using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IUniversityService
    {
        bool insert(UniversityParam universityParam);
        bool update(int? id, UniversityParam universityParam);
        bool delete(int? id);
        List<University> Get();
        University Get(int? id);
    }
}
