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

namespace NEAFrontent
{
    public partial class Menu : Form
    {
        
        private string username;
        
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Notification_Finding();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public HashSet<string> Notification_Finding()
        {
            HashSet<string> UNames = new HashSet<string>();
            string connectionstring = "datasource = localhost; port=3306;username=root;password=root;database=/"; //Pick a DB name for the database
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = $"SELECT Username FROM Messages WHERE MessageRead = False AND Recipient = {username}";
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string temp = reader.GetString("Username");
                    if (!UNames.Contains(temp))
                    {
                        UNames.Add(temp);
                    }
                }
            }
            connection.Close();
            return UNames;
        }
    }
}
