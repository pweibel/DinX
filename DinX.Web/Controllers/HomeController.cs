using System.Web.Mvc;

namespace DinX.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(this.Request.IsAuthenticated)
            {
                ViewData["Message"] = string.Format("Welcome {0} to ASP.NET MVC!", this.User.Identity.Name);
            }
            else
            {
                ViewData["Message"] = "Welcome to ASP.NET MVC!";
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
