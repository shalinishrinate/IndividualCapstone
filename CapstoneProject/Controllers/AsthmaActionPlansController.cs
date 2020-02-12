using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapstoneProject.Enum;
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
        [HttpGet, ActionName("Index")]
        public ActionResult IndexDetail(int id)
        {

            context = new ApplicationDbContext();

            List<AsthmaActionPlan> asthmaPerson = (from ap in context.AsthmaActionPlans
                                                   join people in context.People.DefaultIfEmpty() on ap.Id equals people.Id
                                                   join doctor in context.Doctors.DefaultIfEmpty() on people.DoctorId equals doctor.DoctorId
                                                   where ap.Id == id
                                                   select new
                                                   {
                                                       GreenMedicineName = ap.GreenMedicineName,
                                                       GreenMedicineDosage = ap.GreenMedicineDosage,
                                                       GreenMedicineSchedule = ap.GreenMedicineSchedule,
                                                       YellowMedicineName = ap.YellowMedicineName,
                                                       YellowMedicineDosage = ap.YellowMedicineDosage,
                                                       YellowMedicineSchedule = ap.YellowMedicineSchedule,
                                                       RedMedicineName = ap.RedMedicineName,
                                                       RedMedicineDosage = ap.RedMedicineDosage,
                                                       RedMedicineSchedule = ap.RedMedicineSchedule,
                                                       NormalPeakFlowRate = ap.NormalPeakFlowRate,
                                                       Person = people,
                                                       Doctor = people.Doctor

                                                   }).ToList().Select
              (x => new AsthmaActionPlan
              {
                  GreenMedicineName = x.GreenMedicineName,
                  GreenMedicineDosage = x.GreenMedicineDosage,
                  GreenMedicineSchedule = x.GreenMedicineSchedule,
                  YellowMedicineName = x.YellowMedicineName,
                  YellowMedicineDosage = x.YellowMedicineDosage,
                  YellowMedicineSchedule = x.YellowMedicineSchedule,
                  RedMedicineName = x.RedMedicineName,
                  RedMedicineDosage = x.RedMedicineDosage,
                  RedMedicineSchedule = x.RedMedicineSchedule,
                  NormalPeakFlowRate = x.NormalPeakFlowRate,
                  Person = new Person
                  {
                      FirstName = x.Person.FirstName,
                      LastName = x.Person.LastName,
                      Doctor = new Doctor
                      {
                          FirstName = x.Doctor.FirstName,
                          LastName = x.Doctor.LastName,
                          PhoneNumber = x.Doctor.PhoneNumber,
                          StreetAddress = x.Doctor.StreetAddress
                      }
                  }

              }).ToList();

            if (asthmaPerson.Count == 0)
            {

                var peopleModel = (from p in context.People
                                   join d in context.Doctors.DefaultIfEmpty()
                                   on p.DoctorId equals d.DoctorId
                                   where p.Id == id
                                   select new
                                   {
                                       Person = p,
                                       Doctor = p.Doctor

                                   }).ToList().Select
              (x => new AsthmaActionPlan
              {
                  Person = new Person
                  {
                      FirstName = x.Person.FirstName,
                      LastName = x.Person.LastName,
                      Doctor = new Doctor
                      {
                          FirstName = x.Doctor.FirstName,
                          LastName = x.Doctor.LastName,
                          PhoneNumber = x.Doctor.PhoneNumber,
                          StreetAddress = x.Doctor.StreetAddress
                      }
                  }

              }).ToList();

                TempData["PersonId"] = id;
                TempData.Keep();
                return View(peopleModel);
            }

            TempData["PersonId"] = id;
            TempData.Keep();
            return View(asthmaPerson);

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AsthmaActionPlan asthmaActionPlan)
        {
            int asthmaActionPlanId = asthmaActionPlan.AsthmaActionPlanId;

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


        [HttpPost]
        public JsonResult Create(AsthmaActionPlan asthmaActionPlan)
        {
            int PersonId = (int)TempData["PersonId"];

            var existingAsthmaActionPlans = context.AsthmaActionPlans
                                            .Where(p => p.Id == PersonId)
                                            .Include(p => p.Person)
                                            .Include(p => p.Person.Doctor)
                                            .SingleOrDefault();

            var person = context.People.Find(PersonId);

            if (existingAsthmaActionPlans != null)
            {
                existingAsthmaActionPlans.GreenMedicineDosage = asthmaActionPlan.GreenMedicineDosage;
                existingAsthmaActionPlans.GreenMedicineName = asthmaActionPlan.GreenMedicineName;
                existingAsthmaActionPlans.GreenMedicineSchedule = asthmaActionPlan.GreenMedicineSchedule;
                existingAsthmaActionPlans.YellowMedicineDosage = asthmaActionPlan.YellowMedicineDosage;
                existingAsthmaActionPlans.YellowMedicineName = asthmaActionPlan.YellowMedicineName;
                existingAsthmaActionPlans.YellowMedicineSchedule = asthmaActionPlan.YellowMedicineSchedule;
                existingAsthmaActionPlans.RedMedicineDosage = asthmaActionPlan.RedMedicineDosage;
                existingAsthmaActionPlans.RedMedicineName = asthmaActionPlan.RedMedicineName;
                existingAsthmaActionPlans.RedMedicineSchedule = asthmaActionPlan.RedMedicineSchedule;
                existingAsthmaActionPlans.NormalPeakFlowRate = asthmaActionPlan.NormalPeakFlowRate;

                context.Entry(existingAsthmaActionPlans).State = existingAsthmaActionPlans.AsthmaActionPlanId == 0 ? EntityState.Added : EntityState.Modified;

                existingAsthmaActionPlans.Person.FirstName = asthmaActionPlan.Person.FirstName;
                existingAsthmaActionPlans.Person.LastName = asthmaActionPlan.Person.LastName;

                context.Entry(existingAsthmaActionPlans.Person).State = existingAsthmaActionPlans.Person.Id == 0 ? EntityState.Added : EntityState.Modified;

                existingAsthmaActionPlans.Person.Doctor.FirstName = asthmaActionPlan.Person.Doctor.FirstName;
                existingAsthmaActionPlans.Person.Doctor.LastName = asthmaActionPlan.Person.Doctor.LastName;
                existingAsthmaActionPlans.Person.Doctor.PhoneNumber = asthmaActionPlan.Person.Doctor.PhoneNumber;
                existingAsthmaActionPlans.Person.Doctor.StreetAddress = asthmaActionPlan.Person.Doctor.StreetAddress;


                context.Entry(existingAsthmaActionPlans.Person.Doctor).State = existingAsthmaActionPlans.Person.DoctorId == 0 ? EntityState.Added : EntityState.Modified;

                context.SaveChanges();
                TempData["PersonId"] = PersonId;
                TempData.Keep();
                string url = Url.Action("Details", "People", new { id = existingAsthmaActionPlans.Person.ApplicationId });
                return Json(url, JsonRequestBehavior.DenyGet);
            }
            else
            {
                asthmaActionPlan.Person.DoctorId = person.DoctorId;
                asthmaActionPlan.Person.ApplicationId = person.ApplicationId;
                asthmaActionPlan.Person.FirstName = person.FirstName;
                asthmaActionPlan.Person.LastName = person.LastName;
                asthmaActionPlan.Person.DOB = person.DOB;
                asthmaActionPlan.Person.Email = person.Email;
                asthmaActionPlan.Person.StreetAddress = person.StreetAddress;
                asthmaActionPlan.Person.PhoneNumber = person.PhoneNumber;
                asthmaActionPlan.Person.State = person.State;
                asthmaActionPlan.Person.City = person.City;
                asthmaActionPlan.Person.Zipcode = person.Zipcode;

                context.AsthmaActionPlans.Add(asthmaActionPlan);
                context.People.Remove(person);
                context.SaveChanges();
                TempData["PersonId"] = PersonId + 1;
                TempData.Keep();
                string url = Url.Action("Details", "People", new { id = asthmaActionPlan.Person.ApplicationId });
                return Json(url, JsonRequestBehavior.DenyGet);
            }
        }

        // GET: AsthmaActionPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            AsthmaActionPlan asthmaActionPlan = new AsthmaActionPlan();
            asthmaActionPlan = context.AsthmaActionPlans.Where(p => p.AsthmaActionPlanId == id).SingleOrDefault();
            if (asthmaActionPlan == null)
            {
                return HttpNotFound();
            }
            return View(asthmaActionPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AsthmaActionPlan asthmaActionPlan)
        {
            try
            {
                var editedAsthmaActionPlan = context.AsthmaActionPlans.Where(p => p.Id == asthmaActionPlan.AsthmaActionPlanId).SingleOrDefault();
                editedAsthmaActionPlan.GreenMedicineName = asthmaActionPlan.GreenMedicineName;
                editedAsthmaActionPlan.GreenMedicineDosage = asthmaActionPlan.GreenMedicineDosage;
                editedAsthmaActionPlan.GreenMedicineSchedule = asthmaActionPlan.GreenMedicineSchedule;
                editedAsthmaActionPlan.YellowMedicineName = asthmaActionPlan.YellowMedicineName;
                editedAsthmaActionPlan.YellowMedicineDosage = asthmaActionPlan.YellowMedicineDosage;
                editedAsthmaActionPlan.YellowMedicineSchedule = asthmaActionPlan.YellowMedicineSchedule;
                editedAsthmaActionPlan.RedMedicineName = asthmaActionPlan.RedMedicineName;
                editedAsthmaActionPlan.RedMedicineDosage = asthmaActionPlan.RedMedicineDosage;
                editedAsthmaActionPlan.RedMedicineSchedule = asthmaActionPlan.RedMedicineSchedule;
                context.SaveChanges();
                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                return View();
            }
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
