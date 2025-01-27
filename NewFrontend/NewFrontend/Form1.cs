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
            if(!Signin())
            {
                MessageBox.Show("Invalid Username or Password");
            }

        }
        private bool Signin()
        {
            string searchterm = UName_Input.Text;
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            connection.Open();
            string commandstring = "%" + searchterm + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Password FROM SignIn WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
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
