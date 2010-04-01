using System.Collections.Generic;
using DinX.Data.PersistenceManager;
using DinX.Logic.Domain;
using NHibernate;
using NUnit.Framework;

namespace DinX.Tests.Data
{
    [TestFixture]
    public class PersistenceUserTest
    {
        [Test]
        public void TestPersistUser()
        {
            //Arrange
            User u = new User();
            u.Username = "test";
            u.Password = "Test123";
            u.Firstname = "Hans";
            u.Lastname = "Muster";
            u.EMail = "hans.muster@test.ch";

            //Act
            using(ISession session = PersistenceManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(u);
                    transaction.Commit();
                }
            }

            //Assert
            using(ISession session = PersistenceManager.OpenSession())
            {
                IQuery query = session.CreateQuery("FROM User");
                IList<User> users = query.List<User>();
                Assert.AreEqual(1, users.Count);
            }
        }
    }
}
