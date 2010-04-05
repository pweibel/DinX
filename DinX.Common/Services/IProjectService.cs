using System;
using System.Collections.Generic;
using DinX.Common.Domain;

namespace DinX.Common.Services
{
    public interface IProjectService
    {
        bool CreateProject(Project project, string strUsername);
        bool EditProject(Project project, string strUsername);
        Project GetProject(Guid projectId);
        IList<Project> GetProjects();
        IList<Project> GetProjectsByOwner(User user);
        IList<Sprint> GetSprintsByProject(Project project);
        IList<Task> GetProductBacklogByProject(Project project);
    }
}
