using System;
using System.Security.Cryptography;
using System.Text;
using DinX.Common.Domain;
using DinX.Common.Repositories;
using DinX.Common.Services;
using DinX.Data.Repositories;

namespace DinX.Logic.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private IUserRepository _userRepository;
        #endregion

        #region Statics
        public static readonly int MinRequiredPasswordLength = 6;
        #endregion

        #region Properties
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository());
            }
            set
            {
                _userRepository = value;
            }
        }
        #endregion

		public User GetByUsername(string strUsername)
    	{
			if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");

			return this.UserRepository.GetByUsername(strUsername);
		}

    	public bool ValidateUser(string strUsername, string strPassword)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");
            if(string.IsNullOrEmpty(strPassword)) throw new ArgumentNullException("strPassword");

            User user = this.UserRepository.GetByUsername(strUsername);
            
            if(user == null) return false;

            return IsPasswordValid(user, strPassword);
        }

        public User CreateUser(string strUsername, string strPassword, string strEMail)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");
            if(string.IsNullOrEmpty(strPassword)) throw new ArgumentNullException("strPassword");

            User user = this.UserRepository.GetByUsername(strUsername);

            if(user != null) throw new Exception("Username ist bereits vergeben.");

            user = new User
                       {
                           Username = strUsername, 
                           Password = this.EncodePassword(strPassword)
                       };

            if(!string.IsNullOrEmpty(strEMail)) user.EMail = strEMail;

            this.UserRepository.Add(user);

            return user;
        }

        public bool ChangePassword(string strUsername, string strOldPassword, string strNewPassword)
        {
            if(string.IsNullOrEmpty(strUsername)) throw new ArgumentNullException("strUsername");
            if(string.IsNullOrEmpty(strOldPassword)) throw new ArgumentNullException("strOldPassword");
            if(string.IsNullOrEmpty(strNewPassword)) throw new ArgumentNullException("strNewPassword");

            User user = this.UserRepository.GetByUsername(strUsername);

            if(user == null) throw new Exception(string.Format("User mit Username {0} nicht gefunden.", strUsername));

            if(!IsPasswordValid(user, strOldPassword)) throw new Exception("Altes Passwort stimmt nicht überein.");

            user.Password = EncodePassword(strNewPassword);

            this.UserRepository.Update(user);

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
