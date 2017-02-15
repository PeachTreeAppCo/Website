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
            string queryStr = "SELECT * FROM Users WHERE Email = @paramEmail AND Pword = @paramPassword";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@paramUsername", email);
            cmd.Parameters.AddWithValue("@paramPassword", pwd);
            try
            {
                myConnection.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int UserID = int.Parse(myReader["PTA_ID_User"].ToString());
                    string GivenName = myReader["GivenName "].ToString();
                    string Surname = myReader["Surname"].ToString();
                    int UserType = int.Parse(myReader["UserType"].ToString());
                    string Email = myReader["Email"].ToString();
                    string Password = myReader["Pword"].ToString();
                    string MobileNumber = myReader["MobileNumber"].ToString();
                    int StudyYear = int.Parse(myReader["StudyYear"].ToString());
                    u = new SiteUser(UserID, GivenName, Surname, UserType, Email, Password, MobileNumber, StudyYear);                    
                }
                myConnection.Close();
                return u;
            }
            catch (Exception e)
            {                
                Console.WriteLine(e.ToString());
                return null;
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
                myConnection.Close();
                return f;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static List<string> getFaculties()
        {
            List<string> faculties = new List<string>();
            //SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.PeachTreeConnectionString);
            //SqlDataReader myReader = null;
            //string queryStr = "SELECT FacultyName FROM PTA_Faculty";
            //SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            //try
            //{
            //    myConnection.Open();
            //    myReader = cmd.ExecuteReader();
            //    while (myReader.Read())
            //    {
            //        string faculty = myReader["PTA_ID_Faculty"].ToString();
            //        faculties.Add(faculty);
            //    }
            //    myConnection.Close();
            //    return faculties;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //    return null;
            //}

            faculties = new List<string>(new string[] {
            "Architecture, Computing & Humanities",
            "Business School",
            "Education & Health",
            "Engineering & Science"});
            return faculties;
        }
    }
}