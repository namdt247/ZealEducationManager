using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Controllers
{
    public class CertificateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Certificate
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var ExamDetails = db.ExamDetails.Where(e => e.ApplicationUserId == UserId && e.Mark > 40).ToList();
            var Exams = new List<Exam>();
            foreach (var item in ExamDetails)
            {
                Exams.Add(item.Exam);
            }

            var query = (from ed in ExamDetails
                         join e in db.Exams on ed.ExamId equals e.Id
                         join b in db.Batches on e.BatchId equals b.Id
                         join c in db.Courses on b.CourseId equals c.Id
                         select new { ed.Mark, e.BatchId, ed.ApplicationUserId, b.CourseId, c.Name, BatchName = b.Name }
                        ).ToList();

            var ListModel = new List<InfoCourseViewModel>();
            foreach (var item in query)
            {
                ListModel.Add(new InfoCourseViewModel() {
                    CourseName = item.Name,
                    Mark = item.Mark,
                    BatchId = item.BatchId,
                    CourseId = item.CourseId,
                    UserId = item.ApplicationUserId,
                    BatchName = item.BatchName
                });
            }

            var Certificates = db.Certificates.ToList();
            foreach (var item in ListModel)
            {
                foreach (var c in Certificates)
                {
                    var rs = c.CheckCertificate(item.UserId, item.BatchId);
                    if (rs)
                    {
                        item.IsCertificate = rs;
                    if (c.Status == Certificate.CertificateStatus.ACTIVE)
                        {
                            item.ReceivedDate = c.ReceivedDate.ToShortDateString();
                        }
                        else
                        {
                            item.ReceivedDate = null;
                        }
                    }
                    
                }
            }
            return View(ListModel);
        }

        public ActionResult Registration(string userid, int batchid) 
        {
            try
            {
                var Certificate = new Certificate()
                {
                    ApplicationUserId = userid,
                    BatchId = batchid,
                    RegistrationDate = DateTime.Now,
                    Note = "hello world",
                    Status = Zeal_Institute.Models.Certificate.CertificateStatus.DEACTIVE,
                };

                db.Certificates.Add(Certificate);
                db.SaveChanges();
                return Json(new { code = 200, Certificate = Certificate, msg = "Add Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Add Faild" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}