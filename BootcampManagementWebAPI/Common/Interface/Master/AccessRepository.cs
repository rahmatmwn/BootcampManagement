using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface
{
    public class AccessRepository : IAccessRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Access access = new Access();
        public bool delete(int? id)
        {
            var result = 0;
            access = myContext.Accesses.Find(id);
            access.IsDelete = true;
            access.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Access> Get()
        {
            var getAll = myContext.Accesses.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Access Get(int? id)
        {
            var get = myContext.Accesses.Find(id);
            return get;
        }

        public bool insert(AccessParam accessParam)
        {
            var result = 0;
            access.Name = accessParam.Name;
            access.CreateDate = DateTimeOffset.Now.LocalDateTime;
            access.IsDelete = false;
            myContext.Accesses.Add(access);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, AccessParam accessParam)
        {
            var result = 0;
            access = myContext.Accesses.Find(id);
            access.Name = accessParam.Name;
            access.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}

