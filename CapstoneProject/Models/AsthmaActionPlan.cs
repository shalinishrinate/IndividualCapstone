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

        public string Medicine1Name { get; set; }
        public string Medicine1Dosage { get; set; }
        public string Medicine1Schedule { get; set; }

        public string Medicine2Name { get; set; }
        public string Medicine2Dosage { get; set; }
        public string Medicine2Schedule { get; set; }

        public string Medicine3Name { get; set; }
        public string Medicine3Dosage { get; set; }
        public string Medicine3Schedule { get; set; }

        [ForeignKey("Person")]
        public int Id { get; set; }
        public Person Person { get; set; }
    }
}