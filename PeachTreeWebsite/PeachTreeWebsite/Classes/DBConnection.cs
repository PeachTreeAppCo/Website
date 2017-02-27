using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PeachTreeWebsite.Classes;

namespace PeachTreeWebsite
{
    public class DBConnection
    {
        public static SiteUser login(string email, string pwd)
        {
            SiteUser u = null;
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "SELECT * FROM PTA_User WHERE Email = @paramEmail AND Pword = @paramPassword";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramEmail", email);
            cmd.Parameters.AddWithValue("@paramPassword", pwd);
            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int UserID = int.Parse(myReader["PTA_ID_User"].ToString());
                    string GivenName = myReader["GivenName"].ToString();
                    string Surname = myReader["Surname"].ToString();
                    string UserType = myReader["UserType"].ToString();
                    string Email = myReader["Email"].ToString();
                    string Password = myReader["Pword"].ToString();
                    string MobileNumber = myReader["MobileNumber"].ToString();
                    int GenderID = int.Parse(myReader["PTA_ID_GenderLookup"].ToString());
                    int FacultyID = int.Parse(myReader["PTA_ID_Faculty"].ToString());
                    u = new SiteUser(UserID, GivenName, Surname, UserType, Email, Password, MobileNumber, GenderID, FacultyID);                    
                }                
                return u;
            }
            catch (Exception e)
            {                
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static FacultyUser facultyLogin (string facultyName, string facultyPwd)
        {
            FacultyUser f = new FacultyUser();
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "SELECT * FROM PTA_Faculty WHERE FacultyName = @paramFName AND FacultyPword = @paramFPwd";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramFName", facultyName);
            cmd.Parameters.AddWithValue("@paramFPwd", facultyPwd);
            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int facultyID = int.Parse(myReader["PTA_ID_Faculty"].ToString());
                    f = new FacultyUser(facultyID, facultyName);                    
                }
                return f;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<string> getFaculties()
        {
            List<string> faculties = new List<string>();
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "SELECT FacultyName FROM PTA_Faculty";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    string faculty = myReader["FacultyName"].ToString();
                    faculties.Add(faculty);
                }
                return faculties;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<UserType> getUserTypes()
        {
            List<UserType> userTypes = new List<UserType>();
            UserType a = new UserType(1, "Student");
            UserType b = new UserType(1, "Marketing Coordinator");
            UserType c = new UserType(1, "Marketing Manager");
            userTypes.Add(a);
            userTypes.Add(b);
            userTypes.Add(c);
            return userTypes;
        }

        public static List<SiteUser> getUsersByType(string UserType)
        {
            List<SiteUser> users = new List<SiteUser>();
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "SELECT * FROM Users WHERE UserType = @paramUserType";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramUserType", UserType);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int UserID = int.Parse(myReader["PTA_ID_User"].ToString());
                    string GivenName = myReader["GivenName "].ToString();
                    string Surname = myReader["Surname"].ToString();
                    string Email = myReader["Email"].ToString();
                    string Password = myReader["Pword"].ToString();
                    string MobileNumber = myReader["MobileNumber"].ToString();
                    int GenderID = int.Parse(myReader["PTA_ID_GenderLookup"].ToString());
                    int FacultyID = int.Parse(myReader["PTA_ID_Faculty"].ToString());
                    SiteUser s = new SiteUser(UserID, GivenName, Surname, UserType, Email, Password, MobileNumber, GenderID, FacultyID);
                    users.Add(s);
                }
                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void AddFailedLogin(string email, string pwd)
        {
            LoginAttempt u = new LoginAttempt(email, pwd);
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string queryStr = "INSERT INTO PTA_LoginAttempt (EmailEntered, PwordEntered) VALUES (@paramEmail, @paramPassword)";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramEmail", email);
            cmd.Parameters.AddWithValue("@paramPassword", pwd);
            try
            {
                myConnection.Open();
                cmd.ExecuteNonQuery();                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static bool UploadFile(string title, string filename, string contenttype, byte[] bytes, int userID, int compID)
        {
            // insert the contribution into database with file
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "INSERT INTO PTA_Contribution(Title, FileTitle, FileContentType, Cont_File, Cont_Status, PTA_ID_User, PTA_ID_Competition) "
                + "values (@paramTitle, @paramFileName, @paramContentType, @paramBytes, 'Submitted', @paramUserID, @paramCompID)";
            SqlCommand cmd = new SqlCommand(strQuery, myConnection);
            cmd.Parameters.AddWithValue("@paramTitle", title);
			cmd.Parameters.AddWithValue("@paramFileName", filename);
			cmd.Parameters.AddWithValue("@paramContentType", contenttype);
			cmd.Parameters.AddWithValue("@paramBytes", bytes);
            cmd.Parameters.AddWithValue("@paramUserID", userID);
            cmd.Parameters.AddWithValue("@paramCompID", compID);

            try
            {
                myConnection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static bool UploadFileWithImg(string title, string filename, string contenttype, byte[] fileBytes, string imgName, byte[] imgBytes, int userID, int compID)
        {
            // insert the contribution into database with file & image
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "INSERT INTO PTA_Contribution(Title, FileTitle, FileContentType, Cont_File, ImageTitle, Cont_Image, Cont_Status, PTA_ID_User, PTA_ID_Competition) "
				+ "values (@paramTitle, @paramFileName, @paramContentType, @paramFileBytes, @paramImgName, @paramImgBytes, 'Submitted', @paramUserID, @paramCompID)";
            SqlCommand cmd = new SqlCommand(strQuery, myConnection);
            cmd.Parameters.AddWithValue("@paramTitle", title);
			cmd.Parameters.AddWithValue("@paramFileName", filename);
			cmd.Parameters.AddWithValue("@paramContentType", contenttype);
			cmd.Parameters.AddWithValue("@paramFileBytes", fileBytes);
			cmd.Parameters.AddWithValue("@paramImgName", imgName);
			cmd.Parameters.AddWithValue("@paramImgBytes", imgBytes);
            cmd.Parameters.AddWithValue("@paramUserID", userID);
            cmd.Parameters.AddWithValue("@paramCompID", compID);

            try
            {
                myConnection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<Competition> getCompetitons()
        {
            List<Competition> comps = new List<Competition>();
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "SELECT * FROM PTA_Competition";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    Competition c = new Competition();
                    int ID = int.Parse(myReader["PTA_ID_Competition"].ToString());
                    DateTime initClose;
                    DateTime.TryParse(myReader["InitialClosureDate"].ToString(), out initClose);
                    DateTime finalClose;
                    DateTime.TryParse(myReader["FinalClosureDate"].ToString(), out finalClose);
                    string name = myReader["CompetitionName"].ToString();
                    c = new Competition(ID, initClose, finalClose, name);
                    comps.Add(c);
                }
                return comps;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

		public static List<Contribution> getContributionsForUser(int userID)
		{
			List<Contribution> contributions = new List<Contribution>();
			SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
			SqlDataReader myReader = null;
			string queryStr = "SELECT * FROM PTA_Contribution WHERE PTA_ID_User = @paramUserID";
			SqlCommand cmd = new SqlCommand(queryStr, myConnection);
			cmd.Parameters.AddWithValue("@paramUserID", userID);

			try
			{
				myConnection.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					int contID = int.Parse(myReader["PTA_ID_Contribution"].ToString());
					string title = myReader["Title"].ToString();
					string imgTitle = null;
					byte[] imgBytes = null;
					if (myReader["ImageTitle"] != DBNull.Value && myReader["Cont_Image"] != DBNull.Value)
					{
						imgTitle = myReader["ImageTitle"].ToString();
						imgBytes = (byte[])myReader["Cont_Image"];
					}
					string docTitle = myReader["FileTitle"].ToString();
					string docContentType = myReader["FileContentType"].ToString();
					byte[] docBytes = (byte[])myReader["Cont_File"];
					string status = myReader["Cont_Status"].ToString();
					string feedback = myReader["Feedback"].ToString();
					int compID = int.Parse(myReader["PTA_ID_Competition"].ToString());
					Contribution c = new Contribution(contID,title,imgTitle,imgBytes,docTitle,docContentType,docBytes,status,feedback,userID,compID);
					contributions.Add(c);
				}
				return contributions;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				return null;
			}
			finally
			{
				myConnection.Close();
			}
		}
	}
}