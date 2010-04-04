using System;
using System.Collections.Generic;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using NHibernate;
using NHibernate.Criterion;

namespace DinX.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            using(ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }

        public void Update(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            using(ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }

        public User GetByUsername(string strUsername)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");

            User user = null;
            using(ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(User))
                            .Add(Restrictions.Eq("Username", strUsername));

                IList<User> users = criteria.List<User>();
                if(users.Count == 1) user = users[0];
            }

            return user;
        }
    }
}
