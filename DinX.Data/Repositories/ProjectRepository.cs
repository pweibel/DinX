using System;
using System.Collections.Generic;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Helper;
using NHibernate;

namespace DinX.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void SaveOrUpdate(Project project)
        {
            if (project == null) throw new ArgumentNullException("project");

            using (ISession session = PersistenceManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(project);
                    transaction.Commit();
                }
            }
        }

        public void Delete(Project project)
        {
            if (project == null) throw new ArgumentNullException("project");

            using (ISession session = PersistenceManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(project);
                    transaction.Commit();
                }
            }
        }

        public Project GetProject(Guid projectId)
        {
            Project project;

            using (ISession session = PersistenceManager.OpenSession())
            {
                project = session.Get<Project>(projectId);
            }
            return project;
        }

        public IList<Project> GetProjects()
        {
            IList<Project> projects;

            using(ISession session = PersistenceManager.OpenSession())
            {
                projects = session.CreateQuery("FROM Project").List<Project>();
            }

            return projects;
        }

        public IList<Project> GetProjectsByOwner(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            IList<Project> projects;

            using (ISession session = PersistenceManager.OpenSession())
            {
                projects = session.CreateQuery("FROM Project p WHERE p.Owner = :pOwner").SetEntity("pOwner", user).List<Project>();
            }

            return projects;
        }

        public Project LoadProductBacklog(Project project)
        {
            if(project == null) throw new ArgumentNullException("project");

            IList<Task> listTasks;

            using(ISession session = PersistenceManager.OpenSession())
            {
                listTasks = session.CreateQuery("FROM Task t WHERE t.Project = :tProject").SetEntity("tProject", project).List<Task>();
            }

            if(listTasks != null && listTasks.Count > 0) project.ProductBacklog = listTasks;

            return project;
        }

        public Project LoadSprints(Project project)
        {
            if(project == null) throw new ArgumentNullException("project");

            IList<Sprint> listSprints;

            using(ISession session = PersistenceManager.OpenSession())
            {
                listSprints = session.CreateQuery("FROM Sprint s WHERE s.Project = :sProject").SetEntity("sProject", project).List<Sprint>();
            }

            if(listSprints != null && listSprints.Count > 0) project.Sprints = listSprints;

            return project;
        }
    }
}
