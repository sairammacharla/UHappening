using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UHappeningServices.Models;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace UHappeningServices
{
    public class EventHandling
    {
        private SqlConnection conn;

        public EventHandling()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UHappeningDB"].ConnectionString);
        }

        public bool createEvent(Events Event)
        {
            string sqlCommand = "INSERT into dbo.[Events] (EventName, EventType, Location, StartTime, EndTime, EventDescription, Capacity, isPrivate, CreatedBy) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9)";

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sqlCommand;
                    cmd.Parameters.AddWithValue("@val1", Event.EventName);
                    cmd.Parameters.AddWithValue("@val2", Event.EventType);
                    cmd.Parameters.AddWithValue("@val3", Event.Location);
                    cmd.Parameters.AddWithValue("@val4", Event.StartTime);
                    cmd.Parameters.AddWithValue("@val5", Event.EndTime);
                    cmd.Parameters.AddWithValue("@val6", Event.EventDesc);
                    cmd.Parameters.AddWithValue("@val7", Event.Capacity);
                    cmd.Parameters.AddWithValue("@val8", Event.isPrivate);
                    cmd.Parameters.AddWithValue("@val9", Event.CreatedBy);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }


            }

        }

        public bool createUser(User User)
        {
            string sqlCommand = "INSERT into Users  (FirstName, LastName, AlbanyId, EmailId, UserName, Password, CreatedTime, Department) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8)";

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sqlCommand;
                    cmd.Parameters.AddWithValue("@val1", User.FirstName);
                    cmd.Parameters.AddWithValue("@val2", User.LastName);
                    cmd.Parameters.AddWithValue("@val3", User.AlbanyId);
                    cmd.Parameters.AddWithValue("@val4", User.EmailId);
                    cmd.Parameters.AddWithValue("@val5", User.UserName);
                    cmd.Parameters.AddWithValue("@val6", EncryptText(User.Password));
                    cmd.Parameters.AddWithValue("@val7", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@val8", User.Department);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable retrievePublicEvents()
        {
            string cmdString = "Select (EventId ,EventName, EventType, Location, StartTime, EndTime, EventDescription, Capacity) from Events where isPrivate=0";
            SqlDataAdapter sda = new SqlDataAdapter(cmdString, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        public DataTable retrievePrivateEvents()
        {
            string cmdString = "Select (EventId ,EventName, EventType, Location, StartTime, EndTime, EventDescription, Capacity) from Events where isPrivate=0";
            SqlDataAdapter sda = new SqlDataAdapter(cmdString, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        private string EncryptText(string input)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            var hashPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hashPassword.Length * 2);
            foreach (byte b in hashPassword)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        // create a group 
        public bool CreateGroup() // enter a group type variable
        {
            //enter a proper search query.
            string sqlCommand = "INSERT into dbo.[Events] (EventName, EventType, Location, StartTime, EndTime, EventDescription, Capacity, isPrivate) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8)";

            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sqlCommand;
                    //cmd.Parameters.AddWithValue("@val1", Event.EventName);
                    //cmd.Parameters.AddWithValue("@val2", Event.EventType);
                    //cmd.Parameters.AddWithValue("@val3", Event.Location);
                    //cmd.Parameters.AddWithValue("@val4", Event.StartTime);
                    //cmd.Parameters.AddWithValue("@val5", Event.EndTime);
                    //cmd.Parameters.AddWithValue("@val6", Event.EventDesc);
                    //cmd.Parameters.AddWithValue("@val7", Event.Capacity);
                    //cmd.Parameters.AddWithValue("@val8", Event.isPrivate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }

            }

            // retrieve all the personal groups

            // 
        }

        // retrive the personal groups that the user has made.
        public DataTable retrieveGroups()// enter the userid 
        {
            string cmdString = "Select (EventId ,EventName, EventType, Location, StartTime, EndTime, EventDescription, Capacity) from Events where isPrivate=0";
            SqlDataAdapter sda = new SqlDataAdapter(cmdString, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
    }
}