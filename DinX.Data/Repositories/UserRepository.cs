using System;
using System.Collections.Generic;
using DinX.Common.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace DinX.Data.Repositories
{
    public class UserRepository
    {
        public User GetUserByName(string strUsername)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");

            User user = null;
            using(ISession session = PersistenceManager.PersistenceManager.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(User))
                            .Add(Expression.Eq("Username", strUsername));

                IList<User> users = criteria.List<User>();
                if(users.Count == 1) user = users[0];
            }

            return user;
        }

        public void Save(User user)
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
    }
}
