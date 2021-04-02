using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [DisplayName("StudentId")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }
        public double AmountPayable { get; set; }
        public double AmountPaid { get; set; }

        public PaymentType Type { get; set; }
        public enum PaymentType
        {
            [Display(Name = "Course Fee")]
            FEE,
            [Display(Name = "Fine")]
            FINE
        }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Pay")]
        public DateTime PayDate { get; set; }

        [Column(TypeName = "TEXT")]
        [Display(Name = "Note")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        public PaymentStatus Status { get; set; }

        public enum PaymentStatus
        {
            [Display(Name = "Active")]
            ACTIVE,
            [Display(Name = "Deactive")]
            DEACTIVE,
            [Display(Name = "Deleted")]
            DELETED
        }

        public double RemainingAmount(double AmountPayable, double AmountPaid)
        {
            var RemainingAmount = AmountPayable - AmountPaid;
            return RemainingAmount;
        }
    }
}