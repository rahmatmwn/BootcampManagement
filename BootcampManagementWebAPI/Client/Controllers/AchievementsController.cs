using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class AchievementsController : Controller
    {
        // GET: Achievements
        public ActionResult Index()
        {
            return View();
        }
    }
}