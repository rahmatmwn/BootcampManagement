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
    public class DistrictRepository : IDistrictRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        District district = new District();
        public bool delete(int? id)
        {
            var result = 0;
            district = myContext.Districts.Find(id);
            district.IsDelete = true;
            district.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<District> Get()
        {
            var getAll = myContext.Districts.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public List<District> GetDistrict(int? Id)
        {

            return myContext.Districts.Where(a => a.Regencies.Id == Id).OrderBy(a => a.Name).ToList();
        }

        public District Get(int? id)
        {
            var get = myContext.Districts.Find(id);
            return get;
        }

        public bool insert(DistrictParam districtParam)
        {
            var result = 0;
            district.Name = districtParam.Name;
            var getRegency = myContext.Regencies.Find(districtParam.Regencies_Id);
            district.Regencies = getRegency;
            district.CreateDate = DateTimeOffset.Now.LocalDateTime;
            district.IsDelete = false;
            myContext.Districts.Add(district);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, DistrictParam districtParam)
        {
            var result = 0;
            district = myContext.Districts.Find(id);
            district.Name = districtParam.Name;
            var getRegency = myContext.Regencies.Find(districtParam.Regencies_Id);
            district.Regencies = getRegency;
            district.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
