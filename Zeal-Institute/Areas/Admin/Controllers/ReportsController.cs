﻿using Microsoft.AspNet.Identity;
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
        public ActionResult ListFee()
        {
            var ListFee = db.Payments.Where(x => x.Type == Payment.PaymentType.FEE).ToList();
            return View(ListFee);
        }

        public ActionResult ListFine()
        {
            var ListFine = db.Payments.Where(x => x.Type == Payment.PaymentType.FINE).ToList();
            return View(ListFine);
        }

        public ActionResult ListOutstanding()
        {
            var ListOutstanding = db.Payments.Where(x => x.AmountPaid < x.AmountPayable).ToList();
            return View(ListOutstanding);
        }

        public ActionResult ListReminder()
        {
            var ListReminder = db.Reminders.ToList();
            return View(ListReminder);
        }

        // Reports batch
        public ActionResult EndBatches()
        {
            var ListEndBatches = db.Batches.Where(x => x.DateEnd < DateTime.Now).ToList();
            return View(ListEndBatches);
        }

        public ActionResult StartBatches()
        {
            var ListStartBatches = db.Batches.Where(x => x.DateEnd >= DateTime.Now).ToList();
            return View(ListStartBatches);
        }

        // Reports student
        public ActionResult ListDiscount()
        {
            var ListDiscount = db.Discounts.ToList();
            return View(ListDiscount);
        }

        public ActionResult ListStudent()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var role = roleManager.FindByName("Student").Users.First();
            var ListStudent = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList();
            return View(ListStudent);
        }

        public ActionResult ListCertificate()
        {
            var ListCertificate = db.Certificates.OrderByDescending(x => x.RegistrationDate).ToList();
            return View(ListCertificate);
        }
        // GET: Admin/Reports/DetailsCertificate/1
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