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

        }

        private void Search_Click(object sender, EventArgs e)
        {
            string Name = Friend_Box.Text;
            DB_Read Friend_Search = new DB_Read(_Username);
            if (Friend_Search.Check_Friend(Name))
            {
                // Redirect to chat passing friend name as parameter
            }
            else
            {
                MessageBox.Show($"No friends found with name {Name}. Please try another username");
            }

        }

        private void Settings_Button_Click(object sender, EventArgs e)
        {
            // Redirect to the settings page but do not close the menu page
        }

        private void Sign_Out_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
            
        }
    }
}
