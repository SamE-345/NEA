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
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            SignIn_Button.Enabled = false;
            // Prevents too many requests being sent
            DB_Read Sign_in = new DB_Read(Username);
            if (Sign_in.Sign_In(Password))
            {
                // redirect to different form
                redirect(Username);
            }
            else
            {
                SignIn_Button.Enabled = true;
                // display error message
                MessageBox.Show("Incorrect Username or Password");
            }
        }

        private void New_Account_Click(object sender, EventArgs e)
        {
            string Username = U_Input.Text;
            string Password = P_Input.Text;
            New_Account.Enabled = false; 
            // Prevents too many requests
            DB_Read new_account = new DB_Read(Username);
            if (new_account.Check_Unique_Account(Password)) // Check if account already exists
            {
                DB_Write create_Account = new DB_Write(Username);
                create_Account.Add_Account(Password);
                redirect(Username); // redirect to different form
            }
            else
            {
                New_Account.Enabled = true;
                MessageBox.Show("Account already exists!");
            }
        }
        private void redirect(string Username)
        {
            Form2 menu = new Form2(Username);
            this.Hide();
            menu.Show();
        }

        private void Remove_Later_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("Sam");
        }
    }
}
