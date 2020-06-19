using API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository
{
    public interface ILoginRepo
    {
        UserModel AuthenticateUser(UserModel login);
    }
}
