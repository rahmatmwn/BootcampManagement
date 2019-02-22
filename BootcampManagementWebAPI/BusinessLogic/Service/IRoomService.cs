using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IRoomService
    {
        bool insert(RoomParam roomParam);
        bool update(int? id, RoomParam roomParam);
        bool delete(int? id);
        List<Room> Get();
        Room Get(int? id);
    }
}
