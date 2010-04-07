using System;
using System.Collections.Generic;

using DinX.Common.Domain;
using DinX.Common.Repositories;

using NHibernate;
using NHibernate.Criterion;

namespace DinX.Data.Repositories
{
	public class SprintRepository : ISprintRepository
	{
		public Sprint GetCurrentSprint(Project project)
		{
			Sprint sprint;
			using(ISession session = PersistenceManager.PersistenceManager.OpenSession())
			{
				ICriteria criteria = session.CreateCriteria(typeof(Sprint))
							.Add(Restrictions.Eq("Project", project))
							.Add(Restrictions.Le("Start", DateTime.Now))
							.Add(Restrictions.Ge("End", DateTime.Now));

				IList<Sprint> sprints = criteria.List<Sprint>();
				sprint = sprints.Count > 0 ? sprints[0] : null;
			}

			return sprint;
		}
	}
}
