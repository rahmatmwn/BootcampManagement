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
    public class PlacementRepository : IPlacementRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Placement placement = new Placement();
        public bool delete(int? id)
        {
            var result = 0;
            placement = myContext.Placements.Find(id);
            placement.IsDelete = true;
            placement.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;


        }

        public List<Placement> Get()
        {
            var getAll = myContext.Placements.Where(x => x.IsDelete == false).ToList();
            return getAll;

        }

        public Placement Get(int? id)
        {
            var get = myContext.Placements.Find(id);
            return get;
        }

        public bool insert(PlacementParam placementParam)
        {
            var result = 0;
            placement.Name = placementParam.Name;
            placement.Address = placementParam.Address;
            placement.Phone = placementParam.Phone;
            var getVillage = myContext.Villages.Find(placementParam.Village_Id);
            placement.Villages = getVillage;
            placement.CreateDate = DateTimeOffset.Now.LocalDateTime;
            placement.IsDelete = false;
            myContext.Placements.Add(placement);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public bool update(int? id, PlacementParam placementParam)
        {
            var result = 0;
            placement = myContext.Placements.Find(id);
            placement.Name = placementParam.Name;
            placement.Address = placementParam.Address;
            placement.Phone = placementParam.Phone;
            var getVillage = myContext.Villages.Find(placementParam.Village_Id);
            placement.Villages = getVillage;
            placement.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Placements.Add(placement);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
