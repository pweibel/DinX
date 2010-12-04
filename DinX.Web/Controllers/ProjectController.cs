using System;
using System.Web.Mvc;
using DinX.Common.Domain;
using DinX.Common.Services;
using DinX.Logic.Services;
using DinX.Web.Attributes;
using DinX.Web.Models;

namespace DinX.Web.Controllers
{
    public class ProjectController : Controller
    {
        #region Fields
        private IProjectService _projectService;
        #endregion

        #region Properties
        public IProjectService ProjectService
        {
            get
            {
                return _projectService ?? (_projectService = new ProjectService());
            }
        }
        #endregion

        [NHibernateSession]
        public ActionResult Index()
        {
            ProjectViewModel vmProject = new ProjectViewModel();
            vmProject.Projects = this.ProjectService.GetProjects();
            
            return View(vmProject);
        }

        [NHibernateSession]
        public ActionResult Show(Guid id)
        {
            Project project = this.ProjectService.GetProject(id);

            return View(project);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Contact/Create
        [AcceptVerbs(HttpVerbs.Post)]
        [NHibernateSession]
        public ActionResult Create(Project project)
        {
            if(this.ProjectService.CreateProject(project, this.User.Identity.Name))
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        [NHibernateSession]
        public ActionResult Edit(Guid id)
        {
            IProjectService service = new ProjectService();
            Project project = service.GetProject(id);

            return View(project);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [NHibernateSession]
        public ActionResult Edit(Project project)
        {
            if(this.ProjectService.EditProject(project, this.User.Identity.Name))
            {
                return RedirectToAction("Show", new { id = project.Id });
            }

            return View(project);
        }
    }
}
