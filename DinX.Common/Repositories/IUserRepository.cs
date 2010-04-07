using DinX.Common.Domain;

namespace DinX.Common.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        User GetByUsername(string strUsername);
    }
}
