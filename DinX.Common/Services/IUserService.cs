﻿using DinX.Common.Domain;

namespace DinX.Common.Services
{
    public interface IUserService
    {
    	User GetByUsername(string userName);
		bool ValidateUser(string userName, string password);
        User CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
