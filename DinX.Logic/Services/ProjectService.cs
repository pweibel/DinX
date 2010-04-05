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
        public bool CreateProject(Project project, string strUsername)
        {
            if(project == null) throw new ArgumentNullException("project");

            if(!string.IsNullOrEmpty(strUsername))
            {
                IUserRepository userRepository = new UserRepository();
                User user = userRepository.GetByUsername(strUsername);
                project.Owner = user;
            }

            IProjectRepository repository = new ProjectRepository();
            repository.Add(project);

            return true;
        }

        public bool EditProject(Project project, string strUsername)
        {
            if (project == null) throw new ArgumentNullException("project");

            if (!string.IsNullOrEmpty(strUsername))
            {
                IUserRepository userRepository = new UserRepository();
                User user = userRepository.GetByUsername(strUsername);
                project.Owner = user;
            }

            IProjectRepository repository = new ProjectRepository();
            repository.Update(project);

            return true;
        }

        public Project GetProject(Guid projectId)
        {
            IProjectRepository repository = new ProjectRepository();
            return repository.GetProject(projectId);
        }

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
