using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

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

        [Display(Name = "Asthma Trigger - Animals?")]
        public bool AreAnimalsATrigger { get; set; }

        [Display(Name = "Asthma Trigger - Burning Wood or Grass?")]
        public bool AreBurningWoodOrGrassATrigger { get; set; }
    }
}