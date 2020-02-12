using CapstoneProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext context;

        public ReportController()
        {
            context = new ApplicationDbContext();
        }

      
        public ActionResult Index()
        {
            //var teamTotalScores = (from a in context.AsthmaDetails
            //                       join p in context.People on a.Id equals p.Id
            //                       group a by a.AsthmaAttacks into attackGroup
            //                       select new
            //                       {
            //                           Name = attackGroup.Key,
            //                           TotalAttack = attackGroup.Sum(x => x.AsthmaAttacks),
            //                       });

            return View();

        }
    }
}