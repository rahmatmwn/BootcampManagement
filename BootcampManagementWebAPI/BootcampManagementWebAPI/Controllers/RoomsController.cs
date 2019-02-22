using BusinessLogic.Service;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BootcampManagementWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoomsController : ApiController
    {
        // GET: api/Room
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        } 
        public IEnumerable<Room> Get()
        {
            return _roomService.Get();
        }

        // GET: api/Room/5
        public Room Get(int id)
        {
            return _roomService.Get(id);
        }

        // POST: api/Room
        public void Post(RoomParam roomParam)
        {
            _roomService.insert(roomParam);
        }

        // PUT: api/Room/5
        public void Put(int id, RoomParam roomParam)
        {
            _roomService.update(id, roomParam);
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
            _roomService.delete(id);
        }
    }
}
