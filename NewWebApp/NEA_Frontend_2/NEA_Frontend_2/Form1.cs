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

namespace NEA_Frontend_2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SignIn_Button_Click(object sender, EventArgs e)
        {
            string Username = U_Input.Text;
            string Password = P_Input.Text;
            SqlConnection connection = new SqlConnection(); // Creates connection to DB
            connection.ConnectionString = Properties.Settings.Default.ChatDBConnectionString;
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
                    string DBpassword = reader.GetString(0); //Compared input to actual password
                    if (DBpassword == Password)
                    {
                        connection.Close();
                        // redirect to different form
                        //Redirect();
                    }
                    else
                    {
                        
                    }
                }

            }
            connection.Close();

        }
    }
}
