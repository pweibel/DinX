using DinX.Data.Repositories;
using DinX.Common.Domain;
using NUnit.Framework;

namespace DinX.Tests.Data
{
    [TestFixture]
    public class ProjectRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            // Arrange
            ProjectRepository repository = new ProjectRepository();
            Project p = new Project();
            p.Name = "Testprojekt für Unit-Test";
            User u = new User();
            u.Firstname = "Hans";
            u.Lastname = "Muster";
            u.Username = "hmuster";
            u.EMail = "hans.muster@firma.ch";
            u.Password = "1234";
            p.Owner = u;
            p.Members.Add(u);
            Task t1 = new Task();
            t1.Title = "Task 1";
            t1.Project = p;
            Task t2 = new Task();
            t2.Title = "Task 2";
            t2.Project = p;
            Task t3 = new Task();
            t3.Title = "Task 3";
            t3.Project = p;
            p.ProductBacklog.Add(t1);
            p.ProductBacklog.Add(t2);
            p.ProductBacklog.Add(t3);
            
            // Act
            repository.Add(p);

            // Assert
            Project p2 = repository.GetProject(p.Id);
            p2 = repository.LoadProductBacklog(p2);
            Assert.IsNotNull(p2);
            Assert.AreEqual(p.Name, p2.Name);
            Assert.AreEqual(p2.Owner.Username, u.Username);
            Assert.AreEqual(1, p2.Members.Count);
            Assert.AreEqual(3, p2.ProductBacklog.Count);
        }
    }
}
