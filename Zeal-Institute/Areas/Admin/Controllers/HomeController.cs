using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            var role = roleManager.FindByName("Student").Users.First();
            var dateNow = DateTime.Now;
            var firstDayOfMonth = new DateTime(dateNow.Year, dateNow.Month, 1);
            var startDate = dateNow;
            var endDate = dateNow.AddDays(-29);

            Debug.WriteLine(dateNow);

            var dataStudent = db.Users
                .Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId))
                .Where(u => u.CreatedAt >= endDate)
                .Where(u => u.CreatedAt <= startDate)   
                .GroupBy(x => x.CreatedAt)
                .ToDictionary(k => k.Key.ToString("dd-MM-yyyy"), k=>k.Count())
                ;

            // data student
            var countStudent = db.Users
                .Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId))
                .Where(u => u.CreatedAt >= firstDayOfMonth)
                .Where(u => u.CreatedAt <= dateNow)
                .Count()
                ;

            // data batch
            var countBatch = db.Batches
                .Where(x => x.DateStart >= firstDayOfMonth)
                .Where(x => x.DateStart <= dateNow)
                .Count()
                ;

            // data revenue
            var dataRevenue = db.Payments
                .Where(x => x.PayDate >= firstDayOfMonth)
                .Where(x => x.PayDate <= dateNow)
                .Sum(x => x.AmountPaid)
                ;

            var dataFinancial = db.Payments
                .Where(u => u.PayDate >= endDate)
                .Where(u => u.PayDate <= startDate)
                .GroupBy(x => x.PayDate)
                .ToDictionary(k => k.Key.ToString("dd-MM-yyyy"), k => k.Sum(m => m.AmountPaid))
                ;

            Debug.WriteLine(JsonConvert.SerializeObject(dataFinancial));

            ViewBag.countStudent = countStudent;
            ViewBag.countBatch = countBatch;
            ViewBag.dataRevenue = dataRevenue;
            ViewBag.StudentData = JsonConvert.SerializeObject(dataStudent);
            ViewBag.FinancialData = JsonConvert.SerializeObject(dataFinancial);

            return View();
        }

        [HttpGet]
        public string StudentData(DateTime start, DateTime end)
        {
            var role = roleManager.FindByName("Student").Users.First();
            var startDate = start != null ? start : DateTime.Now.AddDays(-29);
            var endDate = end != null ? end : DateTime.Now;

            var dataStudent = db.Users
                .Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId))
                .Where(u => u.CreatedAt <= endDate)
                .Where(u => u.CreatedAt >= startDate)
                .GroupBy(x => x.CreatedAt)
                .ToDictionary(k => k.Key.ToString("dd-MM-yyyy"), k => k.Count())
                ;

            var data = JsonConvert.SerializeObject(dataStudent);
            return data;
        }

        public string FinancialData(DateTime start, DateTime end)
        {
            var startDate = start != null ? start : DateTime.Now.AddDays(-29);
            var endDate = end != null ? end : DateTime.Now;

            var dataFinancial = db.Payments
                .Where(u => u.PayDate <= endDate)
                .Where(u => u.PayDate >= startDate)
                .GroupBy(x => x.PayDate)
                .ToDictionary(k => k.Key.ToString("dd-MM-yyyy"), k => k.Sum(m => m.AmountPaid))
                ;

            var data = JsonConvert.SerializeObject(dataFinancial);
            return data;
        }

        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Home");
        }
    }
}