using System.Web.Mvc;
using DinX.Common.Services;
using DinX.Logic.Services;
using DinX.Web.Models;

namespace DinX.Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            IProjectService service = new ProjectService();
            ProjectViewModel vmProject = new ProjectViewModel();
            vmProject.Projects = service.GetProjects();
            
            return View(vmProject);
        }
    }
}
