using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite
{
    public class User
    {
        int UserID;
        string UserName;
        int AccessLevel;

        public User (int id, string uname, int accesslvl)
        {
            this.UserID1 = id;
            this.UserName1 = uname;
            this.AccessLevel1 = accesslvl;
        }

        public User () { }

        public int UserID1
        {
            get
            {
                return UserID;
            }

            set
            {
                UserID = value;
            }
        }

        public string UserName1
        {
            get
            {
                return UserName;
            }

            set
            {
                UserName = value;
            }
        }

        public int AccessLevel1
        {
            get
            {
                return AccessLevel;
            }

            set
            {
                AccessLevel = value;
            }
        }
    }
}