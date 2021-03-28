using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class Course
    {
        public int Id { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Code { get; set; }

        public double Price { get; set; }

        [Column(TypeName = "TEXT")]
        public string Thumbnail { get; set; }

        [Column(TypeName = "TEXT")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public CourseStatus Status { get; set; }

        public enum CourseStatus
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