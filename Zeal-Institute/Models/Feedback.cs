using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string FbEmail { get; set; }

        [StringLength(255)]
        public string FbPhone { get; set; }

        [StringLength(255)]
        public string FbName { get; set; }
        public FeedbackType Type { get; set; }
        public enum FeedbackType
        {
            [Display(Name = "Register for course")]
            REGISTER,
            [Display(Name = "Detail of course")]
            DETAIL,
            [Display(Name = "Other")]
            ORTHER
        }

        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(255)]
        public string Note { get; set; }
        public FeedbackStatus Status { get; set; }

        public enum FeedbackStatus
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