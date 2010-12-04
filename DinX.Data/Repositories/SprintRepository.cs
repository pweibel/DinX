using System;
using System.Collections.Generic;

using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Data.Helper;
using NHibernate;
using NHibernate.Criterion;

namespace DinX.Data.Repositories
{
	public class SprintRepository : ISprintRepository
	{
		public Sprint GetCurrentSprint(Project project)
		{
			IList<Sprint> sprints;

			ISession session = PersistenceManager.CurrentSession;
			using(ITransaction trans = session.BeginTransaction())
			{
				ICriteria criteria = session.CreateCriteria(typeof(Sprint))
							.Add(Restrictions.Eq("Project", project))
							.Add(Restrictions.Le("Start", DateTime.Now))
							.Add(Restrictions.Ge("End", DateTime.Now));
				sprints = criteria.List<Sprint>();

				trans.Commit();
			}

			Sprint sprint = sprints.Count > 0 ? sprints[0] : null;

			return sprint;
		}
	}
}
