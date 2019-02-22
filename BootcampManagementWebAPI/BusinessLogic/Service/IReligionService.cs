using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IReligionService
    {
        bool insert(ReligionParam religionParam);
        bool update(int? id, ReligionParam religionParam);
        bool delete(int? id);
        List<Religion> Get();
        Religion Get(int? id);
    }
}
