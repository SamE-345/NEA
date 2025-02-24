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

            DB_Read Sign_in = new DB_Read(Username);
            if (Sign_in.Sign_In(Password))
            {
                // redirect to different form
                redirect(Username);
            }
            else
            {
                // display error message
            }
        }

        private void New_Account_Click(object sender, EventArgs e)
        {
             string Username = U_Input.Text;
            string Password = P_Input.Text;
            
            DB_Read new_account = new DB_Read(Username);
            if (new_account.Check_Unique_Account(Password))
            {
                // redirect to different form
                redirect(Username);
            }
            else
            {
                // display error message
            }

        }
        private void redirect(string Username)
        {
            Form2 menu = new Form2(Username);
            this.Hide();
            menu.Show();
        }
    }
}
