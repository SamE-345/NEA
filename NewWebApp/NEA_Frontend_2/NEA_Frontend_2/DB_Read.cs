using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NEA_Frontend_2
{
    abstract class Database_Modify
    {
        protected SqlConnection _connection = new SqlConnection();

        protected string UserID;
        protected string SQLCommand;
        
    }
    internal class DB_Read : Database_Modify
    {

        public DB_Read() 
        {
            // Creates connection to DB
            _connection.ConnectionString = Properties.Settings.Default.ChatDBConnectionString;


        }
        public bool Sign_In(string Username, string Password)
        {
            _connection.Open();
            string commandstring = "%" + Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = _connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string DBpassword = reader.GetString(0); //Compared input to actual password
                    if (DBpassword == Password)
                    {
                        _connection.Close();
                        return true;
                    }
                }
            }
            _connection.Close();
            return false;
        }


        }
}
