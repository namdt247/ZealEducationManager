using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Zeal_Institute.Models;

namespace Zeal_Institute.Areas.Admin.Controllers
{
    public class ExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Exams
        [Authorizee(Roles = "Admin")]
        public ActionResult Index()
        {
            var exams = db.Exams
                .OrderByDescending(x => x.DateExam)
                .Include(e => e.Batch)
                ;
            return View(exams.ToList());
        }

        // GET: Admin/Exams/Details/5
        [Authorizee(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            var ListExamStudent = db.ExamDetails.Where(x => x.ExamId == exam.Id).ToList();
            ViewData["ListExamStudent"] = ListExamStudent;
            return View(exam);
        }

        // GET: Admin/Exams/Create
        [Authorizee(Roles = "Admin")]
        public ActionResult Create()
        {
            var listBatchId = db.Exams.Select(x => x.BatchId).ToArray();
            var listBatch = db.Batches.Where(x => !listBatchId.Contains(x.Id));
            ViewBag.BatchId = new SelectList(listBatch, "Id", "Name");
            return View();
        }

        // POST: Admin/Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,BatchId,DateExam,StartTime,Status")] Exam exam)
        {
            Batch batch = db.Batches.Find(exam.BatchId);
            if (ModelState.IsValid)
            {
                if (batch.ListStudent != null)
                {
                    string[] subse = batch.ListStudent.Split(',');
                    for (int i = 0; i < subse.Length - 1; i++)
                    {
                        var idStudent = subse[i];
                        var student = db.Users.Where(s => s.Id == idStudent).Single();
                        db.ExamDetails.Add(new ExamDetail { ExamId = exam.Id, ApplicationUserId = student.Id, Mark = 0, Note = "" });
                    }
                }
                exam.Status = Exam.ExamStatus.ONGOING;
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchId = new SelectList(db.Batches, "Id", "Name", exam.BatchId);
            return View(exam);
        }

        // GET: Admin/Exams/Edit/5
        [Authorizee(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchId = new SelectList(db.Batches, "Id", "Name", exam.BatchId);
            return View(exam);
        }

        // POST: Admin/Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,BatchId,DateExam,StartTime,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchId = new SelectList(db.Batches, "Id", "Name", exam.BatchId);
            return View(exam);
        }

        // GET: Admin/Exams/Delete/5
        [Authorizee(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Admin/Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult UpdateExamDetails(List<ExamDetail> exam)
        {
            try
            {
                var ExamId = 0;
                foreach (var item in exam)
                {
                    var objExamDetail = new ExamDetail() { ExamId = item.ExamId, ApplicationUserId = item.ApplicationUserId, Mark = item.Mark, Note = "" };
                    db.Entry(objExamDetail).State = EntityState.Modified;
                    if (ExamId == 0)
                    {
                        ExamId = item.ExamId;
                    }
                }
                Exam currentExam = db.Exams.Find(ExamId);
                if (currentExam != null && currentExam.Status != Exam.ExamStatus.DONE)
                {
                    currentExam.Status = Exam.ExamStatus.DONE;
                    db.Entry(currentExam).State = EntityState.Modified;
                }
                db.SaveChanges();
                ViewData["ListExamStudent"] = exam;
                return Json(new { result = exam }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { list = "not" }, JsonRequestBehavior.AllowGet);
            }
            
            
        }
    }
}
