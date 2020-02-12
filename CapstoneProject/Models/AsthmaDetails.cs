using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    public class AsthmaDetails
    {
        //public string UserId { get; set; }

        //public int AsthmaDetailsId { get; set; }
        //public int AsmthaAttacksInJanuary { get; set; }
        //public int AsmthaAttacksInFebruary { get; set; }
        //public int AsmthaAttacksInMarch { get; set; }
        //public int AsmthaAttacksInApril { get; set; }
        //public int AsmthaAttacksInMay { get; set; }
        //public int AsmthaAttacksInJune { get; set; }
        //public int AsmthaAttacksInJuly { get; set; }
        //public int AsmthaAttacksInAugust { get; set; }
        //public int AsmthaAttacksInSeptember { get; set; }
        //public int AsmthaAttacksInOctober { get; set; }
        //public int AsmthaAttacksInNovember { get; set; }
        //public int AsmthaAttacksInDecember { get; set; }
        [Key]
        public int AsthamaDetailsId{ get; set; }

        [DataType(DataType.Date)]
        public DateTime PeakFlowRecordedDate { get; set; }
        public int PeakFlowNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime AsthmaAttackDate { get; set; }
        public int AsthmaAttackNumber { get; set; }
       

        [ForeignKey("Person")]
        public int Id { get; set; }
        public Person Person { get; set; }
    

    }
}