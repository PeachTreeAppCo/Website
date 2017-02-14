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
        private int UserType;
        private string Email;
        private string Password;
        private string MobileNumber;
        private int StudyYear;

        public SiteUser() { }

        public SiteUser(int id, string fname, string sname, int type, string email, string pwd, string mobnum, int year)
        {
            this.UserID1 = id;
            this.GivenName1 = fname;
            this.Surname1 = sname;
            this.UserType1 = type;
            this.Email1 = email;
            this.Password1 = pwd;
            this.MobileNumber1 = mobnum;
            this.StudyYear1 = year;
        }

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

        public string GivenName1
        {
            get
            {
                return GivenName;
            }

            set
            {
                GivenName = value;
            }
        }

        public string Surname1
        {
            get
            {
                return Surname;
            }

            set
            {
                Surname = value;
            }
        }

        public int UserType1
        {
            get
            {
                return UserType;
            }

            set
            {
                UserType = value;
            }
        }

        public string Email1
        {
            get
            {
                return Email;
            }

            set
            {
                Email = value;
            }
        }

        public string Password1
        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }

        public string MobileNumber1
        {
            get
            {
                return MobileNumber;
            }

            set
            {
                MobileNumber = value;
            }
        }

        public int StudyYear1
        {
            get
            {
                return StudyYear;
            }

            set
            {
                StudyYear = value;
            }
        }
    }
}