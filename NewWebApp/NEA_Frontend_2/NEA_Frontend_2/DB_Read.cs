using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_Frontend_2
{
    public struct Message //Use of struct
    {
        public string Sender;
        public string Recipient;
        public string Text;
        public DateTime Timestamp;
        public bool Read;
    }
    public abstract class Database_Modify //Abstract class
    {
        // Use of access modifiers
        protected SqlConnection _connection = new SqlConnection();
        protected Encrypt _encrypt = new Encrypt();
        protected string _Username; 

        protected Message Filter(Message Packet)
        {
            string[] bannedWords = new string[] { "Hello", "Goodbye" }; // List of banned words
            string filteredText = "";
            string[] textSplit = Packet.Text.Split(' '); //Splits up the sentence into individual words

            for (int i = 0; i < textSplit.Length; i++)
            {
                for (int j = 0; j < bannedWords.Length; j++)
                {
                    if (textSplit[i].ToUpper() == bannedWords[j].ToUpper())
                    {
                        textSplit[i] = "*****";
                    }
                }
            }
            try
            {
                filteredText = filteredText.Insert(filteredText.Length - 1, ".");
            }
            catch
            {
                Console.WriteLine("No Text Inputted");
            }
            Packet.Text = filteredText;
            return Packet;
        }
    }
    public class DB_Read : Database_Modify // Demonstrates inheritance
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
            string Uname_Parameter = "%" + _Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", Uname_Parameter);
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
        public bool Check_Unique_Account(string Password)
        {
            _connection.Open();
            string Uname_Parameter = "%" + _Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", Uname_Parameter); //Passes username as parameter into SQL command
            command.Connection = _connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string DBpassword = reader.GetString(0);
                    //Compared input to actual password
                    if (DBpassword != null || DBpassword != string.Empty)
                    {
                        _connection.Close();
                        return true;
                    }
                }
            }
            _connection.Close();
            return false;
        }
        public List<Message> Read_Messages(string Recipient)
        {
            List<Message> Messages = new List<Message>();
            return Messages;
        }
        public bool Check_Friend(string Friend)
        {
            bool status;
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Status FROM Friends WHERE User1 = @Username OR User1 = @Recipient AND User2 = @Username OR User2=@Recipient";
            // Command above checks whether the two users are friends allowing for either combination of user1 and user 2
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Recipient", Friend);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                status = reader.GetBoolean(0);
            }
            _connection.Close();
            return status;
        }
    }
    public class DB_Write : Database_Modify //Inheritance from abstract class
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
            // Hashes the password and passes it into the SQL command
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Write_Message(string Message, string recipient)
        {
            _connection.Open();

            Message = _encrypt.encrypt(Message);
            string key = _encrypt.Get_Key(); // Encrypts the text and gets the key
            DateTime timestamp = DateTime.Now; // Timestamps the message
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO Messages (Username, Message, Recipient) VALUES (@Username, @Message, @Recipient)"; //User of dynamically generated SQL query
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Message", Message); 
            command.Parameters.AddWithValue("@Recipient", recipient);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
