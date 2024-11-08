﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abidi.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FullNamePartial()
        {
            return PartialView();
        }

    }
}
