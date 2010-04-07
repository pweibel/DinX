using System;
using System.Web.Mvc;
using DinX.Common.Services;
using DinX.Logic.Services;
using DinX.Web.Models;

namespace DinX.Web.Controllers
{
    public class SprintController : Controller
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

		public ActionResult Index(Guid id)
        {
			SprintViewModel model = new SprintViewModel();
			model.Project = this.ProjectService.GetProject(id);
			model.Current = this.ProjectService.GetCurrentSprint(model.Project);

			return View(model);
        }
    }
}
