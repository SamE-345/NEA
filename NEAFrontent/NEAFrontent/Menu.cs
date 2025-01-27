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
        BindingSource bindingSource = new BindingSource();
        private string username;
        private List<string> new_Messages = new List<string>();
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public List<string> Notification_Finding()
        {
            List<string> UNames = new List<string>();
            string connectionstring = "datasource = localhost; port=3306;username=root;password=root;database=/"; //Pick a DB name for the database
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT Username FROM Messages WHERE MessageRead = False";
            command.Connection = connection;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    UNames.Add(reader.GetString("Username"));

                }
            }
            connection.Close();

            return UNames;
        }
    }
}
