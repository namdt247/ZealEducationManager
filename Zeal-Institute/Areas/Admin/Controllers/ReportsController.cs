using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Areas.Admin.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        // GET: Admin/Reports
        // Reports financial
        [Authorizee(Roles = "Admin")]
        public ActionResult ListFee()
        {
            var ListFee = db.Payments
                .Where(x => x.Type == Payment.PaymentType.FEE)
                .Where(x => x.Status != Payment.PaymentStatus.DELETED)
                .OrderByDescending(x => x.PayDate)
                .ToList();
            return View(ListFee);
        }

        [Authorizee(Roles = "Admin")]
        public ActionResult ListFine()
        {
            var ListFine = db.Payments
                .Where(x => x.Type == Payment.PaymentType.FINE)
                .Where(x => x.Status != Payment.PaymentStatus.DELETED)
                .OrderByDescending(x => x.PayDate)
                .ToList();
            return View(ListFine);
        }

        [Authorizee(Roles = "Admin")]
        public ActionResult ListOutstanding()
        {
            var ListOutstanding = db.Payments
                .Where(x => x.AmountPaid < x.AmountPayable)
                .Where(x => x.Status != Payment.PaymentStatus.DELETED)
                .OrderByDescending(x => x.Id)
                .ToList();
            return View(ListOutstanding);
        }

        [Authorizee(Roles = "Admin")]
        public ActionResult ListReminder()
        {
            var ListReminder = db.Reminders
                .Where(x => x.Status != Reminder.ReminderStatus.DELETED)
                .OrderByDescending(x => x.Id)
                .ToList();
            return View(ListReminder);
        }

        [Authorizee(Roles = "Admin")]
        // Reports batch
        public ActionResult EndBatches()
        {
            var ListEndBatches = db.Batches
                .Where(x => x.DateEnd < DateTime.Now)
                .Where(x => x.Status != Batch.BatchStatus.DELETED)
                .OrderByDescending(x => x.DateEnd)
                .ToList();
            return View(ListEndBatches);
        }

        [Authorizee(Roles = "Admin")]
        public ActionResult StartBatches()
        {
            var ListStartBatches = db.Batches
                .Where(x => x.DateEnd >= DateTime.Now)
                .Where(x => x.Status != Batch.BatchStatus.DELETED)
                .OrderByDescending(x => x.DateStart)
                .ToList();
            return View(ListStartBatches);
        }

        // Reports student
        [Authorizee(Roles = "Admin")]
        public ActionResult ListDiscount()
        {
            var ListDiscount = db.Discounts
                .Where(x => x.Status != Discount.DiscountStatus.DELETED)
                .OrderByDescending(x => x.Id)
                .ToList();
            return View(ListDiscount);
        }

        [Authorizee(Roles = "Admin")]
        public ActionResult ListStudent()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var role = roleManager.FindByName("Student").Users.First();
            var ListStudent = db.Users
                .Where(u => u.Roles.Select(r => r.RoleId)
                .Contains(role.RoleId))
                .Where(x => x.Status != ApplicationUser.UserStatus.DELETED)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return View(ListStudent);
        }

        [Authorizee(Roles = "Admin")]
        public ActionResult ListCertificate()
        {
            var ListCertificate = db.Certificates
                .Where(x => x.Status != Certificate.CertificateStatus.DELETED)
                .OrderByDescending(x => x.RegistrationDate)
                .ToList();
            return View(ListCertificate);
        }
        // GET: Admin/Reports/DetailsCertificate/1
        [Authorizee(Roles = "Admin")]
        public ActionResult DetailsCertificate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificate certificate = db.Certificates.Find(id);
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult DetailsCertificate([Bind(Include = "Id,ApplicationUserId,BatchId,RegistrationDate,ReceivedDate,Note,Status")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                certificate.Status = Certificate.CertificateStatus.DONE;
                certificate.ReceivedDate = DateTime.Now;
                db.Entry(certificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListCertificate");
            }
            return View(certificate);
        }

        // detail ending batch
        [Authorizee(Roles = "Admin")]
        public ActionResult DetailsEnding(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);

            var listStudent = new List<ApplicationUser>();
            string[] subse = batch.ListStudent.Split(',');
            for (int i = 0; i < subse.Length - 1; i++)
            {
                var idStudent = subse[i];
                listStudent.Add(db.Users.Where(s => s.Id == idStudent).Single());
            }
            ViewData["ListStudent_End"] = listStudent;
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }
        // detail ending batch
        [Authorizee(Roles = "Admin")]
        public ActionResult DetailsStart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);

            var listStudent = new List<ApplicationUser>();
            string[] subs = batch.ListStudent.Split(',');
            for (int i = 0; i < subs.Length - 1; i++)
            {
                var idStudent = subs[i];
                listStudent.Add(db.Users.Where(s => s.Id == idStudent).Single());
            }
            ViewData["ListStudent_Start"] = listStudent;
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }
    }
}