using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_Frontend_2
{
    public partial class Form4 : Form
    {
        private static string _Username;
        public Form4(string UName)
        {
            InitializeComponent();
            _Username = UName;

        }
        private void Change_Friendship(CheckBox box)
        {
            box.Enabled = false;
            if (box.Checked)
            {
                // Add friend if not already friends
                DB_Write dB_Write = new DB_Write(_Username);
                dB_Write.Add_Friend(box.Text);
            }
            else
            {
                // Remove friend
                DB_Write dB_Write = new DB_Write(_Username);
                dB_Write.Remove_Friend(box.Text);
            }
            box.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        { }


        private void Form4_Load(object sender, EventArgs e)
        {
            DB_Read dB_Read = new DB_Read(_Username);
            List<string> Friends = dB_Read.Find_Friends();
            //List<string> Friends = new List<string>();
            Friends.Add("Friend1");
            Friends.Add("User123");
            Friends.Add("Friend");
            
            for (int i = 0; i < Friends.Count; i++)
            {
                CheckBox Friend = new CheckBox(); //Creates a new checkbox for each friend
                Friend.Text = Friends[i];
                Friend.Location = new Point(64, 100 + (i * 24));
                Friend.Size = new Size(114, 24);
                Friend.Checked = true;
                Friend.CheckedChanged += (s, evnt) => Change_Friendship(Friend); //Adds event for when a dynamically generated checkbox is ticked  which changes the friend status
                Friend.Show();
                this.Controls.Add(Friend); //Adds the checkbox to the form
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Search_User = User_Textbox.Text;
            if (!Validate_Input(Search_User))
            {
                MessageBox.Show("Invalid input");
                return;
            }
            DB_Read dB_Read = new DB_Read(_Username);
            if (!dB_Read.Check_Friend(Search_User))
            {
                // Checks if two users are already friends and if not, adds them as friends
                DB_Write dB_Write = new DB_Write(_Username);
                dB_Write.Add_Friend(Search_User);
                MessageBox.Show($"{Search_User} added as friend");
            }
            else
            {
                MessageBox.Show("User is already a friend");
            }
        }
        private bool Validate_Input(string input) // Checks that input does not exceed 30 characters due to DB restrictions
        {
            if (input.Length > 29)
            {
                return false;
            }
            else if (input == "")
            {
                return false;
            }
            return true;

        }
    }
}
