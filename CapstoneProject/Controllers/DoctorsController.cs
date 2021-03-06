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
    public class DoctorsController : Controller
    {
        private ApplicationDbContext context;

        public DoctorsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Doctors
        public ActionResult Index()
        {
            return View(context.Doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = context.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,FirstName,LastName,Email,PhoneNumber,StreetAddress,City,State,Zipcode")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = context.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,FirstName,LastName,Email,PhoneNumber,StreetAddress,City,State,Zipcode")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                context.Entry(doctor).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            Doctor doctor = new Doctor();
            doctor = context.Doctors.Where(d => d.DoctorId == id).SingleOrDefault();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Doctor doctor = context.Doctors.Find(id);
            //if (doctor == null)
            //{
            //    return HttpNotFound();
            //}
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Doctor doctor = context.Doctors.Where(d => d.DoctorId == id).SingleOrDefault();
            context.Doctors.Remove(doctor);
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
