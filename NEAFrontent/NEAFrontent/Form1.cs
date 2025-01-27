namespace NEAFrontent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SignIn_button_Click(object sender, EventArgs e)
        {
            bool valid_SignIn = false;
            string username = UserName_Input.Text;
            string password = Password_Input.Text;
            // Check if username and password combination are in database
            if (valid_SignIn)
            {
                // return new page
            }
        }

        private void New_Account_Click(object sender, EventArgs e)
        {
            // Check if username is unique
            // If so, add to database
            // Then redirect to main page
        }
    }
}
