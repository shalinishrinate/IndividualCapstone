using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapstoneProject.Models;

namespace CapstoneProject.Controllers
{
    public class AsthmaDetailsController : Controller
    {
        private ApplicationDbContext context;

        public AsthmaDetailsController()
        {
             context = new ApplicationDbContext();
        }
        // GET: AsthmaDetails
        public ActionResult Index()
        {
            var asthmaDetails = context.AsthmaDetails.Include(a => a.Person).ToList();
            return View(asthmaDetails);
        }

        // GET: AsthmaDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaDetails asthmaDetails = context.AsthmaDetails.Include(p =>p.Person).SingleOrDefault(p =>p.AsthamaDetailsId == id);
            if (asthmaDetails == null)
            {
                return HttpNotFound();
            }
            return View(asthmaDetails);
        }

        // GET: AsthmaDetails/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(context.People, "Id", "FirstName", "LastName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsthmaDetails asthmaDetails)
        {
            try
            {
                context.AsthmaDetails.Add(asthmaDetails);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    context.AsthmaDetails.Add(asthmaDetails);
            //    context.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.Id = new SelectList(context.People, "Id", "FirstName", asthmaDetails.Id);
            //return View(asthmaDetails);
        }

        // GET: AsthmaDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            AsthmaDetails asthmadetails = new AsthmaDetails();
            asthmadetails = context.AsthmaDetails.Where(p => p.AsthamaDetailsId == id).SingleOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(asthmadetails);
            //AsthmaDetails asthmaDetails = context.AsthmaDetails.Find(id);
            //if (asthmaDetails == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Id = new SelectList(context.People, "Id", "FirstName", asthmaDetails.Id);
            //return View(asthmaDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AsthmaDetails asthmaDetails)
        {
            try
            {
                var editedAsthmaDetails = context.AsthmaDetails.Where(p => p.AsthamaDetailsId == asthmaDetails.Id).SingleOrDefault();
                editedAsthmaDetails.PeakFlowRecordedDate = asthmaDetails.PeakFlowRecordedDate;
                editedAsthmaDetails.PeakFlowNumber = asthmaDetails.PeakFlowNumber;
                editedAsthmaDetails.AsthmaAttackNumber = asthmaDetails.AsthmaAttackNumber;
                context.SaveChanges();
                return RedirectToAction("Index", "AsthmaDetails");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(asthmaDetails).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Id = new SelectList(context.People, "Id", "FirstName", asthmaDetails.Id);
        //    return View(asthmaDetails);
        //}

        // GET: AsthmaDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaDetails asthmaDetails = context.AsthmaDetails.Find(id);
            if (asthmaDetails == null)
            {
                return HttpNotFound();
            }
            return View(asthmaDetails);
        }

        // POST: AsthmaDetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                AsthmaDetails asthmaDetails = context.AsthmaDetails.Find(id);
                context.AsthmaDetails.Remove(asthmaDetails);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
