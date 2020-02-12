using CapstoneProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject.Controllers
{
    public class PeakFlowReportController : Controller
    {
        private ApplicationDbContext context;

        public PeakFlowReportController()
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
                              orderby tags.PeakFlowRecordedDate ascending
                              select new { tags.PeakFlowRecordedDate, tags.PeakFlowNumber }).ToList();
                return Content(JsonConvert.SerializeObject(result), "application/json");
            }
        }
    }
}