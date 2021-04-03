using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Areas.Admin.Controllers
{
    public class BatchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        // GET: Admin/Batches
        public ActionResult Index()
        {
            var batches = db.Batches.Include(b => b.Course);
            return View(batches.ToList());
        }

        // GET: Admin/Batches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: Admin/Batches/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            return View();
        }

        // POST: Admin/Batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,CourseId,ListStudent,Description,DateStart,DateEnd,Status")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Batches.Add(batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", batch.CourseId);
            return View(batch);
        }

        // GET: Admin/Batches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", batch.CourseId);
            return View(batch);
        }

        // POST: Admin/Batches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,CourseId,ListStudent,Description,DateStart,DateEnd,Status")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", batch.CourseId);
            return View(batch);
        }

        // GET: Admin/Batches/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Batch btc = db.Batches.Find(id);
            if (btc == null)
            {
                return HttpNotFound();
            }
            db.Batches.Remove(btc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Batch batch = db.Batches.Find(id);
        //    if (batch == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(batch);
        //}

        //// POST: Admin/Batches/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Batch batch = db.Batches.Find(id);
        //    db.Batches.Remove(batch);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetListStudent(string searchTerm)
        {
            var role = roleManager.FindByName("Student").Users.First();
            var listStudent = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList();
            if (searchTerm != null)
            {
                listStudent = db.Users.Where(x => x.FullName.Contains(searchTerm)).ToList();
            }
            var modifiedData = listStudent.Select(x => new {
                id = x.Id,
                text = x.FullName + " - " + x.RollNumber
            });
            Debug.WriteLine(modifiedData);
            return Json(modifiedData, JsonRequestBehavior.AllowGet);

        }
    }
}
