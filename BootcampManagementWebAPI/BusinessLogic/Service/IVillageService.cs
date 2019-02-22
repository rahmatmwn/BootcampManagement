using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IVillageService
    {
        bool insert(VillageParam villageParam);
        bool update(int? id, VillageParam villageParam);
        bool delete(int? id);
        List<Village> Get();
        Village Get(int? id);
        List<Village> GetVillage(int? Id);
    }
}
