using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
    public class Competition
    {
        int ID;
        DateTime InitialClosure;
        DateTime FinalClosure;
        string name;

        public int ID1
        {
            get
            {
                return ID;
            }
        }

        public DateTime InitialClosure1
        {
            get
            {
                return InitialClosure;
            }

            set
            {
                InitialClosure = value;
            }
        }

        public DateTime FinalClosure1
        {
            get
            {
                return FinalClosure;
            }

            set
            {
                FinalClosure = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Competition() { }

        public Competition(DateTime initialClose, DateTime finalClose, string name)
        {
            this.InitialClosure = initialClose;
            this.FinalClosure = finalClose;
            this.Name = name;
        }

        public Competition(int id, DateTime initialClose, DateTime finalClose, string name)
        {
            this.ID = id;
            this.InitialClosure = initialClose;
            this.FinalClosure = finalClose;
            this.Name = name;
        }
    }
}