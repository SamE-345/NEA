using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_Frontend_2
{
    public abstract class Database_Modify
    {
        protected SqlConnection _connection = new SqlConnection();
        protected Encrypt _encrypt = new Encrypt();
        protected string _Username;
        // protected string _SQLCommand;
        
    }
    public class DB_Read : Database_Modify
    {

        public DB_Read(string p_Username) 
        {
            // Creates connection to DB
            _connection.ConnectionString = Properties.Settings.Default.ChatDBConnectionString;
            _Username = p_Username;

        }
        public bool Sign_In(string Password)
        {
            _connection.Open();
            string commandstring = "%" + _Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = _connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string DBpassword = reader.GetString(0); //Compared input to actual password
                    if (DBpassword == _encrypt.Hash(Password))
                    {
                        _connection.Close();
                        return true;
                    }
                }
            }
            _connection.Close();
            return false;
        }
        public bool Create_Account( string Password)
        {
            _connection.Open();
            string commandstring = "%" + _Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = _connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string DBpassword = reader.GetString(0); //Compared input to actual password
                    if (DBpassword != null || DBpassword != string.Empty)
                    {
                        _connection.Close();
                        // Call function for inserting into DB
                        return true;
                    }
                }
            }
            _connection.Close();
            return false;
        }
        public string Read_Message()
        {
            return "message";
        }
    }
    public class DB_Write : Database_Modify
    {
        public DB_Write(string p_Username)
        {
            // Creates connection to DB
            _connection.ConnectionString = Properties.Settings.Default.ChatDBConnectionString;
            _Username = p_Username;
        }
        public void Add_Account(string Password)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO SignIn (Username, Password) VALUES (@Username, @Password)";
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Password", _encrypt.Hash(Password));
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Write_Message(string Message)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO Messages (Username, Message) VALUES (@Username, @Message)";
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Message", Message);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }

}
