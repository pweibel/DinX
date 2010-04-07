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
        #region Fields
        private IUserRepository _userRepository;
        private IProjectRepository _projectRepository;
    	private ISprintRepository _sprintRepository;
        #endregion

        #region Properties
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository());
            }
            set
            {
                _userRepository = value;
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                return _projectRepository ?? (_projectRepository = new ProjectRepository());
            }
            set
            {
                _projectRepository = value;
            }
        }

		public ISprintRepository SprintRepository
		{
			get
			{
				return _sprintRepository ?? (_sprintRepository = new SprintRepository());
			}
			set
			{
				_sprintRepository = value;
			}
		}
		#endregion

        public bool CreateProject(Project project, string strUsername)
        {
            if(project == null) throw new ArgumentNullException("project");

            if(!string.IsNullOrEmpty(strUsername))
            {
                User user = this.UserRepository.GetByUsername(strUsername);
                project.Owner = user;
            }

            this.ProjectRepository.Add(project);

            return true;
        }

        public bool EditProject(Project project, string strUsername)
        {
            if (project == null) throw new ArgumentNullException("project");

            if (!string.IsNullOrEmpty(strUsername))
            {
                User user = this.UserRepository.GetByUsername(strUsername);
                project.Owner = user;
            }

            this.ProjectRepository.Update(project);

            return true;
        }

        public Project GetProject(Guid projectId)
        {
            return this.ProjectRepository.GetProject(projectId);
        }

        public IList<Project> GetProjects()
        {
            return this.ProjectRepository.GetProjects();
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

		public Sprint GetCurrentSprint(Project project)
    	{
			return this.SprintRepository.GetCurrentSprint(project);
    	}
    }
}
