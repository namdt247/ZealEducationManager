using System.Web.Mvc;

namespace Zeal_Institute.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Login", id = UrlParameter.Optional },
                new[] { "Zeal_Institute.Areas.Admin.Controllers" }
            );
        }
    }
}