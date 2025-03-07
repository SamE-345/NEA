using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IdentityModel.Protocols.WSTrust;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        
    }
    public abstract class Database_Modify //Abstract class
    {
        // Use of access modifiers
        protected SqlConnection _connection = new SqlConnection();
        protected Encrypt _encrypt = new Encrypt();
        protected string _Username; 

        protected Message Filter(Message Packet)
        {   
            List<string> bannedWords = new List<string>();
            StreamReader streamReader = new StreamReader("Banned_Words.txt");
            string word = streamReader.ReadLine();
            while (word != null)
            {
                bannedWords.Add(word);
                word = streamReader.ReadLine();
            }

             // List of banned words
            string filteredText = "";
            string[] textSplit = Packet.Text.Split(' '); //Splits up the sentence into individual words

            for (int i = 0; i < textSplit.Length; i++)
            {
                for (int j = 0; j < bannedWords.Count; j++)
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
            if (p_Username == string.Empty || p_Username == null)
            {

            }
            _Username = p_Username;
        }
        public bool Sign_In(string Password)
        {
            _connection.Open();
            string Uname_Parameter = "%" + _Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE UserName = @Search";
            command.Parameters.AddWithValue("@Search", Uname_Parameter); 
            command.Connection = _connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string DBpassword = reader.GetString(reader.GetOrdinal("Password")); //Compared input to actual password
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
            command.CommandText = "SELECT Password FROM SignIn WHERE UserName = @Search";
            command.Parameters.AddWithValue("@Search", Uname_Parameter); //Passes username as parameter into SQL command
            command.Connection = _connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                try
                {
                    string DBpassword = reader.GetString(reader.GetOrdinal("Password"));
                    if (DBpassword != null || DBpassword != string.Empty)
                    {
                        _connection.Close();
                        return false;
                    }
                }
                catch
                {
                    return true;
                }
                    //Compared input to actual password
                
                
            }
            _connection.Close();
            return true;
        }
        public List<Message> Read_Messages(string Recipient)
        {
            List<Message> Messages = new List<Message>();
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT TOP 10 Text, Time,Recipient, Sender, Key FROM Messages WHERE Recipient = @Recipient OR Recipient = @Username AND Sender = @Recipient OR Sender = @Username AND Read ORDERBY Time ASC"; //W3Schools SQL
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Recipient", Recipient);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string key =  reader.GetString(reader.GetOrdinal("Key"));
                    Message Retrieved_Message = new Message();
                    Retrieved_Message.Recipient = reader.GetString(reader.GetOrdinal("Recipient"));
                    Retrieved_Message.Sender = reader.GetString(reader.GetOrdinal("Sender"));
                    Retrieved_Message.Text = _encrypt.decrypt(reader.GetString(reader.GetOrdinal("Text")),key);
                    Messages.Add(Filter(Retrieved_Message));
                }
            }
            command.CommandText = "UPDATE TOP 10 Messages SET Read = True WHERE Recipient = @Recipient AND Sender = @Username";
            command.ExecuteNonQuery();
            _connection.Close();
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
                try
                {
                    status = reader.GetBoolean(reader.GetOrdinal("Status"));
                }
                catch
                {
                    return false;
                }
            }
            _connection.Close();
            return status;
        }
        public List<string> Find_Friends()
        {
            List<string> friends = new List<string>();
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select User1, User2 FROM Friends WHERE Status=True AND User1 = @Username OR User2 = @Username";
            command.Parameters.AddWithValue("@Username", _Username);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("User1")) == _Username)
                    {
                        friends.Add(reader.GetString(reader.GetOrdinal("User2")));
                    }
                    else
                    {
                        friends.Add(reader.GetString(reader.GetOrdinal("User1")));
                    }
                }
            }
            _connection.Close();
            return friends;
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
            command.CommandText = "INSERT INTO SignIn (UserName, Password) VALUES (@Username, @Password)";
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
            command.CommandText = "INSERT INTO Messages (UserName, Message, Recipient, Key, Time, Read) VALUES (@Username, @Message, @Recipient, @key, @time, False)"; //User of dynamically generated SQL query
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Message", Message); 
            command.Parameters.AddWithValue("@Recipient", recipient);
            command.Parameters.AddWithValue("@Key", key);
            command.Parameters.AddWithValue("@Time", timestamp);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Change_Password(string new_Password)
        {
            // Changes the password of the user
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE SignIn SET Password = @Password WHERE UserName = @Username";
            command.Parameters.AddWithValue("@Password", _encrypt.Hash(new_Password));
            command.Parameters.AddWithValue("@Username", _Username);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Remove_Friend(string friend)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE * FROM Friends WHERE User1 = @Username AND User2 = @Friend OR User1 = @Friend AND User2 = @Username";
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Friend", friend);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Add_Friend(string friend)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO Friends (User1, User2, Status) VALUES (@Username, @Friend, @Status)";
            command.Parameters.AddWithValue("@Username", _Username);
            command.Parameters.AddWithValue("@Friend", friend);
            DB_Read dB_Read = new DB_Read(_Username);
            command.Parameters.AddWithValue("@Status", dB_Read.Check_Unique_Account(friend));
            command.Connection = _connection;
            command.ExecuteNonQuery();
            _connection.Close();
        }
        public void Delete_Account()
        {
            _connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE * FROM SignIn WHERE UserName = @Username";
            command.Parameters.AddWithValue("@Username", _Username);
            command.Connection = _connection;
            command.ExecuteNonQuery();
            command.CommandText = "DELETE * FROM Friends WHERE User1 = @Username OR User2= @Username";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE * FROM Messages WHERE Sender=@Username OR Recipient=@Username";
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
