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
    public class PeopleController : Controller
    {
        private ApplicationDbContext context; 

        public PeopleController()
        {
            context = new ApplicationDbContext();
        }
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = context.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            Person person = new Person();
            return View(person);
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                context.People.Add(person);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Person person = new Person();
            person = context.People.Where(p => p.Id == id).SingleOrDefault();
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            try
            {
                var editedPerson = context.People.Where(p => p.Id == person.Id).SingleOrDefault();
                editedPerson.FirstName = person.FirstName;
                editedPerson.LastName = person.LastName;
                editedPerson.DOB = person.DOB;
                editedPerson.PhoneNumber = person.PhoneNumber;
                editedPerson.Email = person.Email;
                editedPerson.StreetAddress = person.StreetAddress;
                editedPerson.City = person.City;
                editedPerson.State = person.State;
                editedPerson.Zipcode = person.Zipcode;
                editedPerson.IsPollutionATrigger = person.IsPollutionATrigger;
                editedPerson.ArePollensATrigger = person.ArePollensATrigger;
                editedPerson.AreDustMitesATrigger = person.AreDustMitesATrigger;
                editedPerson.IsTobaccoSmokeATrigger = person.IsTobaccoSmokeATrigger;
                editedPerson.IsMoldATrigger = person.IsMoldATrigger;
                editedPerson.AreBurningWoodOrGrassATrigger = person.AreBurningWoodOrGrassATrigger;
                
                context.SaveChanges();
                return RedirectToAction("Index", "People");

            }
            catch (Exception e)
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    context.Entry(person).State = EntityState.Modified;
            //    context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            Person person = new Person();
            person = context.People.Where(p => p.Id == id).SingleOrDefault();
            return View(person);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Person person = context.People.Find(id);
            //if (person == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Person person)
        {
            try
            {
                person = context.People.Where(p => p.Id == id).SingleOrDefault();
                context.People.Remove(person);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetDoctorDetails(int id)
        {
            var doctorDetails = context.People.Where(p => p.Id == id).Select(p => p.DoctorId == id);

            return View(doctorDetails);
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
