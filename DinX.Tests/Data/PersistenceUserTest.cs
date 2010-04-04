using System.Collections.Generic;
using DinX.Common.Domain;
using DinX.Data.PersistenceManager;
using DinX.Data.Repositories;
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
            UserRepository repository = new UserRepository();
            User user = repository.GetUserByName(u.Username);
            Assert.IsNotNull(user);
        }
    }
}
