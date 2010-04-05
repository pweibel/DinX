using System;
using System.Collections.Generic;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Common.Services;
using DinX.Data.Repositories;

namespace DinX.Logic.Services
{
    public class ProjectService : IProjectService
    {
        public IList<Project> GetProjects()
        {
            IProjectRepository repository = new ProjectRepository();
            return repository.GetProjects();
        }

        public IList<Project> GetProjectsByOwner(User user)
        {
            throw new NotImplementedException();
        }

        public IList<Sprint> GetSprintsByProject(Project project)
        {
            throw new NotImplementedException();
        }

        public IList<Task> GetProductBacklogByProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
