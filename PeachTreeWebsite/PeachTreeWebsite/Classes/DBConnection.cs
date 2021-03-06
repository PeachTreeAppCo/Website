﻿using System;
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
                    DateTime lastLogin;
                    DateTime.TryParse(myReader["LastLogin"].ToString(), out lastLogin);
                    u = new SiteUser(UserID, GivenName, Surname, UserType, Email, Password, MobileNumber, GenderID, FacultyID, lastLogin);                    
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

        public static bool updateCompetition(Competition c, string title, DateTime initClose, DateTime finalClose)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "UPDATE PTA_Competition SET "
                + "CompetitionName = @paramTitle,"
                + "InitialClosureDate = @paramInitClose, "
                + "FinalClosureDate = @paramFinalClose "
                + "WHERE PTA_ID_Competition = @paramID; ";
            SqlCommand cmd = new SqlCommand(strQuery, myConnection);
            cmd.Parameters.AddWithValue("@paramTitle", title);
            cmd.Parameters.AddWithValue("@paramInitClose", initClose);
            cmd.Parameters.AddWithValue("@paramFinalClose", finalClose);
            cmd.Parameters.AddWithValue("@paramID", c.ID1);

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

        public static int addCompetition(string title, DateTime initClose, DateTime finalClose)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "INSERT INTO PTA_Competition (InitialClosureDate, FinalClosureDate, CompetitionName) VALUES "
                + "(@paramInitClose, @paramFinalClose, @paramTitle);"
                + "SELECT CAST(scope_identity() AS int);";
            SqlCommand cmd = new SqlCommand(strQuery, myConnection);
            cmd.Parameters.AddWithValue("@paramTitle", title);
            cmd.Parameters.AddWithValue("@paramInitClose", initClose);
            cmd.Parameters.AddWithValue("@paramFinalClose", finalClose);

            try
            {
                myConnection.Open();
                int id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
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
                    return f;
                }
                return null;
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
                    DateTime lastLogin;
                    DateTime.TryParse(myReader["LastLogin"].ToString(), out lastLogin);
                    SiteUser s = new SiteUser(UserID, GivenName, Surname, UserType, Email, Password, MobileNumber, GenderID, FacultyID, lastLogin);
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

        public static int UploadFile(string title, string filename, string contenttype, byte[] bytes, int userID, int compID)
        {
            // insert the contribution into database with file
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "INSERT INTO PTA_Contribution(Title, FileTitle, FileContentType, Cont_File, Cont_Status, PTA_ID_User, PTA_ID_Competition) "
                + "values (@paramTitle, @paramFileName, @paramContentType, @paramBytes, 'Submitted', @paramUserID, @paramCompID)"
                + "SELECT CAST(scope_identity() AS int)";
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
                int id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static int UploadFileWithImg(string title, string filename, string contenttype, byte[] fileBytes, string imgName, byte[] imgBytes, int userID, int compID)
        {
            // insert the contribution into database with file & image
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "INSERT INTO PTA_Contribution(Title, FileTitle, FileContentType, Cont_File, ImageTitle, Cont_Image, Cont_Status, PTA_ID_User, PTA_ID_Competition) "
				+ "values (@paramTitle, @paramFileName, @paramContentType, @paramFileBytes, @paramImgName, @paramImgBytes, 'Submitted', @paramUserID, @paramCompID);"
                + " SELECT CAST(scope_identity() AS int);";
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
                int id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
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
            string queryStr = "SELECT * FROM PTA_Competition order by FinalClosureDate DESC";
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
			string queryStr = "SELECT * FROM PTA_Contribution WHERE PTA_ID_User = @paramUserID order by PTA_ID_Contribution DESC";
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

        public static void UpdateLoginTime(int userID)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string queryStr = "UPDATE PTA_User SET LastLogin = GETDATE() WHERE PTA_ID_USER = @paramUserID";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramUserID", userID);

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

        public static bool UpdateContribution(Contribution c, string title, string filename, string contenttype, byte[] bytes)
        {
            // insert the contribution into database with file
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "UPDATE PTA_Contribution SET "
                + "Title = @paramTitle,"
                + "FileTitle = @paramFileName, "
                + "FileContentType = @paramContentType, "
                + "Cont_File = @paramBytes, "
                + "ImageTitle = '', "
                + "Cont_Image = NULL, "
                + "Cont_Status = 'Submitted' "
                + "WHERE PTA_ID_Contribution = @paramContID; ";
            SqlCommand cmd = new SqlCommand(strQuery, myConnection);
            cmd.Parameters.AddWithValue("@paramTitle", title);
            cmd.Parameters.AddWithValue("@paramFileName", filename);
            cmd.Parameters.AddWithValue("@paramContentType", contenttype);
            cmd.Parameters.AddWithValue("@paramBytes", bytes);
            cmd.Parameters.AddWithValue("@paramContID", c.ContributionID);

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

        public static bool UpdateContributionWithImg(Contribution c, string title, string filename, string contenttype, byte[] fileBytes, string imgName, byte[] imgBytes)
        {
            // insert the contribution into database with file & image
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);

            string strQuery = "UPDATE PTA_Contribution SET "
                + "Title = @paramTitle,"
                + "FileTitle = @paramFileName, "
                + "FileContentType = @paramContentType, "
                + "Cont_File = @paramBytes, "
                + "Cont_Status = 'Submitted', "
                + "ImageTitle = @paramImgName, "
                + "Cont_Image = @paramImgBytes "
                + "WHERE PTA_ID_Contribution = @paramContID ";
            SqlCommand cmd = new SqlCommand(strQuery, myConnection);
            cmd.Parameters.AddWithValue("@paramTitle", title);
            cmd.Parameters.AddWithValue("@paramFileName", filename);
            cmd.Parameters.AddWithValue("@paramContentType", contenttype);
            cmd.Parameters.AddWithValue("@paramBytes", fileBytes);            
            cmd.Parameters.AddWithValue("@paramImgName", imgName);
            cmd.Parameters.AddWithValue("@paramImgBytes", imgBytes) ;
            cmd.Parameters.AddWithValue("@paramContID", c.ContributionID);

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

        public static void deleteContribution(Contribution c)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string queryStr = "DELETE FROM PTA_Contribution WHERE PTA_ID_Contribution = @paramContID";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramContID", c.ContributionID);

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

        public static string getMarketingCoordinatorEmail(int contributionID)
        {
            string mmEmail = "";
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "Select mm.Email from PTA_User mm "
                + "inner join PTA_User s on s.PTA_ID_Faculty = mm.PTA_ID_Faculty "
                + "inner join PTA_Contribution c on c.PTA_ID_User = s.PTA_ID_User "
                + "where mm.UserType = 'Marketing Coordinator' and c.PTA_ID_Contribution = @paramContID";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramContID", contributionID);
            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    mmEmail = myReader["Email"].ToString();
                }
                return mmEmail;
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

        public static List<Contribution> getContributionsForFaculty(int marketingCoordinatorID)
        {
            List<Contribution> contributions = new List<Contribution>();
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "SELECT * FROM PTA_Contribution c "
                + "inner join PTA_User u on u.PTA_ID_User = c.PTA_ID_User "
                + "inner join PTA_User mc on u.PTA_ID_Faculty = mc.PTA_ID_Faculty "
                + "where mc.PTA_ID_User = @paramMCID "
                + "order by c.PTA_ID_Competition DESC, c.PTA_ID_Contribution DESC;";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramMCID", marketingCoordinatorID);

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
                    int userID = int.Parse(myReader["PTA_ID_User"].ToString());
                    int compID = int.Parse(myReader["PTA_ID_Competition"].ToString());
                    Contribution c = new Contribution(contID, title, imgTitle, imgBytes, docTitle, docContentType, docBytes, status, feedback, userID, compID);
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

        public static bool UpdateContributionStatus(Contribution c, string status, string feedback)
        {
            // insert the contribution into database with file
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            string strQuery = "UPDATE PTA_Contribution SET "
                + "Cont_Status = @paramStatus, "
                + "feedback = @paramfeedback "
                + "WHERE PTA_ID_Contribution = @paramContID; ";
            SqlCommand cmd = new SqlCommand(strQuery, myConnection);
            cmd.Parameters.AddWithValue("@paramStatus", status);
            cmd.Parameters.AddWithValue("@paramfeedback", feedback);
            cmd.Parameters.AddWithValue("@paramContID", c.ContributionID);

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

        public static List<PublishedContribution> getPublishedContributions()
        {
            List<PublishedContribution> contributions = new List<PublishedContribution>();
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "select c.Title,c.ImageTitle,c.Cont_Image,c.FileTitle,c.FileContentType,c.Cont_File,u.GivenName,u.Surname,f.FacultyName,comp.CompetitionName from PTA_Contribution c "
                + "inner join PTA_User u on u.PTA_ID_User = c.PTA_ID_User "
                + "inner join PTA_Faculty f on u.PTA_ID_Faculty = f.PTA_ID_Faculty "
                + "inner join PTA_Competition comp on comp.PTA_ID_Competition = c.PTA_ID_Competition "
                + "where Cont_Status = 'Published' "
                + "order by c.PTA_ID_Contribution DESC;";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
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
                    string fName = myReader["GivenName"].ToString();
                    string sName = myReader["Surname"].ToString();
                    string facultyName = myReader["FacultyName"].ToString();
                    string compName = myReader["CompetitionName"].ToString();
                    PublishedContribution c = new PublishedContribution(title, imgTitle, imgBytes, docTitle, docContentType, docBytes, fName, sName, facultyName, compName);
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

        public static List<PublishedContribution> getPublishedContributionsForComp(string compName)
        {
            List<PublishedContribution> contributions = new List<PublishedContribution>();
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "select c.Title,c.ImageTitle,c.Cont_Image,c.FileTitle,c.FileContentType,c.Cont_File,u.GivenName,u.Surname,f.FacultyName,comp.CompetitionName from PTA_Contribution c "
                + "inner join PTA_User u on u.PTA_ID_User = c.PTA_ID_User "
                + "inner join PTA_Faculty f on u.PTA_ID_Faculty = f.PTA_ID_Faculty "
                + "inner join PTA_Competition comp on comp.PTA_ID_Competition = c.PTA_ID_Competition "
                + "where c.Cont_Status = 'Published' "
                + "and comp.CompetitionName = @paramComp "
                + "order by u.Surname, u.GivenName;";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramComp", compName);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
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
                    string fName = myReader["GivenName"].ToString();
                    string sName = myReader["Surname"].ToString();
                    string facultyName = myReader["FacultyName"].ToString();
                    PublishedContribution c = new PublishedContribution(title, imgTitle, imgBytes, docTitle, docContentType, docBytes, fName, sName, facultyName, compName);
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

        public static string report_getTotalContributions(int compID)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "select count(*) as count from PTA_Contribution where PTA_ID_Competition = @paramCompID";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramCompID", compID);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {                    
                    return myReader["count"].ToString();
                }
                return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "0";
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static string report_getContributionsForFaculty(int compID, int facultyID)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "select count(c.PTA_ID_Contribution) as count from PTA_Contribution c "
                + "inner join PTA_User u on c.PTA_ID_User = u.PTA_ID_User "
                + "inner join PTA_Faculty f on u.PTA_ID_Faculty = f.PTA_ID_Faculty "
                + "where c.PTA_ID_Competition = @paramCompID "
                + "and f.PTA_ID_Faculty = @paramFacultyID;";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramCompID", compID);
            cmd.Parameters.AddWithValue("@paramFacultyID", facultyID);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    return myReader["count"].ToString();
                }
                return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "0";
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static string report_getCountContributors(int compID, int facultyID)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "select count(DISTINCT u.PTA_ID_User) as count from PTA_Contribution c "
                + "inner join PTA_User u on c.PTA_ID_User = u.PTA_ID_User "
                + "inner join PTA_Faculty f on u.PTA_ID_Faculty = f.PTA_ID_Faculty "
                + "where c.PTA_ID_Competition = @paramCompID "
                + "and f.PTA_ID_Faculty = @paramFacultyID;";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramCompID", compID);
            cmd.Parameters.AddWithValue("@paramFacultyID", facultyID);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    return myReader["count"].ToString();
                }
                return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "0";
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static string report_getContributionsNoResponse()
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "select count(c.PTA_ID_Contribution) as count from PTA_Contribution c where c.feedback IS NULL;";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    return myReader["count"].ToString();
                }
                return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "0";
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static string report_getContributionsNoResponse14Days()
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            SqlDataReader myReader = null;
            string queryStr = "select count(c.PTA_ID_Contribution) as count from PTA_Contribution c "
                + "where c.feedback IS NULL "
                + "and c.timeofUpload < dateadd(week, -3, getdate());";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);

            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    return myReader["count"].ToString();
                }
                return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "0";
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}