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
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsthmaDetails
        public ActionResult Index()
        {
            var asthmaDetails = db.AsthmaDetails.Include(a => a.Person);
            return View(asthmaDetails.ToList());
        }

        // GET: AsthmaDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaDetails asthmaDetails = db.AsthmaDetails.Find(id);
            if (asthmaDetails == null)
            {
                return HttpNotFound();
            }
            return View(asthmaDetails);
        }

        // GET: AsthmaDetails/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.People, "Id", "FirstName");
            return View();
        }

        // POST: AsthmaDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsthamaDetailsId,PeakFlowRecordedDate,PeakFlowNumber,AsthmaAttacks,Id")] AsthmaDetails asthmaDetails)
        {
            if (ModelState.IsValid)
            {
                db.AsthmaDetails.Add(asthmaDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.People, "Id", "FirstName", asthmaDetails.Id);
            return View(asthmaDetails);
        }

        // GET: AsthmaDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaDetails asthmaDetails = db.AsthmaDetails.Find(id);
            if (asthmaDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.People, "Id", "FirstName", asthmaDetails.Id);
            return View(asthmaDetails);
        }

        // POST: AsthmaDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsthamaDetailsId,PeakFlowRecordedDate,PeakFlowNumber,AsthmaAttacks,Id")] AsthmaDetails asthmaDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asthmaDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.People, "Id", "FirstName", asthmaDetails.Id);
            return View(asthmaDetails);
        }

        // GET: AsthmaDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaDetails asthmaDetails = db.AsthmaDetails.Find(id);
            if (asthmaDetails == null)
            {
                return HttpNotFound();
            }
            return View(asthmaDetails);
        }

        // POST: AsthmaDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsthmaDetails asthmaDetails = db.AsthmaDetails.Find(id);
            db.AsthmaDetails.Remove(asthmaDetails);
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
