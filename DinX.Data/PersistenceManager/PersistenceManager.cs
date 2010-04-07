using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace DinX.Data.PersistenceManager
{
    public class PersistenceManager
    {
        private static ISessionFactory factory;
        
        public static ISession OpenSession()
        {
            if (factory == null)
            {
                Configuration config = CreateConfiguration();
                factory = config.BuildSessionFactory();
            }

            return factory.OpenSession();
        }

        public static Configuration CreateConfiguration()
        {
            Configuration config = new Configuration();
            config.Configure();

            // XML-Files
            config.AddAssembly(Assembly.GetExecutingAssembly());

            return config;
        }
    }
}
