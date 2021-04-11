using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var Courses = db.Courses.ToList();
            return View(Courses);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Event()
        {
            return View();
        }

        public ActionResult Feedback(string email, string name, string phone, Zeal_Institute.Models.Feedback.FeedbackType type, string content)
        {
            try
            {
                var Feedback = new Feedback()
                {
                    FbEmail = email,
                    FbName = name,
                    FbPhone = phone,
                    Type = type,
                    Content = content,
                    Status = Zeal_Institute.Models.Feedback.FeedbackStatus.ACTIVE
                };

                db.Feedbacks.Add(Feedback);
                db.SaveChanges();
                return Json(new { code = 200, Feedback = Feedback, msg = "Add Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Add Faild" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}