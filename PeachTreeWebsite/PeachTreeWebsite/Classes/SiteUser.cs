using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite
{
    public class SiteUser
    {
        private int UserID;
        private string GivenName;
        private string Surname;
        private string UserType;
        private string Email;
        private string Password;
        private string MobileNumber;
        private int StudyYear;

        public SiteUser() { }

        public SiteUser(int id, string fname, string sname, string type, string email, string pwd, string mobnum, int year)
        {
            this.UserID = id;
            this.GivenName = fname;
            this.Surname = sname;
            this.UserType = type;
            this.Email = email;
            this.Password = pwd;
            this.MobileNumber = mobnum;
            this.StudyYear = year;
        }

        public int UserID1
        {
            get
            {
                return UserID;
            }
        }

        public string GivenName1
        {
            get
            {
                return GivenName;
            }
        }

        public string Surname1
        {
            get
            {
                return Surname;
            }
        }

        public string UserType1
        {
            get
            {
                return UserType;
            }
        }

        public string Email1
        {
            get
            {
                return Email;
            }
        }

        public string Password1
        {
            get
            {
                return Password;
            }
        }

        public string MobileNumber1
        {
            get
            {
                return MobileNumber;
            }
        }

        public int StudyYear1
        {
            get
            {
                return StudyYear;
            }
        }
    }
}