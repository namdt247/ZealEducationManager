using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Batch
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Code { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public string ListStudent { get; set; }

        [Column(TypeName = "TEXT")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date Start")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date End")]
        public DateTime DateEnd { get; set; }

        public BatchStatus Status { get; set; }

        public enum BatchStatus
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