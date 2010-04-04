using System;
using System.Security.Cryptography;
using System.Text;
using DinX.Common.Domain;
using DinX.Data.Repositories;
using DinX.Logic.ServiceInterfaces;

namespace DinX.Logic.Services
{
    public class UserService : IUserService
    {
        public static readonly int MinRequiredPasswordLength = 6;
        
        public bool ValidateUser(string strUsername, string strPassword)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");
            if(string.IsNullOrEmpty(strPassword)) throw new ArgumentNullException("strPassword");

            UserRepository repository = new UserRepository();
            User user = repository.GetUserByName(strUsername);
            
            if(user == null) return false;

            return IsPasswordValid(user, strPassword);
        }

        public User CreateUser(string strUsername, string strPassword, string strEMail)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");
            if(string.IsNullOrEmpty(strPassword)) throw new ArgumentNullException("strPassword");

            UserRepository repository = new UserRepository();
            User user = repository.GetUserByName(strUsername);

            if(user != null) throw new Exception("Username ist bereits vergeben.");

            user = new User();
            user.Username = strUsername;
            user.Password = EncodePassword(strPassword);
            if(!string.IsNullOrEmpty(strEMail)) user.EMail = strEMail;

            repository.Save(user);

            return user;
        }

        public bool ChangePassword(string strUsername, string strOldPassword, string strNewPassword)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");
            if(string.IsNullOrEmpty(strOldPassword)) throw new ArgumentNullException("strOldPassword");
            if(string.IsNullOrEmpty(strNewPassword)) throw new ArgumentNullException("strNewPassword");

            UserRepository repository = new UserRepository();
            User user = repository.GetUserByName(strUsername);

            if(user == null) throw new Exception(string.Format("User mit Username {0} nicht gefunden.", strUsername));

            if(!IsPasswordValid(user, strOldPassword)) throw new Exception("Altes Passwort stimmt nicht überein.");

            user.Password = EncodePassword(strNewPassword);

            repository.Save(user);

            return true;
        }

        private bool IsPasswordValid(User user, string strPassword)
        {
            if(string.IsNullOrEmpty(strPassword)) throw new ArgumentNullException("strPassword");

            return user.Password == EncodePassword(strPassword);
        }

        private string EncodePassword(string strPassword)
        {
            if(string.IsNullOrEmpty(strPassword)) throw new ArgumentNullException("strPassword");

            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(provider.ComputeHash(Encoding.Unicode.GetBytes(strPassword)));
        }
    }
}
