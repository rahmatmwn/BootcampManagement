using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class WeeklyScoresController : Controller
    {
        // GET: WeeklyScores
        public ActionResult Index()
        {
            return View();
        }
    }
}