using API.Common;
using IRepository;
using SampleInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEntity
{
    public class LoginEntity : ILoginEntity
    {
        private readonly ILoginRepo _loginRepo;
        public LoginEntity(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;   
        }
        public UserModel AuthenticateUser(UserModel login)
        {
            Cipher cp = new Cipher();
            string encPassword = cp.EncryptPasswd(login.Passwd);
            login.Passwd = encPassword;
            //int result = CheckUserActive(login, connectionString);
            //if (result == 1)
            //{
                return _loginRepo.AuthenticateUser(login);
            //}
            //else
            //{ return null; }
            //_loginRepo.AuthenticateUser(login, connectionString);
            //return user;
        }

        public bool TestLogin(string userName,int password) {
            if (userName == "Test" && password >0)
            {
                return true;

            }
            else {
                return false;
            }
        
        }

    }
}
