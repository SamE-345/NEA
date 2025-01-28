using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Data.SqlClient;

namespace NewFrontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        

        private void CreateAccount_Button_Click(object sender, EventArgs e)
        {
            string Username = UName_Input.Text;
            string Password = PWord_Input.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            connection.Open();
            string commandstring = "%" + Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = connection;
            bool new_Login = true;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string password = reader.GetString(0);
                    if (!string.IsNullOrEmpty(password))
                    {
                        connection.Close();
                        MessageBox.Show("Username already exists");
                        new_Login = false;
                        // redirect to different form
                    }
                }
                if (new_Login)
                {
                    SqlCommand insert = new SqlCommand();
                    insert.CommandText = "INSERT INTO SignIn (Username, Password) VALUES (@Username, @Password)";
                    insert.Parameters.AddWithValue("@Username", Username); // Binds the username var to the @Username parameter in command
                    insert.Parameters.AddWithValue("@Password", Password);
                    insert.Connection = connection;
                    connection.Close();
                    // Redirect to different form
                  
    
                }
            }
            connection.Close();
        }

        private void SignIn_Button_Click(object sender, EventArgs e)
        {
            string Username = UName_Input.Text;
            string Password = PWord_Input.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            connection.Open();
            string commandstring = "%" + Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string DBpassword = reader.GetString(0);
                    if (!string.IsNullOrEmpty(DBpassword) && DBpassword == Password)
                    {
                        connection.Close();
                        
                        // redirect to different form
                    }
                }

            }
            connection.Close();
            //Messagebox.Show("Invalid Username or Password");
        }
    }
}
