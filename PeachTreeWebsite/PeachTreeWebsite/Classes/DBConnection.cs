using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
                    string UserType = myReader["UserType"].ToString();
                    string Email = myReader["Email"].ToString();
                    string Password = myReader["Pword"].ToString();
                    string MobileNumber = myReader["MobileNumber"].ToString();
                    int StudyYear = int.Parse(myReader["StudyYear"].ToString());
                    u = new SiteUser(UserID, GivenName, Surname, UserType, Email, Password, MobileNumber, StudyYear);
                    myConnection.Close();
                }                
            }
            catch (Exception e)
            {                
                Console.WriteLine(e.ToString());
                return null;
            }
            return u;
        }
    }
}