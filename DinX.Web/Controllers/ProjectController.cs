using System;
using System.Web.Mvc;
using DinX.Common.Domain;
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

        public ActionResult Show(Guid id)
        {
            IProjectService service = new ProjectService();
            Project project = service.GetProject(id);

            return View(project);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Contact/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Project project)
        {
            IProjectService service = new ProjectService();
            if(service.CreateProject(project, this.User.Identity.Name))
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        public ActionResult Edit(Guid id)
        {
            IProjectService service = new ProjectService();
            Project project = service.GetProject(id);

            return View(project);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Project project)
        {
            IProjectService service = new ProjectService();
            if(service.EditProject(project, this.User.Identity.Name))
            {
                return RedirectToAction("Show", new { id = project.Id });
            }

            return View(project);
        }
    }
}
