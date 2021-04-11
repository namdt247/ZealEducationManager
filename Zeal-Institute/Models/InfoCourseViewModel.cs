using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeal_Institute.Models
{
    public class InfoCourseViewModel
    {
        public string CourseName { get; set; }
        public float Mark { get; set; }
        public int BatchId { get; set; }
        public int CourseId { get; set; }
        public string UserId { get; set; }
        public bool IsCertificate { get; set; }
        public string BatchName { get; set; }
        public string ReceivedDate { get; set; }
    }
}