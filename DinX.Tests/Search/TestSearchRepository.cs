using System.Collections;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Repositories;
using NUnit.Framework;

namespace DinX.Tests.Search
{
    [TestFixture]
    public class TestSearchRepository
    {
        [Test]
        public void TestSimpleTaskSearch()
        {
            //Arrange
            ISearchRepository repository = new SearchRepository();
            User u = new User();
            u.Username = "Test";
            u.Password = "123";
            Project p = new Project();
            p.Name = "Testprojekt";
            p.Owner = u;
            Task t1 = new Task();
            t1.Title = "Schreiben des Rhbs";
            t1.Project = p;
            Task t2 = new Task();
            t2.Title = "Dialog implementieren";
            t2.Project = p;
            Task t3 = new Task();
            t3.Title = "Schreiben von Unit test";
            t3.Project = p;
            p.ProductBacklog.Add(t1);
            p.ProductBacklog.Add(t2);
            p.ProductBacklog.Add(t3);
            IProjectRepository projectRepository = new ProjectRepository();
            projectRepository.SaveOrUpdate(p);

            //Act
            IList result = repository.Search("Title:Schreiben*");
            
            //Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
