using DinX.Common.Domain;

namespace DinX.Common.Repositories
{
    public interface IUserRepository
    {
        void SaveOrUpdate(User user);
        void Delete(User user);
        User GetByUsername(string strUsername);
    }
}
