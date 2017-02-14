using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
    public class FacultyUser
    {
        int FacultyID;
        string FacultyName;

        public FacultyUser() { }

        public FacultyUser(int id, string name)
        {
            this.FacultyID = id;
            this.FacultyName = name;
        }

        public int FacultyID1
        {
            get
            {
                return FacultyID;
            }

            set
            {
                FacultyID = value;
            }
        }

        public string FacultyName1
        {
            get
            {
                return FacultyName;
            }

            set
            {
                FacultyName = value;
            }
        }
    }
}