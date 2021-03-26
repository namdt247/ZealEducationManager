using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Discount
    {
        public int Id { get; set; }

        [DisplayName("StudentId")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public double CoursePrice { get; set; }
        public double DiscountValue { get; set; }

        public DiscountStatus Status { get; set; }

        public enum DiscountStatus
        {
            [Display(Name = "Active")]
            ACTIVE,
            [Display(Name = "Deactive")]
            DEACTIVE,
            [Display(Name = "Deleted")]
            DELETED
        }
    }
}