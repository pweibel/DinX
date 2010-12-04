using DinX.Common.Domain;
using DinX.Data.Helper;
using DinX.Data.Repositories;
using NHibernate;
using NHibernate.Context;
using NUnit.Framework;

namespace DinX.Tests.Data
{
	[TestFixture]
	public class ProjectRepositoryTest
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
		public void TestCreate()
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
			repository.SaveOrUpdate(p);

			// Assert
			Project p2 = repository.GetProject(p.Id);
			p2 = repository.LoadProductBacklog(p2);
			Assert.IsNotNull(p2);
			Assert.AreEqual(p.Name, p2.Name);
			Assert.AreEqual(p2.Owner.Username, u.Username);
			Assert.AreEqual(1, p2.Members.Count);
			Assert.AreEqual(3, p2.ProductBacklog.Count);
		}
		
		[Test]
		public void TestRead()
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
			repository.SaveOrUpdate(p);

			// Act
			Project proj = repository.GetProject(p.Id);

			// Assert
			Assert.IsNotNull(proj);
			Assert.AreEqual(u.Username, proj.Owner.Username);
			Assert.AreEqual(1, proj.Members.Count);
		}
		#endregion
	}
}
