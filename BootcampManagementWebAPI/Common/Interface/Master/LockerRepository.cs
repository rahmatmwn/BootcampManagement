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
    public class LockerRepository : ILockerRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Locker locker = new Locker();
        public bool delete(int? id)
        {

            var result = 0;
            locker = myContext.Lockers.Find(id);
            locker.IsDelete = true;
            locker.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }

        public List<Locker> Get()
        {
            var getAll = myContext.Lockers.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Locker Get(int? id)
        {
            var get = myContext.Lockers.Find(id);
            return get;
        }

        public bool insert(LockerParam lockerParam)
        {
            var result = 0;
            locker.Name = lockerParam.Name;
            locker.CreateDate = DateTimeOffset.Now.LocalDateTime;
            locker.IsDelete = false;
            myContext.Lockers.Add(locker);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, LockerParam lockerParam)
        {
            var result = 0;
            locker = myContext.Lockers.Find(id);
            locker.Name = lockerParam.Name;
            locker.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }
    }
}
