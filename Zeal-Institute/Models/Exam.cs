using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date Exam")]
        public DateTime DateExam { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        [DisplayName("Start Time")]
        public TimeSpan StartTime { get; set; }

        public ExamStatus Status { get; set; }

        public enum ExamStatus
        {
            [Display(Name = "Done")]
            DONE,
            [Display(Name = "Up Comming")]
            UPCOMING,
            [Display(Name = "On Going")]
            ONGOING
        }

        public virtual ICollection<ExamDetail> ExamDetails { get; set; }
    }
}