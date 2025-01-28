using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewFrontend
{
    public partial class Menu : Form
    {
        private string _Username
        private List<string> _FriendList =  new List<string>();
        public Menu(string Passed_username)
        {
            InitializeComponent();
            Username = Passed_username;
        }
        private void Menu_Load(object sender, EventArgs e){
            //Must identify all friends of the user upon loading
            connection.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            connection.Open();
            string commandstring = "%" + Username + "%";
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Friend_User FROM Friends WHERE Username = @Search";
            command.Parameters.AddWithValue("@Search", commandstring);
            command.Connection = connection;

            SqlDataReader reader = new SqlDataReader();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    FriendList.Add(reader.GetString("Friend_User")) //Adds to list of friends
                }
            }
        }
        private void Redirect(string Page)
        {
            this.Hide();
            if(Page=="Sign_in"){
                Form1 base_Form = new Form1();
                base_Form.show();
            }
            
        }
        private void Redirect(string Page, string Second_User)
        {
            this.Hide();
            if(Page=="Sign_in"){
                Form1 base_Form = new Form1();
                base_Form.show();
            }
            else {
                Message Friendchat = new Message(Second_User);
                Friendchat.show();
            }
            
        }
    }
    
}
