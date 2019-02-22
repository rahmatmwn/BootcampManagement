using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface ILockerRepository
    {
        bool insert(LockerParam lockerParam);
        bool update(int? id, LockerParam lockerParam);
        bool delete(int? id);
        List<Locker> Get();
        Locker Get(int? id);
    }
}
