using System;
using System.Collections.Generic;
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
            SiteUser u = new SiteUser();
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
    }
}