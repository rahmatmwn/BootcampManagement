using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IClassService
    {
        bool insert(ClassParam classParam);
        bool update(int? id, ClassParam classParam);
        bool delete(int? id);
        List<Class> Get();
        Class Get(int? id);
    }
}
