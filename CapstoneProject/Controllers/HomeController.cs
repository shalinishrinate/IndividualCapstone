﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Map()
        {
            ViewBag.MapURL = PrivateKeys.googleMap;
            return View();
        }
        public ActionResult AsthmaCheckList()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AsthmaFactsMyths()
        {
           // ViewBag.Message = "Contact Us";

            return View();
        }
    }
}