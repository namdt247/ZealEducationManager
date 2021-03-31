using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zeal_Institute.Models;

namespace Zeal_Institute.Areas.Admin.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}