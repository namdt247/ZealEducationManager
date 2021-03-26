using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Reminder
    {
        public int Id { get; set; }

        [DisplayName("StudentId")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public ReminderStatus Status { get; set; }

        public enum ReminderStatus
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