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
    public class RegencyRepository : IRegencyRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Regency regency = new Regency();
        public bool delete(int? id)
        {
            var result = 0;
            regency = myContext.Regencies.Find(id);
            regency.IsDelete = true;
            regency.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Regency> Get()
        {
            var getAll = myContext.Regencies.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Regency Get(int? id)
        {
            var get = myContext.Regencies.Find(id);
            return get;
        }

        public bool insert(RegencyParam regencyParam)
        {
            var result = 0;
            regency.Name = regencyParam.Name;
            var getProvince = myContext.Provinces.Find(regencyParam.Provinces_Id);
            regency.Provinces = getProvince;
            regency.CreateDate = DateTimeOffset.Now.LocalDateTime;
            regency.IsDelete = false;
            myContext.Regencies.Add(regency);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, RegencyParam regencyParam)
        {
            var result = 0;
            regency = myContext.Regencies.Find(id);
            regency.Name = regencyParam.Name;
            var getProvince = myContext.Provinces.Find(regencyParam.Provinces_Id);
            regency.Provinces = getProvince;
            regency.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Regency> GetRegency(int? Id)
        {

            return myContext.Regencies.Where(a => a.Provinces.Id==Id).OrderBy(a => a.Name).ToList();
        }
    }
}
