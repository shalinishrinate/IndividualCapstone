using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    public class AsthmaActionPlan
    {
        [Key]
        public int AsthmaActionPlanId { get; set; }

        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }

        [Display(Name = "Medicine Dosage")]
        public string MedicineDosage { get; set; }

        [Display(Name = "Medicine Schedule")]
        public string MedicineSchedule { get; set; }

       [ForeignKey("Person")]
        public int Id { get; set; }
        public Person Person { get; set; }
    }
}