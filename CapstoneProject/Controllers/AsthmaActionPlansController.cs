﻿using System;
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
        private ApplicationDbContext context;

        public AsthmaActionPlansController()
        {
            context = new ApplicationDbContext();

        }

        // GET: AsthmaActionPlans
        public ActionResult Index()
        {
            //var asthmaActionPlans = context.AsthmaActionPlans.Include(a => a.Person);
            //return View(asthmaActionPlans.ToList());
            return View();
        }

        [HttpPost]
        public ActionResult Index(AsthmaActionPlan asthmaActionPlan)
        {
            int asthmaActionPlanId = asthmaActionPlan.AsthmaActionPlanId;
            string medicineName = asthmaActionPlan.MedicineName;
            string medicineDosage = asthmaActionPlan.MedicineDosage;
            string medicineSchedule = asthmaActionPlan.MedicineSchedule;

            return View();
        }

        // GET: AsthmaActionPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaActionPlan asthmaActionPlan = context.AsthmaActionPlans.Find(id);
            if (asthmaActionPlan == null)
            {
                return HttpNotFound();
            }
            return View(asthmaActionPlan);
        }

        // GET: AsthmaActionPlans/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(context.People, "Id", "FirstName");
            return View();
        }

        // POST: AsthmaActionPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsthmaActionPlanId,Medicine1Name,Medicine1Dosage,Medicine1Schedule,Medicine2Name,Medicine2Dosage,Medicine2Schedule,Medicine3Name,Medicine3Dosage,Medicine3Schedule,Id")] AsthmaActionPlan asthmaActionPlan)
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    context.AsthmaActionPlans.Add(asthmaActionPlan);
            //    context.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.Id = new SelectList(context.People, "Id", "FirstName", asthmaActionPlan.Id);
            //return View(asthmaActionPlan);
        }

        // GET: AsthmaActionPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            AsthmaActionPlan asthmaActionPlan = new AsthmaActionPlan();
            asthmaActionPlan = context.AsthmaActionPlans.Where(p => p.AsthmaActionPlanId == id).SingleOrDefault();
            if(asthmaActionPlan == null)
            {
                return HttpNotFound();
            }
            return View(asthmaActionPlan);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //AsthmaActionPlan asthmaActionPlan = context.AsthmaActionPlans.Find(id);
            //if (asthmaActionPlan == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.Id = new SelectList(context.People, "Id", "FirstName", asthmaActionPlan.Id);
            //return View(asthmaActionPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AsthmaActionPlan asthmaActionPlan)
        {
            try
            {
                var editedAsthmaActionPlan = context.AsthmaActionPlans.Where(p => p.Id == asthmaActionPlan.AsthmaActionPlanId).SingleOrDefault();
                editedAsthmaActionPlan.MedicineName = asthmaActionPlan.MedicineName;
                editedAsthmaActionPlan.MedicineDosage = asthmaActionPlan.MedicineDosage;
                editedAsthmaActionPlan.MedicineSchedule = asthmaActionPlan.MedicineSchedule;
                context.SaveChanges();
                return RedirectToAction("Details");
            }
            catch(Exception e)
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    context.Entry(asthmaActionPlan).State = EntityState.Modified;
            //    context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.Id = new SelectList(context.People, "Id", "FirstName", asthmaActionPlan.Id);
            //return View(asthmaActionPlan);
        }

        // GET: AsthmaActionPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsthmaActionPlan asthmaActionPlan = context.AsthmaActionPlans.Find(id);
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
            AsthmaActionPlan asthmaActionPlan = context.AsthmaActionPlans.Find(id);
            context.AsthmaActionPlans.Remove(asthmaActionPlan);
            context.SaveChanges();
            return RedirectToAction("Index");
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
