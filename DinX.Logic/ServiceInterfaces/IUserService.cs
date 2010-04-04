using DinX.Common.Domain;

namespace DinX.Logic.ServiceInterfaces
{
    public interface IUserService
    {
        bool ValidateUser(string userName, string password);
        User CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
