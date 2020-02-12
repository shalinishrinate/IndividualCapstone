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
using CapstoneProject.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace CapstoneProject.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext context;

        #region Action Methods

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
            PersonProfileViewModel personProfile = new PersonProfileViewModel();
            var userId = User.Identity.GetUserId();
            var person = context.People.Where(p => p.ApplicationId == userId).FirstOrDefault();
            personProfile.Id = person.Id;
            personProfile.FirstName = person.FirstName;
            personProfile.LastName = person.LastName;
            personProfile.DOB = person.DOB;
            personProfile.PhoneNumber = person.PhoneNumber;
            personProfile.Email = person.Email;
            personProfile.StreetAddress = person.StreetAddress;
            personProfile.City = person.City;
            personProfile.State = person.State;
            personProfile.Zipcode = person.Zipcode;
            personProfile.IsPollutionATrigger = person.IsPollutionATrigger;
            personProfile.ArePollensATrigger = person.ArePollensATrigger;
            personProfile.AreDustMitesATrigger = person.AreDustMitesATrigger;
            personProfile.IsTobaccoSmokeATrigger = person.IsTobaccoSmokeATrigger;
            personProfile.IsMoldATrigger = person.IsMoldATrigger;
            personProfile.AreBurningWoodOrGrassATrigger = person.AreBurningWoodOrGrassATrigger;
            personProfile.Doctors = FillDoctorDropdown();
            return View(personProfile);

        }
        [HttpPost]
        public ActionResult PersonIndex(PersonProfileViewModel profileDetails)
        {
            //code for saving data
            Person person = new Person();
            person.Id = profileDetails.Id;
            person.FirstName = profileDetails.FirstName;
            person.LastName = profileDetails.LastName;
            person.DOB = profileDetails.DOB;
            person.PhoneNumber = profileDetails.PhoneNumber;
            person.Email = profileDetails.Email;
            person.StreetAddress = profileDetails.StreetAddress;
            person.City = profileDetails.City;
            person.State = profileDetails.State;
            person.Zipcode = profileDetails.Zipcode;
            person.IsPollutionATrigger = profileDetails.IsPollutionATrigger;
            person.ArePollensATrigger = profileDetails.ArePollensATrigger;
            person.AreDustMitesATrigger = profileDetails.AreDustMitesATrigger;
            person.IsTobaccoSmokeATrigger = profileDetails.IsTobaccoSmokeATrigger;
            person.IsMoldATrigger = profileDetails.IsMoldATrigger;
            person.AreBurningWoodOrGrassATrigger = profileDetails.AreBurningWoodOrGrassATrigger;
            person.DoctorId = Convert.ToInt32(profileDetails.SelectedDoctor);

            context.People.Add(person);
            context.SaveChanges();
            return RedirectToAction("DetailsView", new { id = profileDetails.Id });
        }

        // GET: People/Details/5
        public ActionResult DetailsView(int id)
        {
           // var id = Convert.ToInt32(userId);

            var person = context.People.Include(p => p.Doctor).FirstOrDefault(p => p.Id == id);
            if (person == null)
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

        // GET: People/Details/5
        public ActionResult Details(string id)
        {
            var person = context.People.Include(p => p.Doctor).FirstOrDefault(p => p.ApplicationId == id);
            if (person == null)
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

                return RedirectToAction("DetailsView", new { id = person.Id });
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            Person person = new Person();
            person = context.People.Where(p => p.Id == id).SingleOrDefault();
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

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
                return RedirectToAction("PersonIndex", "People");
                //return View(person);

            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            Person person = new Person();
            person = context.People.Where(p => p.Id == id).SingleOrDefault();
            return View(person);
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
        #endregion
        #region Helper Methods
        public IEnumerable<SelectListItem> FillDoctorDropdown()
        {
            List<SelectListItem> doctors = new List<SelectListItem>();
            try
            {
                var dbDoctors = context.Doctors.ToList();
                if(dbDoctors.Count>0)
                {
                    foreach(var doctor in dbDoctors)
                    {
                        doctors.Add(new SelectListItem()
                        {
                            Text=doctor.FirstName+" "+doctor.LastName,
                            Value=Convert.ToString(doctor.DoctorId.Value)

                        });
                    }
                }
            }
            catch (Exception e)
            {

                //handling or logging code
            }
            
            return doctors;
        }
        #endregion

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
