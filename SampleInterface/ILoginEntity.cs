using API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleInterface
{
    public interface ILoginEntity
    {
        UserModel AuthenticateUser(UserModel login);
        bool TestLogin(string userName, int password);
    }
}
