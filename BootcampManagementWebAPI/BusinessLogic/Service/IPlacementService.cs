using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IPlacementService
    {
        bool insert(PlacementParam placementParam);
        bool update(int? id, PlacementParam placementParam);
        bool delete(int? id);
        List<Placement> Get();
        Placement Get(int? id);
    }
}
