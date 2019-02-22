using BusinessLogic.Service;
using Common.Interface;
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
    public class LessonsController : ApiController
    {
        // GET: api/Lesson
        private readonly ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public IEnumerable<Lesson> Get()
        {
            return _lessonService.Get();
        }

        // GET: api/Lesson/5
        public Lesson Get(int id)
        {
            return _lessonService.Get(id);
        }

        // POST: api/Lesson
        public void Post(LessonParam lessonParam)
        {
            _lessonService.insert(lessonParam);
        }

        // PUT: api/Lesson/5
        public void Put(int id, LessonParam lessonParam)
        {
            _lessonService.update(id, lessonParam);
        }

        // DELETE: api/Lesson/5
        public void Delete(int id)
        {
            _lessonService.delete(id);
        }
    }
}
