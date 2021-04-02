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
    }
}