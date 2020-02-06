using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapstoneProject.Models;
using Microsoft.AspNet.Identity;

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
            var people = context.People.Include(p => p.Doctor).ToList();
            return View(people);
        }
        /// <summary>
        /// Created view for person profile-redirected from registration of person/patient
        /// </summary>
        /// <returns></returns>
        public ActionResult PersonIndex()
        {
            var userId = User.Identity.GetUserId();
            var person = context.People.Where(p => p.ApplicationId == userId).FirstOrDefault();
            return View(person);
            //var person = context.People.Include(p => p.ApplicationUser).FirstOrDefault();
            //var SinglePerson = context.People.Where(p => p.Id == person.Id).SingleOrDefault();
            //return View(SinglePerson);
        }
        [HttpPost]
        public ActionResult PersonIndex(Person profileDetails)
        {
            return View();
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            var person = context.People.Include(p => p.Doctor).SingleOrDefault(p => p.Id == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Person person = context.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

          
        
        // GET: People/Create
        public ActionResult Create()
        {
            var doctors = context.Doctors.ToList();
            Person person = new Person()
            {
                Doctors = doctors
            };
        
            return View(person);
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                string currentUserId = User.Identity.GetUserId();
                person.ApplicationId = currentUserId;
                context.People.Add(person);
                context.SaveChanges();
                
                return RedirectToAction("PersonIndex");
            }
            catch (Exception e)
            {
                return View();
            }

            //if(person.Id == 0)
            //{
            //    context.People.Add(person);
            //}
            //else
            //{
            //    var personinDB = context.People.Where(p =>p.Id ==)
            //    personinDB.FirstName = person.FirstName;
            //    personinDB.LastName = person.LastName;
            //    personinDB.DOB = person.DOB;
            //    personinDB.PhoneNumber = person.PhoneNumber;
            //    personinDB.Email = person.Email;
            //    personinDB.StreetAddress = person.StreetAddress;
            //    personinDB.City = person.City;
            //    personinDB.State = person.State;
            //    personinDB.Zipcode = person.Zipcode;
            //    personinDB.IsPollutionATrigger = person.IsPollutionATrigger;
            //    personinDB.ArePollensATrigger = person.ArePollensATrigger;
            //    personinDB.AreDustMitesATrigger = person.AreDustMitesATrigger;
            //    personinDB.IsTobaccoSmokeATrigger = person.IsTobaccoSmokeATrigger;
            //    personinDB.IsMoldATrigger = person.IsMoldATrigger;
            //    personinDB.AreBurningWoodOrGrassATrigger = person.AreBurningWoodOrGrassATrigger;
            //    personinDB.DoctorId = person.DoctorId;

            //}
            //context.SaveChanges();
            //return View(person);
            //return RedirectToAction("Details","People");
            //return View(person);
            //if (ModelState.IsValid)
            //{
            //    context.People.Add(person);
            //    //var Doctors = context.Doctors.Where(d => d);
            //    context.SaveChanges();

            //    return RedirectToAction("Index");
            //}

            // return View(person);
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
                editedPerson.DoctorId = person.DoctorId;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Person person)
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
