using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class OrganizationsController : Controller
    {
        // GET: Organizations
        public ActionResult Index()
        {
            return View();
        }
    }
}