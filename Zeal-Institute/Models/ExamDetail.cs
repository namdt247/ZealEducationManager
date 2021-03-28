using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class ExamDetail
    {
        [Key]
        [Column(Order = 1)]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        [Key]
        [Column(Order = 2)]
        [DisplayName("StudentId")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public float Mark { get; set; }

        [StringLength(255)]
        public string Note { get; set; }
    }
}