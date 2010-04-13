using System;
using System.Collections.Generic;
using DinX.Common.Domain;

namespace DinX.Common.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project project);
        void Update(Project project);
        Project GetProject(Guid projectId);
        IList<Project> GetProjects();
        IList<Project> GetProjectsByOwner(User user);
        Project LoadProductBacklog(Project project);
        Project LoadSprints(Project project);
    }
}
