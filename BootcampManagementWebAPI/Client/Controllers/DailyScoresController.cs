﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class DailyScoresController : Controller
    {
        // GET: DailyScores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDailyScore()
        {
            return View();
        }
    }
}