using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
    public class LoginAttempt
    {
        private string emailEntered;
        private string pwdEntered;

        public LoginAttempt(string email, string pwd)
        {
            this.emailEntered = email;
            this.pwdEntered = pwd;
        }
    }
}