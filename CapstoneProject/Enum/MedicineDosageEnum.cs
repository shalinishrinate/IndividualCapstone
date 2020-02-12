using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneProject.Enum
{
    public enum MedicineDosageEnum
    {
        [Display(Name = "One puff")]
        OnePuff = 1,

        [Display(Name = "Two puffs")]
        TwoPuff = 2,

        [Display(Name = "Three puffs")]
        ThreePuff = 3,

        [Display(Name = "Four puffs")]
        FourPuff = 4,

    }
}