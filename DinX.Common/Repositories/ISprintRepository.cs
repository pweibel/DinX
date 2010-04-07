using DinX.Common.Domain;

namespace DinX.Common.Repositories
{
	public interface ISprintRepository
	{
		Sprint GetCurrentSprint(Project project);
	}
}
