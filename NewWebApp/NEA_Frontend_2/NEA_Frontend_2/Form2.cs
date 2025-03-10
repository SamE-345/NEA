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
    public partial class Form2 : Form
    {
        private static string _Username;
        public Form2(string uName)
        {
            InitializeComponent();
            _Username = uName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Name_label.Text = $"Hello {_Username}";
        }
        private void Search_Click(object sender, EventArgs e)
        {
            string Name = Friend_Box.Text;
            DB_Read Friend_Search = new DB_Read(_Username);
            if (Validate_Input(Name) && Friend_Search.Check_Friend(Name))
            {
                // Redirect to chat passing friend name as parameter
                Form3 form3 = new Form3(_Username, Name, Dark_Mode_Box.Checked);
            }
            else
            {
                MessageBox.Show($"No friends found with name {Name}. Please try another username");
            }

        }

        private void Settings_Button_Click(object sender, EventArgs e) //Removed
        {
            Form4 form4 = new Form4(_Username);
            form4.Show();
            // Redirect to the settings page but do not close the menu page
        }
        private void Sign_Out_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Dark_Mode_Box_CheckedChanged(object sender, EventArgs e) //Toggles between lightmode and darkmode
        {
            if (Dark_Mode_Box.Checked)
            {
                // Enable dark mode
                BackColor = Color.FromArgb(31, 31, 31);
                label1.ForeColor = Color.White;
                Sign_Out_Button.BackColor = Color.Orange;
                Friend_Box.BackColor = Color.Orange;
                Friend_Box.ForeColor = Color.White;
                Friends_Button.BackColor = Color.Orange;
                Name_label.ForeColor = Color.White;
                Dark_Mode_Box.ForeColor = Color.White;
                Search.BackColor = Color.Orange;
                Search.ForeColor = Color.White;
            }
            else
            {
                // Disable dark mode
                
                label1.ForeColor = Color.Black;
                Sign_Out_Button.BackColor = Color.Blue;
                Friends_Button.BackColor = Color.Blue;
                Name_label.ForeColor = Color.Black;
                BackColor = Color.Aqua;
                Friend_Box.BackColor = Color.LightGray;
                Dark_Mode_Box.ForeColor = Color.Black;
            }
        }

        private void Friends_Button_Click(object sender, EventArgs e)
        {
            //Redirects user to friends page but does not close the menu page
            Form4 Friends_Page = new Form4(_Username);
            Friends_Page.Show();
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
