using System.Web.Mvc;

using DinX.Web.Models;

namespace DinX.Web.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search()
        {
            return View(new SearchViewModel());
        }

    }
}
