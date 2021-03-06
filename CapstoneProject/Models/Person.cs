﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your First name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Zipcode")]
        public int Zipcode { get; set; }

        //[Display(Name = "Asthma Trigger - Food?")]
        //public bool IsFoodATrigger { get; set; }

        [Display(Name = "Asthma Trigger - OutdoorAirPollution?")]
        public bool IsPollutionATrigger { get; set; }

        [Display(Name = "Asthma Trigger - Pollens?")]
        public bool ArePollensATrigger { get; set; }

        [Display(Name = "Asthma Trigger - Dust Mites?")]
        public bool AreDustMitesATrigger { get; set; }

        [Display(Name = "Asthma Trigger - Tobacco Smoke?")]
        public bool IsTobaccoSmokeATrigger { get; set; }

        [Display(Name = "Asthma Trigger - Mold?")]
        public bool IsMoldATrigger { get; set; }

        //[Display(Name = "Asthma Trigger - Animals?")]
        //public bool AreAnimalsATrigger { get; set; }

        [Display(Name = "Asthma Trigger - Burning Wood or Grass?")]
        public bool AreBurningWoodOrGrassATrigger { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }

    }
}