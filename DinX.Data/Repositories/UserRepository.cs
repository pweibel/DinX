using System;
using System.Linq;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Helper;
using NHibernate;
using NHibernate.Linq;

namespace DinX.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void SaveOrUpdate(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                session.SaveOrUpdate(user);
                trans.Commit();
            }
        }

        public void Delete(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                session.Delete(user);
                trans.Commit();
            }
        }

        public User GetByUsername(string strUsername)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");

            User user;

            ISession session = PersistenceManager.CurrentSession;
            using(ITransaction trans = session.BeginTransaction())
            {
                var query = from u in PersistenceManager.CurrentSession.Linq<User>()
                            where u.Username == strUsername
                            select u;

                user = query.Count() > 0 ? query.First() : null;
                trans.Commit();
            }

            return user;
        }
    }
}
