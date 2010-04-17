using System;
using System.Linq;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace DinX.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void SaveOrUpdate(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            using(ISession session = PersistenceManager.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(user);
                    transaction.Commit();
                }
            }
        }

        public void Delete(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            using(ISession session = PersistenceManager.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

        public User GetByUsername(string strUsername)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");

            User user;
            using(ISession session = PersistenceManager.OpenSession())
            {
                /*
                ICriteria criteria = session.CreateCriteria(typeof(User))
                            .SaveOrUpdate(Restrictions.Eq("Username", strUsername));

                IList<User> users = criteria.List<User>();
                if(users.Count == 1) user = users[0];
                */
                var query = from u in session.Linq<User>()
                            where u.Username == strUsername
                            select u;
                
                user = query.Count() > 0 ? query.First() : null;
            }

            return user;
        }
    }
}
