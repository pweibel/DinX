using System.Collections.Generic;
using DinX.Common.Domain;

namespace DinX.Common.Repositories
{
    public interface IProjectRepository
    {
        void Add(Project project);
        void Update(Project project);
        IList<Project> GetProjects();
        IList<Project> GetProjectsByOwner(User user);
    }
}
