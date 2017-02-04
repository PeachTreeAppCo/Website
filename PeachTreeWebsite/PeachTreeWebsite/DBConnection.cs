using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PeachTreeWebsite
{
    public class DBConnection
    {
        public static User login(string uname, string pwd)
        {
            User foundUser = new User();
            SqlConnection myConnection = new SqlConnection("user id=username;" +
                                      "password=password;" +
                                      "server=serverurl;" +
                                      "Trusted_Connection=yes;" +
                                      "database=database; " +
                                      "connection timeout=30");
            SqlDataReader myReader = null;
            string queryStr = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
            SqlCommand cmd = new SqlCommand(queryStr, myConnection);
            cmd.Parameters.AddWithValue("@username", uname);
            cmd.Parameters.AddWithValue("@password", pwd);
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                foundUser = new User(
                    int.Parse(myReader["UserID"].ToString()),
                    myReader["Username"].ToString(),
                    int.Parse(myReader["AccessLevel"].ToString())
                    );
            }
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return foundUser;
        }
    }
}