using System;
using System.Collections.Generic;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Helper;

namespace DinX.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void SaveOrUpdate(Project project)
        {
            if (project == null) throw new ArgumentNullException("project");

            PersistenceManager.CurrentSession.SaveOrUpdate(project);
        }

        public void Delete(Project project)
        {
            if (project == null) throw new ArgumentNullException("project");

             PersistenceManager.CurrentSession.Delete(project);
        }

        public Project GetProject(Guid projectId)
        {
            Project project = PersistenceManager.CurrentSession.Get<Project>(projectId);

            return project;
        }

        public IList<Project> GetProjects()
        {
            IList<Project> projects = PersistenceManager.CurrentSession.CreateQuery("FROM Project").List<Project>();

            return projects;
        }

        public IList<Project> GetProjectsByOwner(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            IList<Project> projects = PersistenceManager.CurrentSession.CreateQuery("FROM Project p WHERE p.Owner = :pOwner").SetEntity("pOwner", user).List<Project>();

            return projects;
        }

        public Project LoadProductBacklog(Project project)
        {
            if(project == null) throw new ArgumentNullException("project");

            IList<Task> listTasks = PersistenceManager.CurrentSession.CreateQuery("FROM Task t WHERE t.Project = :tProject").SetEntity("tProject", project).List<Task>();

            if(listTasks != null && listTasks.Count > 0) project.ProductBacklog = listTasks;

            return project;
        }

        public Project LoadSprints(Project project)
        {
            if(project == null) throw new ArgumentNullException("project");

            IList<Sprint> listSprints = PersistenceManager.CurrentSession.CreateQuery("FROM Sprint s WHERE s.Project = :sProject").SetEntity("sProject", project).List<Sprint>();

            if(listSprints != null && listSprints.Count > 0) project.Sprints = listSprints;

            return project;
        }
    }
}
