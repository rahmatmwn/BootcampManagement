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
    public class RoomRepository : IRoomRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Room room = new Room();
        public bool delete(int? id)
        {
            var result = 0;
            room = myContext.Rooms.Find(id);
            room.IsDelete = true;
            room.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Room> Get()
        {
            var getAll = myContext.Rooms.Where(x => x.IsDelete == false).ToList();
            return getAll;
        }

        public Room Get(int? id)
        {
            var get = myContext.Rooms.Find(id);
            return get;
        }

        public bool insert(RoomParam roomParam)
        {
            var result = 0;
            room.Name = roomParam.Name;
            room.Capacity = roomParam.Capacity;
            room.Location = roomParam.Location;
            room.CreateDate = DateTimeOffset.Now.LocalDateTime;
            room.IsDelete = false;
            myContext.Rooms.Add(room);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, RoomParam roomParam)
        {
            var result = 0;
            room = myContext.Rooms.Find(id);
            room.Name = roomParam.Name;
            room.Capacity = roomParam.Capacity;
            room.Location = roomParam.Location;
            room.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
