using System;
using System.Collections.Generic;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using NHibernate;

namespace DinX.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void Add(Project project)
        {
            if (project == null) throw new ArgumentNullException("project");

            using (ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(project);
                    transaction.Commit();
                }
            }
        }

        public void Update(Project project)
        {
            if (project == null) throw new ArgumentNullException("project");

            using (ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(project);
                    transaction.Commit();
                }
            }
        }

        public IList<Project> GetProjects()
        {
            IList<Project> projects;

            using(ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                projects = session.CreateQuery("FROM Project").List<Project>();
            }

            return projects;
        }

        public IList<Project> GetProjectsByOwner(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            IList<Project> projects;

            using (ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                projects = session.CreateQuery("FROM Project p WHERE p.Owner = :pOwner").SetEntity("pOwner", user).List<Project>();
            }

            return projects;
        }
    }
}
