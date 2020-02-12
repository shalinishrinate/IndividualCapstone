using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneProject.Enum
{
    public enum MedicineScheduleEnum
    {
        [Display(Name = "Once a day")]
        OnceADay =1,

        [Display(Name = "Twice a day")]
        TwiceADay = 2,

        [Display(Name = "Every 4 hours")]
        Every4Hours = 3,

        [Display(Name = "Every 6 hours")]
        Every6Hours = 4,

        [Display(Name = "When needed")]
        WhenNeeded = 5
    }
}   