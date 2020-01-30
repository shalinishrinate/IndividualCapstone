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
    public class AsthmaActionPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsthmaActionPlans
        public ActionResult Index()
        {
            var asthmaActionPlans = db.AsthmaActionPlans.Include(a => a.Person);
            return View(asthmaActionPlans.ToList());
        }

        // GET: AsthmaActionPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaActionPlan asthmaActionPlan = db.AsthmaActionPlans.Find(id);
            if (asthmaActionPlan == null)
            {
                return HttpNotFound();
            }
            return View(asthmaActionPlan);
        }

        // GET: AsthmaActionPlans/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.People, "Id", "FirstName");
            return View();
        }

        // POST: AsthmaActionPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsthmaActionPlanId,Medicine1Name,Medicine1Dosage,Medicine1Schedule,Medicine2Name,Medicine2Dosage,Medicine2Schedule,Medicine3Name,Medicine3Dosage,Medicine3Schedule,Id")] AsthmaActionPlan asthmaActionPlan)
        {
            if (ModelState.IsValid)
            {
                db.AsthmaActionPlans.Add(asthmaActionPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.People, "Id", "FirstName", asthmaActionPlan.Id);
            return View(asthmaActionPlan);
        }

        // GET: AsthmaActionPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaActionPlan asthmaActionPlan = db.AsthmaActionPlans.Find(id);
            if (asthmaActionPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.People, "Id", "FirstName", asthmaActionPlan.Id);
            return View(asthmaActionPlan);
        }

        // POST: AsthmaActionPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsthmaActionPlanId,Medicine1Name,Medicine1Dosage,Medicine1Schedule,Medicine2Name,Medicine2Dosage,Medicine2Schedule,Medicine3Name,Medicine3Dosage,Medicine3Schedule,Id")] AsthmaActionPlan asthmaActionPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asthmaActionPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.People, "Id", "FirstName", asthmaActionPlan.Id);
            return View(asthmaActionPlan);
        }

        // GET: AsthmaActionPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaActionPlan asthmaActionPlan = db.AsthmaActionPlans.Find(id);
            if (asthmaActionPlan == null)
            {
                return HttpNotFound();
            }
            return View(asthmaActionPlan);
        }

        // POST: AsthmaActionPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsthmaActionPlan asthmaActionPlan = db.AsthmaActionPlans.Find(id);
            db.AsthmaActionPlans.Remove(asthmaActionPlan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
