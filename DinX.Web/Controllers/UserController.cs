using System.Web.Mvc;

using DinX.Web.Models;

namespace DinX.Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            UserViewModel model = new UserViewModel();
			
			return View(model);
        }

    }
}
