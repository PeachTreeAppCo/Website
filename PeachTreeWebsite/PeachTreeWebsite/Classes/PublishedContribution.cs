using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
    public class PublishedContribution
    {
        string title;
        string imgTitle;
        Byte[] imgBytes;
        string docTitle;
        string docContentType;
        Byte[] docBytes;
        string fName;
        string sName;
        string facultyName;
        string competitionName;

        public PublishedContribution() { }
        public PublishedContribution(string atitle, string aimgTitle, Byte[] aimgBytes, string adocTitle, string adocContentType, Byte[] adocBytes, string afName, string asName, string afacultyName, string compName)
        {
            this.Title = atitle;
            this.ImgTitle = aimgTitle;
            this.ImgBytes = aimgBytes;
            this.DocTitle = adocTitle;
            this.DocContentType = adocContentType;
            this.DocBytes = adocBytes;
            this.FName = afName;
            this.SName = asName;
            this.FacultyName = afacultyName;
            this.CompetitionName = compName;
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string ImgTitle
        {
            get
            {
                return imgTitle;
            }

            set
            {
                imgTitle = value;
            }
        }

        public byte[] ImgBytes
        {
            get
            {
                return imgBytes;
            }

            set
            {
                imgBytes = value;
            }
        }

        public string DocTitle
        {
            get
            {
                return docTitle;
            }

            set
            {
                docTitle = value;
            }
        }

        public string DocContentType
        {
            get
            {
                return docContentType;
            }

            set
            {
                docContentType = value;
            }
        }

        public byte[] DocBytes
        {
            get
            {
                return docBytes;
            }

            set
            {
                docBytes = value;
            }
        }

        public string FName
        {
            get
            {
                return fName;
            }

            set
            {
                fName = value;
            }
        }

        public string SName
        {
            get
            {
                return sName;
            }

            set
            {
                sName = value;
            }
        }

        public string FacultyName
        {
            get
            {
                return facultyName;
            }

            set
            {
                facultyName = value;
            }
        }

        public string CompetitionName
        {
            get
            {
                return competitionName;
            }

            set
            {
                competitionName = value;
            }
        }
    }
}