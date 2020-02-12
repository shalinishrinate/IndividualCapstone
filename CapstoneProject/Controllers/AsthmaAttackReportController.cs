using CapstoneProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject.Controllers
{
    public class AsthmaAttackReportController : Controller
    {
        private ApplicationDbContext context;

        public AsthmaAttackReportController()
        {
            context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ContentResult GetData()
        {
            using (var db = new ApplicationDbContext())
            {
                var result = (from tags in db.AsthmaDetails
                              orderby tags.AsthmaAttackDate ascending
                              select new { tags.AsthmaAttackDate, tags.AsthmaAttackNumber }).ToList();
                return Content(JsonConvert.SerializeObject(result), "application/json");
            }
        }
    }
}