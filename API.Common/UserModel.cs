using System;
using System.Collections.Generic;
using System.Text;

namespace API.Common
{
   public  class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Token { get; set; }
        public string Passwd { get; set; }
    }
}
