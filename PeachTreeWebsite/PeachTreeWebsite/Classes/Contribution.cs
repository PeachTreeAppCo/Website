using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite.Classes
{
	public class Contribution
	{
		int contributionID;
		string title;
		string imgTitle;
		byte[] imgBytes;
		string docTitle;
		string docContentType;
		byte[] docBytes;
		string status;
		string feedback;
		int userID;
		int competitionID;

		public Contribution() { }

		public Contribution(string myTitle, string imgtitle, byte[] img, string doctitle, string doccontent, byte[] doc, string state, string fdbk, int uID, int compID)
		{
			this.title = myTitle;
			this.imgTitle = imgtitle;
			this.imgBytes = img;
			this.docTitle = doctitle;
			this.DocContentType = doccontent;
			this.docBytes = doc;
			this.status = state;
			this.feedback = fdbk;
			this.userID = uID;
			this.competitionID = compID;
		}

		public Contribution(int ID, string myTitle, string imgtitle, byte[] img, string doctitle, string doccontent, byte[] doc, string state, string fdbk, int uID, int compID)
		{
			this.contributionID = ID;
			this.title = myTitle;
			this.imgTitle = imgtitle;
			this.imgBytes = img;
			this.docTitle = doctitle;
			this.DocContentType = doccontent;
			this.docBytes = doc;
			this.status = state;
			this.feedback = fdbk;
			this.userID = uID;
			this.competitionID = compID;
		}

		public int ContributionID
		{
			get
			{
				return contributionID;
			}

			set
			{
				contributionID = value;
			}
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

		public string Status
		{
			get
			{
				return status;
			}

			set
			{
				status = value;
			}
		}

		public string Feedback
		{
			get
			{
				return feedback;
			}

			set
			{
				feedback = value;
			}
		}

		public int UserID
		{
			get
			{
				return userID;
			}

			set
			{
				userID = value;
			}
		}

		public int CompetitionID
		{
			get
			{
				return competitionID;
			}

			set
			{
				competitionID = value;
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
	}
}