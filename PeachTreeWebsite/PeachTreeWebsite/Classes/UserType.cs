using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
    public class UserType
    {
        int UserTypeID;
        string UserTypeName;

        public UserType(int id, string name)
        {
            this.UserTypeID1 = id;
            this.UserTypeName1 = name;
        }

        public int UserTypeID1
        {
            get
            {
                return UserTypeID;
            }

            set
            {
                UserTypeID = value;
            }
        }

        public string UserTypeName1
        {
            get
            {
                return UserTypeName;
            }

            set
            {
                UserTypeName = value;
            }
        }
    }
}