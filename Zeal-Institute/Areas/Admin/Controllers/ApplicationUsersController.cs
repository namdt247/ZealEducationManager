using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Areas.Admin.Controllers
{
    public class ApplicationUsersController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        // GET: Admin/ApplicationUsers
        [Authorizee(Roles = "Admin")]
        public ActionResult Index()
        {
            var role = roleManager.FindByName("Student").Users.First();
            var usersInRole = db.Users
                .Where(u => u.Roles.Select(r => r.RoleId)
                .Contains(role.RoleId))
                .Where(x => x.Status != ApplicationUser.UserStatus.DELETED)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return View(usersInRole);
        }

        // GET: Admin/ApplicationUsers/Details/5
        [Authorizee(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Admin/ApplicationUsers/Create
        [Authorizee(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ApplicationUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,FullName,RollNumber,Address,Avatar,Description,CreatedAt,Status,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");
            Random r = new Random();
            int num = r.Next();

            applicationUser.UserName = applicationUser.FullName;
            applicationUser.EmailConfirmed = false;
            applicationUser.Status = ApplicationUser.UserStatus.ACTIVE;
            applicationUser.PasswordHash = password;
            applicationUser.PhoneNumberConfirmed = false;
            applicationUser.LockoutEndDateUtc = null;
            applicationUser.LockoutEnabled = false;
            applicationUser.AccessFailedCount = 0;
            applicationUser.TwoFactorEnabled = false;
            applicationUser.SecurityStamp = "1";
            applicationUser.CreatedAt = DateTime.Now;
            applicationUser.RollNumber = "D006" + num.ToString();

            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: Admin/ApplicationUsers/Edit/5
        [Authorizee(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/ApplicationUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,FullName,RollNumber,Address,Avatar,Description,CreatedAt,Status,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: Admin/ApplicationUsers/Delete/5
        [Authorizee(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            applicationUser.Status = ApplicationUser.UserStatus.DELETED;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorizee(Roles = "Admin")]
        public ActionResult DeleteFaculty(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            applicationUser.Status = ApplicationUser.UserStatus.DELETED;
            db.SaveChanges();
            return RedirectToAction("ListFaculty");
        }

        // POST: Admin/ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorizee(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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

        [Authorizee(Roles = "Admin")]
        public ActionResult ListFaculty()
        {
            var role = roleManager.FindByName("Faculty").Users.First();
            var usersInRole = db.Users
                .Where(u => u.Roles.Select(r => r.RoleId)
                .Contains(role.RoleId))
                .Where(x => x.Status != ApplicationUser.UserStatus.DELETED)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return View(usersInRole);
        }
    }
}
