using System.Collections.Generic;
using DinX.Common.Domain;

namespace DinX.Common.Services
{
    public interface IProjectService
    {
        IList<Project> GetProjects();
        IList<Project> GetProjectsByOwner(User user);
        IList<Sprint> GetSprintsByProject(Project project);
        IList<Task> GetProductBacklogByProject(Project project);
    }
}
