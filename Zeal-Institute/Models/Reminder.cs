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
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }

        [StringLength(255)]
        public string Note { get; set; }
        public ReminderStatus Status { get; set; }

        public enum ReminderStatus
        {
            [Display(Name = "Pending")]
            PENDING,
            [Display(Name = "Done")]
            DONE,
            [Display(Name = "Deleted")]
            DELETED
        }
    }
}