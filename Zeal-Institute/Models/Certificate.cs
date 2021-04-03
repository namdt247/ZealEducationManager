using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Certificate
    {
        public int Id { get; set; }

        [DisplayName("StudentId")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Registration")]
        public DateTime RegistrationDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Received")]
        public DateTime ReceivedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public CertificateStatus Status { get; set; }

        public enum CertificateStatus
        {
            [Display(Name = "Pending")]
            PENDING,
            [Display(Name = "Done")]
            DONE,
            [Display(Name = "Deleted")]
            DELETED
        }

        public double Mark(int BatchId, string UserId)
        {
            using (var db = new ApplicationDbContext())
            {
                var exam = db.Exams.FirstOrDefault(x => x.BatchId == BatchId);
                if (exam != null)
                {
                    var StudentExam = db.ExamDetails.FirstOrDefault(x => x.ExamId == exam.Id && x.ApplicationUserId == UserId);
                    if (StudentExam != null)
                    {
                        return StudentExam.Mark;
                    }
                }
                return 0;
            }
        }
    }
}