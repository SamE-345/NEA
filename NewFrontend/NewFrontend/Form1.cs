using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            if(!Signin())
            {
                MessageBox.Show("Invalid Username or Password");
            }

        }
        private bool Signin()
        {
            string searchterm = UName_Input.Text;
            string connection_string = "server=localhost;database=Database1";
            MySqlConnection connection = new MySqlConnection(connection_string);
            connection.Open();
            string commandstring = "%" + searchterm + "%";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Name = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string password = reader.GetString(0);
                    if (!string.IsNullOrEmpty(password))
                    {
                        connection.Close();
                        return true;
                        // redirect to different form
                    }
                }

            }
            connection.Close();
            return false;

        }
            
    }
}
