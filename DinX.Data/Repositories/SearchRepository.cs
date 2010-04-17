using System.Collections;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using NHibernate;
using NHibernate.Search;

namespace DinX.Data.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        public IList Search(string strQuery)
        {
            if(string.IsNullOrEmpty(strQuery)) return new ArrayList();

            IList result;

            using(ISession session = PersistenceManager.OpenSession())
            {
                using(IFullTextSession ftSession = NHibernate.Search.Search.CreateFullTextSession(session))
                {
                    result = ftSession.CreateFullTextQuery<Task>(strQuery).List();
                }
            }

            return result;
        }
    }
}
