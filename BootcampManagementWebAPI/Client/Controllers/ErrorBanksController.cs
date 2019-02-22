using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ErrorBanksController : Controller
    {
        // GET: Provincies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewErrorBank()
        {
            return View();
        }
    }
}