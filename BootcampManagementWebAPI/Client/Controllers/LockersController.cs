using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class LockersController : Controller
    {
        // GET: Lockers
        public ActionResult Index()
        {
            return View();
        }
    }
}