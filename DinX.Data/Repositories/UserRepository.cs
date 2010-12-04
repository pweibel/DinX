using System;
using System.Linq;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Helper;
using NHibernate.Linq;

namespace DinX.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void SaveOrUpdate(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            PersistenceManager.CurrentSession.SaveOrUpdate(user);
        }

        public void Delete(User user)
        {
            if(user == null) throw new ArgumentNullException("user");

            PersistenceManager.CurrentSession.Delete(user);
        }

        public User GetByUsername(string strUsername)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");

            /*
            ICriteria criteria = session.CreateCriteria(typeof(User))
                        .SaveOrUpdate(Restrictions.Eq("Username", strUsername));

            IList<User> users = criteria.List<User>();
            if(users.Count == 1) user = users[0];
            */
            var query = from u in PersistenceManager.CurrentSession.Linq<User>()
                        where u.Username == strUsername
                        select u;
                
            User user = query.Count() > 0 ? query.First() : null;

            return user;
        }
    }
}
