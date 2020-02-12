using CapstoneProject.Enum;
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

        [Display(Name = "Green Medicine Name")]
        public MedicineNameEnum GreenMedicineName { get; set; }

        [Display(Name = "Green Medicine Dosage")]
        public MedicineDosageEnum GreenMedicineDosage { get; set; }

        [Display(Name = "Green Medicine Schedule")]
        public MedicineScheduleEnum GreenMedicineSchedule { get; set; }

        [Display(Name = "Yellow Medicine Name")]
        public MedicineNameEnum YellowMedicineName { get; set; }

        [Display(Name = "Yellow Medicine Dosage")]
        public MedicineDosageEnum YellowMedicineDosage { get; set; }

        [Display(Name = "Yellow Medicine Schedule")]
        public MedicineScheduleEnum YellowMedicineSchedule { get; set; }

        [Display(Name = "Red Medicine Name")]
        public MedicineNameEnum RedMedicineName { get; set; }

        [Display(Name = "Red Medicine Dosage")]
        public MedicineDosageEnum RedMedicineDosage { get; set; }

        [Display(Name = "Red Medicine Schedule")]
        public MedicineScheduleEnum RedMedicineSchedule { get; set; }

        [Display(Name = "Normal Peak Flow Rate")]
        public int NormalPeakFlowRate { get; set; }


        [ForeignKey("Person")]
        public int Id { get; set; }
        public Person Person { get; set; }
    }
}