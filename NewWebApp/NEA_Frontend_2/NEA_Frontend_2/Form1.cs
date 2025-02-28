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
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace NEA_Frontend_2
{

    public partial class Form1 : Form
    {
        static int Failed_Attempts = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void SignIn_Button_Click(object sender, EventArgs e)
        {
            SignIn_Button.Enabled = false;
            if (Failed_Attempts < 5) { 
                string Username = U_Input.Text;
                string Password = P_Input.Text;
                if (!Validate_Input(Username) || !Validate_Input(Password)) // Validate input
                {
                    MessageBox.Show("Invalid input");
                    SignIn_Button.Enabled = true;
                    return;
                }

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
                    Failed_Attempts++;
                    Attempts_Label.Text = 5 - Failed_Attempts + " attempts left";
                }
            }
            else
            {
                
                MessageBox.Show("Too many failed attempts. Please try again later");
            }
        }

        private void New_Account_Click(object sender, EventArgs e)
        {
            New_Account.Enabled = false;
            string Username = U_Input.Text;
            string Password = P_Input.Text;
            if (!Validate_Input(Username) || !Validate_Input(Password)) // Validate input
            {
                MessageBox.Show("Invalid input");
                SignIn_Button.Enabled = true;
                return;
            }
            // Prevents too many requests
            DB_Read new_account = new DB_Read(Username);
            if (new_account.Check_Unique_Account(Password)) // Check if account already exists
            {
                redirect(Username); // redirect to different form
                DB_Write create_Account = new DB_Write(Username);
                create_Account.Add_Account(Password);
            }
            else 
            {
                 New_Account.Enabled = true;
                 MessageBox.Show("Account already exists!");
                 Failed_Attempts++;
                 Attempts_Label.Text = 5 - Failed_Attempts + " attempts left";
            }         
        }
        private void redirect(string Username) // Takes user to the menu page if successful sign in
        {
            Form2 menu = new Form2(Username);
            this.Hide();
            menu.Show();
        }
        private void Remove_Later_Click(object sender, EventArgs e) // Testing purposes only
        {
            this.Hide();
            Form2 form2 = new Form2("Sam");
            form2.Show();
        }

        private void Forgot_PWord_Button_Click(object sender, EventArgs e)
        {
            if (!Validate_Input(U_Input.Text) || !Validate_Input(P_Input.Text)) // Validate input
            {
                MessageBox.Show("Invalid input");
                SignIn_Button.Enabled = true;
                return;
            }
            Password_Label.Text = "Enter new Password"; 
            DB_Write dB_Write = new DB_Write(U_Input.Text);
            dB_Write.Change_Password(P_Input.Text);
            redirect(U_Input.Text);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Remove_Later.Visible = false;
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
