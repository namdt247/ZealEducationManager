using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Course
        public ActionResult Index()
        {
            var Courses = db.Courses.ToList();
            return View(Courses);
        }

        public ActionResult Detail(int id)
        {
            var Courses = db.Courses.Find(id);
            return View(Courses);
        }
    }
}