using DataAccess.Context;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface.Master
{
    public class VillageRepository : IVillageRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Village village = new Village();
        public bool delete(int? id)
        {
            var result = 0;
            village = myContext.Villages.Find(id);
            village.IsDelete = true;
            village.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Village> Get()
        {
            var getAll = myContext.Villages.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public List<Village> GetVillage(int? Id)
        {

            return myContext.Villages.Where(a => a.Districts.Id == Id).OrderBy(a => a.Name).ToList();
        }

        public Village Get(int? id)
        {
            var get = myContext.Villages.Find(id);
            return get;
        }

        public bool insert(VillageParam villageParam)
        {
            var result = 0;
            village.Name = villageParam.Name;
            var getDistrict = myContext.Districts.Find(villageParam.Districts_Id);
            village.Districts = getDistrict;
            village.CreateDate = DateTimeOffset.Now.LocalDateTime;
            village.IsDelete = false;
            myContext.Villages.Add(village);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, VillageParam villageParam)
        {
            var result = 0;
            village = myContext.Villages.Find(id);
            village.Name = villageParam.Name;
            var getDistrict = myContext.Districts.Find(villageParam.Districts_Id);
            village.Districts = getDistrict;
            village.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
