﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
    public class MarketingManager : SiteUser
    {
        public MarketingManager(int id, string fname, string sname, string type, string email, string pwd, string mobnum, int genderID, int facultyID, DateTime lastLogin) 
            :base(id, fname, sname, type, email, pwd, mobnum, genderID, facultyID, lastLogin)
        {

        }
    }
}