using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Helper;
using DinX.Data.Repositories;
using NHibernate;
using NHibernate.Context;
using NUnit.Framework;

namespace DinX.Tests.Data
{
    [TestFixture]
    public class UserRepositoryTest
    {
        #region SetUp and TearDown
        [SetUp]
        public void SetUp()
        {
            ISession session = PersistenceManager.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        [TearDown]
        public void TearDown()
        {
            ISession session = CurrentSessionContext.Unbind(PersistenceManager.Factory);
            session.Close();
        }
        #endregion

        #region Tests
        [Test]
        public void TestAdd()
        {
            // Arrange
            IUserRepository repository = new UserRepository();
            User u = new User
                         {
                             Username = "test",
                             Password = "Test123",
                             Firstname = "Hans",
                             Lastname = "Muster",
                             EMail = "hans.muster@test.ch"
                         };

            // Act
            repository.SaveOrUpdate(u);

            // Assert
            User user = repository.GetByUsername(u.Username);
            Assert.IsNotNull(user);
            Assert.AreEqual(u.Username, user.Username);
            Assert.AreEqual(u.Firstname, user.Firstname);
            Assert.AreEqual(u.Lastname, user.Lastname);
            Assert.AreEqual(u.EMail, user.EMail);
        }
        #endregion
    }
}
