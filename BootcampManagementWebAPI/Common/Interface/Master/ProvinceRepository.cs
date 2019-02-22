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
    public class ProvinceRepository : IProvinceRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Province province = new Province();
        public bool delete(int? id)
        {
            var result = 0;
            province = myContext.Provinces.Find(id);
            province.IsDelete = true;
            province.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Province> Get()
        {
            var getAll = myContext.Provinces.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Province Get(int? id)
        {
            var get = myContext.Provinces.Find(id);
            return get;
        }

        public bool insert(ProvinceParam provinceParam)
        {
            var result = 0;
            province.Name = provinceParam.Name;
            province.CreateDate = DateTimeOffset.Now.LocalDateTime;
            province.IsDelete = false;
            myContext.Provinces.Add(province);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, ProvinceParam provinceParam)
        {
            var result = 0;
            province = myContext.Provinces.Find(id);
            province.Name = provinceParam.Name;
            province.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
