using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Repositories;
using NUnit.Framework;

namespace DinX.Tests.Data
{
    [TestFixture]
    public class UserRepositoryTest
    {
        [Test]
        public void TestAdd()
        {
            //Arrange
            User u = new User();
            u.Username = "test";
            u.Password = "Test123";
            u.Firstname = "Hans";
            u.Lastname = "Muster";
            u.EMail = "hans.muster@test.ch";

            //Act
            IUserRepository repository = new UserRepository();
            repository.Add(u);

            //Assert
            User user = repository.GetByUsername(u.Username);
            Assert.IsNotNull(user);
            Assert.AreEqual(u.Username, user.Username);
            Assert.AreEqual(u.Firstname, user.Firstname);
            Assert.AreEqual(u.Lastname, user.Lastname);
            Assert.AreEqual(u.EMail, user.EMail);
        }
    }
}
