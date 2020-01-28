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
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Home City Zipcode")]
        public int Zipcode { get; set; }

        [Display(Name = "Home City")]
        public string City { get; set; }

        [Display(Name = "Home State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Asthma Triggers")]
        public bool AsthmaTriggers { get; set; }
    }
}