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
    public class ReligionRepository : IReligionRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Religion religion = new Religion();
        public bool delete(int? id)
        {
            var result = 0;
            religion = myContext.Religions.Find(id);
            religion.IsDelete = true;
            religion.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Religion> Get()
        {
            var getAll = myContext.Religions.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Religion Get(int? id)
        {
            var get = myContext.Religions.Find(id);
            return get;
        }

        public bool insert(ReligionParam religionParam)
        {
            var result = 0;
            religion.Name = religionParam.Name;
            religion.CreateDate = DateTimeOffset.Now.LocalDateTime;
            religion.IsDelete = false;
            myContext.Religions.Add(religion);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, ReligionParam religionParam)
        {
            var result = 0;
            religion = myContext.Religions.Find(id);
            religion.Name = religionParam.Name;
            religion.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
