using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using NHibernate.Search.Event;

namespace DinX.Data.Helper
{
    public class PersistenceManager
    {
        #region Fields
        private static ISessionFactory _factory;
        #endregion

        #region Properties
        public static ISessionFactory Factory
        {
            get
            {
                if(_factory == null)
                {
                    Configuration config = CreateConfiguration();
                    _factory = config.BuildSessionFactory();
                }

                return _factory;
            }
        }

        public static ISession CurrentSession
        {
            get { return Factory.GetCurrentSession(); }
        }
        #endregion

        #region Publics
        public static ISession OpenSession()
        {
            return Factory.OpenSession();
        }

        public static Configuration CreateConfiguration()
        {
            // XML-Files
            Configuration config = new Configuration();
            config.AddAssembly(Assembly.GetExecutingAssembly());

            // Event-Listener
            config.SetListeners(ListenerType.PostInsert, new[] { new FullTextIndexEventListener() });
            config.SetListeners(ListenerType.PostUpdate, new[] { new FullTextIndexEventListener() });
            config.SetListeners(ListenerType.PostDelete, new[] { new FullTextIndexEventListener() });
            config.SetListener(ListenerType.PostCollectionRecreate, new FullTextIndexCollectionEventListener());
            config.SetListener(ListenerType.PostCollectionRemove, new FullTextIndexCollectionEventListener());
            config.SetListener(ListenerType.PostCollectionUpdate, new FullTextIndexCollectionEventListener());

            return config;
        }
        #endregion
    }
}
