﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class SchedulesController : Controller
    {
        // GET: Provincies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewSchedule()
        {
            return View();
        }
    }
}