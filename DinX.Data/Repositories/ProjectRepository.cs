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

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                session.SaveOrUpdate(project);
                trans.Commit();
            }
        }

        public void Delete(Project project)
        {
            if (project == null) throw new ArgumentNullException("project");

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                session.Delete(project);
                trans.Commit();
            }
        }

        public Project GetProject(Guid projectId)
        {
            Project project;

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                project = session.Get<Project>(projectId);
                trans.Commit();
            }

            return project;
        }

        public IList<Project> GetProjects()
        {
            IList<Project> projects;

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                projects = session.CreateQuery("FROM Project").List<Project>();
                trans.Commit();
            }

            return projects;
        }

        public IList<Project> GetProjectsByOwner(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            IList<Project> projects;

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                projects = session.CreateQuery("FROM Project p WHERE p.Owner = :pOwner").SetEntity("pOwner", user).List<Project>();
                trans.Commit();
            }

            return projects;
        }

        public Project LoadProductBacklog(Project project)
        {
            if(project == null) throw new ArgumentNullException("project");

            IList<Task> listTasks;

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                listTasks = session.CreateQuery("FROM Task t WHERE t.Project = :tProject").SetEntity("tProject", project).List<Task>();
                trans.Commit();
            }

            if(listTasks != null && listTasks.Count > 0) project.ProductBacklog = listTasks;

            return project;
        }

        public Project LoadSprints(Project project)
        {
            if(project == null) throw new ArgumentNullException("project");

            IList<Sprint> listSprints;

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                listSprints = session.CreateQuery("FROM Sprint s WHERE s.Project = :sProject").SetEntity("sProject", project).List<Sprint>();
                trans.Commit();
            }

            if(listSprints != null && listSprints.Count > 0) project.Sprints = listSprints;

            return project;
        }
    }
}
