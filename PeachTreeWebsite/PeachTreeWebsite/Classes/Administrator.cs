﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
    public class Administrator : SiteUser
    {
        public Administrator(int id, string fname, string sname, int type, string email, string pwd, string mobnum, int year) 
            :base(id, fname, sname, type, email, pwd, mobnum, year)
        {

        }    
    }
}