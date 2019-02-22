using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IAccessRepository
    {
        bool insert(AccessParam accessParam);
        bool update(int? id, AccessParam accessParam);
        bool delete(int? id);
        List<Access> Get();
        Access Get(int? id);
    }
}
